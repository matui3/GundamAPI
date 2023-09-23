using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using GundamAPI.Controllers;
using GundamAPI.Dto;
using GundamAPI.Interfaces;
using GundamAPI.Models;
using GundamAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GundamAPI.Tests.Controllers
{
	public class ReviewControllerTests
	{
		private readonly IReviewRepository _reviewRepository;
		private readonly IMapper _mapper;
        public ReviewControllerTests()
        {
            _reviewRepository = A.Fake<IReviewRepository>();
            _mapper = A.Fake<IMapper>();
        }

		[Fact]
		public void ReviewController_GetReviews_ReturnsOk()
		{
			// Arrange
			var reviews = A.Fake<ICollection<ReviewDto>>();
			var reviewList = A.Fake<List<ReviewDto>>();
			A.CallTo(() => _mapper.Map<List<ReviewDto>>(reviews)).Returns(reviewList);
			var controller = new ReviewController(_reviewRepository, _mapper);

			// Act
			var result = controller.GetReviews();

			// Assert
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(OkObjectResult));
		}

		[Fact]
		public void ReviewController_GetReview_ReturnsOk()
		{
			// Arrange
			// Create a fake feature object
			var	reviewId = 1;
			var review = A.Fake<Review>();
			var reviewDto = A.Fake<ReviewDto>();

			A.CallTo(() => _reviewRepository.ReviewExists(reviewId)).WithAnyArguments().Returns(true);

			A.CallTo(() => _reviewRepository.GetReview(reviewId)).WithAnyArguments().Returns(review);

			var controller = new ReviewController(_reviewRepository, _mapper);

			// Act
			var result = controller.GetReview(reviewId); // Replace with the desired Armament ID

			// Assert
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(OkObjectResult));
		}

		[Fact]
		public void ReviewController_GetReviewsForAGundam_ReturnsOk()
		{
			// Arrange
			var gundamId = 1;
			var reviews = A.CollectionOfFake<Review>(3);
			var reviewDto = A.CollectionOfFake<ReviewDto>(3);

			A.CallTo(() => _reviewRepository.GetReviewsOfAGundam(gundamId)).WithAnyArguments().Returns(reviews);

			A.CallTo(() => _mapper.Map<List<ReviewDto>>(A<IEnumerable<Review>>._))
				.WithAnyArguments()
				.ReturnsLazily(call => reviewDto.ToList());

			var controller = new ReviewController(_reviewRepository, _mapper);

			// Act
			var result = controller.GetReviewsForAGundam(gundamId);

			// Assert
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(OkObjectResult));
		}
	}
}
 