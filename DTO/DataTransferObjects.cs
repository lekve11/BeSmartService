using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeSmartService.DTO
{
    [DataContract]
    public class TestCreatorUser
    {
        [DataMember]
        public string UserName { get; set; }

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
    public class Interest
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class Subject
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Interest Interest { get; set; }
    }
}
