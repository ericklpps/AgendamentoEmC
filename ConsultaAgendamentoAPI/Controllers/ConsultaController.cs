using ConsultaAgendamentoAPI.Models;
using ConsultaAgendamentoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaAgendamentoAPI.Controllers
{
    [ApiController]
    [Route("api/consultas")]
    public class ConsultaController : ControllerBase
    {
        private readonly ConsultaService _consultaService;

        public ConsultaController(ConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        // Recupera todas as consultas
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var consultas = await _consultaService.GetConsultasAsync();
            if (consultas == null || !consultas.Any())
                return NotFound("Nenhuma consulta encontrada.");
            return Ok(consultas);
        }

        // Recupera uma consulta específica pelo ID
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var consulta = await _consultaService.GetConsultaByIdAsync(id);
            if (consulta == null)
                return NotFound($"Consulta com ID {id} não encontrada.");
            return Ok(consulta);
        }

        // Cria uma nova consulta
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Consulta consulta)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _consultaService.ConfirmarConsultaAsync(consulta);
            return CreatedAtAction(nameof(GetById), new { id = consulta.ConsultaId }, consulta);
        }

        // Atualiza uma consulta existente pelo ID
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Consulta consultaAtualizada)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var consultaExistente = await _consultaService.GetConsultaByIdAsync(id);
            if (consultaExistente == null)
                return NotFound($"Consulta com ID {id} não encontrada para atualização.");

            // Atualizar os dados da consulta
            consultaExistente.NomePaciente = consultaAtualizada.NomePaciente;
            consultaExistente.EmailPaciente = consultaAtualizada.EmailPaciente;
            consultaExistente.DataConsulta = consultaAtualizada.DataConsulta;
            consultaExistente.HoraConsulta = consultaAtualizada.HoraConsulta;
            consultaExistente.Dentista = consultaAtualizada.Dentista;

            await _consultaService.ConfirmarConsultaAsync(consultaExistente);
            return Ok(consultaExistente);
        }

        // Deleta uma consulta pelo ID
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var consulta = await _consultaService.GetConsultaByIdAsync(id);
            if (consulta == null)
                return NotFound($"Consulta com ID {id} não encontrada para exclusão.");

            await _consultaService.DeleteConsultaAsync(id);
            return NoContent();
        }
    }
}
