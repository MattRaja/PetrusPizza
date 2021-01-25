using AutoMapper;
using AutoMapper.Configuration;
using ee.itcollege.mrajam.BLL.App.DTO;
using ee.itcollege.mrajam.BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;

namespace BLL.App.Mappers
{
    public class OrderRowServiceMapper: BaseMapper<DAL.App.DTO.OrderRow, OrderRow>, IOrderRowServiceMapper
    {
        public OrderRowServiceMapper():base()
        {
            //MapperConfigurationExpression.CreateMap<DAL.App.DTO.OrderRowView, OrderRowView>();
            // add more mappings
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Identity.AppUser, ee.itcollege.mrajam.BLL.App.DTO.Identity.AppUser>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.OrderRow, OrderRow>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.ToppingType, ToppingType>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
        
        public OrderRow MapOrderRowType(DAL.App.DTO.OrderRow inObject)
        {
            return Mapper.Map<OrderRow>(inObject);
        }
        public ToppingType MapToppingType(DAL.App.DTO.ToppingType inObject)
        {
            return Mapper.Map<ToppingType>(inObject);
        }

        public OrderRow MapOrderRow(DAL.App.DTO.OrderRow inObject)
        {
            return Mapper.Map<OrderRow>(inObject);
        }

        public OrderRow MapOrderRowView(DAL.App.DTO.OrderRow inObject)
        {
            throw new System.NotImplementedException();
        }

        public DAL.App.DTO.OrderRow MapOrderRowBLLDTO(OrderRow orderRow)
        {
            return Mapper.Map<DAL.App.DTO.OrderRow>(orderRow);
        }
    }

}