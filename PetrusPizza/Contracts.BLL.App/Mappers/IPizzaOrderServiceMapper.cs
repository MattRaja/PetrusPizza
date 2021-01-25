using ee.itcollege.mrajam.Contracts.BLL.Base.Mappers;
using BLLAppDTO=ee.itcollege.mrajam.BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;

namespace Contracts.BLL.App.Mappers
{
    public interface IPizzaOrderServiceMapper : IBaseMapper<DALAppDTO.PizzaOrder, BLLAppDTO.PizzaOrder>
    {
        BLLAppDTO.PizzaOrder MapPizzaOrderView(DALAppDTO.PizzaOrder inObject);
    }
}