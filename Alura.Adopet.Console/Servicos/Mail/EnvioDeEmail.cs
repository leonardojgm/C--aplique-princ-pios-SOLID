using System.Net.Mail;
using System.Net;
using Alura.Adopet.Console.Settings;
using FluentResults;
using Alura.Adopet.Console.Results;

namespace Alura.Adopet.Console.Servicos.Mail
{
    public static class EnvioDeEmail
    {
        private static IMailService CriarMailService()
        {
            MailSettings settings = Configurations.MailSettings;
            SmtpClient smtp = new()
            {
                Host = settings.Servidor!,
                Port = settings.Porta,
                Credentials = new NetworkCredential(settings.Usuario, settings.Senha),
                EnableSsl = true,
                UseDefaultCredentials = false
            };

            return new SmtpClientMailService(smtp);
        }

        public static void Disparar(Result resultado)
        {
            ISuccess? success = resultado.Successes.FirstOrDefault();

            if (success is null) return;

            if (success is SuccessWithPets sucesso)
            {
                IMailService mailService = CriarMailService();

                mailService.SendMailAsync(
                    remetente: "ro-reply@adopet.com.br",
                    titulo: $"[Adopet] {sucesso.Message}",
                    corpo: $"Foram importados {sucesso.Data.Count()} pets.",
                    destinatario: "cookie.maia@gmail.com"
                    );
            }
        }
    }
}
