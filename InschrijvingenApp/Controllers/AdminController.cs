using InschrijvingPietieterken.Business;
using InschrijvingPietieterken.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace InschrijvingPietieterken.Controllers
{
    [Route("api/[controller]")]
    public class AdminController : Controller
    {

        private readonly IDataProcessor _dataProcessor;
        private readonly ILoginManager _loginManager;
        private readonly IAttachmentProcessor _attachmentProcessor;


        public AdminController(IDataProcessor dataProcessor, IAttachmentProcessor attachmentProcessor, ILoginManager loginManager)
        {
            _dataProcessor = dataProcessor ?? throw new ArgumentNullException(nameof(dataProcessor));
            _attachmentProcessor = attachmentProcessor ?? throw new ArgumentNullException(nameof(attachmentProcessor));
            _loginManager = loginManager ?? throw new ArgumentNullException(nameof(loginManager));
        }

        [HttpPost("resetpwd/tim")]
        public async Task<IActionResult> ResetPwd([FromQuery] string paswoord)
        {
            try
            {
                await _loginManager.ResetPasswoord(paswoord);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] string password)
        {
            try
            {
                var loggedIn = await _loginManager.Login(password);
                if (loggedIn)
                    return Ok(new { status = "ingelogd" });
                else
                    return Unauthorized();
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        [HttpGet("kleuters")]
        public async Task<IActionResult> GetKleuters()
        {
            var groep = LeeftijdenGroepen.Kleuters;
            return await MakeMessageForGroup(groep);
        }

        [HttpGet("jongsten")]
        public async Task<IActionResult> GetJongsten()
        {
            var groep = LeeftijdenGroepen.Jongsten;
            return await MakeMessageForGroup(groep);
        }

        [HttpGet("midden")]
        public async Task<IActionResult> GetMidden()
        {
            var groep = LeeftijdenGroepen.Middden;
            return await MakeMessageForGroup(groep);
        }

        [HttpGet("oudsten")]
        public async Task<IActionResult> GetOudsten()
        {
            var groep = LeeftijdenGroepen.Oudsten;
            return await MakeMessageForGroup(groep);
        }

        [HttpGet("kind/zoek")]
        public async Task<IActionResult> SearchChildren([FromQuery] string zoekTekst, [FromQuery] string param = "naam")
        {
            var result = await _dataProcessor.Search(zoekTekst, param);

            return Ok(result);

        }

        [HttpGet("kind/{id:int}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var result = await _dataProcessor.GetChild(id);

            return Ok(result);

        }

        private async Task<IActionResult> MakeMessageForGroup(string groep)
        {
            var childList = await _dataProcessor.GetChildList(groep);
            var attachment = _attachmentProcessor.GetExcel(childList, groep);
            var fileContentResult = new FileContentResult(attachment, "application/xlsx")
            {
                FileDownloadName = $"{groep}.xlsx"
            };
            return fileContentResult;
        }
    }
}
