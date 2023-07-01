using AutoMapper;

using Contracts;

using Entities.DataTransferObjects;
using Entities.Models;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace Events_module_API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IUnitofWork _repository;

        public EventController(IUnitofWork repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllEvents([FromQuery] EventParameters eventParameters)
        {
            try
            {
                var events = _repository.Event.GetAllEvent(eventParameters);

                var metadata = new
                {
                    events.TotalCount,
                    events.PageSize,
                    events.CurrentPage,
                    events.TotalPages,
                    events.HasNext,
                    events.HasPrevious
                };
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                _logger.LogInfo($"Returned {events.TotalCount} event from repository");
                var eventsResult = _mapper.Map<IEnumerable<EventDto>>(events);
                return Ok(eventsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllEvent action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "EventById")]
        public IActionResult GetEventById(Guid id)
        {
            try
            {
                var @event = _repository.Event.GetEventById(id);

                if (@event is null)
                {
                    _logger.LogInfo($"Event with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    var eventResult = _mapper.Map<EventDto>(@event);
                    _logger.LogInfo($"Returned owner with id: {id}");
                    return Ok(eventResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetEventById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateEvent([FromBody] CreateEventDto @event)
        {
            try
            {
                if (@event is null)
                {
                    _logger.LogError("@Event object sent from client is null.");
                    return BadRequest("@Event object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid @event object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var eventEntity = _mapper.Map<Event>(@event);

                _repository.Event.CreateEvent(eventEntity);
                _repository.Save();

                var createdEvent = _mapper.Map<EventDto>(eventEntity);

                return CreatedAtRoute("EventById", new { id = createdEvent.Id }, createdEvent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateEvent action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEvent(Guid id, [FromBody] UpdateEventDto @event)
        {
            try
            {
                if (@event is null)
                {
                    _logger.LogError("Event object sent from client is null.");
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid event object sent from client.");
                    return BadRequest();
                }

                var ownerEntity = _repository.Event.GetEventById(id);
                if (ownerEntity is null)
                {
                    _logger.LogError($"Event with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(@event, ownerEntity);
                _repository.Event.UpdateEvent(ownerEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateEvent action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(Guid id)
        {
            try
            {
                var @event = _repository.Event.GetEventById(id);
                if (@event is null)
                {
                    _logger.LogError($"Event with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Event.DeleteEvent(@event);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateEvent action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}