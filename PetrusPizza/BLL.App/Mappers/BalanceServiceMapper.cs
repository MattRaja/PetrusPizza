using AutoMapper;
using AutoMapper.Configuration;
using ee.itcollege.mrajam.BLL.App.DTO;
using ee.itcollege.mrajam.BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;
using ee.itcollege.mrajam.BLL.App.DTO.Identity;
using ee.itcollege.mrajam.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class BalanceServiceMapper: BaseMapper<DAL.App.DTO.Balance, Balance>, IBalanceServiceMapper
    {
        public BalanceServiceMapper():base()
        {
            //MapperConfigurationExpression.CreateMap<DAL.App.DTO.BalanceView, BalanceView>();
            // add more mappings
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Identity.AppUser, AppUser>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Balance, Balance>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.ToppingType, ToppingType>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
        
        public Balance MapBalanceType(DAL.App.DTO.Balance inObject)
        {
            return Mapper.Map<Balance>(inObject);
        }
        public ToppingType MapToppingType(DAL.App.DTO.ToppingType inObject)
        {
            return Mapper.Map<ToppingType>(inObject);
        }

        public Balance MapBalance(DAL.App.DTO.Balance inObject)
        {
            return Mapper.Map<Balance>(inObject);
        }

        public Balance MapBalanceView(DAL.App.DTO.Balance inObject)
        {
            throw new System.NotImplementedException();
        }
    }

}