using tcc.Models;

namespace tcc.Services.VendasService
{
    public interface IVendaService
    {
        Guid CriarVenda(VendaModel vanda);
        (VendaModel, List<ProdutoModel>) GetVenda(Guid vanda);

        void DeleteVenda(Guid vendaId);
    }
}
