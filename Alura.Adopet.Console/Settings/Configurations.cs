using Microsoft.Extensions.Configuration;

namespace Alura.Adopet.Console.Settings
{
    public static class Configurations
    {
        public static ApiSettings ApiSettings
        {
            get
            {
                IConfiguration _config = BuildConfiguration();

                return _config.GetSection(ApiSettings.Section)
                    .Get<ApiSettings>() ?? throw new ArgumentException("Seção para configuração da API não encontrada!");
            }
        }

        public static MailSettings MailSettings
        {
            get
            {
                IConfiguration _config = BuildConfiguration();

                return _config.GetSection(MailSettings.EmailSection)
                    .Get<MailSettings>() ?? throw new ArgumentException("Seção para configuração do e-mail não encontrada!");
            }
        }

        private static IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddUserSecrets("b65fd100-064e-4fa8-9ebb-c9e8036de8ac")
                .Build();
        }
    }
}
