using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BeSmartService.DTO;

namespace BeSmartService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IBeSmartService
    {
        #region GET
        [WebGet(UriTemplate ="TestCreators",ResponseFormat =WebMessageFormat.Json)]
        ResponseData<List<TestCreatorUser>> GetTestCreators();

        [WebGet(UriTemplate ="TestCreators/{userName}",ResponseFormat =WebMessageFormat.Json)]
        ResponseData<TestCreatorUser> GetTestCreatorUserById(string userName);

        [WebGet(UriTemplate = "Interest", ResponseFormat = WebMessageFormat.Json)]
        ResponseData<List<Interest>> GetInterests();

        [WebGet(UriTemplate = "Interest/{Id}", ResponseFormat = WebMessageFormat.Json)]
        ResponseData<Interest> GetInterestById(string Id);

        [WebGet(UriTemplate="Subjects",ResponseFormat =WebMessageFormat.Json)]
        ResponseData<List<Subject>> GetSubjects();

        [WebGet(UriTemplate ="Subjects/{id}",ResponseFormat =WebMessageFormat.Json)]
        ResponseData<Subject> GetSubjectById(string id);

        [WebGet(UriTemplate ="StudentUsers",ResponseFormat =WebMessageFormat.Json)]
        ResponseData<List<StudentUser>> GetStudentUsers();

        [WebGet(UriTemplate ="StudentUsers/{id}",ResponseFormat =WebMessageFormat.Json)]
        ResponseData<StudentUser> GetStudentUserById(string id);

        [WebGet(UriTemplate = "Tests", ResponseFormat = WebMessageFormat.Json)]
        ResponseData<List<Test>> GetTests();

        [WebGet(UriTemplate = "Tests/{id}", ResponseFormat = WebMessageFormat.Json)]
        ResponseData<Test> GetTestById(string id);

        [WebGet(UriTemplate = "QuestionTypes", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        ResponseData<List<QuestionType>> GetQuestionTypes();

        [WebGet(UriTemplate = "QuestionTypes/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        ResponseData<QuestionType> GetQuestionTypeById(string id);

        [WebGet(UriTemplate = "Achievements", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        ResponseData<List<Achievement>> GetAchievements();

        [WebGet(UriTemplate = "Achievements/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        ResponseData<Achievement> GetAchievementById(string id);
        #endregion

        #region PUT
        [WebInvoke(UriTemplate ="TestCreators",Method ="PUT",ResponseFormat =WebMessageFormat.Json,RequestFormat =WebMessageFormat.Json)]
        ResponseData<int> SaveTestCreatorUser(SaveTestCreatorUser savableData);

        [WebInvoke(UriTemplate = "Interest", Method = "PUT", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        ResponseData<int> SaveInterest(SaveInterest savableData);

        [WebInvoke(UriTemplate ="Subjects",Method ="PUT",ResponseFormat =WebMessageFormat.Json,RequestFormat =WebMessageFormat.Json)]
        ResponseData<int> SaveSubject(SaveSubject saveSubject);

        [WebInvoke(UriTemplate ="StudentUsers",Method="PUT",ResponseFormat =WebMessageFormat.Json,RequestFormat =WebMessageFormat.Json)]
        ResponseData<int> SaveStudentUser(SaveStudentUser saveStudentUser);

        [WebInvoke(UriTemplate = "Tests", Method = "PUT", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        ResponseData<int> SaveTest(SaveTest saveTest);

        [WebInvoke(UriTemplate = "QuestionTypes", Method = "PUT", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        ResponseData<int> SaveQuestionType(SaveQuestionType saveQuestionType);

        [WebInvoke(UriTemplate = "Achievements", Method = "PUT", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        ResponseData<int> SaveAchievement(SaveAchievement saveAchievement);
        #endregion

        #region DELETE
        [WebInvoke(UriTemplate ="TestCreators",Method ="DELETE",RequestFormat =WebMessageFormat.Json,ResponseFormat =WebMessageFormat.Json)]
        ResponseData<object> DeleteTestCreatorUser(DeleteTestCreatorUser deleteTestCreatorUser);

        [WebInvoke(UriTemplate = "Interest", Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseData<object> DeleteInterest(DeleteInterest deleteInterest);

        [WebInvoke(UriTemplate ="Subjects",Method ="DELETE",RequestFormat =WebMessageFormat.Json,ResponseFormat =WebMessageFormat.Json)]
        ResponseData<object> DeleteSubject(DeleteSubject deleteSubject);

        [WebInvoke(UriTemplate="StudentUsers",Method ="DELETE",RequestFormat =WebMessageFormat.Json,ResponseFormat =WebMessageFormat.Json)]
        ResponseData<object> DeleteStudentUser(DeleteStudentUser deleteStudentUser);

        [WebInvoke(UriTemplate = "Tests", Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseData<object> DeleteTest(DeleteTest deleteTest);

        [WebInvoke(UriTemplate = "QuestionTypes", Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseData<object> DeleteQuestionType(DeleteQuestionType deleteQuestionType);

        [WebInvoke(UriTemplate = "Achievements", Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResponseData<object> DeleteAchievement(DeleteAchievement deleteAchievement);
        #endregion
    }



}
