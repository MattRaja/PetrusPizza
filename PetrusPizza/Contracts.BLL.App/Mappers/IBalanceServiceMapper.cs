using ee.itcollege.mrajam.Contracts.BLL.Base.Mappers;
using BLLAppDTO=ee.itcollege.mrajam.BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;

namespace Contracts.BLL.App.Mappers
{
    public interface IBalanceServiceMapper : IBaseMapper<DALAppDTO.Balance, BLLAppDTO.Balance>
    {
        BLLAppDTO.Balance MapBalanceView(DALAppDTO.Balance inObject);
    }
}