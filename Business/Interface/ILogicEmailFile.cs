using DataRepository.Dto;
using Entities;

namespace Business.Interface
{
    public interface ILogicEmailFile
    {
        Task<List<Departamento>> GetStates(int idUser);
    }
}