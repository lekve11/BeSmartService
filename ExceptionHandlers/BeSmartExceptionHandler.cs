using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeSmartService.DTO;
using System.Data.SqlClient;
using log4net;
using BeSmartService.GOF;

namespace BeSmartService.ExceptionHandlers
{
    public abstract class BeSmartExceptionHandler
    {
        protected readonly ILog logger = LogManager.GetLogger("BeSmartService");

        public abstract void Handle(Exception ex);
    }

    public class ResponseExceptionHandler<T> : BeSmartExceptionHandler
    {
        IResponableData<T> _response;

        IList<IExceptionValidator> _exceptionValidators;

        public ResponseExceptionHandler(IResponableData<T> responseData)
        {
            _response = responseData;

            _exceptionValidators = new List<IExceptionValidator>()
            {
                new SQLEntityDeleteValidator()
            };
        }

        public override void Handle(Exception ex)
        {
            _response.IsError = true;
            logger.Error(ex.Message);


            foreach (var validator in _exceptionValidators)
            {
                if (validator.Validate(ex))
                {
                    _response.Message = validator.Message;
                    return;
                }
                    
            }

            _response.Message = ex.Message;
            
        }
    }
}
