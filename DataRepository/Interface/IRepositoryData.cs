using DataRepository.Dto;
using Entities;

namespace DataRepository.Interface
{
    public interface IRepositoryData
    {
       Task<List<Departamento>> GetDataStatesAsync();
       Task<User> GetUserEmail(int idUser);
    }
}
