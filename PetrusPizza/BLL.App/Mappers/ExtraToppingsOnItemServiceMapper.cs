using AutoMapper;
using AutoMapper.Configuration;
using ee.itcollege.mrajam.BLL.App.DTO;
using ee.itcollege.mrajam.BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;

namespace BLL.App.Mappers
{
    public class ExtraToppingsOnItemServiceMapper: BaseMapper<DAL.App.DTO.ExtraToppingsOnItem, ExtraToppingsOnItem>, IExtraToppingsOnItemServiceMapper
    {
        public ExtraToppingsOnItemServiceMapper():base()
        {
            //MapperConfigurationExpression.CreateMap<DAL.App.DTO.ExtraToppingsOnItemView, ExtraToppingsOnItemView>();
            // add more mappings
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Identity.AppUser, ee.itcollege.mrajam.BLL.App.DTO.Identity.AppUser>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.ExtraToppingsOnItem, ExtraToppingsOnItem>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.ToppingType, ToppingType>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
        
        public ExtraToppingsOnItem MapExtraToppingsOnItemType(DAL.App.DTO.ExtraToppingsOnItem inObject)
        {
            return Mapper.Map<ExtraToppingsOnItem>(inObject);
        }
        public ToppingType MapToppingType(DAL.App.DTO.ToppingType inObject)
        {
            return Mapper.Map<ToppingType>(inObject);
        }

        public ExtraToppingsOnItem MapExtraToppingsOnItem(DAL.App.DTO.ExtraToppingsOnItem inObject)
        {
            return Mapper.Map<ExtraToppingsOnItem>(inObject);
        }

        public ExtraToppingsOnItem MapExtraToppingsOnItemView(DAL.App.DTO.ExtraToppingsOnItem inObject)
        {
            throw new System.NotImplementedException();
        }
    }

}