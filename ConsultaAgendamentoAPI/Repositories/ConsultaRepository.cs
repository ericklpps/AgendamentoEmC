using ConsultaAgendamentoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultaAgendamentoAPI.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly ConsultaDbContext _context;

        public ConsultaRepository(ConsultaDbContext context)
        {
            _context = context;
        }

        // Recupera todas as consultas
        public async Task<List<Consulta>> GetConsultasAsync()
        {
            return await _context.Consultas.AsNoTracking().ToListAsync();
        }

        // Recupera uma consulta específica pelo ID
        public async Task<Consulta?> GetConsultaByIdAsync(int id)
        {
            return await _context.Consultas.AsNoTracking().FirstOrDefaultAsync(c => c.ConsultaId == id);
        }

        // Adiciona uma nova consulta
        public async Task AddConsultaAsync(Consulta consulta)
        {
            _context.Consultas.Add(consulta);
            await _context.SaveChangesAsync();
        }

        // Atualiza uma consulta existente
        public async Task UpdateConsultaAsync(Consulta consulta)
        {
            _context.Entry(consulta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Deleta uma consulta pelo ID
        public async Task DeleteConsultaAsync(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta != null)
            {
                _context.Consultas.Remove(consulta);
                await _context.SaveChangesAsync();
            }
        }
    }
}
