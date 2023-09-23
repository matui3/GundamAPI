using AutoMapper;
using GundamAPI.Dto;
using GundamAPI.Interfaces;
using GundamAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GundamAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewerController : Controller
	{
		private readonly IReviewerRepository _reviewerRepository;
		private readonly IMapper _mapper;
        public ReviewerController(IReviewerRepository reviewerRepository, IMapper mapper)
        {
			_reviewerRepository = reviewerRepository;
			_mapper = mapper;
        }

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
		public IActionResult GetReviewers()
		{
			var reviewers = _mapper.Map<List<ReviewerDto>>(_reviewerRepository.GetReviewers());
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(reviewers);
		}

		[HttpGet("{reviewerId}")]
		[ProducesResponseType(200, Type = typeof(Reviewer))]
		[ProducesResponseType(400)]
		public IActionResult GetReviewer(int reviewerId) // must return an action result
		{
			if (!_reviewerRepository.ReviewerExists(reviewerId))
			{
				return NotFound();
			}

			var reviewer = _mapper.Map<ReviewerDto>(_reviewerRepository.GetReviewer(reviewerId));

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			return Ok(reviewer);
		}

		[HttpGet("{reviewerId}/reviews")]
		public IActionResult GetReviewsByReviewer(int reviewerId)
		{
			if (!_reviewerRepository.ReviewerExists(reviewerId))
			{
				return NotFound();
			}

			var reviews = _mapper.Map<List<ReviewDto>>(_reviewerRepository.GetReviewsByReviewer(reviewerId));

			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			return Ok(reviews);
		}
	}
}
