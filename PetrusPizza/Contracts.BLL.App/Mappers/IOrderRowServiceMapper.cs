using ee.itcollege.mrajam.Contracts.BLL.Base.Mappers;
using BLLAppDTO=ee.itcollege.mrajam.BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;

namespace Contracts.BLL.App.Mappers
{
    public interface IOrderRowServiceMapper : IBaseMapper<DALAppDTO.OrderRow, BLLAppDTO.OrderRow>
    {
        BLLAppDTO.OrderRow MapOrderRowView(DALAppDTO.OrderRow inObject);
    }
}