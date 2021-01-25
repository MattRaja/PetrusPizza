using ee.itcollege.mrajam.Contracts.BLL.Base.Mappers;
using BLLAppDTO=ee.itcollege.mrajam.BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;

namespace Contracts.BLL.App.Mappers
{
    public interface IPaymentServiceMapper : IBaseMapper<DALAppDTO.Payment, BLLAppDTO.Payment>
    {
        BLLAppDTO.Payment MapPaymentView(DALAppDTO.Payment inObject);
    }
}