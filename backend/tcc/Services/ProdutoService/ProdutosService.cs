
using AutoMapper;
using System.Linq.Expressions;
using tcc.EntityModels;
using tcc.Models;
using tcc.Repositorys;

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

        public ProdutoModel UpdateProduto(ProdutoModel produto)
        {
            // criando expressão para busca customizada
            Expression<Func<ProdutoEntityModel, bool>> condiction = e => e.Id == produto.Id;
            var dbProduto = _repository.ProdutoRepository.FindByCondition(condiction).FirstOrDefault();
           
            // Atribuindo get ao modelo de entidade
            var prod = _mapper.Map<ProdutoEntityModel>(dbProduto);
            prod.Id = produto.Id;
            prod.Nome = produto.Nome;
            prod.Detalhe = produto.Detalhe;
            prod.dt_lote = produto.dt_lote;

            _repository.ProdutoRepository.Update(prod);
            _repository.Save();

            var response = _repository.ProdutoRepository.FindByCondition(condiction).FirstOrDefault();
            var entityResponse = _mapper.Map<ProdutoEntityModel>(response);
            return _mapper.Map<ProdutoModel>(entityResponse);
        }
    }
}
