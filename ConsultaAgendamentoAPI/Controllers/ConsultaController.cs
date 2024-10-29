using ConsultaAgendamentoAPI.Models;
using ConsultaAgendamentoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaAgendamentoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultaController : ControllerBase
    {
        private readonly ConsultaService _consultaService;

        public ConsultaController(ConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        // Recupera todas as consultas
        [HttpGet]
        public async Task<IActionResult> GetConsultas() =>
            Ok(await _consultaService.GetConsultasAsync());

        // Recupera uma consulta pelo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConsultaById(int id)
        {
            var consulta = await _consultaService.GetConsultaByIdAsync(id);
            return consulta == null ? NotFound() : Ok(consulta);
        }

        // Cria uma nova consulta
        [HttpPost]
        public async Task<IActionResult> CreateConsulta([FromBody] Consulta consulta)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _consultaService.ConfirmarConsultaAsync(consulta);
            return CreatedAtAction(nameof(GetConsultaById), new { id = consulta.ConsultaId }, consulta);
        }

        // Deleta uma consulta pelo ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsulta(int id)
        {
            var consulta = await _consultaService.GetConsultaByIdAsync(id);
            if (consulta == null) return NotFound();

            await _consultaService.DeleteConsultaAsync(id);
            return NoContent();
        }
    }
}
