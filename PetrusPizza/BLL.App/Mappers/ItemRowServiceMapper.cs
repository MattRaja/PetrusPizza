using AutoMapper;
using AutoMapper.Configuration;
using ee.itcollege.mrajam.BLL.App.DTO;
using ee.itcollege.mrajam.BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;

namespace BLL.App.Mappers
{
    public class ItemRowServiceMapper: BaseMapper<DAL.App.DTO.ItemRow, ItemRow>, IItemRowServiceMapper
    {
        public ItemRowServiceMapper():base()
        {
            //MapperConfigurationExpression.CreateMap<DAL.App.DTO.ItemRowView, ItemRowView>();
            // add more mappings
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Identity.AppUser, ee.itcollege.mrajam.BLL.App.DTO.Identity.AppUser>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.ItemRow, ItemRow>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.ToppingType, ToppingType>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
        
        public ItemRow MapItemRowType(DAL.App.DTO.ItemRow inObject)
        {
            return Mapper.Map<ItemRow>(inObject);
        }
        public ToppingType MapToppingType(DAL.App.DTO.ToppingType inObject)
        {
            return Mapper.Map<ToppingType>(inObject);
        }

        public ItemRow MapItemRow(DAL.App.DTO.ItemRow inObject)
        {
            return Mapper.Map<ItemRow>(inObject);
        }

        public ItemRow MapItemRowView(DAL.App.DTO.ItemRow inObject)
        {
            throw new System.NotImplementedException();
        }
    }

}