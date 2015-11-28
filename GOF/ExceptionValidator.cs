using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BeSmartService.GOF
{
    public interface IExceptionValidator
    {
        bool Validate(Exception ex);

        string Message { get;}
    }

    public class SQLEntityDeleteValidator:IExceptionValidator
    {
        public  bool Validate(Exception ex)
        {
            if (!(ex is SqlException))
                return false;

            SqlException sqlException = ex as SqlException;

            if(sqlException.Errors[0].Number==547)
            {
                Message = "არ შ ეგიძლება მოცემული ინფორმაციის წაშლა რადგან სხვა ადგილასაა გამოყენებული";
                return true;

            }

            return false;
        }


        public string Message { get; private set; }
    }
}