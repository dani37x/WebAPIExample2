using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIExample2.IServices;
using WebAPIExample2.Models;
using WebAPIExample2.Services;

namespace WebAPIExample2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : ControllerBase
    {
        private readonly IPartService _partService;

        public PartController(IPartService partService)
        {
            _partService = partService;
        }

        [HttpGet("{partId}")]
        public async Task<ActionResult> GetPart(int partId)
        {
            var part = await _partService.GetPart(partId);
            if (part != null)
            {
                return Ok(part);
            }
            return BadRequest($"Lack of part with id: {partId}");

        }
    
        [HttpGet]
        [Route("parts")]
        public async Task<IActionResult> GetParts()
        {
            var parts = await _partService.GetParts();

                if (parts != null)
                {
                    return Ok(parts);
                }
            return NotFound("Lack of parts");
        }

        [HttpPost]
        public async Task<ActionResult> AddPart(Part partModel)
        {
            if (await _partService.AddPart(partModel))
            {
                return Ok(partModel);
            }
            return NotFound("Part of this name already exists");
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePart(Part partModel)
        {
            var existingPart = await _partService.GetPart(partModel.PartId);
            if (existingPart == null)
            {
                return NotFound("There is no part like this one");
            }

            await _partService.UpdatePart(partModel);
            return Ok("The part has been updated");
        }

        [HttpDelete("{partId}")]
        public async Task<ActionResult> DeletePart(int partId)
        {
            var existingPart = await _partService.GetPart(partId);
            if (existingPart == null)
            {
                return NotFound();
            }

            await _partService.DeletePart(partId);
            return NoContent();
        }
    }
}
