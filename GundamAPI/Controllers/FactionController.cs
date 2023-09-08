using AutoMapper;
using GundamAPI.Dto;
using GundamAPI.Interfaces;
using GundamAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GundamAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FactionController : Controller
	{
		private readonly IFactionRepository _factionRepository;
		private readonly IMapper _mapper;

        public FactionController(IFactionRepository factionRepository, IMapper mapper)
        {
            _factionRepository = factionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type=typeof(IEnumerable<Faction>))]
		public IActionResult GetFactions()
        {
			var factions = _mapper.Map<List<FactionDto>>(_factionRepository.GetFactions());
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(factions);
		}

		[HttpGet("{factionId}")]
		[ProducesResponseType(200, Type = typeof(Faction))]
		[ProducesResponseType(400)]
		public IActionResult GetFaction(int factionId)
		{
			if (!_factionRepository.FactionExists(factionId))
			{
				return NotFound();
			}

			var faction = _mapper.Map<FactionDto>(_factionRepository.GetFaction(factionId));

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(faction);
		}

		[HttpGet("pilots/{pilotId}")]
		[ProducesResponseType(200, Type = typeof(Faction))]
		[ProducesResponseType(400)]
		public IActionResult GetFactionByPilot(int pilotId)
		{
			var faction = _mapper.Map<FactionDto>(_factionRepository.GetFactionByPilot(pilotId));

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(faction);
		}

		[HttpGet("{factionId}/pilots")]
		public IActionResult GetPilotFromAFaction(int factionId)
		{
			if (!_factionRepository.FactionExists(factionId))
			{
				return NotFound();
			}

			var pilots = _mapper.Map<List<PilotDto>>(_factionRepository.GetPilotsFromAFaction(factionId));

			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			return Ok(pilots);
		}
	}
}
