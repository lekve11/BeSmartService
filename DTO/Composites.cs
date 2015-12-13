using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeSmartService.DTO
{
    #region Save
    [DataContract]
    public class SaveTestCreatorUser
    {
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }

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
    }

   
    [DataContract]
    public class SaveInterest
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class SaveSubject
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int InterestId { get; set; }
    }

    [DataContract]
    public class SaveStudentUser
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Password { get; set; }

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
    public class SaveTest
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
        public int SubjectId { get; set; }

        [DataMember]
        public string Comment { get; set; }

        [DataMember]
        public string CreatorId { get; set; }
    }

    [DataContract]
    public class SaveQuestionType
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class SaveAchievement
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class SaveTestRank
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int TestId { get; set; }

        [DataMember]
        public Guid StudentUserId { get; set; }

        [DataMember]
        public byte Rank { get; set; }
    }

    [DataContract]
    public class SaveTestQuestions
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Question { get; set; }

        [DataMember]
        public string ImgUrl { get; set; }

        [DataMember]
        public int TestId { get; set; }

        [DataMember]
        public int QuestionTypeId { get; set; }
    }

    [DataContract]
    public class SaveStudentUserAchievement
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Guid StudentUserId { get; set; }

        [DataMember]
        public int AchievementId { get; set; }

        [DataMember]
        public DateTime DateAchieved { get; set; }

        [DataMember]
        public bool IsSeenByUser { get; set; }
    }

    [DataContract]
    public class SaveQuestionAnswer
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Answer { get; set; }

        [DataMember]
        public int TestQuestionsId { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }

        [DataMember]
        public int AnswerIndex { get; set; }
    }

    [DataContract]
    public class SaveStudentTests
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int TestId { get; set; }

        [DataMember]
        public Guid StudentUserId { get; set; }

        [DataMember]
        public bool IsCompleted { get; set; }
    }

    [DataContract]
    public class SaveStatusComment
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int StatusId { get; set; }

        [DataMember]
        public string Comment { get; set; }

        [DataMember]
        public Guid StudentUserId { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }
    }

    [DataContract]
    public class SaveStatus
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Guid StudentUserId { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }

        [DataMember]
        public int SmartPoint { get; set; }

        [DataMember]
        public int InterestId { get; set; }

        [DataMember]
        public string Text { get; set; }
    }


    [DataContract]
    public class SaveUserExperienceInterest
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Guid StudentUserId { get; set; }

        [DataMember]
        public int InterestId { get; set; }

        [DataMember]
        public int ExperiencePoint { get; set; }
    }

    [DataContract]
    public class SaveUserInterestPoints
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Guid StudentUserId { get; set; }

        [DataMember]
        public int InterestId { get; set; }

        [DataMember]
        public int ExperiencePoint { get; set; }
    }

    [DataContract]
    public class SaveCreatorUserInterests
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string TestCreatorUserId { get; set; }

        [DataMember]
        public int InterestId { get; set; }
    }

    [DataContract]
    public class SaveStudentInterests
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Guid StudentUserId { get; set; }

        [DataMember]
        public int InterestId { get; set; }
    }


    [DataContract]
    public class SaveOauthUsers
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Guid StudentUserId { get; set; }

        [DataMember]
        public int OauthId { get; set; }

        [DataMember]
        public string Email { get; set; }
    }

    [DataContract]
    public class SaveTestDownload
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Guid StudentUserId { get; set; }

        [DataMember]
        public int TestId { get; set; }

        [DataMember]
        public DateTime DownloadDate { get; set; }
    }

    #endregion




    /// <summary>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>


    #region Delete
    [DataContract]
    public class DeleteInterest
    {
        [DataMember]
        public int Id { get; set; }
    }
    
    [DataContract]
    public class DeleteSubject
    {
        [DataMember]
        public int Id { get; set; }
    }

    [DataContract]
    public class DeleteTestCreatorUser
    {
        [DataMember]
        public string Username { get; set; }
    }

    [DataContract]
    public class DeleteStudentUser
    {
        [DataMember]
        public Guid Id { get; set; }
    }

    [DataContract]
    public class DeleteTest
    {
        [DataMember]
        public int Id { get; set; }
    }

    [DataContract]
    public class DeleteQuestionType
    {
        [DataMember]
        public int Id { get; set; }
    }

    [DataContract]
    public class DeleteAchievement
    {
        [DataMember]
        public int Id { get; set; }
    }

    [DataContract]
    public class DeleteTestQuestions
    {
        [DataMember]
        public int Id { get; set; }
    }

    [DataContract]
    public class DeleteStudentUserAchievement
    {
        [DataMember]
        public int Id { get; set; }
    }

    [DataContract]
    public class DeleteQuestionAnswer
    {
        [DataMember]
        public int Id { get; set; }
    }

    [DataContract]
    public class DeleteStudentTests
    {
        [DataMember]
        public int Id { get; set; }
    }

    [DataContract]
    public class DeleteStatusComment
    {
        [DataMember]
        public int Id { get; set; }
    }

    [DataContract]
    public class DeleteStatus
    {
        [DataMember]
        public int Id { get; set; }
    }


    [DataContract]
    public class DeleteUserExperienceInterest
    {
        [DataMember]
        public int Id { get; set; }
    }

    [DataContract]
    public class DeleteUserInterestPoints
    {
        [DataMember]
        public int Id { get; set; }
    }

    [DataContract]
    public class DeleteCreatorUserInterests
    {
        [DataMember]
        public int Id { get; set; }
    }

    [DataContract]
    public class DeleteStudentInterests
    {
        [DataMember]
        public int Id { get; set; }
    }


    [DataContract]
    public class DeleteOauthUsers
    {
        [DataMember]
        public int Id { get; set; }
    }
    #endregion
}
