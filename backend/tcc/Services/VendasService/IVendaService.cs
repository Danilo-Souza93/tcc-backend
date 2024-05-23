using tcc.Models;

namespace tcc.Services.VendasService
{
    public interface IVendaService
    {
        void CriarVenda(VendaModel vanda);
        (VendaModel, List<ProdutoModel>) GetVenda(Guid vanda);
    }
}
