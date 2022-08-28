using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestbART.Dtos;
using TestbART.Model;
using TestbART.Services.Interfaces;

namespace TestbART.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IIncidentService _incidentService;

        public IncidentsController(IIncidentService incidentService, IMapper mapper)
        {
            _mapper = mapper;
            _incidentService = incidentService;
        }

        // GET: api/Incidents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Incident>>> GetIncidents()
        {
            return Ok(_incidentService.GetAllIncidents());
        }

        // GET: api/Incidents/5
        [HttpGet("{name}")]
        public async Task<ActionResult<Incident>> GetIncidents([FromRoute]string name)
        {
            var incidentName = _incidentService.GetIncidentById(name);
            return Ok(incidentName);
        }

        // PUT: api/Incidents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutIncidents(Incident incidents)
        {
            await _incidentService.UpdateIncidentAsync(incidents);

            return Ok();
        }

        // POST: api/Incidents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Incident>> PostIncidents(IncidentCreateDto incidentDto)
        {
            var incident = _mapper.Map<Incident>(incidentDto);

            await _incidentService.CreateIncidentAsync(incident);

            return Ok();
        }

        // DELETE: api/Incidents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncidents(string name)
        {
            await _incidentService.DeleteIncidentAsync(name);

            return Ok();
        }
    }
}
