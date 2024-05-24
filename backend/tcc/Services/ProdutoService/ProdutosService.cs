
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
                _repository.Save();
            }
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
                
                if (dbProduto != null) {
                    dbProdutoList.Add(dbProduto);
                }
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
            //var entityResponse = _mapper.Map<ProdutoEntityModel>(response);
            return _mapper.Map<ProdutoModel>(response);

        }
    }
}
