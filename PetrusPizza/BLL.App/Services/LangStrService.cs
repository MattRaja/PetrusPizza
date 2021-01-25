using BLL.App.Mappers;
using ee.itcollege.mrajam.BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.EF;
using ee.itcollege.mrajam.BLL.App.DTO;

namespace BLL.App.Services
{
    public class LangStrService :
        BaseEntityService<IAppUnitOfWork, ILangStrRepository, ILangStrServiceMapper,
            DAL.App.DTO.LangStr, LangStr>, ILangStrService
    {
        public LangStrService(IAppUnitOfWork uow) : base(uow, uow.LangStrs, new LangStrServiceMapper())
        {
        }
    }
}