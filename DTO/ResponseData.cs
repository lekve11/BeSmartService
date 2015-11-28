using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeSmartService.DTO
{
    public interface IResponableData<T>
    {
        T Data {get; set; }

        string Message { get; set; }

        bool IsError { get; set; }
    }

    [DataContract]
    public class ResponseData<T>:IResponableData<T>
    {
        [DataMember]
        public T Data { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public bool IsError { get; set; }
    }

    
}
