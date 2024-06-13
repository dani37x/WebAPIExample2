using WebAPIExample2.Interfaces;
using WebAPIExample2.IRepositories;
using WebAPIExample2.IServices;
using WebAPIExample2.Models;

namespace WebAPIExample2.Services
{
    public class PartService : IPartService
    {
        private readonly IPartRepository _partRepository;
        public PartService(IPartRepository partRepository)
        {
            _partRepository = partRepository;
        }

        public async Task<Part> GetPart(int partId)
        {
            return await _partRepository.GetPart(partId);
        }

        public async Task<IEnumerable<Part>> GetParts()
        {
            return await _partRepository.GetParts();
        }

        public async Task<bool> AddPart(Part partModel)
        {
            return await _partRepository.AddPart(partModel);
        }

        public async Task UpdatePart(Part partModel)
        {
            await _partRepository.UpdatePart(partModel);
        }

        public async Task DeletePart(int partId)
        {
            await _partRepository.DeletePart(partId);
        }
    }
}
