using GaleriaGatos.Properties.Model;
using GaleriaGatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GaleriaGatos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatosController : ControllerBase
    {
        private readonly IGatosRepository _gatosRepository;
        public GatosController(IGatosRepository gatosRepository)
        {
            _gatosRepository = gatosRepository;
        }

        private readonly ILogger<GatosController> _logger;

        public GatosController(ILogger<GatosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Gatos>> GetGatos()
        {
            return await _gatosRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gatos>> GetGatos(int id)
        {
            return await _gatosRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Gatos>> PostGatos([FromBody] Gatos gatos)
        {
            var newGato = await _gatosRepository.Create(gatos);
            return CreatedAtAction(nameof(GetGatos), new { id = newGato.Id }, newGato);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var gatosToDelete = await _gatosRepository.Get(id);

            if (gatosToDelete == null)
               return NotFound();

            await _gatosRepository.Delete(gatosToDelete.Id);
            return NoContent();

        }

        [HttpPut]
        public async Task<ActionResult> PutGatos(int id, [FromBody] Gatos gatos)
        {
            if (id != gatos.Id)
                return BadRequest();

                await _gatosRepository.Update(gatos);

            return NoContent();
        }
    }
}
