using Microsoft.AspNetCore.Mvc;
using tcc.Models;
using tcc.Services;

namespace tcc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public VendasController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        [HttpPost]
        public IActionResult CriarVenda([FromBody]VendaModel venda)
        {
            _serviceWrapper.VendaService.CriarVenda(venda);
            return Ok();
        }
    }
}
