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
	public class GundamControllerTests
	{
		private readonly IGundamRepository _gundamRepository;
		private readonly IMapper _mapper;

        public GundamControllerTests()
        {
            _gundamRepository = A.Fake<IGundamRepository>();
			_mapper = A.Fake<IMapper>();
        }

        [Fact]
		public void GundamsController_GetGundams_ReturnsOk()
		{
			// Arrange
			var gundams = A.Fake<ICollection<GundamDto>>();
			var gundamList = A.Fake<List<GundamDto>>();
			A.CallTo(() => _mapper.Map<List<GundamDto>>(gundams)).Returns(gundamList);
			var controller = new GundamController(_gundamRepository, _mapper);

			// Act
			var result = controller.GetGundams();

			// Assert
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(OkObjectResult));
		}

		[Fact]
		public void GundamController_GetGundam_ReturnsOk()
		{
			// Arrange
			// Create a fake feature object
			var gundamId = 1;
			var gundam = A.Fake<Gundam>();
			var gundamDto = A.Fake<GundamDto>();

			A.CallTo(() => _gundamRepository.GundamExists(gundamId)).WithAnyArguments().Returns(true);

			A.CallTo(() => _gundamRepository.GetGundam(gundamId)).WithAnyArguments().Returns(gundam);

			var controller = new GundamController(_gundamRepository, _mapper);

			// Act
			var result = controller.GetGundam(gundamId); // Replace with the desired Armament ID

			// Assert
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(OkObjectResult));
		}
	}
	

	
}
