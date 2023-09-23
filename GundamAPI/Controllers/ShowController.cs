using AutoMapper;
using GundamAPI.Dto;
using GundamAPI.Interfaces;
using GundamAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GundamAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShowController : Controller
	{
		private readonly IShowRepository _showRepository;
		private readonly IMapper _mapper;
        public ShowController(IShowRepository showRepository, IMapper mapper)
        {
            _showRepository = showRepository;
			_mapper = mapper;
        }

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Show>))]
		public IActionResult GetShows()
		{
			var shows = _mapper.Map<List<ShowDto>>(_showRepository.GetShows());
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(shows);
		}

		[HttpGet("{showId}")]
		[ProducesResponseType(200, Type = typeof(Show))]
		[ProducesResponseType(400)]
		public IActionResult GetShow(int showId) // must return an action result
		{
			if (!_showRepository.ShowExists(showId))
			{
				return NotFound();
			}

			var show = _mapper.Map<ShowDto>(_showRepository.GetShow(showId));

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			return Ok(show);
		}

	}
}
