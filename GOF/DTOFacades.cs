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

        public SubjectFacade()
        {
            _subjectRepo = DefaultRepository<SubjectDal, int>.GetDefaultRepo().DefaultRepo;
        }

        List<Interest> _interestsCache = new List<Interest>();

        public List<Subject> GetAll()
        {
            var subjectDals = _subjectRepo.GetAll();

            if (subjectDals == null || subjectDals.Count()==0)
                return null;

            return subjectDals.ToList().ConvertAll(o => Mapper.Map<SubjectDal, Subject>(o));

        }


        public Subject GetById(int id)
        {
            var currDal = _subjectRepo.GetById(id);

            if (currDal == null)
                return null;

            var sub = Mapper.Map<SubjectDal, Subject>(currDal);

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

    public class StudentUserFacade : IRetrievableType<StudentUser, Guid>,ISavableType<SaveStudentUser>,IDeletableType<DeleteStudentUser>
    {
        IRepository<StudentUserDal, Guid> _repository;

        public StudentUserFacade()
        {
            _repository = DefaultRepository<StudentUserDal, Guid>.GetDefaultRepo().DefaultRepo;
        }

        public void Delete(DeleteStudentUser deletableId)
        {
            _repository.Delete(deletableId.Id);
        }

        public List<StudentUser> GetAll()
        {
            var dals = _repository.GetAll();

            if(dals!=null && dals.Count() != 0)
                return dals.ToList().ConvertAll<StudentUser>(o => Mapper.Map<StudentUserDal, StudentUser>(o));

            return null;
        }

        public StudentUser GetById(Guid id)
        {
            var dal = _repository.GetById(id);

            if (dal != null)
                return Mapper.Map<StudentUserDal, StudentUser>(dal);

            return null;
        }

        public int Save(SaveStudentUser savableObj)
        {
            StudentUserDal currDal = new StudentUserDal()
            {
                Email=savableObj.Email,
                Id=savableObj.Id,
                ImageUrl=savableObj.ImageUrl,
                LastName=savableObj.LastName,
                Name=savableObj.Name,
                Password=savableObj.Password,
                PhoneNumber=savableObj.PhoneNumber              
            };

            if (savableObj.Id == default(Guid))
            {
                currDal.Id = Guid.NewGuid();
                currDal.Password = Globals.GetSHA256(currDal.Id.ToString(), currDal.Password);//shesacvlelia saswrafod
                return _repository.Insert(currDal);
            }

            currDal.Password = Globals.GetSHA256(currDal.Id.ToString(), currDal.Password);
            _repository.Update(currDal);

            return 0;
        }
    }
}
