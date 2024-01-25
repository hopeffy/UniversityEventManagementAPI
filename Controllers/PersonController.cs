using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
