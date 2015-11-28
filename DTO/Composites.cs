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

    #endregion

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

    #endregion
}
