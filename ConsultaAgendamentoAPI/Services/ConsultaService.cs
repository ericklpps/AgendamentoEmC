using ConsultaAgendamentoAPI.Models;
using ConsultaAgendamentoAPI.Repositories;
using System.Threading.Tasks;

namespace ConsultaAgendamentoAPI.Services
{
    public class ConsultaService
    {
        private readonly IConsultaRepository _consultaRepository;

        public ConsultaService(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        // Recupera todas as consultas
        public async Task<List<Consulta>> GetConsultasAsync()
        {
            return await _consultaRepository.GetConsultasAsync();
        }

        // Recupera uma consulta específica pelo ID
        public async Task<Consulta?> GetConsultaByIdAsync(int id)
        {
            return await _consultaRepository.GetConsultaByIdAsync(id);
        }

        // Confirma uma nova consulta (cria)
        public async Task ConfirmarConsultaAsync(Consulta consulta)
        {
            await _consultaRepository.AddConsultaAsync(consulta);
        }

        // Atualiza uma consulta existente
        public async Task<bool> UpdateConsultaAsync(int id, Consulta consultaAtualizada)
        {
            var consultaExistente = await _consultaRepository.GetConsultaByIdAsync(id);
            if (consultaExistente == null)
                return false;

            // Atualizar os dados da consulta existente
            consultaExistente.NomePaciente = consultaAtualizada.NomePaciente;
            consultaExistente.EmailPaciente = consultaAtualizada.EmailPaciente;
            consultaExistente.DataConsulta = consultaAtualizada.DataConsulta;
            consultaExistente.HoraConsulta = consultaAtualizada.HoraConsulta;
            consultaExistente.Dentista = consultaAtualizada.Dentista;
            consultaExistente.Observacoes = consultaAtualizada.Observacoes;

            await _consultaRepository.UpdateConsultaAsync(consultaExistente);
            return true;
        }

        // Exclui uma consulta pelo ID
        public async Task<bool> DeleteConsultaAsync(int id)
        {
            var consulta = await _consultaRepository.GetConsultaByIdAsync(id);
            if (consulta == null)
                return false;

            await _consultaRepository.DeleteConsultaAsync(id);
            return true;
        }
    }
}
