using AutoMapper;
using AutoMapper.Configuration;
using ee.itcollege.mrajam.BLL.App.DTO;
using ee.itcollege.mrajam.BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;

namespace BLL.App.Mappers
{
    public class ToppingServiceMapper: BaseMapper<DAL.App.DTO.Topping, Topping>, IToppingServiceMapper
    {
        public ToppingServiceMapper():base()
        {
            //MapperConfigurationExpression.CreateMap<DAL.App.DTO.ToppingView, ToppingView>();
            // add more mappings
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Identity.AppUser, ee.itcollege.mrajam.BLL.App.DTO.Identity.AppUser>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Topping, Topping>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.ToppingType, ToppingType>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
        
        public Topping MapToppingType(DAL.App.DTO.Topping inObject)
        {
            return Mapper.Map<Topping>(inObject);
        }
        public ToppingType MapToppingType(DAL.App.DTO.ToppingType inObject)
        {
            return Mapper.Map<ToppingType>(inObject);
        }

        public Topping MapTopping(DAL.App.DTO.Topping inObject)
        {
            return Mapper.Map<Topping>(inObject);
        }
        
        public DAL.App.DTO.Topping MapToppingBLLDTO(Topping inObject)
        {
            return Mapper.Map<DAL.App.DTO.Topping>(inObject);
        } 

        public Topping MapToppingView(DAL.App.DTO.Topping inObject)
        {
            throw new System.NotImplementedException();
        }
    }

}