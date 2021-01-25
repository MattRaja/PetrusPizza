using AutoMapper;
using AutoMapper.Configuration;
using ee.itcollege.mrajam.BLL.App.DTO;
using ee.itcollege.mrajam.BLL.App.DTO.Identity;
using ee.itcollege.mrajam.BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;
using ee.itcollege.mrajam.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class AppUserServiceMapper: BaseMapper<DAL.App.DTO.Identity.AppUser, AppUser>, IAppUserServiceMapper
    {
        public AppUserServiceMapper():base()
        {
            //MapperConfigurationExpression.CreateMap<DAL.App.DTO.Identity.AppUserView, .Identity.AppUserView>();
            // add more mappings
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Identity.AppUser, AppUser>();
            //MapperConfigurationExpression.CreateMap<DAL.App.DTO.ToppingType, ToppingType>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
        
        // public Identity.AppUser MapAppUserType(DAL.App.DTO.Identity.AppUser inObject)
        // {
        //     return Mapper.Map<ee.itcollege.mrajam.Identity.AppUser>(inObject);
        // }
        // public ToppingType MapToppingType(DAL.App.DTO.ToppingType inObject)
        // {
        //     return Mapper.Map<ToppingType>(inObject);
        // }
        //
        // public AppUser MapAppUser(DAL.App.DTO.Identity.AppUser inObject)
        // {
        //     return Mapper.Map<ee.itcollege.mrajam.Identity.AppUser>(inObject);
        // }

        public AppUser MapAppUserView(DAL.App.DTO.Identity.AppUser inObject)
        {
            throw new System.NotImplementedException();
        }
    }

}