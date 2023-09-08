using AutoMapper;
using GundamAPI.Dto;
using GundamAPI.Interfaces;
using GundamAPI.Models;
using GundamAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GundamAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PilotController : Controller
	{
		private readonly IPilotRepository _pilotRepository;
		private readonly IMapper _mapper;
        public PilotController(IPilotRepository pilotRepository, IMapper mapper)
        {
             _pilotRepository = pilotRepository;
            _mapper = mapper;
        }

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Pilot>))]
		public IActionResult GetPilots()
		{
			var pilots = _mapper.Map<List<PilotDto>>(_pilotRepository.GetPilots());
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(pilots);
		}

		[HttpGet("{pilotId}")]
		[ProducesResponseType(200, Type = typeof(Pilot))]
		[ProducesResponseType(400)]
		public IActionResult GetPilot(int pilotId) // must return an action result
		{
			if (!_pilotRepository.PilotExists(pilotId))
			{
				return NotFound();
			}

			var pilot = _mapper.Map<PilotDto>(_pilotRepository.GetPilot(pilotId));

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			return Ok(pilot);
		}

		[HttpGet("gundam/{gundamId}")]
		[ProducesResponseType(200, Type = typeof(Gundam))]
		[ProducesResponseType(400)]
		public IActionResult GetPilotByGundam(int pilotId)
		{
			var gundam = _mapper.Map<GundamDto>(_pilotRepository.GetGundamOfAPilot(pilotId));

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(gundam);
		}

		[HttpGet("{pilotId}/gundam")]
		public IActionResult GetGundamOfAPilot(int pilotId)
		{
			if (!_pilotRepository.PilotExists(pilotId))
			{
				return NotFound();
			}

			var gundam = _mapper.Map<GundamDto>(_pilotRepository.GetGundamOfAPilot(pilotId));

			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			return Ok(gundam);
		}

	}
}
