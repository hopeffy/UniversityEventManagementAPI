using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityEventManagementAPI.Models;
using UniversityEventManagementAPI.Models.DTO;

namespace UniversityEventManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public EventController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }


        
        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventRequestDto request)
        {
            //map DTO to Domain Model
            var eventObj = new Models.Domain.Event
            {
                name = request.name,
                status = request.status,
                description = request.description,
                startDate = request.startDate,
                endDate = request.endDate
            };

            await _appDbContext.Event.AddAsync(eventObj);
            await _appDbContext.SaveChangesAsync();

            //Domain model to DTO
            var response = new Models.Domain.Event
            {
                id = eventObj.id,
                name = eventObj.name,
                status = eventObj.status,
                description = eventObj.description,
                startDate = eventObj.startDate,
                endDate = eventObj.endDate
            };

            return Ok(response);

        }


        [HttpGet]
        public async Task<ActionResult<List<Models.Domain.Event>>> GetAllEvents() {


            var events = _appDbContext.Event.ToList();

           return Ok(events);

        }






    }
}
