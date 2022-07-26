using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MongoAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrneksController : ControllerBase
    {
        private readonly OrnekService service;

        public OrneksController(OrnekService ornekService) => service = ornekService;


        [HttpGet]
        public async Task<List<Ornek>> Get() => await service.GetAsync();

        [HttpGet("{_id:length(24)}")]
        public async Task<ActionResult<Ornek>> Get(string _id, OrnekService ornekService)
        {
            var ornek = await service.GetAsync(_id);

            if (ornek is null)
            {
                return NotFound();
            }
            return ornek;

        }

        [HttpPost]
        public async Task<IActionResult> Post(Ornek newOrnek)
        {
            await service.CreateAsync(newOrnek);

            return CreatedAtAction(nameof(Get), new { _id = newOrnek._id }, newOrnek);
        }

        [HttpPut("{_id:length(24)}")]
        public async Task<IActionResult> Update(string _id, Ornek updatedOrnek)
        {
            var ornek = await service.GetAsync(_id);

            if (ornek is null)
            {
                return NotFound();
            }

            updatedOrnek._id = ornek._id;

            await service.UpdateAsync(_id, updatedOrnek);

            return NoContent();
        }

        [HttpDelete("{_id:length(24)}")]
        public async Task<IActionResult> Delete(string _id)
        {
            var ornek = await service.GetAsync(_id);

            if (ornek is null)
            {
                return NotFound();
            }

            await service.RemoveAsync(_id);

            return NoContent();
        }

    }
}
