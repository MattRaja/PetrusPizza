using System;
using System.Threading.Tasks;
using ee.itcollege.mrajam.BLL.App.DTO;
using ee.itcollege.mrajam.Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using PublicApi.DTO.v1;

namespace Contracts.BLL.App.Services
{
    public interface IDefaultToppingService : IBaseEntityService<DefaultTopping>, IDefaultToppingRepositoryCustom<DefaultTopping>
    {
        Task AddAndUpdateAsync(DefaultTopping balance);
        Task UpdateAsync(DefaultTopping balance);
        Task UpdateAsync(Topping defaultToppingIds);
        Task AddAndUpdateAsync(PizzaNameCreateEditDTO pizzaName, Topping topping);
    }

}