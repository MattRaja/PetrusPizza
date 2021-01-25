using AutoMapper;
using AutoMapper.Configuration;
using ee.itcollege.mrajam.BLL.App.DTO;
using ee.itcollege.mrajam.BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;

namespace BLL.App.Mappers
{
    public class PizzaOrderServiceMapper: BaseMapper<DAL.App.DTO.PizzaOrder, PizzaOrder>, IPizzaOrderServiceMapper
    {
        public PizzaOrderServiceMapper():base()
        {
            //MapperConfigurationExpression.CreateMap<DAL.App.DTO.PizzaOrderView, PizzaOrderView>();
            // add more mappings
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Identity.AppUser, ee.itcollege.mrajam.BLL.App.DTO.Identity.AppUser>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.PizzaOrder, PizzaOrder>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.ToppingType, ToppingType>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
        
        public PizzaOrder MapPizzaOrderType(DAL.App.DTO.PizzaOrder inObject)
        {
            return Mapper.Map<PizzaOrder>(inObject);
        }
        public ToppingType MapToppingType(DAL.App.DTO.ToppingType inObject)
        {
            return Mapper.Map<ToppingType>(inObject);
        }

        public PizzaOrder MapPizzaOrder(DAL.App.DTO.PizzaOrder inObject)
        {
            return Mapper.Map<PizzaOrder>(inObject);
        }

        public PizzaOrder MapPizzaOrderView(DAL.App.DTO.PizzaOrder inObject)
        {
            throw new System.NotImplementedException();
        }
    }

}