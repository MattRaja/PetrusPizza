using System;
using System.Threading.Tasks;
using ee.itcollege.mrajam.Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IPersonRepository : IBaseRepository<Person>, IPersonRepositoryCustom
    {
        Task<Person> GetFirstWithAllLocationsAsync(Guid id);
    }
}