using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSmartService.DAL
{
    [DalObj(Alias ="besmart.TestCreatorUser")]
    public class TestCreatorUserDal : IEntity<string>
    {
        [DalObj(IsPrimaryKey =true,Alias ="UserName")]
        public string Id
        {
            get; set;
        }

        [DalObj(Alias ="Password")]
        public string Password { get; set; }

        [DalObj(Alias = "Email")]
        public string Email { get; set; }

        [DalObj(Alias = "Organization")]
        public string Organization { get; set; }

        [DalObj(Alias = "Addres")]
        public string Address { get; set; }

        [DalObj(Alias = "Website")]
        public string WebSite { get; set; }

        [DalObj(Alias = "PhoneNumber")]
        public string PhoneNumber { get; set; }

        [DalObj(Alias = "MobileNumber")]
        public string MobileNumber { get; set; }

        [DalObj(Alias = "ImgUrl")]
        public string ImgUrl { get; set; }

    }
    

    [DalObj(Alias = "besmart.Interest")]
    public class InterestDal : IEntity<int>
    {
        [DalObj(IsPrimaryKey = true, Alias = "Id")]
        public int Id { get; set; }

        [DalObj(Alias = "Name")]
        public string Name { get; set; }
    }

    [DalObj(Alias ="besmart.Subject")]
    public class SubjectDal : IEntity<int>
    {
        [DalObj(IsPrimaryKey =true,Alias ="Id")]
        public int Id
        {
            get; set;
        }

        [DalObj(Alias ="Name")]
        public string Name { get; set; }

        [DalObj(Alias ="InterestId")]
        public int InterestId { get; set; }
    }

    [DalObj(Alias ="besmart.StudentUser")]
    public class StudentUserDal : IEntity<Guid>
    {
        [DalObj(IsPrimaryKey =true,Alias ="id")]
        public Guid Id
        {
            get; set;
        }

        [DalObj(Alias ="Name")]
        public string Name { get; set; }

        [DalObj(Alias ="LastName")]
        public string LastName { get; set; }

        [DalObj(Alias ="ImageUrl")]
        public string ImageUrl { get; set; }

        [DalObj(Alias ="Password")]
        public string Password { get; set; }

        [DalObj(Alias ="Email")]
        public string Email { get; set; }

        [DalObj(Alias ="PhoneNumber")]
        public string PhoneNumber { get; set; }
    }

    [DalObj(Alias = "besmart.Test")]
    public class TestDal : IEntity<int>
    {
        [DalObj(Alias = "Id", IsPrimaryKey = true)]
        public int Id { get; set; }

        [DalObj(Alias ="Name")]
        public string Name { get; set; }

        [DalObj(Alias = "PublishDate")]
        public DateTime PublishDate { get; set; }

        [DalObj(Alias = "Price")]
        public decimal Price { get; set; }

        [DalObj(Alias = "DownloadCount")]
        public int DownloadCount { get; set; }

        [DalObj(Alias = "SubjectId")]
        public int SubjectId { get; set; }

        [DalObj(Alias = "Comment")]
        public string Comment { get; set; }

        [DalObj(Alias = "CreatorId")]
        public string CreatorId { get; set; }
    }

    [DalObj(Alias ="besmart.QuestionType")]
    public class QuestionTypeDal : IEntity<int>
    {
        [DalObj(Alias = "Id", IsPrimaryKey = true)]
        public int Id { get; set; }

        [DalObj(Alias = "Name")]
        public string Name { get; set; }
    }


    [DalObj(Alias ="besmart.TestRank")]
    public class TestRankDal : IEntity<int>
    {
        [DalObj(Alias ="Id",IsPrimaryKey =true)]
        public int Id
        {
            get; set;
        }

        [DalObj(Alias ="TestId")]
        public int TestId { get; set; }

        [DalObj(Alias ="StudentUserId")]
        public Guid StudentUserId { get; set; }

        [DalObj(Alias ="Rank")]
        public byte Rank { get; set; }
    }

    [DalObj(Alias ="besmart.Achievement")]
    public class AchievementDal : IEntity<int>
    {
        [DalObj(Alias = "Id", IsPrimaryKey = true)]
        public int Id { get; set; }

        [DalObj(Alias = "Name")]
        public string Name { get; set; }
    }

    [DalObj(Alias = "besmart.TestQuestions")]  //only dal
    public class TestQuestionsDal : IEntity<int>
    {
        [DalObj(Alias = "Id", IsPrimaryKey = true)]
        public int Id { get; set; }

        [DalObj(Alias = "Question")]
        public string Question { get; set; }

        [DalObj(Alias = "ImgUrl")]
        public string ImgUrl { get; set; }

        [DalObj(Alias = "TestId")]
        public int TestId { get; set; }

        [DalObj(Alias = "QuestionTypeId")]
        public int QuestionTypeId { get; set; }
    }

    [DalObj(Alias = "besmart.StudentUserAchievement")]  //only dal
    public class StudentUserAchievementDal : IEntity<int>
    {
        [DalObj(Alias = "Id", IsPrimaryKey = true)]
        public int Id { get; set; }

        [DalObj(Alias = "StudentUserId")]
        public Guid StudentUserId { get; set; }

        [DalObj(Alias = "AchievementId")]
        public int AchievementId { get; set; }

        [DalObj(Alias = "DateAchieved")]
        public DateTime DateAchieved { get; set; }

        [DalObj(Alias = "IsSeenByUser")]
        public bool IsSeenByUser { get; set; }
    }

    [DalObj(Alias = "besmart.QuestionAnswer")]  //only dal  !!missing one value??!!
    public class QuestionAnswerDal : IEntity<int>
    {
        [DalObj(Alias = "Id", IsPrimaryKey = true)]
        public int Id { get; set; }

        [DalObj(Alias = "Answer")]
        public string Answer { get; set; }

        [DalObj(Alias = "QuestionId")]
        public int QuestionId { get; set; }

        [DalObj(Alias = "ImageUrl")]
        public string ImageUrl { get; set; }

        [DalObj(Alias = "AnswerIndex")]
        public int AnswerIndex { get; set; }
    }

    [DalObj(Alias = "besmart.StudentTests")]  //only dal 
    public class StudentTestsDal : IEntity<int>
    {
        [DalObj(Alias = "Id", IsPrimaryKey = true)]
        public int Id { get; set; }

        [DalObj(Alias = "TestId")]
        public int TestId { get; set; }

        [DalObj(Alias = "StudentId")]
        public Guid StudentId { get; set; }

        [DalObj(Alias = "IsCompleted")]
        public bool IsCompleted { get; set; }
    }

    [DalObj(Alias = "besmart.StatusComment")]  //only dal 
    public class StatusCommentDal : IEntity<int>
    {
        [DalObj(Alias = "Id", IsPrimaryKey = true)]
        public int Id { get; set; }

        [DalObj(Alias = "StatusId")]
        public int StatusId { get; set; }

        [DalObj(Alias = "Comment")]
        public string Comment { get; set; }

        [DalObj(Alias = "UserId")]
        public Guid UserId { get; set; }

        [DalObj(Alias = "ImageUrl")]
        public string ImageUrl { get; set; }
    }

    [DalObj(Alias = "besmart.Status")]  //only dal   !!smartpoint type?!!
    public class StatusDal : IEntity<int>
    {
        [DalObj(Alias = "Id", IsPrimaryKey = true)]
        public int Id { get; set; }

        [DalObj(Alias = "UserId")]
        public Guid UserId { get; set; }

        [DalObj(Alias = "ImageUrl")]
        public string ImageUrl { get; set; }

        [DalObj(Alias = "SmartPoint")]
        public int SmartPoint { get; set; }

        [DalObj(Alias = "InterestId")]
        public int InterestId { get; set; }

        [DalObj(Alias = "Text")]
        public string Text { get; set; }
    }


    [DalObj(Alias = "besmart.UserExperienceInterest")]  //only dal   !!experience point type?!!
    public class UserExperienceInterestDal : IEntity<int>
    {
        [DalObj(Alias = "Id", IsPrimaryKey = true)]
        public int Id { get; set; }

        [DalObj(Alias = "StudentUserId")]
        public Guid StudentUserId { get; set; }

        [DalObj(Alias = "InterestId")]
        public int InterestId { get; set; }

        [DalObj(Alias = "ExperiencePoint")]
        public int ExperiencePoint { get; set; }
    }

    [DalObj(Alias = "besmart.UserInterestPoints")]  //only dal   !!experience point type?!!
    public class UserInterestPointsDal : IEntity<int>
    {
        [DalObj(Alias = "Id", IsPrimaryKey = true)]
        public int Id { get; set; }

        [DalObj(Alias = "StudentUserId")]
        public Guid StudentUserId { get; set; }

        [DalObj(Alias = "InterestId")]
        public int InterestId { get; set; }

        [DalObj(Alias = "ExperiencePoint")]
        public int ExperiencePoint { get; set; }
    }

    [DalObj(Alias = "besmart.CreatorUserInterests")]  //dal only
    public class CreatorUserInterestsDal : IEntity<int>
    {
        [DalObj(IsPrimaryKey = true, Alias = "Id")]
        public int Id { get; set; }

        [DalObj(Alias = "CreatorUserId")]
        public string CreatorUserId { get; set; }

        [DalObj(Alias = "InterestId")]
        public int InterestId { get; set; }
    }

    [DalObj(Alias = "besmart.StudentInterests")]  //dal only
    public class StudentInterestsDal : IEntity<int>
    {
        [DalObj(IsPrimaryKey = true, Alias = "Id")]
        public int Id { get; set; }

        [DalObj(Alias = "StudentUserId")]
        public Guid StudentUserId { get; set; }

        [DalObj(Alias = "InterestId")]
        public int InterestId { get; set; }
    }


    [DalObj(Alias = "besmart.OauthUsers")]  //dal only
    public class OauthUsersDal : IEntity<int>
    {
        [DalObj(IsPrimaryKey = true, Alias = "Id")]
        public int Id { get; set; }

        [DalObj(Alias = "UserId")]
        public Guid UserId { get; set; }

        [DalObj(Alias = "OauthId")]
        public int OauthId { get; set; }

        [DalObj(Alias = "Email")]
        public string Email { get; set; }
    }

}
