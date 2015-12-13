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
            DTOCache<Test, int> testCache = new DTOCache<Test, int>(new TestFacade());
            DTOCache<QuestionType, int> questionTypeCache = new DTOCache<QuestionType, int>(new QuestionTypeFacade());
            DTOCache<StudentUser, Guid> studentUserCache = new DTOCache<StudentUser, Guid>(new StudentUserFacade());
            DTOCache<Achievement, int> achievementCache = new DTOCache<Achievement, int>(new AchievementFacade());
            DTOCache<TestQuestions, int> testQuestionsCache = new DTOCache<TestQuestions, int>(new TestQuestionsFacade());
            DTOCache<Status, int> statusCache = new DTOCache<Status, int>(new StatusFacade());

            Mapper.CreateMap<TestCreatorUserDal, TestCreatorUser>();
            Mapper.CreateMap<InterestDal, Interest>();
            Mapper.CreateMap<SubjectDal, Subject>().ForMember(i => i.Interest, map => map.MapFrom(d => interestCache.GetDtoFromCache(d.InterestId)));
            Mapper.CreateMap<StudentUserDal, StudentUser>();
            Mapper.CreateMap<TestDal, Test>().ForMember(i => i.Subject, map => map.MapFrom(d => subjectCache.GetDtoFromCache(d.SubjectId))).ForMember(i=>i.TestCreator,map=>map.MapFrom(d=> testCreatorCache.GetDtoFromCache(d.CreatorId)));
            Mapper.CreateMap<QuestionTypeDal, QuestionType>();
            Mapper.CreateMap<AchievementDal, Achievement>();

            Mapper.CreateMap<TestQuestionsDal, TestQuestions>().ForMember(i => i.Test, map => map.MapFrom(d => testCache.GetDtoFromCache(d.TestId))).ForMember(i => i.QuestionType, map => map.MapFrom(d => questionTypeCache.GetDtoFromCache(d.QuestionTypeId)));
            Mapper.CreateMap<StudentUserAchievementDal, StudentUserAchievement>().ForMember(i => i.StudentUser, map => map.MapFrom(d => studentUserCache.GetDtoFromCache(d.StudentUserId))).ForMember(i => i.Achievement, map => map.MapFrom(d => achievementCache.GetDtoFromCache(d.AchievementId)));
            Mapper.CreateMap<QuestionAnswerDal, QuestionAnswer>().ForMember(i => i.TestQuestions, map => map.MapFrom(d => testQuestionsCache.GetDtoFromCache(d.QuestionId)));
            Mapper.CreateMap<StudentTestsDal, StudentTests>().ForMember(i => i.Test, map => map.MapFrom(d => testCache.GetDtoFromCache(d.TestId))).ForMember(d => d.StudentUser, map => map.MapFrom(d => studentUserCache.GetDtoFromCache(d.StudentId)));
            Mapper.CreateMap<StatusCommentDal, StatusComment>().ForMember(d => d.StudentUser, map => map.MapFrom(d => studentUserCache.GetDtoFromCache(d.UserId))).ForMember(d => d.Status, map => map.MapFrom(d => statusCache.GetDtoFromCache(d.StatusId)));
            Mapper.CreateMap<StatusDal, Status>().ForMember(d => d.StudentUser, map => map.MapFrom(d => studentUserCache.GetDtoFromCache(d.UserId))).ForMember(i => i.Interest, map => map.MapFrom(d => interestCache.GetDtoFromCache(d.InterestId)));
            Mapper.CreateMap<UserExperienceInterestDal, UserExperienceInterest>().ForMember(d => d.StudentUser, map => map.MapFrom(d => studentUserCache.GetDtoFromCache(d.StudentUserId))).ForMember(i => i.Interest, map => map.MapFrom(d => interestCache.GetDtoFromCache(d.InterestId)));
            Mapper.CreateMap<UserInterestPointsDal, UserInterestPoints>().ForMember(d => d.StudentUser, map => map.MapFrom(d => studentUserCache.GetDtoFromCache(d.StudentUserId))).ForMember(i => i.Interest, map => map.MapFrom(d => interestCache.GetDtoFromCache(d.InterestId)));
            Mapper.CreateMap<CreatorUserInterestsDal, CreatorUserInterests>().ForMember(d => d.TestCreatorUser, map => map.MapFrom(d => testCreatorCache.GetDtoFromCache(d.CreatorUserId))).ForMember(i => i.Interest, map => map.MapFrom(d => interestCache.GetDtoFromCache(d.InterestId)));
            Mapper.CreateMap<StudentInterestsDal, StudentInterests>().ForMember(d => d.StudentUser, map => map.MapFrom(d => studentUserCache.GetDtoFromCache(d.StudentUserId))).ForMember(i => i.Interest, map => map.MapFrom(d => interestCache.GetDtoFromCache(d.InterestId)));
            Mapper.CreateMap<OauthUsersDal, OauthUsers>().ForMember(d => d.StudentUser, map => map.MapFrom(d => studentUserCache.GetDtoFromCache(d.UserId)));
        }

        public static void ConfigureDtoSavables()
        {
            Mapper.CreateMap<SaveTestRank, TestRankDal>();
        }
    }
}
