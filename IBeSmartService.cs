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
        #endregion
    }



}
