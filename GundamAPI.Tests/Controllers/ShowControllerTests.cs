using AutoMapper;
using FakeItEasy;
using GundamAPI.Controllers;
using GundamAPI.Dto;
using GundamAPI.Interfaces;
using GundamAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GundamAPI.Tests.Controllers
{
	public class ShowControllerTests
	{
		private readonly IReviewRepository _reviewRepository;
		private readonly IMapper _mapper;
		//	public ReviewControllerTests()
		//	{
		//		_reviewRepository = A.Fake<IReviewRepository>();
		//		_mapper = A.Fake<IMapper>();
		//	}

		//	[Fact]
		//	public void PilotController_GetPilots_ReturnsOk()
		//	{
		//		// Arrange
		//		var pilots = A.Fake<ICollection<PilotDto>>();
		//		var pilotList = A.Fake<List<PilotDto>>();
		//		A.CallTo(() => _mapper.Map<List<PilotDto>>(pilots)).Returns(pilotList);
		//		var controller = new PilotController(_pilotRepository, _mapper);

		//		// Act
		//		var result = controller.GetPilots();

		//		// Assert
		//		result.Should().NotBeNull();
		//		result.Should().BeOfType(typeof(OkObjectResult));
		//	}

		//	[Fact]
		//	public void PilotController_GetPilot_ReturnsOk()
		//	{
		//		// Arrange
		//		// Create a fake feature object
		//		var pilotId = 1;
		//		var pilot = A.Fake<Pilot>();
		//		var pilotDto = A.Fake<PilotDto>();

		//		A.CallTo(() => _pilotRepository.PilotExists(pilotId)).WithAnyArguments().Returns(true);

		//		A.CallTo(() => _pilotRepository.GetPilot(pilotId)).WithAnyArguments().Returns(pilot);

		//		var controller = new PilotController(_pilotRepository, _mapper);

		//		// Act
		//		var result = controller.GetPilot(pilotId); // Replace with the desired Armament ID

		//		// Assert
		//		result.Should().NotBeNull();
		//		result.Should().BeOfType(typeof(OkObjectResult));
		//	}
	}
}
