
Send Email

Namespace
using System.Net.Mail;

Packages para acessar o arquivo de configuração appsetting.json

    Microsoft.Extensions.Configuration
    Microsoft.Extensions.Configuration.FileExtensions
    Microsoft.Extensions.Configuration.Json    
    Microsoft.Extensions.Configuration.Binder

Passos para enviar um email
* Configurar o servidor SMTP em um arquivo especifico.
    Host - Para quem enviar
    Port - Em que porta
    Credenciais - Username e password
* Criar a mensagem (From, To, Subject, Body, Attachment)
* Pegar as configurações para onde sera enviado junto com as credenciais 
* Enviar


Tarefas 
[ ] Portar o código para MailKit