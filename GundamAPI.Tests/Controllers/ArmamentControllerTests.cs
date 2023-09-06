using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using GundamAPI.Controllers;
using GundamAPI.Dto;
using GundamAPI.Interfaces;
using GundamAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GundamAPI.Tests.Controllers
{
	public class ArmamentControllerTests
	{
		private readonly IArmamentRepository _armamentRepository;
		private readonly IMapper _mapper;

		public ArmamentControllerTests()
		{
			_armamentRepository = A.Fake<IArmamentRepository>();
			_mapper = A.Fake<IMapper>();
		}

		[Fact]
		public void ArmamentController_GetArmaments_ReturnsOk()
		{
			// Arrange
			var armaments = A.Fake<ICollection<ArmamentDto>>();
			var armamentList = A.Fake<List<ArmamentDto>>();
			A.CallTo(() => _mapper.Map<List<ArmamentDto>>(armaments)).Returns(armamentList);
			var controller = new ArmamentController(_armamentRepository, _mapper);

			// Act
			var result = controller.GetArmaments();

			// Assert
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(OkObjectResult));
		}

		[Fact]
		public void ArmamentController_GetArmament_ReturnsOk()
		{
			// Arrange
			// Create a fake Armament object
			var armamentId = 1;
			var armament = A.Fake<Armament>();
			var armamentDto = A.Fake<ArmamentDto>();

			A.CallTo(() => _armamentRepository.ArmamentExists(armamentId)).WithAnyArguments().Returns(true);

			A.CallTo(() => _armamentRepository.GetArmament(armamentId)).WithAnyArguments().Returns(armament);

			var controller = new ArmamentController(_armamentRepository, _mapper);

			// Act
			var result = controller.GetArmament(1); // Replace with the desired Armament ID

			// Assert
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(OkObjectResult));
		}
	}
}
