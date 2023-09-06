using AutoMapper;
using GundamAPI.Dto;
using GundamAPI.Interfaces;
using GundamAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GundamAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArmamentController : Controller
	{
		private readonly IArmamentRepository _armamentRepository;
		private readonly IMapper _mapper;

        public ArmamentController(IArmamentRepository armamentRepository, IMapper mapper)
        {
            _armamentRepository = armamentRepository;
			_mapper = mapper;
        }

		[HttpGet]
		[ProducesResponseType(200, Type=typeof(IEnumerable<Armament>))]
		public IActionResult GetArmaments()
		{
			var armaments = _mapper.Map<List<ArmamentDto>>(_armamentRepository.GetArmaments());
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(armaments);
		}
    }
}
