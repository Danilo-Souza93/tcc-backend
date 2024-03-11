namespace tcc.Services
{
    public class ServiceBase
    {
        private protected IRepositoryWrapper _repository;

        public ServiceBase(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
    }
}
