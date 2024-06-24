using Business.Interface;
using DataRepository.Interface;
using Entities;
using System.Net;
using System.Net.Mail;

namespace Business.Implementation
{
    public class EmailSender : IEmailSender
    {
        private readonly IRepositoryData _repositoryData;

        public EmailSender(IRepositoryData repositoryData)
        {
            _repositoryData = repositoryData;
        }

        public async Task<bool> VerifyCredential(int idUser)
        {
            bool areCredentialsValid = false;

            User queryUser = await _repositoryData.GetUserEmail(idUser);

            if (queryUser == null)
            {
                string mensaje = "Datos no encontrados";
            }


            using (var smtpClient = new SmtpClient("smtp.gmail.com"))
            {
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential(queryUser!.Email!.ToString(), queryUser.Password!.ToString()!);
                smtpClient.EnableSsl = true;

                try
                {
                    smtpClient.Send(new MailMessage(queryUser.Email!.ToString(), queryUser.Password!.ToString(), "Test Subject", "Test Body"));
                    Console.WriteLine("Credenciales válidas.");
                    areCredentialsValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al verificar credenciales: {ex.Message}");
                    areCredentialsValid = false;
                }
            }
             SendEmail(queryUser);

            return areCredentialsValid;
        }


        public bool SendEmail(User user)
        {
            string attachmentPath = "Departamentos.xlsx";
            using var smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Credentials = new NetworkCredential(user!.Email, user.Password);
            smtpClient.EnableSsl = true;

            bool isEmailSent;
            try
            {
                var mail = new MailMessage()
                {
                    From = new MailAddress(user.Email!),
                    Subject = "Tiendas Morada Store Bogota",
                    Body = "<b>Archivo de excel departamentos Bogota</b>",
                    IsBodyHtml = true
                };

                mail.To.Add(new MailAddress(user.EmailDestination!));
                mail.Attachments.Add(new Attachment(attachmentPath));

                smtpClient.Send(mail);
                Console.WriteLine("Correo electrónico enviado con éxito.");
                isEmailSent = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el correo electrónico: {ex.Message}");
                isEmailSent = false;
            }

            return isEmailSent;
        }

    }
}