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
                Guid vendaId = _serviceWrapper.VendaService.CriarVenda(venda);

                return Ok("venda criada");
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCodes.Status500InternalServerError, ex.Message });
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
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCodes.Status404NotFound, ex.Message });
            }
        }

        [HttpDelete]
        public IActionResult DeleteVenda([FromBody] Guid vendaId)
        {
            try
            {
                _serviceWrapper.VendaService.DeleteVenda(vendaId);

                return Ok("Venda Deletada");
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCodes.Status500InternalServerError, ex.Message });
            }
        }
    }
}
