using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BeSmartService.DAL;
using BeSmartService.GOF;

namespace BeSmartService.DTO
{
    public  class DTOCache<T,S> where T :IDTO<S>
    {

        private  IRetrievableType<T, S> _retrievable;
        private   List<T> _cachedData = new List<T>();

        public DTOCache(IRetrievableType<T, S> retrievable)
        {
            _retrievable = retrievable;
        }

        public T GetDtoFromCache(S id)
        {
            T currDto = _cachedData.Where(o => o.Id.Equals(id)).SingleOrDefault();

            if (currDto == null)
            {
                currDto = _retrievable.GetById(id);
                _cachedData.Add(currDto);
            }

            return currDto;
        }

    }

    public static class AutoMapperConfigurator
    {
        public static void Configure() {
            
            Mapper.CreateMap<TestCreatorUserDal, TestCreatorUser>();
            Mapper.CreateMap<InterestDal, Interest>();

            DTOCache<Interest, int> interestCache = new DTOCache<Interest, int>(new InterestFacade());
            Mapper.CreateMap<SubjectDal, Subject>().ForMember(i => i.Interest, map => map.MapFrom(d => interestCache.GetDtoFromCache(d.InterestId)));
            Mapper.CreateMap<StudentUserDal, StudentUser>();
        }
    }
}
