
using AutoMapper;
using tcc.EntityModels;
using tcc.Models;
using tcc.Repositorys;

namespace tcc.Services.ProdutoService
{
    public class ProdutosService : ServiceBase, IProdutoService
    {
        private readonly IMapper _mapper;

        public ProdutosService(IRepositoryWrapper repository, IMapper mapper): base(repository)
        {
            _mapper = mapper;
        }

        public void CriarProdutos(List<ProdutoModel> listaProdutos)
        {
            var produtos = _mapper.Map<List<ProdutoEntityModel>>(listaProdutos);

            foreach (var produto in produtos)
            {
                //produto.Id = new Guid();
                _repository.ProdutoRepository.Create(produto);
                _repository.Save()
;            }
        }
    }
}
