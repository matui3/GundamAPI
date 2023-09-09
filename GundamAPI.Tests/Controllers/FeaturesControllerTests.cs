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
	public class FeaturesControllerTests
	{
		private readonly IFeaturesRepository _featuresRepository;
		private readonly IMapper _mapper;
        public FeaturesControllerTests()
        {
            _featuresRepository = A.Fake<IFeaturesRepository>();
            _mapper = A.Fake<IMapper>();
        }

		[Fact]
		public void FeaturesController_GetFeatures_ReturnsOk()
		{
			// Arrange
			var features = A.Fake<ICollection<FeatureDto>>();
			var featureList = A.Fake<List<FeatureDto>>();
			A.CallTo(() => _mapper.Map<List<FeatureDto>>(features)).Returns(featureList);
			var controller = new FeatureController(_featuresRepository, _mapper);

			// Act
			var result = controller.GetFeatures();

			// Assert
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(OkObjectResult));
		}

		[Fact]
		public void FeatureController_GetFeature_ReturnsOk()
		{
			// Arrange
			// Create a fake feature object
			var featureId = 1;
			var feature = A.Fake<Feature>();
			var featureDto = A.Fake<FeatureDto>();

			A.CallTo(() => _featuresRepository.FeaturesExists(featureId)).WithAnyArguments().Returns(true);

			A.CallTo(() => _featuresRepository.GetFeature(featureId)).WithAnyArguments().Returns(feature);

			var controller = new FeatureController(_featuresRepository, _mapper);

			// Act
			var result = controller.GetFeature(featureId); // Replace with the desired Armament ID

			// Assert
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(OkObjectResult));
		}

		[Fact]
		public void FeatureController_GetGundamByFeatures_ReturnsOk()
		{
			var featureId = 1;
			var gundams = new List<Gundam>();
			var gundamDtos = new List<GundamDto>();

			// Fake repository
			A.CallTo(() => _featuresRepository.GetGundamsByFeatures(featureId)).WithAnyArguments().Returns(gundams);

			A.CallTo(() => _mapper.Map<List<GundamDto>>(gundams)).Returns(gundamDtos);

			var controller = new FeatureController(_featuresRepository, _mapper);

			// Act
			var result = controller.GetGundamByFeatureId(featureId);

			// Assert
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(OkObjectResult));
		}
	}
}
