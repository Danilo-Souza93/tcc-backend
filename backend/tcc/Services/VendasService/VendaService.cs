using AutoMapper;
using tcc.EntityModels;
using tcc.Models;
using tcc.Repositories;
using tcc.Strategies;

namespace tcc.Services.VendasService
{
    public class VendaService : ServiceBase, IVendaService
    {
        private readonly IMapper _mapper;
        private readonly IStrategy _strategy;

        public VendaService(
            IRepositoryWrapper repository, 
            IMapper mapper,
            IStrategy strategy
            ) : base(repository)
        {
            _mapper = mapper;
            _strategy = strategy;
        }

        public void CriarVenda(VendaModel venda)
        {
            var produtos = _strategy.ValidacaoVenda(venda);

            VendaEntityModel vendaEntity = _mapper.Map<VendaEntityModel>(venda);
            vendaEntity.Id = Guid.NewGuid();
            _repository.VendaRepository.Create(vendaEntity);

            foreach (var prod in venda.ProdutosVendidos) 
            {
                int prodId =  _repository.ProdutoRepository.FindByCondition(x => x.Id == prod.ProdutoId).FirstOrDefault().Id;

                if (prodId != null)
                {
                    VendaProdutosEntityModel vendaProd = new VendaProdutosEntityModel();
                    vendaProd.ProdutoId = prodId;
                    vendaProd.VendaId = vendaEntity.Id;
                    vendaProd.Quantidade = prod.Quantidade;

                    _repository.VendaProdutoRepository.Create(vendaProd);
                }
            }

            //remover itens do estoque.
            foreach (var prod in produtos)
            {
                _repository.ProdutoRepository.Update(prod);             
            }

            _repository.Save();
        }

        public (VendaModel, List<ProdutoModel>) GetVenda(Guid vendaId)
        { 
            List<ProdutoModel> produtosVendidosList = new List<ProdutoModel>();
            
            VendaEntityModel vendaDb = _repository.VendaRepository.FindByCondition(x => x.Id == vendaId).FirstOrDefault();
            VendaModel venda = _mapper.Map<VendaModel>(vendaDb);

            List<VendaProdutosEntityModel> vendaProdutoList = _repository.VendaProdutoRepository.FindByCondition(x => x.VendaId == vendaId).ToList();
            
            if(vendaProdutoList != null)
            {
                foreach(var produto in vendaProdutoList) 
                { 
                   ProdutoEntityModel produtoDb = _repository.ProdutoRepository.FindByCondition(x => x.Id == produto.ProdutoId).FirstOrDefault();
                   produtosVendidosList.Add(_mapper.Map<ProdutoModel>(produtoDb));
                }
            }

            return (venda, produtosVendidosList);
        }
    }
}
