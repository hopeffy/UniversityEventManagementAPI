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
        public IActionResult GetAllEvents() {
            var events = _appDbContext.Event.ToList();

            return Ok(events);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Domain.Event>> getEvent(Guid id)
        {
            var eventById = await _appDbContext.Event.FindAsync(id);
            return Ok(eventById);
        }

        [NonAction]
        public Models.Domain.Event GetEventById(Guid id)
        {
            var eventById = _appDbContext.Event.Find(id);
            if (eventById == null)
            {
                throw new KeyNotFoundException("User Not Found");
            }
                return eventById;
        }

        [HttpPut("{id}")]
        public Task<ActionResult<Models.Domain.Event>> UpdateEvent([FromBody]Models.Domain.Event request)
        {

            /*  Models.Domain.Event newEvent = _appDbContext.Event.Find(request.Id);


             if(newEvent != null)
             {
                 newEvent.name = request.name; 
                 newEvent.status = request.status;
                 newEvent.description = request.description;
                 newEvent.startDate = request.startDate;
                 newEvent.endDate = request.endDate;

                 await _appDbContext.Event.AddAsync(newEvent);

             }
             await _appDbContext.SaveChangesAsync(); */

            _appDbContext.Event.Attach(request);
            _appDbContext.Event.Entry(request).State = EntityState.Modified;

            _appDbContext.Event.Update(request);
            _appDbContext.SaveChanges();


            return Task.FromResult<ActionResult<Models.Domain.Event>>(Ok(request));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Domain.Event>> DeleteEvent(Guid id)
        {
            Models.Domain.Event deleted = GetEventById(id);

            _appDbContext.Event.Remove(deleted);

            _appDbContext.SaveChanges();

            return Ok(deleted);
        }










    }
}
