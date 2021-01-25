using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.mrajam.Contracts.BLL.Base;
using ee.itcollege.mrajam.Contracts.DAL.Base;

namespace ee.itcollege.mrajam.BLL.Base
{
    public abstract class BaseBLL<TUnitOfWork> : IBaseBLL
        where TUnitOfWork: IBaseUnitOfWork
    {

        protected readonly TUnitOfWork UnitOfWork;
        
        private readonly Dictionary<Type, object> _serviceCache = new Dictionary<Type, object>();
        
        public BaseBLL(TUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        
        public Task<int> SaveChangesAsync()
        {
            return UnitOfWork.SaveChangesAsync();
        }

        // public int SaveChanges()
        // {
        //     return UnitOfWork.SaveChanges();
        // }
        //
        private readonly Dictionary<Type, object> _repoCache = new Dictionary<Type, object>();

        public TService GetService<TService>(Func<TService> serviceCreationMethod) where TService : class
        {
            if (_serviceCache.TryGetValue(typeof(TService), out var repo))
            {
                return (TService) repo;
            }

            var newRepoInstance = serviceCreationMethod();
            _serviceCache.Add(typeof(TService), newRepoInstance);
            return newRepoInstance;
        }

    }
}