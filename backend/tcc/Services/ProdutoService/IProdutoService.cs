﻿using tcc.Models;

namespace tcc.Services.ProdutoService
{
    public interface IProdutoService
    {
        void CriarProdutos(List<ProdutoModel> produtos);
    }
}
