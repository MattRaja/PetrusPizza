using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Configuration;
using ee.itcollege.mrajam.BLL.App.DTO;
using ee.itcollege.mrajam.BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;

namespace BLL.App.Mappers
{
    public class PizzaNameServiceMapper: BaseMapper<DAL.App.DTO.PizzaName, PizzaName>, IPizzaNameServiceMapper
    {
        public PizzaNameServiceMapper():base()
        {
            //MapperConfigurationExpression.CreateMap<DAL.App.DTO.PizzaNameView, PizzaNameView>();
            // add more mappings
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Identity.AppUser, ee.itcollege.mrajam.BLL.App.DTO.Identity.AppUser>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.PizzaName, PizzaName>();
            MapperConfigurationExpression.CreateMap<PizzaName, DAL.App.DTO.PizzaName>();
            MapperConfigurationExpression.CreateMap<DefaultTopping, DAL.App.DTO.DefaultTopping>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.ToppingType, ToppingType>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
        
        public PizzaName MapPizzaNameType(DAL.App.DTO.PizzaName inObject)
        {
            return Mapper.Map<PizzaName>(inObject);
        }
        
        public DAL.App.DTO.PizzaName MapPizzaNameBLLDTO(PizzaName inObject)
        {
            return Mapper.Map<DAL.App.DTO.PizzaName>(inObject);
        } 
        public DAL.App.DTO.DefaultTopping MapDefaultToppingBLLDTO(DefaultTopping inObject)
        {
            return Mapper.Map<DAL.App.DTO.DefaultTopping>(inObject);
        }
        public DAL.App.DTO.Topping MapToppingBLLDTO(Topping inObject)
        {
            return Mapper.Map<DAL.App.DTO.Topping>(inObject);
        } 
        
        public DAL.App.DTO.PizzaSize MapPizzaSizeBLLDTO(PizzaSize inObject)
        {
            return Mapper.Map<DAL.App.DTO.PizzaSize>(inObject);
        } 
        
        public DAL.App.DTO.PizzaType MapPizzaTypeBLLDTO(PizzaType inObject)
        {
            return Mapper.Map<DAL.App.DTO.PizzaType>(inObject);
        }

        public PizzaName MapPizzaName(DAL.App.DTO.PizzaName inObject)
        {
            return Mapper.Map<PizzaName>(inObject);
        } 
        
        public Topping MapToppings(DAL.App.DTO.Topping inObject)
        {
            return Mapper.Map<Topping>(inObject);
        }

        public PizzaName MapPizzaNameView(DAL.App.DTO.PizzaName inObject)
        {
            throw new System.NotImplementedException();
        }
    }

}