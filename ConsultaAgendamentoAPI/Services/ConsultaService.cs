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

        public async Task<List<Consulta>> GetConsultasAsync()
        {
            return await _consultaRepository.GetConsultasAsync();
        }

        public async Task<Consulta?> GetConsultaByIdAsync(int id)
        {
            return await _consultaRepository.GetConsultaByIdAsync(id);
        }

        public async Task ConfirmarConsultaAsync(Consulta consulta)
        {
            await _consultaRepository.AddConsultaAsync(consulta);
        }

        public async Task DeleteConsultaAsync(int id)
        {
            await _consultaRepository.DeleteConsultaAsync(id);
        }
    }
}
