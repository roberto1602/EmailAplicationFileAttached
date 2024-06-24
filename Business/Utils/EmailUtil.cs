using Business.Interface;
using Entities;

namespace Business.Utils
{
    public class EmailUtil
    {
        private readonly IEmailSender _emailSender;

        public EmailUtil(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public void FileExcel(List<Departamento> listDepto)
        {
            FileLoad fileLoad = new();
            fileLoad.FileExcel(listDepto);
        }

        public async Task<bool> VerifyEmail(int idUser)
        {
            var verifyEmail = await _emailSender.VerifyCredential(idUser);
            return verifyEmail;
        }
    }
}
