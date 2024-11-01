using System.ComponentModel.DataAnnotations;

namespace ConsultaAgendamentoAPI.ViewModels
{
    public class ConsultaEditViewModel
    {
        [Required]
        public int ConsultaId { get; set; }

        [Required(ErrorMessage = "O nome do paciente é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do paciente deve ter no máximo 100 caracteres.")]
        public string? NomePaciente { get; set; }

        [Required(ErrorMessage = "O e-mail do paciente é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string? EmailPaciente { get; set; }

        [Required(ErrorMessage = "A data da consulta é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DataConsulta { get; set; }

        [Required(ErrorMessage = "O horário da consulta é obrigatório.")]
        [RegularExpression(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Horário inválido. Use o formato HH:mm.")]
        public string? HoraConsulta { get; set; }

        [Required(ErrorMessage = "O nome do dentista é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do dentista deve ter no máximo 100 caracteres.")]
        public string? Dentista { get; set; }

        [StringLength(500, ErrorMessage = "As observações devem ter no máximo 500 caracteres.")]
        public string? Observacoes { get; set; }
    }
}
