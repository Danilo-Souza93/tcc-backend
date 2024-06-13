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
            try
            {
                Guid vendaId = _serviceWrapper.VendaService.CriarVenda(venda);
                var response = new
                {
                    mensagem = "venda criada",
                    StatusCode = 200,
                    vendaId = vendaId,
                };                 

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new
                 {
                    mensagem = "erro ao criar venda",
                    StatusCode = 500,
                    error = ex.Message,
                 };
                return BadRequest(response);
            }
        }

        [Route("{vendaId}")]
        [HttpGet]
        public IActionResult GetVenda(Guid vendaId)
        {
            try
            {
                (VendaModel venda, List<ProdutoModel> produtosList) detalheVenda = _serviceWrapper.VendaService.GetVenda(vendaId);

                var response = new
                {
                    mensagem = "venda encontrada",
                    StatusCode = 200,
                    venda = detalheVenda,
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    mensagem = "venda não encontrada",
                    StatusCode = 500,
                    error = ex.Message,
                };
                return BadRequest(response);
            }
        }

        [HttpDelete]
        public IActionResult DeleteVenda([FromBody] Guid vendaId)
        {
            try
            {
                _serviceWrapper.VendaService.DeleteVenda(vendaId);
                var response = new
                {
                    mensagem = "venda excluida",
                    StatusCode = 200,
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    mensagem = "erro ao deletar venda",
                    StatusCode = 500,
                    error = ex.Message,
                };
                return BadRequest(response);
            }
        }
    }
}
