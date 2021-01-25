using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.mrajam.DAL.Base.EF.Repositories;
using ee.itcollege.mrajam.DAL.Base.Mappers;
using Domain.App.Identity;


namespace DAL.App.EF.Repositories
{
    public class LangStrRepository :
        EFBaseRepository<AppDbContext, AppUser, Domain.App.LangStr, DAL.App.DTO.LangStr>,
        ILangStrRepository
    {
        public LangStrRepository(AppDbContext repoDbContext) : base(repoDbContext,
            new DALMapper<Domain.App.LangStr, DAL.App.DTO.LangStr>())
        {
        }
    }
}