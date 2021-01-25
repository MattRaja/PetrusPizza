using ee.itcollege.mrajam.Contracts.BLL.Base.Mappers;
using ee.itcollege.mrajam.Contracts.BLL.Base.Mappers;
using BLLAppDTO=ee.itcollege.mrajam.BLL.App.DTO.Identity;
using DALAppDTO=DAL.App.DTO.Identity;

namespace Contracts.BLL.App.Mappers
{
    public interface IAppUserServiceMapper : IBaseMapper<DALAppDTO.AppUser, BLLAppDTO.AppUser>
    {
        BLLAppDTO.AppUser MapAppUserView(DALAppDTO.AppUser inObject);
    }
}