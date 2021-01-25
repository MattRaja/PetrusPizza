using System;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Repositories;
using ee.itcollege.mrajam.DAL.Base.EF;
using ee.itcollege.mrajam.DAL.Base.EF;

namespace DAL.App.EF
{
    public class AppUnitOfWork : EFBaseUnitOfWork<Guid, AppDbContext>, IAppUnitOfWork
    {
        public AppUnitOfWork(AppDbContext uowDbContext) : base(uowDbContext)
        {
        }

        public IAppUserRepository AppUsers =>
            GetRepository<IAppUserRepository>(() => new AppUserRepository(UOWDbContext));
        public IBalanceRepository Balances => 
            GetRepository<IBalanceRepository>(() => new BalanceRepository(UOWDbContext));
        public IExtraToppingsOnItemRepository ExtraToppingsOnItems =>
            GetRepository<IExtraToppingsOnItemRepository>(() => new ExtraToppingsOnItemRepository(UOWDbContext));
        public IDefaultToppingRepository DefaultToppings =>
            GetRepository<IDefaultToppingRepository>(() => new DefaultToppingRepository(UOWDbContext));
        public IItemRowRepository ItemRows =>
            GetRepository<IItemRowRepository>(() => new ItemRowRepository(UOWDbContext));
        public IOrderRepository Orders =>
            GetRepository<IOrderRepository>(() => new OrderRepository(UOWDbContext));
        public IOrderRowRepository OrderRows =>
            GetRepository<IOrderRowRepository>(() => new OrderRowRepository(UOWDbContext));
        //public IPaymentMethodRepository PaymentMethods =>
            //GetRepository<IPaymentMethodRepository>(() => new PaymentMethodRepository(UOWDbContext));
        public IPaymentRepository Payments =>
            GetRepository<IPaymentRepository>(() => new PaymentRepository(UOWDbContext));
        public IPersonRepository Persons =>
            GetRepository<IPersonRepository>(() => new PersonRepository(UOWDbContext));
        public IPizzaNameRepository PizzaNames =>
            GetRepository<IPizzaNameRepository>(() => new PizzaNameRepository(UOWDbContext));
        public IPizzaOrderRepository PizzaOrders =>
            GetRepository<IPizzaOrderRepository>(() => new PizzaOrderRepository(UOWDbContext));
        public IPizzaSizeRepository PizzaSizes =>
            GetRepository<IPizzaSizeRepository>(() => new PizzaSizeRepository(UOWDbContext));
        public IPizzaTypeRepository PizzaTypes =>
            GetRepository<IPizzaTypeRepository>(() => new PizzaTypeRepository(UOWDbContext));
        public IToppingRepository Toppings =>
            GetRepository<IToppingRepository>(() => new ToppingRepository(UOWDbContext));
        public ILangStrRepository LangStrs =>
            GetRepository<ILangStrRepository>(() => new LangStrRepository(UOWDbContext));

        public ILangStrTranslationRepository LangStrTranslations =>
            GetRepository<ILangStrTranslationRepository>(() => new LangStrTranslationRepository(UOWDbContext));

    }
}