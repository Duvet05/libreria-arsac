using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MimeKit;
using System;
using System.IO;
using System.Threading;

namespace ARSACSoft
{
    class MandarCorreo
    {
        static string[] Scopes = { GmailService.Scope.GmailCompose, GmailService.Scope.GmailSend };
        static string _ApplicationName = "ARSAC";
        static GmailService gmailService; // Variable para acceder al servicio de Gmail

        static void Main(string[] args, byte[] pdfBytes)
        {
            // Obtén el servicio de Gmail autenticado
            gmailService = GetGmailService();

            // Ejemplo de envío de correo electrónico
            string from = args[0]; //cambiar
            string to = args[1]; //cambiar
            string subject = args[2]; //cambiar
            string body = args[3]; //cambiar
            var emailMessage = CreateEmail(from, to, subject, body, pdfBytes);
            SendMessage(emailMessage);
        }

        // Función para autenticar y obtener el servicio de Gmail
        static GmailService GetGmailService()
        {
            UserCredential credential;

            using (var stream = new FileStream("ruta/credenciales.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "ruta/token.json";

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "usuario",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            // Crea el servicio de Gmail
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = _ApplicationName,
            });

            return service;
        }

        // Función para enviar un mensaje MimeMessage
        private static void SendMessage(MimeMessage emailMessage)
        {
            using (var stream = new MemoryStream())
            {
                emailMessage.WriteTo(stream);
                var rawMessage = Base64UrlEncode(stream.ToArray());

                var message = new Message
                {
                    Raw = rawMessage
                };

                gmailService.Users.Messages.Send(message, "me").Execute();
            }
        }

        // Crea un objeto MimeMessage con los campos especificados
        private static MimeMessage CreateEmail(string from, string to, string subject, string body, byte[] pdfBytes)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("", from));
            emailMessage.To.Add(new MailboxAddress("", to));
            emailMessage.Subject = subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = body;

            // Adjunta el archivo PDF generado en memoria al cuerpo del mensaje
            var attachment = new MimePart("application", "pdf")
            {
                Content = new MimeContent(new MemoryStream(pdfBytes)),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = "archivo.pdf"
            };


            bodyBuilder.Attachments.Add(attachment);

            emailMessage.Body = bodyBuilder.ToMessageBody();

            return emailMessage;
        }


        // Convierte una cadena en formato base64url
        private static string Base64UrlEncode(byte[] input)
        {
            return Convert.ToBase64String(input)
                .Replace('+', '-')
                .Replace('/', '_')
                .Replace("=", "");
        }
    }
}