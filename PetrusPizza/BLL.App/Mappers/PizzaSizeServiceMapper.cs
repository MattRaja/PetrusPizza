using AutoMapper;
using AutoMapper.Configuration;
using ee.itcollege.mrajam.BLL.App.DTO;
using ee.itcollege.mrajam.BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;

namespace BLL.App.Mappers
{
    public class PizzaSizeServiceMapper: BaseMapper<DAL.App.DTO.PizzaSize, PizzaSize>, IPizzaSizeServiceMapper
    {
        public PizzaSizeServiceMapper():base()
        {
            //MapperConfigurationExpression.CreateMap<DAL.App.DTO.PizzaSizeView, PizzaSizeView>();
            // add more mappings
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Identity.AppUser, ee.itcollege.mrajam.BLL.App.DTO.Identity.AppUser>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.PizzaSize, PizzaSize>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.ToppingType, ToppingType>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
        
        public PizzaSize MapPizzaSizeType(DAL.App.DTO.PizzaSize inObject)
        {
            return Mapper.Map<PizzaSize>(inObject);
        }
        public ToppingType MapToppingType(DAL.App.DTO.ToppingType inObject)
        {
            return Mapper.Map<ToppingType>(inObject);
        }

        public DAL.App.DTO.PizzaSize MapPizzaSizeBLLDTO(PizzaSize inObject)
        {
            return Mapper.Map<DAL.App.DTO.PizzaSize>(inObject);
        }

        public PizzaSize MapPizzaSizeView(DAL.App.DTO.PizzaSize inObject)
        {
            throw new System.NotImplementedException();
        }
    }

}