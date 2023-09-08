using AutoMapper;
using GundamAPI.Dto;
using GundamAPI.Interfaces;
using GundamAPI.Models;
using GundamAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GundamAPI.Controllers
{
	public class FeatureController : Controller
	{
		private readonly IFeaturesRepository _featuresRepository;
		private readonly IMapper _mapper;
        public FeatureController(IFeaturesRepository featuresRepository, IMapper mapper)
        {
            _featuresRepository = featuresRepository;
            _mapper = mapper;
        }

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Feature>))]
		public IActionResult GetFeatures()
		{
			var features = _mapper.Map<List<FeatureDto>>(_featuresRepository.GetFeatures());
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(features);
		}

		[HttpGet("{featureId}")]
		[ProducesResponseType(200, Type = typeof(Feature))]
		[ProducesResponseType(400)]
		public IActionResult GetFeature(int featureId)
		{
			if (!_featuresRepository.FeaturesExists(featureId))
			{
				return NotFound();
			}

			var feature = _mapper.Map<FeatureDto>(_featuresRepository.GetFeature(featureId));

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(feature);
		}

		[HttpGet("gundams/{featureId}")]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Feature>))]
		[ProducesResponseType(400)]
		public IActionResult GetGundamByFeatureId(int featureId)
		{
			var gundams = _mapper.Map<List<GundamDto>>(_featuresRepository.GetGundamsByFeatures(featureId));

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(gundams);
		}
	}
}
