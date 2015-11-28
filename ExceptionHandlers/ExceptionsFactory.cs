using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeSmartService.DTO;

namespace BeSmartService.ExceptionHandlers
{
  public class ExceptionHandlerFactory
    {
        private ExceptionHandlerFactory() { }

        private static ExceptionHandlerFactory _factory;

        public static ExceptionHandlerFactory Factory { get
            {
                if (_factory == null)
                    _factory = new ExceptionHandlerFactory();

                return _factory;
            } }

        public ResponseExceptionHandler<T> GetResponseExceptionHandler<T>(IResponableData<T> responsableData)
        {
            return new ResponseExceptionHandler<T>(responsableData);
        }
    }
}
