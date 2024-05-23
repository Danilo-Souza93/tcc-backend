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

        [Route("venda")]
        [HttpPost]
        public IActionResult CriarVenda([FromBody]VendaModel venda)
        {
            try
            {
                _serviceWrapper.VendaService.CriarVenda(venda);
                return Ok("venda criada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("{vendaId}")]
        [HttpGet]
        public IActionResult GetVenda(Guid vendaId)
        {
            try
            {
                (VendaModel venda, List<ProdutoModel> produtosList) detalheVenda = _serviceWrapper.VendaService.GetVenda(vendaId);   

                return Ok(new { detalheVenda.venda, detalheVenda.produtosList });

            }catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
