using Acv2.SharedKernel.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestSolution.Application.DTOs.Dto;
using TestSolution.Domain.Models;
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

        public async Task<bool> delete(RegisterDto entity, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> delete(RegisterDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<RegisterDto> edit(RegisterDto entity)
        {
            try
            {
                db.register.Update(entity.ProjectedAs<Register>());
                db.SaveChanges();
                return await Task.FromResult(entity);
            }
            catch (Exception x)
            {
                throw new ArgumentException(x.Message);
            }
        }

        public async Task<RegisterDto> edit(string sql)
        {
            throw new NotImplementedException();
        }

        public async Task<RegisterDto> find(int id)
        {
            try
            {
                var entity = db.register.Find(id);
                if (entity == null)
                {
                    entity = new Register();
                }
                return await Task.FromResult(entity.ProjectedAs<RegisterDto>());
            }
            catch (Exception x)
            {
                throw new ArgumentException(x.Message);
            }
        }

        public async Task<RegisterDto> find(Func<RegisterDto, bool> lanbdaExpresion)
        {
            throw new NotImplementedException();
        }

        public async Task<RegisterDto> insert(RegisterDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<RegisterDto> insert(IEnumerable<RegisterDto> list)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RegisterDto>> list()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RegisterDto>> list(Func<RegisterDto, bool> lanbdaExpresion)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RegisterDto>> list(int id)
        {
            throw new NotImplementedException();
        }
    }
}
