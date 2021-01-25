using Contracts.DAL.App.Repositories;
using ee.itcollege.mrajam.Contracts.DAL.Base.Mappers;
using DAL.App.EF.Mappers;
using ee.itcollege.mrajam.DAL.Base.EF.Repositories;
using ee.itcollege.mrajam.DAL.Base.Mappers;
using Domain.App;
using Domain.App.Identity;

namespace DAL.App.EF.Repositories
{
    public class LangStrTranslationRepository :
        EFBaseRepository<AppDbContext, AppUser, Domain.App.LangStrTranslation,
            DAL.App.DTO.LangStrTranslation>,
        ILangStrTranslationRepository
    {
        public LangStrTranslationRepository(AppDbContext repoDbContext) : base(repoDbContext,
            new DALMapper<Domain.App.LangStrTranslation, DTO.LangStrTranslation>())
        {
        }
    }
}