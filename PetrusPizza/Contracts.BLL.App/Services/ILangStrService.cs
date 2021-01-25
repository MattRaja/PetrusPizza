using Contracts.DAL.App.Repositories;
using ee.itcollege.mrajam.BLL.App.DTO;
using ee.itcollege.mrajam.Contracts.BLL.Base.Services;

namespace Contracts.BLL.App.Services
{
    public interface ILangStrService : IBaseEntityService<LangStr>, ILangStrRepositoryCustom<LangStr>
    {
        
    }
}