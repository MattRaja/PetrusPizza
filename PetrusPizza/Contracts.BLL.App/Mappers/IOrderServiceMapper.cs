using ee.itcollege.mrajam.Contracts.BLL.Base.Mappers;
using BLLAppDTO=ee.itcollege.mrajam.BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;

namespace Contracts.BLL.App.Mappers
{
    public interface IOrderServiceMapper : IBaseMapper<DALAppDTO.Order, BLLAppDTO.Order>
    {
        BLLAppDTO.Order MapOrderView(DALAppDTO.Order inObject);
    }
}