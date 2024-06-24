using Entities;

namespace Business.Interface
{
    public interface IEmailSender
    {
         Task<bool> VerifyCredential(int idUser);
         bool SendEmail(User user);
    }
}