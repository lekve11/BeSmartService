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

}
