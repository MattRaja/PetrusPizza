using AutoMapper;
using AutoMapper.Configuration;
using ee.itcollege.mrajam.BLL.App.DTO;
using ee.itcollege.mrajam.BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;

namespace BLL.App.Mappers
{
    public class OrderServiceMapper: BaseMapper<DAL.App.DTO.Order, Order>, IOrderServiceMapper
    {
        public OrderServiceMapper():base()
        {
            //MapperConfigurationExpression.CreateMap<DAL.App.DTO.OrderView, OrderView>();
            // add more mappings
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Identity.AppUser, ee.itcollege.mrajam.BLL.App.DTO.Identity.AppUser>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Order, Order>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.ToppingType, ToppingType>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
        
        public Order MapOrderType(DAL.App.DTO.Order inObject)
        {
            return Mapper.Map<Order>(inObject);
        }
        public ToppingType MapToppingType(DAL.App.DTO.ToppingType inObject)
        {
            return Mapper.Map<ToppingType>(inObject);
        }

        public Order MapOrder(DAL.App.DTO.Order inObject)
        {
            return Mapper.Map<Order>(inObject);
        }

        public Order MapOrderView(DAL.App.DTO.Order inObject)
        {
            throw new System.NotImplementedException();
        }

        public DAL.App.DTO.Order MapOrderBLLDTO(Order order)
        {
            return Mapper.Map<DAL.App.DTO.Order>(order);
        }
    }

}