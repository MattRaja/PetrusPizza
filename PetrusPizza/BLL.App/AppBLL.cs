using System;
using System.Threading.Tasks;
using BLL.App.Services;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.mrajam.BLL.Base;

namespace BLL.App
{
    public class AppBLL : BaseBLL<IAppUnitOfWork>, IAppBLL
    {
        public AppBLL(IAppUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public IAppUserService AppUsers =>
            GetService<IAppUserService>(() => new AppUserService(UnitOfWork));
        public IBalanceService Balances => 
            GetService<IBalanceService>(() => new BalanceService(UnitOfWork));
        public IExtraToppingsOnItemService ExtraToppingsOnItems =>
            GetService<IExtraToppingsOnItemService>(() => new ExtraToppingsOnItemService(UnitOfWork));
        public IDefaultToppingService DefaultToppings =>
            GetService<IDefaultToppingService>(() => new DefaultToppingService(UnitOfWork));
        public IItemRowService ItemRows =>
            GetService<IItemRowService>(() => new ItemRowService(UnitOfWork));
        public ILangStrService LangStrs =>
            GetService<ILangStrService>(() => new LangStrService(UnitOfWork));
        public ILangStrTranslationService LangStrTranslations =>
            GetService<ILangStrTranslationService>(() => new LangStrTranslationService(UnitOfWork));
        public IOrderService Orders =>
            GetService<IOrderService>(() => new OrderService(UnitOfWork));
        public IOrderRowService OrderRows =>
            GetService<IOrderRowService>(() => new OrderRowService(UnitOfWork));


        // public IPaymentMethodService PaymentMethods =>
        //     GetService<IPaymentMethodService>(() => new PaymentMethodService(UnitOfWork));
        public IPaymentService Payments =>
            GetService<IPaymentService>(() => new PaymentService(UnitOfWork));
        public IPersonService Persons =>
            GetService<IPersonService>(() => new PersonService(UnitOfWork));
        public IPizzaNameService PizzaNames =>
            GetService<IPizzaNameService>(() => new PizzaNameService(UnitOfWork));
        public IPizzaOrderService PizzaOrders =>
            GetService<IPizzaOrderService>(() => new PizzaOrderService(UnitOfWork));
        public IPizzaSizeService PizzaSizes =>
            GetService<IPizzaSizeService>(() => new PizzaSizeService(UnitOfWork));
        public IPizzaTypeService PizzaTypes =>
            GetService<IPizzaTypeService>(() => new PizzaTypeService(UnitOfWork));
        public IToppingService Toppings =>
            GetService<IToppingService>(() => new ToppingService(UnitOfWork));
    
    }
}