using AutoMapper;
using AutoMapper.Configuration;
using ee.itcollege.mrajam.BLL.App.DTO;
using ee.itcollege.mrajam.BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;

namespace BLL.App.Mappers
{
    public class PaymentMethodServiceMapper: BaseMapper<DAL.App.DTO.PaymentMethod, PaymentMethod>, IPaymentMethodServiceMapper
    {
        public PaymentMethodServiceMapper():base()
        {
            //MapperConfigurationExpression.CreateMap<DAL.App.DTO.PaymentMethodView, PaymentMethodView>();
            // add more mappings
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Identity.AppUser, ee.itcollege.mrajam.BLL.App.DTO.Identity.AppUser>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.PaymentMethod, PaymentMethod>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.ToppingType, ToppingType>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
        
        public PaymentMethod MapPaymentMethodType(DAL.App.DTO.PaymentMethod inObject)
        {
            return Mapper.Map<PaymentMethod>(inObject);
        }
        public ToppingType MapToppingType(DAL.App.DTO.ToppingType inObject)
        {
            return Mapper.Map<ToppingType>(inObject);
        }

        public PaymentMethod MapPaymentMethod(DAL.App.DTO.PaymentMethod inObject)
        {
            return Mapper.Map<PaymentMethod>(inObject);
        }

        public PaymentMethod MapPaymentMethodView(DAL.App.DTO.PaymentMethod inObject)
        {
            throw new System.NotImplementedException();
        }
    }

}