using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using System.Configuration;
using System;
namespace BibliotecaCLases.Modelo
{
    public static class Email
    {
        /// <summary>
        /// Envia un email de confirmacion al usuario registrado
        /// </summary>
        /// <param name="email"></param>
        public static string SendMessageSmtp(string email, string contraseña, string nombre, string apellido)
        {
            string host = ConfigurationManager.AppSettings["mailgunHost"]!;
            string password = ConfigurationManager.AppSettings["mailgunPassword"]!;
            MimeMessage mail = new MimeMessage();
            mail.From.Add(new MailboxAddress("Sistema Sysacad", $"foo@{host}"));
            mail.To.Add(new MailboxAddress($"{apellido},{nombre}", email));
            mail.Subject = "Registro de alumno";
            mail.Body = new TextPart("plain")
            {
                Text = @$"Registro exitoso, bienvenido al nuevo SistemaSysacad. Tu contraseña es: {contraseña} y tu usario es tu DNI",
            };
            try
            {
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect("smtp.mailgun.org", 587, false);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate($"postmaster@{host}", password);

                    client.Send(mail);
                    client.Disconnect(true);
                }
            }
            catch (Exception)
            {

                return "El mail registrado no se encuentra valido en mailgun";
            }
            return "Email entregado";
        }
    }
}

