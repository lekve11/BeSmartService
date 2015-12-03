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
}

