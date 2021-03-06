using ee.itcollege.mrajam.Contracts.BLL.Base.Mappers;
using BLLAppDTO=ee.itcollege.mrajam.BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;

namespace Contracts.BLL.App.Mappers
{
    public interface IPizzaSizeServiceMapper : IBaseMapper<DALAppDTO.PizzaSize, BLLAppDTO.PizzaSize>
    {
        BLLAppDTO.PizzaSize MapPizzaSizeView(DALAppDTO.PizzaSize inObject);
    }
}