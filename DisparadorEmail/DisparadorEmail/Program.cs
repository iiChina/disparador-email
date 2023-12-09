using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using DisparadorEmail;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseCors(builder => builder
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
);

app.MapPost("/enviar-email", ([FromBody] Email email) =>
{
    // Configurar informações do remetente e destinatário
    string remetente = "arthur.temporario007@gmail.com";
    string senha = "honz qrle xcup flgc";
    string destinatario = email.Valor;
    string assunto = "Recebi seu e-mail";
    string corpo = "É nois professor, me da 10!! :D";

    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
    {
        Port = 587,
        Credentials = new NetworkCredential(remetente, senha),
        EnableSsl = true,
    };

    MailMessage mailMessage = new MailMessage(remetente, destinatario, assunto, corpo);

    try
    {
        smtpClient.Send(mailMessage);
        Console.WriteLine("E-mail enviado com sucesso!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao enviar e-mail: {ex.Message}");
    }
});

app.Run();