using AutoMapper;
using System.Data;
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

        public Guid CriarVenda(VendaModel venda)
        {
            var produtos = _strategy.ValidacaoVenda(venda);
            
            VendaEntityModel vendaEntity = _mapper.Map<VendaEntityModel>(venda);
            vendaEntity.Id = Guid.NewGuid();
            vendaEntity.StatusPagamento = "Aprovado";
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

            return vendaEntity.Id;
        }

        public (VendaModel, List<ProdutoModel>) GetVenda(Guid vendaId)
        { 
            List<ProdutoModel> produtosVendidosList = new List<ProdutoModel>();
            
            VendaEntityModel vendaDb = _repository.VendaRepository.FindByCondition(x => x.Id == vendaId).FirstOrDefault();
            if (vendaDb == null)
            {
                throw new Exception("Venda não encontrada");
            }

            VendaModel venda = _mapper.Map<VendaModel>(vendaDb);

            List<VendaProdutosEntityModel> vendaProdutoList = _repository.VendaProdutoRepository.FindByCondition(x => x.VendaId == vendaId).ToList();

            if (vendaProdutoList == null)
            {
                throw new Exception("Relação venda produto não encontrada");
            }

            foreach(var produto in vendaProdutoList) 
            { 
                ProdutoEntityModel produtoDb = _repository.ProdutoRepository.FindByCondition(x => x.Id == produto.ProdutoId).FirstOrDefault();
                if(produtoDb == null)
                {
                    throw new Exception("Produto não encontrado");
                }
                
                produtosVendidosList.Add(_mapper.Map<ProdutoModel>(produtoDb));
            }
            

            return (venda, produtosVendidosList);
        }

        public void DeleteVenda(Guid vendaId)
        {

            VendaEntityModel vendaDb = _repository.VendaRepository.FindByCondition(x => x.Id == vendaId).FirstOrDefault();
            if (vendaDb == null)
            {
                throw new Exception("Venda não encontrada");
            }

            List<VendaProdutosEntityModel> vendaProdutoListDb = _repository.VendaProdutoRepository.FindByCondition(x => x.VendaId == vendaId).ToList();
            if(vendaProdutoListDb == null)
            {
                throw new Exception("Relação venda produto não encontrada");
            }

            foreach (var item in vendaProdutoListDb)
            {
                _repository.VendaProdutoRepository.Delete(item);
            }

            _repository.VendaRepository.Delete(vendaDb);
            _repository.Save();
        }
    }
}
