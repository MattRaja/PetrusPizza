using AutoMapper;
using ee.itcollege.mrajam.DAL.Base.Mappers;
using Domain.App;

namespace DAL.App.EF.Mappers
{
    public class DALMapper<TLeftObject, TRightObject> : BaseMapper<TLeftObject, TRightObject>
        where TRightObject : class?, new()
        where TLeftObject : class?, new()
    {
        public DALMapper() : base()
        { 
            // add more mappings
            // MapperConfigurationExpression.CreateMap<Domain.App.Identity.AppUser, DAL.App.DTO.Identity.AppUser>();
            // MapperConfigurationExpression.CreateMap<DAL.App.DTO.Identity.AppUser, Domain.App.Identity.AppUser>();
            
            MapperConfigurationExpression.CreateMap<PizzaName, DAL.App.DTO.PizzaName>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.PizzaName, Domain.App.PizzaName>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Topping, Domain.App.Topping>();
            MapperConfigurationExpression.CreateMap<Domain.App.Topping, DAL.App.DTO.Topping>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.DefaultTopping, Domain.App.DefaultTopping>();
            MapperConfigurationExpression.CreateMap<Domain.App.DefaultTopping, DAL.App.DTO.DefaultTopping>();
            
            // MapperConfigurationExpression.CreateMap<Domain.App.GpsLocation, DAL.App.DTO.GpsLocation>();
            // MapperConfigurationExpression.CreateMap<DAL.App.DTO.GpsLocation, Domain.App.GpsLocation>();

            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
    }
}