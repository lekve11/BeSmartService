using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeSmartService.DTO
{
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
    public class DeleteTestCreatorUser
    {
        [DataMember]
        public string Username { get; set; }
    }


    ///// interest composite 
    [DataContract]
    public class SaveInterest
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class DeleteInterest
    {
        [DataMember]
        public int Id { get; set; }
    }


    // Subjects Composites
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
    public class DeleteSubject
    {
        [DataMember]
        public int Id { get; set; }
    }
}
