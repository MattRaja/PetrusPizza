using System;
using System.Threading.Tasks;
using ee.itcollege.mrajam.Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IPizzaOrderRepository : IBaseRepository<PizzaOrder>, IPizzaOrderRepositoryCustom
    {
        Task<PizzaOrder> GetFirstWithAllLocationsAsync(Guid id);
    }
}