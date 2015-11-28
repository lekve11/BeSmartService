using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BeSmartService.DAL;
using BeSmartService.DTO;

namespace BeSmartService.GOF
{
    public class TestCreatorFacade : IRetrievableType<TestCreatorUser, string>,ISavableType<SaveTestCreatorUser>,IDeletableType<DeleteTestCreatorUser>
    {
        private IRepository<TestCreatorUserDal, string> _repository;

        public TestCreatorFacade()
        {
            _repository = DefaultRepository<TestCreatorUserDal, string>.GetDefaultRepo().DefaultRepo;
        }

        public void Delete(DeleteTestCreatorUser deletableId)
        {
            _repository.Delete(deletableId.Username);
        }

        public List<TestCreatorUser> GetAll()
        {
            var dals = _repository.GetAll();

            if(dals!=null && dals.Count() > 0)
            {
                var dtos = dals.ToList().ConvertAll(o => Mapper.Map<TestCreatorUserDal, TestCreatorUser>(o));

                return dtos;
            }

            return null;
        }

        public TestCreatorUser GetById(string id)
        {
            var currdal = _repository.GetById(id);

            if (currdal != null)
                return Mapper.Map<TestCreatorUserDal, TestCreatorUser>(currdal);
                
            return null;
        }

        public int Save(SaveTestCreatorUser savableObj)
        {

            var currDal = _repository.GetById(savableObj.UserName);

            
            var dal = new TestCreatorUserDal()
            {
                Address = savableObj.Address,
                Email = savableObj.Email,
                Id = savableObj.UserName,
                ImgUrl = savableObj.ImgUrl,
                MobileNumber = savableObj.MobileNumber,
                Organization = savableObj.Organization,
                Password = savableObj.Password,
                PhoneNumber = savableObj.PhoneNumber,
                WebSite = savableObj.WebSite
            };
            if(currDal== null)
               return _repository.Insert(dal);

            _repository.Update(dal);

            return 0;
        }
    }
    
    public class InterestFacade : IRetrievableType<Interest, int>, ISavableType<SaveInterest>, IDeletableType<DeleteInterest>
    {
        private IRepository<InterestDal, int> _repository;

        public InterestFacade()
        {
            _repository = DefaultRepository<InterestDal, int>.GetDefaultRepo().DefaultRepo;
        }

        public void Delete(DeleteInterest deletableId)
        {
            _repository.Delete(deletableId.Id);
        }

        public List<Interest> GetAll()
        {
            var dals = _repository.GetAll();

            if (dals != null && dals.Count() > 0)
            {
                var dtos = dals.ToList().ConvertAll(o => Mapper.Map<InterestDal,Interest>(o));
                return dtos;
            }

            return null;
        }

        public Interest GetById(int Id)
        {
            var currdal = _repository.GetById(Id);

            if (currdal != null)
                return Mapper.Map<InterestDal, Interest>(currdal);

            return null;
        }

        public int Save(SaveInterest savableObj)
        {

            var dal = new InterestDal()
            {
                Id = savableObj.Id,
                Name = savableObj.Name,
            };

            if(savableObj.Id==default(int))
                return _repository.Insert(dal);

            _repository.Update(dal);

            return 0;
        }

    }

    public class SubjectFacade : IRetrievableType<Subject, int>,ISavableType<SaveSubject>,IDeletableType<DeleteSubject>
    {
        IRepository<SubjectDal, int> _subjectRepo;
        IRepository<InterestDal, int> _interestRepo;

        public SubjectFacade()
        {
            _subjectRepo = DefaultRepository<SubjectDal, int>.GetDefaultRepo().DefaultRepo;
            _interestRepo = DefaultRepository<InterestDal, int>.GetDefaultRepo().DefaultRepo;

        }

        List<Interest> _interestsCache = new List<Interest>();

        public List<Subject> GetAll()
        {
            var subjectDals = _subjectRepo.GetAll();

            if (subjectDals == null || subjectDals.Count()==0)
                return null;

            List<Subject> subjectList = new List<Subject>();

            foreach (var dalItem in subjectDals)
            {
                var subjectDTO = Mapper.Map<SubjectDal, Subject>(dalItem);
                subjectDTO.Interest = this.getInterestDtoFromDal(dalItem.InterestId);
                subjectList.Add(subjectDTO);
               
            }

            return subjectList;
        }

        private Interest getInterestDtoFromDal(int interestId)
        {
            Interest currInterest =_interestsCache.Where(o => o.Id == interestId).SingleOrDefault();

            if (currInterest != null)
               return currInterest;

            var dalObj = _interestRepo.GetById(interestId);

            currInterest = Mapper.Map<InterestDal, Interest>(dalObj);

            _interestsCache.Add(currInterest);

            return currInterest;
        }

        public Subject GetById(int id)
        {
            var currDal = _subjectRepo.GetById(id);

            if (currDal == null)
                return null;

            var sub = Mapper.Map<SubjectDal, Subject>(currDal);
            sub.Interest = this.getInterestDtoFromDal(currDal.InterestId);

            return sub;
        }

        public int Save(SaveSubject savableObj)
        {
            SubjectDal dalSubject = new SubjectDal() {
                    Id=savableObj.Id,
                    InterestId=savableObj.InterestId,
                    Name=savableObj.Name
            };

            if (savableObj.Id == default(int))
                return _subjectRepo.Insert(dalSubject);

            _subjectRepo.Update(dalSubject);

            return 0;
        }

        public void Delete(DeleteSubject deletableId)
        {
            _subjectRepo.Delete(deletableId.Id);
        }
    }
}
