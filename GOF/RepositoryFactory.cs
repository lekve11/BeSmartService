using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeSmartService.DAL;

namespace BeSmartService.GOF
{
    //singletone
    public  class DefaultRepository<T,S> where T :IEntity<S>
    {
        public  IRepository<T,S> DefaultRepo { get; private set; }

        public IRepositoryProcedure<T,S> DefaultRepoWithProcedure { get; set; }

        private static DefaultRepository<T, S> _singleton;
        private  RepositoryCreator<T, S> _repoCreator;

        private DefaultRepository() {

            _repoCreator = new DapperRepositoryCreator<T, S>();

            DefaultRepo = _repoCreator.FactoryMethod();
            DefaultRepoWithProcedure = _repoCreator.FactoryMethod() as IRepositoryProcedure<T,S>;
        }

        public static DefaultRepository<T, S> GetDefaultRepo() {

            if (_singleton == null)
                _singleton = new DefaultRepository<T, S>();

            return _singleton;
        }
    }

    public abstract class RepositoryCreator<T, S> where T :IEntity<S>
    {
        public abstract IRepository<T, S> FactoryMethod();
    }

    public class DapperRepositoryCreator<T, S> : RepositoryCreator<T, S> where T :IEntity<S>
    {
        public override IRepository<T, S> FactoryMethod()
        {
            return new DapperRepository<T, S>();
        }
    }
}
