using Microsoft.AspNetCore.Mvc;
using TuksConnectAPI.Models;
using TuksConnectAPI.Repositories;

namespace TuksConnectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly IEventRepository _repository;

        public EventController(IEventRepository repository)
        {
            _repository = repository;
        }

        // get all
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            var events = await _repository.GetAllEvents();
            return Ok(events);
        }

        // get by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var eventItem = await _repository.GetEventById(id);
            return eventItem == null ? NotFound() : Ok(eventItem);
        }

        // post
        [HttpPost]
        public async Task<ActionResult<Event>> AddEvent(Event eventItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newEvent = await _repository.AddEvent(eventItem);
            return CreatedAtAction(nameof(GetEvent), new { id = newEvent.Id }, newEvent);
        }

        // put
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, Event eventItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != eventItem.Id) return BadRequest();

            var updated = await _repository.UpdateEvent(eventItem);
            return updated == null ? NotFound() : NoContent();
        }

        // delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var deleted = await _repository.DeleteEvent(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
