using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using GundamAPI.Controllers;
using GundamAPI.Dto;
using GundamAPI.Interfaces;
using GundamAPI.Models;
using GundamAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GundamAPI.Tests.Controllers
{
	public class ReviewerControllerTests
	{
		private readonly IReviewerRepository _reviewerRepository;
		private readonly IMapper _mapper;
        public ReviewerControllerTests()
        {
            _reviewerRepository = A.Fake<IReviewerRepository>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void ReviewerController_GetReviewers_ReturnsOk()
        {
            // Arrange
            var reviewers = A.Fake<ICollection<ReviewerDto>>();
            var reviewersList = A.Fake<List<ReviewerDto>>();

            A.CallTo(() => _mapper.Map<List<ReviewerDto>>(reviewers)).Returns(reviewersList);

            var controller = new ReviewerController(_reviewerRepository, _mapper);

            // Act
            var result = controller.GetReviewers();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void ReviewerController_GetReviewer_ReturnsOk()
        {
        	// Arrange
        	// Create a fake feature object
        	var reviewerId = 1;
        	var reviewer = A.Fake<Reviewer>();
        	var reviewerDto = A.Fake<ReviewerDto>();

        	A.CallTo(() => _reviewerRepository.ReviewerExists(reviewerId)).WithAnyArguments().Returns(true);

        	A.CallTo(() => _reviewerRepository.GetReviewer(reviewerId)).WithAnyArguments().Returns(reviewer);

        	var controller = new ReviewerController(_reviewerRepository, _mapper);

        	// Act
        	var result = controller.GetReviewer(reviewerId); // Replace with the desired Armament ID

        	// Assert
        	result.Should().NotBeNull();
        	result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void ReviewerController_GetReviewsByReviewer_ReturnsOk()
        {
            // Arrange
            var reviewerId = 1;
            var reviews = A.CollectionOfFake<Review>(3);
			var reviewsDtos = A.CollectionOfFake<ReviewDto>(3);

			A.CallTo(() => _reviewerRepository.ReviewerExists(reviewerId)).Returns(true);

			A.CallTo(() => _reviewerRepository.GetReviewsByReviewer(reviewerId)).Returns(reviews);

			A.CallTo(() => _mapper.Map<ReviewDto>(A<Review>._)).ReturnsNextFromSequence(reviewsDtos.ToArray());

			var controller = new ReviewerController(_reviewerRepository, _mapper);
            // Act

            var result = controller.GetReviewsByReviewer(reviewerId);

			// Assert
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(OkObjectResult));
		}
    }
}
