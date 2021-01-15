using ServiceProvider.ServiceProvider;

namespace ServiceProvider.Services
{
    public interface IService
    {
        void InitService(IServices services);
    }
    public abstract class Service : IService
    {
        protected IServices Services { get; private set; }
        public void InitService(IServices services)
        {
            Services = services;
            Init();
        }
        public Service() { }
        protected virtual void Init() { }

    }
}
