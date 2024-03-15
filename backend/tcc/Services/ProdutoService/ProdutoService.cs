
using AutoMapper;
using tcc.Repositorys;

namespace tcc.Services.ProdutoService
{
    public class ProdutoService : ServiceBase
    {
        private readonly IMapper _mapper;

        public ProdutoService(IRepositoryWrapper repository, IMapper mapper): base(repository)
        {
            _mapper = mapper;
        }


    }
}
