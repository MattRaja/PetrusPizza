using ee.itcollege.mrajam.Contracts.BLL.Base.Mappers;
using BLLAppDTO=ee.itcollege.mrajam.BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;

namespace Contracts.BLL.App.Mappers
{
    public interface IPersonServiceMapper : IBaseMapper<DALAppDTO.Person, BLLAppDTO.Person>
    {
        BLLAppDTO.Person MapPersonView(DALAppDTO.Person inObject);
    }
}