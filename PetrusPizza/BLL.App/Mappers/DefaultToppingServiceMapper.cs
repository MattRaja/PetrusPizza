using System;
using AutoMapper;
using AutoMapper.Configuration;
using ee.itcollege.mrajam.BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using ee.itcollege.mrajam.BLL.App.DTO.Identity;
using DefaultTopping = ee.itcollege.mrajam.BLL.App.DTO.DefaultTopping;

namespace BLL.App.Mappers
{
    public class DefaultToppingServiceMapper: BaseMapper<DAL.App.DTO.DefaultTopping, DefaultTopping>, IDefaultToppingServiceMapper
    {
        public DefaultToppingServiceMapper():base()
        {
            //MapperConfigurationExpression.CreateMap<DAL.App.DTO.DefaultToppingView, DefaultToppingView>();
            // add more mappings
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Identity.AppUser, AppUser>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.DefaultTopping, DefaultTopping>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.ToppingType, ToppingType>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
        
        public DefaultTopping MapDefaultToppingType(DAL.App.DTO.DefaultTopping inObject)
        {
            return Mapper.Map<DefaultTopping>(inObject);
        }
        public ToppingType MapToppingType(DAL.App.DTO.ToppingType inObject)
        {
            return Mapper.Map<ToppingType>(inObject);
        }

        public DAL.App.DTO.DefaultTopping MapDefaultToppingBLLDTO(DefaultTopping inObject)
        {
           
            
            var dalDefaultTopping = new DAL.App.DTO.DefaultTopping()
            {
                Id = inObject.Id,
                AppUserId = inObject.AppUserId,
                ToppingId = inObject.ToppingId,
                //ToppingName = topping,
                PizzaNameId = inObject.PizzaNameId,
                //PizzaName = pizzaName
            };
            return dalDefaultTopping;
        }  
        // public DAL.App.DTO.DefaultTopping MapDefaultToppingBLLDTO(List<Guid> inObject)
        // {
       
      
        //     
        //     var dalDefaultTopping = new DAL.App.DTO.DefaultTopping()
        //     {
        //         Id = inObject.Id,
        //         AppUserId = inObject.AppUserId,
        //         ToppingId = inObject.ToppingId,
        //         //ToppingName = topping,
        //         PizzaNameId = inObject.PizzaNameId,
        //         //PizzaName = pizzaName
        //     };
        //     return dalDefaultTopping;
        // }

        public DefaultTopping MapDefaultToppingDALDTO(DAL.App.DTO.DefaultTopping inObject)
        {
            return Mapper.Map<DefaultTopping>(inObject);
        }

        public DefaultTopping MapDefaultToppingView(DAL.App.DTO.DefaultTopping inObject)
        {
            throw new System.NotImplementedException();
        }
    }

}