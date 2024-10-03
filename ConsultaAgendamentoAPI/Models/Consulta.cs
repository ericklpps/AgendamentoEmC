namespace ConsultaAgendamentoAPI.Models
{
    public class Consulta
    {
        public int ConsultaId { get; set; }

        public required string NomePaciente { get; set; }
        public required string EmailPaciente { get; set; }

        public DateTime DataConsulta { get; set; }
        public string HoraConsulta { get; set; } = string.Empty;
        public required string Dentista { get; set; }
    }
}
