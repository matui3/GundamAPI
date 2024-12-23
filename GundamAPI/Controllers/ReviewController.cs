﻿using AutoMapper;
using GundamAPI.Dto;
using GundamAPI.Interfaces;
using GundamAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GundamAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewController : Controller
	{
		private readonly IReviewRepository _reviewRepository;
		private readonly IMapper _mapper;

        public ReviewController(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
		public IActionResult GetReviews()
		{
			var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviews());
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(reviews);
		}

		[HttpGet("{reviewId}")]
		[ProducesResponseType(200, Type = typeof(Review))]
		[ProducesResponseType(400)]
		public IActionResult GetReview(int reviewId) // must return an action result
		{
			if (!_reviewRepository.ReviewExists(reviewId))
			{
				return NotFound();
			}

			var review = _mapper.Map<ReviewDto>(_reviewRepository.GetReview(reviewId));

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			return Ok(review);
		}

		[HttpGet("gundam/{gundamId}")]
		[ProducesResponseType(200, Type = typeof(Review))]
		[ProducesResponseType(400)]
		public IActionResult GetReviewsForAGundam(int gundamId)
		{
			if (!_reviewRepository.ReviewExists(gundamId))
			{
				return NotFound();
			}

			var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviewsOfAGundam(gundamId));

			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			return Ok(reviews);
		}
	}
}
