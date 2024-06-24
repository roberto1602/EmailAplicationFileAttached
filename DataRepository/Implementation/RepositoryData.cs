using DataRepository.Dto;
using DataRepository.Interface;
using Entities;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http2.HPack;
using Microsoft.EntityFrameworkCore;

namespace DataRepository.Implementation
{
    public class RepositoryData(ContextMain context) : IRepositoryData
    {
        private readonly ContextMain _context = context;

        public  Task<List<Departamento>> GetDataStatesAsync()
        {
            List<Departamento>? listaDepartamentos = [];

            listaDepartamentos = [.. (from d in _context.Departamentos
                                   select new Departamento
                                   {
                                       DepartamentoID = d.DepartamentoID,
                                       Nombre = d.Nombre,
                                   })];

            return Task.FromResult(listaDepartamentos);
        }


        public async Task<User> GetUserEmail(int idUser)
        {
            
            var user = await _context.Users
            .Where(u => u.IdentificationUser.Equals(idUser))
            .Select(u => new User
            {
                IdUser = u.IdUser,
                IdentificationUser = u.IdentificationUser,
                EmailDestination = u.EmailDestination,
                Email = u.Email,
                Password = u.Password
            }).AsNoTracking()
            .FirstOrDefaultAsync();
            
            return user!;
        }
    }
}