using System;
using ee.itcollege.mrajam.BLL.App.DTO;

namespace PublicApi.DTO.v1.Mappers
{
    public class DTOMapper
    {
        /*
        public BalanceCreate MapBalanceCreate(ee.itcollege.mrajam.BLL.App.DTO.Balance BLLBalance)
        {
            
        }
        
        public BalanceEdit MapBalanceEdit(ee.itcollege.mrajam.BLL.App.DTO.Balance BLLBalance)
        {
            
        }
        */
        
        public Balance MapBalance(ee.itcollege.mrajam.BLL.App.DTO.Balance BLLBalance)
        {
            return new Balance()
            {
                Id = BLLBalance.Id,
                Payment = BLLBalance.Payment,
                Person = BLLBalance.Person,
                AppUser = BLLBalance.AppUser,
            }; 
        }
        
        public ExtraToppingsOnItem MapExtraToppingsOnItem(ee.itcollege.mrajam.BLL.App.DTO.ExtraToppingsOnItem BLLExtraToppingsOnItem)
        {
            return new ExtraToppingsOnItem()
            {
                Id = BLLExtraToppingsOnItem.Id,
                Price = BLLExtraToppingsOnItem.Price,
                ToppingName = BLLExtraToppingsOnItem.ToppingName,
                AppUser = BLLExtraToppingsOnItem.AppUser
            }; 
        }
        
        public ItemRow MapItemRow(ee.itcollege.mrajam.BLL.App.DTO.ItemRow BLLItemRow)
        {
            return new ItemRow()
            {
                Id = BLLItemRow.Id,
                Amount = BLLItemRow.Amount,
                OrderRows = BLLItemRow.OrderRows,
                AppUser = BLLItemRow.AppUser
            }; 
        }
        
        public Order MapOrder(ee.itcollege.mrajam.BLL.App.DTO.Order BLLOrder)
        {
            return new Order()
            {
                Id = BLLOrder.Id,
                SumWithoutVAT = BLLOrder.SumWithoutVAT,
                SumWithVAT = BLLOrder.SumWithVAT,
                OrderDate = BLLOrder.OrderDate,
                OrderNr = BLLOrder.OrderNr,
                AppUserOrder = BLLOrder.AppUserOrder,
                OrderRows = BLLOrder.OrderRows,
                AppUser = BLLOrder.AppUser
            }; 
        }
        
        public OrderRow MapOrderRow(ee.itcollege.mrajam.BLL.App.DTO.OrderRow BLLOrderRow)
        {
            return new OrderRow()
            {
                Id = BLLOrderRow.Id,
                Price = BLLOrderRow.Price,
                VAT = BLLOrderRow.VAT,
                SumWithVAT = BLLOrderRow.SumWithVAT,
                Sum = BLLOrderRow.Sum,
            }; 
        }
        
        public Payment MapPayment(ee.itcollege.mrajam.BLL.App.DTO.Payment BLLPayment)
        {
            return new Payment()
            {
                Id = BLLPayment.Id,
                PaymentAmount = BLLPayment.PaymentAmount,
                PaymentDate = BLLPayment.PaymentDate,
                OrderPayment = BLLPayment.OrderPayment,
                //PaymentMethodName = BLLPayment.PaymentMethodName,
                Balances = BLLPayment.Balances,
                AppUser = BLLPayment.AppUser
            }; 
        }
        
        public PaymentMethod MapPaymentMethod(ee.itcollege.mrajam.BLL.App.DTO.PaymentMethod BLLPaymentMethod)
        {
            return new PaymentMethod()
            {
                Id = BLLPaymentMethod.Id,
                PaymentMethodName = BLLPaymentMethod.PaymentMethodName,
                AppUser = BLLPaymentMethod.AppUser
            }; 
        }
        
        public Person MapPerson(ee.itcollege.mrajam.BLL.App.DTO.Person BLLPerson)
        {
            return new Person()
            {
                Id = BLLPerson.Id,
                FirstName = BLLPerson.FirstName,
                LastName = BLLPerson.LastName,
                AppUser = BLLPerson.AppUser,
                Balances = BLLPerson.Balances
            }; 
        }
        
        public PizzaName MapPizzaName(ee.itcollege.mrajam.BLL.App.DTO.PizzaName BLLPizzaName)
        {
            return new PizzaName()
            {
                Id = BLLPizzaName.Id,
                Price = BLLPizzaName.Price,
                //PizzaOrders = BLLPizzaName.PizzaOrders,
                NameOfPizza = BLLPizzaName.NameOfPizza,
                AppUser = BLLPizzaName.AppUser
            }; 
        }
        
        public PizzaSize MapPizzaSize(ee.itcollege.mrajam.BLL.App.DTO.PizzaSize BLLPizzaSize)
        {
            return new PizzaSize()
            {
                Id = BLLPizzaSize.Id,
                Price = BLLPizzaSize.Price,
                PizzaOrders = BLLPizzaSize.PizzaOrders,
                PizzaSizeName = BLLPizzaSize.PizzaSizeName,
                AppUser = BLLPizzaSize.AppUser
            }; 
        }
        
        public PizzaOrder MapPizzaOrder(ee.itcollege.mrajam.BLL.App.DTO.PizzaOrder BLLPizzaOrder)
        {
            return new PizzaOrder()
            {
                Id = BLLPizzaOrder.Id,
                Price = BLLPizzaOrder.Price,
                ItemRows = BLLPizzaOrder.ItemRows,
                PizzaName = BLLPizzaOrder.PizzaName,
                PizzaSize = BLLPizzaOrder.PizzaSize,
                PizzaType = BLLPizzaOrder.PizzaType,
                AppUser = BLLPizzaOrder.AppUser
            }; 
        }
        
        public PizzaType MapPizzaType(ee.itcollege.mrajam.BLL.App.DTO.PizzaType BLLPizzaType)
        {
            return new PizzaType()
            {
                Id = BLLPizzaType.Id,
                Price = BLLPizzaType.Price,
                PizzaOrders = BLLPizzaType.PizzaOrders,
                PizzaTypeName = BLLPizzaType.PizzaTypeName,
                AppUser = BLLPizzaType.AppUser
            }; 
        }
        
        public Topping MapTopping(ee.itcollege.mrajam.BLL.App.DTO.Topping BLLTopping)
        {
            return new Topping()
            {
                Id = BLLTopping.Id,
                Price = BLLTopping.Price,
                ToppingName = BLLTopping.ToppingName,
                ExtraToppingsOnItems = BLLTopping.ExtraToppingsOnItems,
                AppUser = BLLTopping.AppUser
            }; 
        }
        
    }
}