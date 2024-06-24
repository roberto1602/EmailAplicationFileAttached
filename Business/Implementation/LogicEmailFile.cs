using Business.Interface;
using Business.Utils;
using DataRepository.Dto;
using DataRepository.Interface;
using Entities;

namespace Business.Implementation
{
    public class LogicEmailFile : ILogicEmailFile
    {
        private readonly IRepositoryData _repositoryData;
        private readonly IEmailSender _emailSender;
        public LogicEmailFile(IRepositoryData repositoryData, IEmailSender emailSender)
        {
            _repositoryData = repositoryData;
            _emailSender = emailSender;
        }


        public async Task<List<Departamento>> GetStates(int idUser)
        {
            EmailUtil emailUtil = new EmailUtil(_emailSender);
            List<DepartamentoDto> departamentoDtoList = [];

            List<Departamento> resultList = await _repositoryData.GetDataStatesAsync();

            string message = string.Empty;

            if (resultList is null)
                message = "datos no encontrados";

            foreach (Departamento departamento in resultList!)
            {
                departamentoDtoList.Add(new DepartamentoDto()
                {
                    DepartamentoID = departamento.DepartamentoID,
                    Nombre = departamento.Nombre
                });
            }

            emailUtil.FileExcel(resultList);
            await emailUtil.VerifyEmail(idUser);

            return  resultList;
        }
    }
}