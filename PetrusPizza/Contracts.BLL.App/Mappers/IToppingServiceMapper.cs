using ee.itcollege.mrajam.Contracts.BLL.Base.Mappers;
using BLLAppDTO=ee.itcollege.mrajam.BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;

namespace Contracts.BLL.App.Mappers
{
    public interface IToppingServiceMapper : IBaseMapper<DALAppDTO.Topping, BLLAppDTO.Topping>
    {
        BLLAppDTO.Topping MapToppingView(DALAppDTO.Topping inObject);
    }
}