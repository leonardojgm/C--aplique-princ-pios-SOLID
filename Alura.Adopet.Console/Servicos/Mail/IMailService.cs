namespace Alura.Adopet.Console.Servicos.Mail
{
    public interface IMailService
    {
        Task SendMailAsync(string remetente, string destinatario, string titulo, string corpo);
    }
}
