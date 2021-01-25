using ee.itcollege.mrajam.Contracts.BLL.Base.Mappers;
using BLLAppDTO=ee.itcollege.mrajam.BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;

namespace Contracts.BLL.App.Mappers
{
    public interface IItemRowServiceMapper : IBaseMapper<DALAppDTO.ItemRow, BLLAppDTO.ItemRow>
    {
        BLLAppDTO.ItemRow MapItemRowView(DALAppDTO.ItemRow inObject);
    }
}