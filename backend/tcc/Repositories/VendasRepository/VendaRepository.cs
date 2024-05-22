using tcc.Context;
using tcc.EntityModels;

namespace tcc.Repositories.VendasRepository
{
    public class VendaRepository: RepositoryBase<VendaEntityModel>, IVendaRepository
    {
        public VendaRepository(APIDbContext dbContext) : base(dbContext) 
        { 
        }
    }
}
