using tcc.Models;

namespace tcc.Services.VendasService
{
    public interface IVendaService
    {
        Guid CriarVenda(VendaModel vanda);
        DetalheVendaModel GetVenda(Guid vanda);
        void DeleteVenda(Guid vendaId);
        Guid UpdateVenda(VendaModel vanda);
    }
}
