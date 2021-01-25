using System;
using Contracts.BLL.App.Services;
using ee.itcollege.mrajam.Contracts.BLL.Base;

namespace Contracts.BLL.App
{
    public interface IAppBLL : IBaseBLL
    {
        IAppUserService AppUsers { get; }
        IBalanceService Balances { get; }
        IExtraToppingsOnItemService ExtraToppingsOnItems { get; }
        IDefaultToppingService DefaultToppings { get; }
        IItemRowService ItemRows { get; }
        ILangStrService LangStrs { get; }
        ILangStrTranslationService LangStrTranslations { get; }

        IOrderService Orders  { get; }
        IOrderRowService OrderRows  { get; }
        //IPaymentMethodService PaymentMethods  { get; }
        IPaymentService Payments { get; }
        IPersonService Persons  { get; }
        IPizzaNameService PizzaNames  { get; }
        IPizzaOrderService PizzaOrders { get; }
        IPizzaSizeService PizzaSizes  { get; }
        IPizzaTypeService PizzaTypes { get; }
        IToppingService Toppings { get; }
    }
}