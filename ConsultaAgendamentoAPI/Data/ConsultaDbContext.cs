using Microsoft.EntityFrameworkCore;
using ConsultaAgendamentoAPI.Models;

public class ConsultaDbContext : DbContext
{
    public ConsultaDbContext(DbContextOptions<ConsultaDbContext> options) : base(options)
    {
    }

    public DbSet<Consulta> Consultas { get; set; }
}
