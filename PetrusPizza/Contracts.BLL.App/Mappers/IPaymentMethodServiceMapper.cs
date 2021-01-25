using ee.itcollege.mrajam.Contracts.BLL.Base.Mappers;
using BLLAppDTO=ee.itcollege.mrajam.BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;

namespace Contracts.BLL.App.Mappers
{
    public interface IPaymentMethodServiceMapper : IBaseMapper<DALAppDTO.PaymentMethod, BLLAppDTO.PaymentMethod>
    {
        BLLAppDTO.PaymentMethod MapPaymentMethodView(DALAppDTO.PaymentMethod inObject);
    }
}