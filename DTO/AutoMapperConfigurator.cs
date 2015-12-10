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
    public class DTOCache<T,S> where T :IDTO<S>
    {

        private  IRetrievableType<T, S> _retrievable;
        private  List<T> _cachedData = new List<T>();

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
            DTOCache<Interest, int> interestCache = new DTOCache<Interest, int>(new InterestFacade());
            DTOCache<Subject, int> subjectCache = new DTOCache<Subject, int>(new SubjectFacade());
            DTOCache<TestCreatorUser, string> testCreatorCache = new DTOCache<TestCreatorUser, string>(new TestCreatorFacade());


            Mapper.CreateMap<TestCreatorUserDal, TestCreatorUser>();
            Mapper.CreateMap<InterestDal, Interest>();
            Mapper.CreateMap<SubjectDal, Subject>().ForMember(i => i.Interest, map => map.MapFrom(d => interestCache.GetDtoFromCache(d.InterestId)));
            Mapper.CreateMap<StudentUserDal, StudentUser>();
            Mapper.CreateMap<TestDal, Test>().ForMember(i => i.Subject, map => map.MapFrom(d => subjectCache.GetDtoFromCache(d.SubjectId))).ForMember(i=>i.TestCreator,map=>map.MapFrom(d=> testCreatorCache.GetDtoFromCache(d.CreatorId)));
            Mapper.CreateMap<QuestionTypeDal, QuestionType>();
            Mapper.CreateMap<AchievementDal, Achievement>();
           
        }

        public static void ConfigureDtoSavables()
        {
            Mapper.CreateMap<SaveTestRank, TestRankDal>();
        }
    }
}
