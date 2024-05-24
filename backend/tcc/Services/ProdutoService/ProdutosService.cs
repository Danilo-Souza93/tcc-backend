
using AutoMapper;
using System.Linq.Expressions;
using tcc.EntityModels;
using tcc.Models;
using tcc.Repositories;

namespace tcc.Services.ProdutoService
{
    public class ProdutosService : ServiceBase, IProdutoService
    {
        private readonly IMapper _mapper;

        public ProdutosService(IRepositoryWrapper repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public void CriarProdutos(List<ProdutoModel> listaProdutos)
        {
            var produtos = _mapper.Map<List<ProdutoEntityModel>>(listaProdutos);

            foreach (var produto in produtos)
            {
                _repository.ProdutoRepository.Create(produto);
            }

            _repository.Save();
        }

        public List<ProdutoModel> GetProductList()
        {
            var dbProduct = _repository.ProdutoRepository.GetAll();
            return _mapper.Map<List<ProdutoModel>>(dbProduct);
        }

        public List<ProdutoEntityModel> GetProductByProductSaledId(List<ProdutosVendidos> produtosVendidos)
        {
            var dbProdutoList = new List<ProdutoEntityModel>();

           //Criando expressão para busca em lista por id
           foreach(var product in produtosVendidos) {
                Expression<Func<ProdutoEntityModel, bool>> condiction = x => x.Id == product.ProdutoId;
                var dbProduto = _repository.ProdutoRepository.FindByCondition(condiction).FirstOrDefault();
                if (dbProduto == null)
                {
                    throw new Exception("Produto não encontrado");
                }

                dbProdutoList.Add(dbProduto);            
           }

           return dbProdutoList;
        }

        public ProdutoModel UpdateProduto(ProdutoModel produto)
        {
            // criando expressão para busca customizada
            Expression<Func<ProdutoEntityModel, bool>> condiction = e => e.Id == produto.Id;
            var dbProduto = _repository.ProdutoRepository.FindByCondition(condiction).FirstOrDefault();

            dbProduto.Id = produto.Id;
            dbProduto.Nome = produto.Nome;
            dbProduto.Detalhe = produto.Detalhe;
            dbProduto.dt_lote = produto.dt_lote;
            dbProduto.QuantidadeEstoque = produto.QuantidadeEstoque;
            dbProduto.Valor = produto.Valor;

            _repository.ProdutoRepository.Update(dbProduto);
            _repository.Save();

            var response = _repository.ProdutoRepository.FindByCondition(condiction).FirstOrDefault();
            if (response == null)
            {
                throw new Exception("Falha ao atualizar produto");
            }

            return _mapper.Map<ProdutoModel>(response);
        }

        public void DeleteProduto(int id) 
        { 
            ProdutoEntityModel produtoDb = _repository.ProdutoRepository.FindByCondition(x => x.Id == id).FirstOrDefault();
            if (produtoDb == null)
            {
                throw new Exception("Produto não encontrado");
            }

            _repository.ProdutoRepository.Delete(produtoDb);
            _repository.Save();
        }
    }
}
