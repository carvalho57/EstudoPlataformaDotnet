using System.IO;
using Microsoft.Extensions.Configuration;


namespace SendEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()                   
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json",false,true)
                    .Build();

            var settings = configuration.Get<Settings>();
        
            EmailService emailService = new EmailService(settings.Smtp);
            var  mailMessage = emailService
                .CreateMailMessage(
                    "gabrielfeocarvalho57@gmail.com",
                    "guilhermefeo@outlook.com",
                    "subject",
                    " <p>Faça elevar<br>O cosmo no seu coração<br>Todo mal combater<br>Despertar o poder</p><p>Sua constelação<br>Sempre irá te proteger<br>Supera a dor e dá forças pra lutar</p><p>Pegasus Fantasy<br>Desejos a realizar<br>Pois as asas de um coração sonhador<br>Ninguém irá roubar</p><p>Saint Seiya!<br>Guerreiro das estrelas<br>Saint Seiya!<br>Nada a temer. Oh, yeah<br>Saint Seiya!<br>Unidos por sua força<br>Saint Seiya!<br>Pegasus, até vencer!</p><p>Faça elevar, seu poder até o céu<br>E enfim, encontrar sua constelação<br>Até chegar la, nunca pense em parar<br>Essa luta é sua, Siga sem hesitar</p><p>Pegasus Fantasy<br>Desejos em seu coração<br>Suas asas serão para poder voar<br>E te libertarão</p><p>Saint Seiya!<br>Guerreiro das estrelas<br>Saint Seiya!<br>Jamas se renderão<br>Saint Seiya!<br>Unidos por sua força<br>Saint Seiya!<br>Pegasus, até vencer!</p><p>Pegasus Fantasy<br>Desejos a realizar<br>Pois as asas de um coração sonhador<br>Ninguém irá roubar</p><p>Saint Seiya!<br>Guerreiro das estrelas<br>Saint Seiya!<br>Nada a temer. Oh, yeah<br>Saint Seiya!<br>Unidos por sua força<br>Saint Seiya!<br>Pegasus, até vencer!</p>"
                );
            emailService.Send(mailMessage);
        }
    }
}
