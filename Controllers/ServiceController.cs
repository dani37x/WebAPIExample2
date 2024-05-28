using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIExample2.DTO;
using WebAPIExample2.IServices;
using WebAPIExample2.Models;

namespace WebAPIExample2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet("{serviceId}")]
        public async Task<ActionResult> GetService(int serviceId)
        {
            return Ok(await _serviceService.GetService(serviceId));
        }
        [HttpGet]
        [Route("ServicesIds")]

        public async Task<IActionResult> GetServices()
        {
            return Ok(await _serviceService.GetServices());
        }

        [HttpPost]
        public async Task<ActionResult> AddService(ServiceDTO serviceDTO)
        {
            await _serviceService.AddService(serviceDTO);
            return Ok(serviceDTO);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateService(ServiceDTO serviceDTO)
        {
            var existingService = await _serviceService.GetService(serviceDTO.ServiceId);
            if (existingService == null)
            {
                return NotFound();
            }

            await _serviceService.UpdateService(serviceDTO);
            return NoContent();
        }

        [HttpDelete("{serviceId}")]
        public async Task<ActionResult> DeleteService(int serviceId)
        {
            var existingService = await _serviceService.GetService(serviceId);
            if (existingService == null)
            {
                return NotFound();
            }

            await _serviceService.DeleteService(serviceId);
            return NoContent();
        }
    }
}
