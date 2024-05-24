using WebAPIExample2.Models;

namespace WebAPIExample2.Interfaces
{
    public interface IServiceRepository
    {
        public Task<Service> GetService(int serviceId);
        public Task<bool> AddService(Service serviceModel);
        public Task<bool> UpdateService(Service serviceModel);
        public Task<bool> DeleteService(int serviceId);
    }
}
