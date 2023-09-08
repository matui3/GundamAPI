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
	public class GundamController : Controller
	{
		private readonly IGundamRepository _gundamRepository;
		private readonly IMapper _mapper;
        public GundamController(IGundamRepository gundamRepository, IMapper mapper)
        {
            _gundamRepository = gundamRepository;
            _mapper = mapper;
        }

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Gundam>))]
		public IActionResult GetGundams()
		{
			var gundams = _mapper.Map<List<GundamDto>>(_gundamRepository.GetGundams());
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(gundams);
		}

		[HttpGet("{gundamId}")]
		[ProducesResponseType(200, Type = typeof(Gundam))]
		[ProducesResponseType(400)]
		public IActionResult GetGundam(int gundamId) // must return an action result
		{
			if (!_gundamRepository.GundamExists(gundamId))
			{
				return NotFound();
			}

			var gundam = _mapper.Map<GundamDto>(_gundamRepository.GetGundam(gundamId));

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			return Ok(gundam);
		}
	}
}
