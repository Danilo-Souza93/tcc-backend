using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tcc.Models;
using tcc.Services;

namespace tcc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public ProdutoController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        [HttpPost]
        public IActionResult CreateProducts([FromBody]List<ProdutoModel> listaProdutos)
        {
            try
            {
                _serviceWrapper.ProdutoService.CriarProdutos(listaProdutos);

                return Ok("Produtos Cadastrados");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult GetProductList()
        {
            try
            {
                return  Ok(_serviceWrapper.ProdutoService.GetProductList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex); 
            }
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] ProdutoModel product)
        {
            try
            {
                return Ok(_serviceWrapper.ProdutoService.UpdateProduto(product));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
