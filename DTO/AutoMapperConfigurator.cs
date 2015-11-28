using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BeSmartService.DAL;

namespace BeSmartService.DTO
{
    public static class AutoMapperConfigurator
    {
        public static void Configure() {

            Mapper.CreateMap<TestCreatorUserDal, TestCreatorUser>().ForMember(o => o.UserName, m => m.MapFrom(s => s.Id));
            Mapper.CreateMap<InterestDal, Interest>();
            Mapper.CreateMap<SubjectDal, Subject>();
            Mapper.CreateMap<StudentUserDal, StudentUser>();
        }
    }
}
