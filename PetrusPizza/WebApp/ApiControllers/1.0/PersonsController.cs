using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.v1.Mappers;
using V1DTO=PublicApi.DTO.v1;

namespace WebApp.ApiControllers._1._0
{
    /// <summary>
    /// Persons
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class PersonsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly PersonMapper _mapper = new PersonMapper();
        
        /// <summary>
        /// Constructor
        /// </summary>
        public PersonsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// get all the Persons
        /// </summary>
        /// <returns>Array of Persons</returns>
        [HttpGet]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<V1DTO.PersonDTO>))]
        public async Task<ActionResult<IEnumerable<V1DTO.PersonDTO>>> GetPersons()
        {
            var persons = _bll.Persons.GetAllAsync().Result;
            return Ok(persons.Select(e => _mapper.Map(e)));
        }

        /// <summary>
        /// Get a single Person
        /// </summary>
        /// <param name="id">GpPerson Id</param>
        /// <returns>Person object</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.PersonDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.PersonDTO>> GetPerson(Guid id)
        {
            var Person = await _bll.Persons.FirstOrDefaultAsync(id);

            if (Person == null)
            {
                return NotFound(new V1DTO.MessageDTO($"Person with id {id} not found"));
            }

            return Ok(_mapper.Map( Person));
        }


        /// <summary>
        /// Update the Person
        /// </summary>
        /// <param name="id">Person Id</param>
        /// <param name="PersonDTO">Person object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<IActionResult> PutPerson(Guid id, ee.itcollege.mrajam.BLL.App.DTO.Person PersonDTO)
        {
            if (id != PersonDTO.Id)
            {
                return BadRequest(new V1DTO.MessageDTO("Id and Person.id do not match"));
            }

            if (!await _bll.Persons.ExistsAsync(PersonDTO.Id, User.UserId<Guid>()))
            {
                return NotFound(new V1DTO.MessageDTO($"Current user does not have session with this id {id}"));
            }
        
            PersonDTO.AppUserId = User.UserId<Guid>();
            var PersonApiDTO = new V1DTO.PersonDTO()
            {
                Id = PersonDTO.Id,
                FirstName = PersonDTO.FirstName,
                LastName = PersonDTO.LastName,
            };
            await _bll.Persons.UpdateAsync(_mapper.Map(PersonApiDTO));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        /// <summary>
        /// Post the new Person
        /// </summary>
        /// <param name="Person"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(V1DTO.PersonDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.PersonDTO>> PostPerson(V1DTO.PersonDTO Person)
        {
            // Console.WriteLine("inapi");
            // var persons = _bll.Persons.GetAllAsync().Result.ToList();
            // var dto = new PublicApi.DTO.v1.PersonCreateEditDTO()
            // {
            //     PersonList = persons
            // };
            // Person.Id = Guid.NewGuid();
            // Person.AppUserId = User.UserGuidId();
            //   
            // var bllPerson = new ee.itcollege.mrajam.BLL.App.DTO.Person()
            // {
            //     Id = Person.Id,
            //     AppUserId = Person.AppUserId,
            //     Price = Person.Price.ToString(),
            //     NameOfPizza = Person.NameOfPizza,
            //     DefaultPersons = null
            // };
            // await _bll.Persons.AddAndUpdateAsync(bllPerson);
            //     
            // foreach (var defaultPerson in Person.DefaultPersonsOut)
            // {
            //     var person = _bll.Persons.GetAllAsync().Result.First(a => a.PersonName == defaultPerson);
            //     await _bll.DefaultPersons.AddAndUpdateAsync(Person, person);
            // }

            return CreatedAtAction(nameof(GetPerson),
                new {id = Person.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"},
                Person);
        }


        /// <summary>
        /// Delete the Person. Also deletes all the GpsLocations for this session.
        /// </summary>
        /// <param name="id">Person Id to delete.</param>
        /// <returns>Person just deleted</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.PersonDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.PersonDTO>> DeletePerson(Guid id)
        {
            //Person? Person = null;

            var userIdTKey = User.IsInRole("admin") ? null : (Guid?) User.UserId<Guid>();

            var Person =
                await _bll.Persons.FirstOrDefaultAsync(id, userIdTKey);

            
            if (Person == null)
            {
                return NotFound(new V1DTO.MessageDTO($"Person with id {id} not found!"));
            }

            await _bll.Persons.RemoveAsync(Person, userIdTKey);
            await _bll.SaveChangesAsync();

            return Ok(Person);
        }


    }
}
