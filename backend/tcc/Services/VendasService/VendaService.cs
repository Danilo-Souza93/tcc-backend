﻿using AutoMapper;
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
            List<VendaProdutosEntityModel> vendaProdList = new List<VendaProdutosEntityModel>();
            var produtos = _strategy.ValidacaoVenda(venda);

            //remover itens do estoque.
            foreach (var prod in produtos) 
            {
                _repository.ProdutoRepository.Update(prod);
                _repository.Save();
            }

            VendaEntityModel vendaEntity = _mapper.Map<VendaEntityModel>(venda);
            vendaEntity.Id = Guid.NewGuid();
            _repository.VendaRepository.Create(vendaEntity);
            _repository.Save();

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
                    _repository.Save();
                }
            }
        }
    }
}
