using ConsultaAgendamentoAPI.Models;
using ConsultaAgendamentoAPI.Repositories;
using System.Net;
using System.Net.Mail;


public class ConsultaService
{
    private readonly IConsultaRepository _consultaRepository;

    public ConsultaService(IConsultaRepository consultaRepository)
    {
        _consultaRepository = consultaRepository;
    }

    public async Task ConfirmarConsultaAsync(Consulta consulta)
    {
        await _consultaRepository.AddConsultaAsync(consulta);
        EnviarEmailConfirmacao(consulta);
    }

    private void EnviarEmailConfirmacao(Consulta consulta)
    {
        var smtpClient = new SmtpClient("smtp.example.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("email@example.com", "senha"),
            EnableSsl = true,
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress("noreply@consulta.com"),
            Subject = "Confirmação de Consulta",
            Body = $"Sua consulta com {consulta.Dentista} foi confirmada para {consulta.DataConsulta.ToShortDateString()} às {consulta.HoraConsulta}.",
            IsBodyHtml = false,
        };
        mailMessage.To.Add(consulta.EmailPaciente);

        smtpClient.Send(mailMessage);
    }
}
