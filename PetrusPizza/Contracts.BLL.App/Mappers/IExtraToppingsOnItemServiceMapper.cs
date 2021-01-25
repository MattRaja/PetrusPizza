using ee.itcollege.mrajam.Contracts.BLL.Base.Mappers;
using BLLAppDTO=ee.itcollege.mrajam.BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;

namespace Contracts.BLL.App.Mappers
{
    public interface IExtraToppingsOnItemServiceMapper : IBaseMapper<DALAppDTO.ExtraToppingsOnItem, BLLAppDTO.ExtraToppingsOnItem>
    {
        BLLAppDTO.ExtraToppingsOnItem MapExtraToppingsOnItemView(DALAppDTO.ExtraToppingsOnItem inObject);
    }
}