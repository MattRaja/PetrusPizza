using ee.itcollege.mrajam.Contracts.BLL.Base.Mappers;
using BLLAppDTO=ee.itcollege.mrajam.BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;

namespace Contracts.BLL.App.Mappers
{
    public interface IPizzaNameServiceMapper : IBaseMapper<DALAppDTO.PizzaName, BLLAppDTO.PizzaName>
    {
        BLLAppDTO.PizzaName MapPizzaNameView(DALAppDTO.PizzaName inObject);
        BLLAppDTO.Topping MapToppings(DALAppDTO.Topping inObject);
    }
}