using System;
using System.Threading.Tasks;
using ee.itcollege.mrajam.BLL.App.DTO;
using ee.itcollege.mrajam.Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;

namespace Contracts.BLL.App.Services
{
    public interface IPizzaSizeService : IBaseEntityService<PizzaSize>, IPizzaSizeRepositoryCustom<PizzaSize>
    {
        Task AddAndUpdateAsync(PizzaSize pizzaSize);
    }

}