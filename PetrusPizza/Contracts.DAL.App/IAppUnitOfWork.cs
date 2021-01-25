using Contracts.DAL.App.Repositories;
using ee.itcollege.mrajam.Contracts.DAL.Base;
using ee.itcollege.mrajam.Contracts.DAL.Base;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IBaseUnitOfWork, IBaseEntityTracker
    {
        IAppUserRepository AppUsers { get; }
        IBalanceRepository Balances { get; }
        IExtraToppingsOnItemRepository ExtraToppingsOnItems { get; }
        IDefaultToppingRepository DefaultToppings { get; }
        IItemRowRepository ItemRows { get; }
        ILangStrRepository LangStrs { get; }
        ILangStrTranslationRepository LangStrTranslations { get; }
        IOrderRepository Orders { get; }
        IOrderRowRepository OrderRows { get; }
        //IPaymentMethodRepository PaymentMethods { get; }
        IPaymentRepository Payments { get; }
        IPersonRepository Persons { get; }
        IPizzaNameRepository PizzaNames { get; }
        IPizzaOrderRepository PizzaOrders { get; }
        IPizzaSizeRepository PizzaSizes { get; }
        IPizzaTypeRepository PizzaTypes { get; }
        IToppingRepository Toppings { get; }
    }
}