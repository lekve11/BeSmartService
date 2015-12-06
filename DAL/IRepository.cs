using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSmartService.DAL
{
    public interface IRepository<T,S> where T :IEntity<S>
    {
        IEnumerable<T> GetAll();

        T GetById(S id);

        void Delete(S objId);

        int Insert(T obj);

        void Update(T obj);
    }

    public interface IRepositoryProcedure<T,S>:IRepository<T,S> where T : IEntity<S>
    {
        K CallProcedure<K>(string name, Dictionary<string, object> argumentDict);
    }
}
