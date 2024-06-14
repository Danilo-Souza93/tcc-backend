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
                var response = new
                {
                    message = "Produtos Cadastrados",
                    statusCode = 200,
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    message = "Erro ao cadastrar produto",
                    statusCode = 500,
                    error = ex.Message
                };

                return BadRequest(response);
            }
        }

        [HttpGet]
        public IActionResult GetProductList()
        {
            try
            {
                return Ok(_serviceWrapper.ProdutoService.GetProductList());
            }
            catch (Exception ex)
            {
                var response = new
                {
                    message = "Erro ao buscar produtos",
                    statusCode = 500,
                    error = ex.Message
                };

                return BadRequest(response); 
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
                var response = new
                {
                    message = "Erro ao atualizar produtos",
                    statusCode = 500,
                    error = ex.Message
                };

                return BadRequest(response);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _serviceWrapper.ProdutoService.DeleteProduto(id);
                var response = new
                {
                    message = "Produto Deletado",
                    statusCode = 200,
                };

                return Ok(response);
            }
            catch(Exception ex)
            {
                var response = new
                {
                    message = "Error ao deletar produto",
                    statusCode = 500,
                    error = ex.Message
                };

                return BadRequest(response);
            }
        }
    }
}
