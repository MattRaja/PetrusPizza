using AutoMapper;
using AutoMapper.Configuration;
using ee.itcollege.mrajam.BLL.App.DTO;
using ee.itcollege.mrajam.BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;

namespace BLL.App.Mappers
{
    public class PaymentServiceMapper: BaseMapper<DAL.App.DTO.Payment, Payment>, IPaymentServiceMapper
    {
        public PaymentServiceMapper():base()
        {
            //MapperConfigurationExpression.CreateMap<DAL.App.DTO.PaymentView, PaymentView>();
            // add more mappings
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Identity.AppUser, ee.itcollege.mrajam.BLL.App.DTO.Identity.AppUser>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Payment, Payment>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.ToppingType, ToppingType>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
        
        public Payment MapPaymentType(DAL.App.DTO.Payment inObject)
        {
            return Mapper.Map<Payment>(inObject);
        }
        public ToppingType MapToppingType(DAL.App.DTO.ToppingType inObject)
        {
            return Mapper.Map<ToppingType>(inObject);
        }

        public Payment MapPayment(DAL.App.DTO.Payment inObject)
        {
            return Mapper.Map<Payment>(inObject);
        }

        public Payment MapPaymentView(DAL.App.DTO.Payment inObject)
        {
            throw new System.NotImplementedException();
        }
    }

}