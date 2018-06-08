using InschrijvingPietieterken.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace InschrijvingPietieterken.Controllers
{
    [Route("api/[controller]")]
    public class GegevensController : Controller
    {
        private readonly IInschrijvingsProcessor _inschrijvingBusiness;

        public GegevensController(IInschrijvingsProcessor inschrijvingsProcessor)
        {
            _inschrijvingBusiness = inschrijvingsProcessor ?? throw new ArgumentNullException(nameof(inschrijvingsProcessor));
        }

        [HttpPost]
        public async Task<IActionResult> PostInschrijving([FromBody] InschrijvingModel model)
        {
            try
            {
                await _inschrijvingBusiness.CreateInschrijving(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
