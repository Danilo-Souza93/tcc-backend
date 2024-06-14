using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
                DetalheVendaModel detalheVenda = _serviceWrapper.VendaService.GetVenda(vendaId);

                return Ok(detalheVenda);
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

        [Route("{vendaId}")]
        [HttpDelete]
        public IActionResult DeleteVenda(Guid vendaId)
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

        [HttpPut]
        public IActionResult UpdateStatusVenda(VendaModel venda)
        {
            try
            {
               return Ok( _serviceWrapper.VendaService.UpdateVenda(venda));
            }
            catch (Exception ex)
            {
                var response = new
                {
                    message = "erro ao atualizar venda",
                    statusCode = 200,
                    error = ex.Message,
                };
                return BadRequest(response);
            }
        }
    }
}
