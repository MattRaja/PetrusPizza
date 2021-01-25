using AutoMapper;
using AutoMapper.Configuration;
using ee.itcollege.mrajam.BLL.App.DTO;
using ee.itcollege.mrajam.BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;
using ee.itcollege.mrajam.BLL.App.DTO.Identity;

namespace BLL.App.Mappers
{
    public class PersonServiceMapper: BaseMapper<DAL.App.DTO.Person, Person>, IPersonServiceMapper
    {
        public PersonServiceMapper():base()
        {
            //MapperConfigurationExpression.CreateMap<DAL.App.DTO.PersonView, PersonView>();
            // add more mappings
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Identity.AppUser, AppUser>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Person, Person>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.ToppingType, ToppingType>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
        
        public Person MapPersonType(DAL.App.DTO.Person inObject)
        {
            return Mapper.Map<Person>(inObject);
        }
        public ToppingType MapToppingType(DAL.App.DTO.ToppingType inObject)
        {
            return Mapper.Map<ToppingType>(inObject);
        }

        public Person MapPerson(DAL.App.DTO.Person inObject)
        {
            return Mapper.Map<Person>(inObject);
        }

        public Person MapPersonView(DAL.App.DTO.Person inObject)
        {
            throw new System.NotImplementedException();
        }
    }

}