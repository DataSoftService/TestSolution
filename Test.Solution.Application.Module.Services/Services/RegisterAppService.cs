using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestSolution.Application.DTOs.Dto;
using TestSolution.Infrastructure.Database.Communication;

namespace Test.Solution.Application.Module.Services.Services
{
    public class RegisterAppService : IRepository<RegisterDto>
    {
        DbContext db;
        public RegisterAppService(DbContext _db)
        {
            db = _db;
        }

        public Task<bool> delete(RegisterDto entity, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> delete(RegisterDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterDto> edit(RegisterDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterDto> edit(string sql)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterDto> find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterDto> find(Func<RegisterDto, bool> lanbdaExpresion)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterDto> insert(RegisterDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterDto> insert(IEnumerable<RegisterDto> list)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RegisterDto>> list()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RegisterDto>> list(Func<RegisterDto, bool> lanbdaExpresion)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RegisterDto>> list(int id)
        {
            throw new NotImplementedException();
        }
    }
}
