using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TestSolution.Application.DTOs.Dto;
using TestSolution.Domain.Models;

namespace Test.Solution.Application.Module.Services.Profiles
{
    public class profile
    {
        public profile()
        {
            Mapper.Initialize(c => {
                c.CreateMap<Register, RegisterDto>().ReverseMap().ForAllOtherMembers(u => u.Ignore());
                c.CreateMap<IEnumerable<Register>, IEnumerable<RegisterDto>>().ReverseMap().ForAllOtherMembers(u => u.Ignore());
            });
        }
    }
}
