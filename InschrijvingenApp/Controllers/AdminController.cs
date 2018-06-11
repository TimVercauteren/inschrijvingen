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
        public async Task<IActionResult> ResetPwd([FromForm] string paswoord)
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
                    return Ok();
                else
                    return Unauthorized();
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

        [HttpGet("kleuters")]
        public async Task<HttpResponseMessage> GetKleuters()
        {
            var groep = LeeftijdenGroepen.Kleuters;
            return await MakeMessageForGroup(groep);
        }

        [HttpGet("jongsten")]
        public async Task<HttpResponseMessage> GetJongsten()
        {
            var groep = LeeftijdenGroepen.Jongsten;
            return await MakeMessageForGroup(groep);
        }

        [HttpGet("midden")]
        public async Task<HttpResponseMessage> GetMidden()
        {
            var groep = LeeftijdenGroepen.Middden;
            return await MakeMessageForGroup(groep);
        }

        [HttpGet("oudsten")]
        public async Task<HttpResponseMessage> GetOudsten()
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

        private async Task<HttpResponseMessage> MakeMessageForGroup(string groep)
        {
            try
            {
                var childList = await _dataProcessor.GetChildList(groep);

                var attachment = _attachmentProcessor.GetExcel(childList, groep);

                var result = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(attachment)
                };
                result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = $"{groep}.xls"
                };
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

                return result;

            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}
