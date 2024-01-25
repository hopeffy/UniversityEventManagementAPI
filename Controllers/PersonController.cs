using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using UniversityEventManagementAPI.Models;
using UniversityEventManagementAPI.Models.DTO;

namespace UniversityEventManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public PersonController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> createPerson(CreatePersonRequestDto request)
        {
            //map DTO to Domain Model
            var personObj = new Models.Domain.Person
            {
                name = request.name,
                surname = request.surname,
                role = request.role,
                createdTime = DateTime.UtcNow
            };

            await _appDbContext.Person.AddAsync(personObj);
            await _appDbContext.SaveChangesAsync();

            var response = new Models.Domain.Person
            {
                id = personObj.id,
                name = personObj.name,
                surname =personObj.surname,
                role = personObj.role,
                createdTime = personObj.createdTime
            };

            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAllPeople()
        {
            var events = _appDbContext.Person.ToList();

            return Ok(events);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Domain.Person>> getPerson(Guid id)
        {
            var personById = await _appDbContext.Person.FindAsync(id);
            return Ok(personById);
        }

        [NonAction]
        public Models.Domain.Person GetPersonById(Guid id)
        {
            var personById = _appDbContext.Person.Find(id);
            if (personById == null)
            {
                throw new KeyNotFoundException("User Not Found");
            }
            return personById;
        }

        [HttpPut("{id}")]
        public Task<ActionResult<Models.Domain.Person>> UpdatePerson([FromBody] Models.Domain.Person request)
        {

            _appDbContext.Person.Attach(request);
            _appDbContext.Person.Entry(request).State = EntityState.Modified;

            _appDbContext.Person.Update(request);
            _appDbContext.SaveChanges();


            return Task.FromResult<ActionResult<Models.Domain.Person>>(Ok(request));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Domain.Person>> DeleteEvent(Guid id)
        {
            Models.Domain.Person deleted = GetPersonById(id);

            _appDbContext.Person.Remove(deleted);

            _appDbContext.SaveChanges();

            return Ok(deleted);
        }
    }
}
