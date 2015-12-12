using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeSmartService.DTO
{
    public interface IDTO<T>
    {

        T Id { get; set; }
    }

    [DataContract]
    public class TestCreatorUser : IDTO<string>
    {
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Organization { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string WebSite { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string MobileNumber { get; set; }

        [DataMember]
        public string ImgUrl { get; set; }

        [DataMember(Name = "UserName")]
        public string Id
        {
            get; set;
        }
    }

    [DataContract]
    public class Interest : IDTO<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class Subject : IDTO<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Interest Interest { get; set; }
    }

    [DataContract]
    public class StudentUser : IDTO<Guid>
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }
    }

    [DataContract]
    public class Test : IDTO<int>
    {
        [DataMember]
        public int Id { get; set; }


        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime PublishDate { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public int DownloadCount { get; set; }

        [DataMember]
        public Subject Subject { get; set; }

        [DataMember]
        public string Comment { get; set; }

        [DataMember]
        public TestCreatorUser TestCreator { get; set; }
    }
    [DataContract]
    public class QuestionType : IDTO<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class Achievement : IDTO<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class TestRank : IDTO<int>
    {
        [DataMember]
        public int Id
        {
            get; set;
        }

        [DataMember]
        public int TestId { get; set; }
        
        [DataMember]
        public byte Rank { get; set; }
    }


    /////////////////////////////////////////////////////////DTO for dals

    [DataContract]
    public class TestQuestions : IDTO<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Question { get; set; }

        [DataMember]
        public string ImgUrl { get; set; }

        [DataMember]
        public Test Test { get; set; }

        [DataMember]
        public QuestionType QuestionType { get; set; }
    }

    [DataContract]
    public class StudentUserAchievement : IDTO<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public StudentUser StudentUser { get; set; }

        [DataMember]
        public Achievement Achievement { get; set; }

        [DataMember]
        public DateTime DateAchieved { get; set; }

        [DataMember]
        public bool IsSeenByUser { get; set; }
    }

    [DataContract]
    public class QuestionAnswer : IDTO<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Answer { get; set; }

        [DataMember]
        public TestQuestions TestQuestions { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }

        [DataMember]
        public int AnswerIndex { get; set; }
    }

    [DataContract]
    public class StudentTests : IDTO<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Test Test { get; set; }

        [DataMember]
        public StudentUser StudentUser { get; set; }

        [DataMember]
        public bool IsCompleted { get; set; }
    }

    [DataContract]
    public class StatusComment : IDTO<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Status Status { get; set; }

        [DataMember]
        public string Comment { get; set; }

        [DataMember]
        public StudentUser StudentUser { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }
    }

    [DataContract]
    public class Status : IDTO<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public StudentUser StudentUser { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }

        [DataMember]
        public int SmartPoint { get; set; }

        [DataMember]
        public Interest Interest { get; set; }

        [DataMember]
        public string Text { get; set; }
    }


    [DataContract]
    public class UserExperienceInterest : IDTO<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public StudentUser StudentUser { get; set; }

        [DataMember]
        public Interest Interest { get; set; }

        [DataMember]
        public int ExperiencePoint { get; set; }
    }

    [DataContract]
    public class UserInterestPoints : IDTO<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public StudentUser StudentUser { get; set; }

        [DataMember]
        public Interest Interest { get; set; }

        [DataMember]
        public int ExperiencePoint { get; set; }
    }

    [DataContract]
    public class CreatorUserInterests : IDTO<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public TestCreatorUser TestCreatorUser { get; set; }

        [DataMember]
        public Interest Interest { get; set; }
    }

    [DataContract]
    public class StudentInterests : IDTO<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public StudentUser StudentUser { get; set; }

        [DataMember]
        public Interest Interest { get; set; }
    }


    [DataContract]
    public class OauthUsers : IDTO<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public StudentUser StudentUser { get; set; }

        [DataMember]
        public int OauthId { get; set; }

        [DataMember]
        public string Email { get; set; }
    }
}

