using ConsultaAgendamentoAPI.Models;
using ConsultaAgendamentoAPI.Repositories;
using Microsoft.EntityFrameworkCore;

public class ConsultaRepository : IConsultaRepository
{
    private readonly ConsultaDbContext _context;

    public ConsultaRepository(ConsultaDbContext context)
    {
        _context = context;
    }

    public async Task<List<Consulta>> GetConsultasAsync()
    {
        return await _context.Consultas.ToListAsync();
    }

    public async Task<Consulta> GetConsultaByIdAsync(int id)
    {
        return await _context.Consultas.FindAsync(id);
    }

    public async Task AddConsultaAsync(Consulta consulta)
    {
        _context.Consultas.Add(consulta);
        await _context.SaveChangesAsync();
    }

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
