using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSmartService.GOF
{
   public interface ISavableType<T>
    {
        int Save(T savableObj);
    }

    public interface IDeletableType<T>
    {
        void Delete(T deletableId);
    }

    public interface IRetrievableType<T,S>
    {
         List<T> GetAll();

        T GetById(S id);
    }
}
