using ConsultaAgendamentoAPI.Models;
using System.Threading.Tasks;

namespace ConsultaAgendamentoAPI.Repositories
{
    public interface IConsultaRepository
    {
        Task<List<Consulta>> GetConsultasAsync();
        Task<Consulta?> GetConsultaByIdAsync(int id);
        Task AddConsultaAsync(Consulta consulta);
        Task UpdateConsultaAsync(Consulta consulta);
        Task DeleteConsultaAsync(int id);
    }
}
