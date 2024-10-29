using System.ComponentModel.DataAnnotations;

namespace ConsultaAgendamentoAPI.Models
{
    public class Consulta
    {
        [Key]
        public int ConsultaId { get; set; }

        [Required(ErrorMessage = "O nome do paciente é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do paciente deve ter no máximo 100 caracteres.")]
        public string? NomePaciente { get; set; }

        [Required(ErrorMessage = "O e-mail do paciente é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string? EmailPaciente { get; set; }

        [Required(ErrorMessage = "A data da consulta é obrigatória.")]
        public DateTime DataConsulta { get; set; }

        [Required(ErrorMessage = "O horário da consulta é obrigatório.")]
        public string? HoraConsulta { get; set; }

        [Required(ErrorMessage = "O nome do dentista é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do dentista deve ter no máximo 100 caracteres.")]
        public string? Dentista { get; set; }
    }
}
