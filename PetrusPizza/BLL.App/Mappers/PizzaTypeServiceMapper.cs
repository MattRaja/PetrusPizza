using AutoMapper;
using AutoMapper.Configuration;
using ee.itcollege.mrajam.BLL.App.DTO;
using ee.itcollege.mrajam.BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;

namespace BLL.App.Mappers
{
    public class PizzaTypeServiceMapper: BaseMapper<DAL.App.DTO.PizzaType, PizzaType>, IPizzaTypeServiceMapper
    {
        public PizzaTypeServiceMapper():base()
        {
            //MapperConfigurationExpression.CreateMap<DAL.App.DTO.PizzaTypeView, PizzaTypeView>();
            // add more mappings
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Identity.AppUser, ee.itcollege.mrajam.BLL.App.DTO.Identity.AppUser>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.PizzaType, PizzaType>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.ToppingType, ToppingType>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
        
        public PizzaType MapPizzaTypeType(DAL.App.DTO.PizzaType inObject)
        {
            return Mapper.Map<PizzaType>(inObject);
        }
        public ToppingType MapToppingType(DAL.App.DTO.ToppingType inObject)
        {
            return Mapper.Map<ToppingType>(inObject);
        }

        public DAL.App.DTO.PizzaType MapPizzaTypeBLLDTO(PizzaType inObject)
        {
            return Mapper.Map<DAL.App.DTO.PizzaType>(inObject);
        }

        public PizzaType MapPizzaTypeView(DAL.App.DTO.PizzaType inObject)
        {
            throw new System.NotImplementedException();
        }
    }

}