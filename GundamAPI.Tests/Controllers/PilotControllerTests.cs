using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using GundamAPI.Controllers;
using GundamAPI.Dto;
using GundamAPI.Interfaces;
using GundamAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GundamAPI.Tests.Controllers
{
	public class PilotControllerTests
	{
		private readonly IPilotRepository _pilotRepository;
		private readonly IMapper _mapper;
        public PilotControllerTests()
        {
            _pilotRepository = A.Fake<IPilotRepository>();
            _mapper = A.Fake<IMapper>();
        }

		[Fact]
		public void PilotController_GetPilots_ReturnsOk()
		{
			// Arrange
			var pilots = A.Fake<ICollection<PilotDto>>();
			var pilotList = A.Fake<List<PilotDto>>();
			A.CallTo(() => _mapper.Map<List<PilotDto>>(pilots)).Returns(pilotList);
			var controller = new PilotController(_pilotRepository, _mapper);

			// Act
			var result = controller.GetPilots();

			// Assert
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(OkObjectResult));
		}

		[Fact]
		public void PilotController_GetPilot_ReturnsOk()
		{
			// Arrange
			// Create a fake feature object
			var pilotId = 1;
			var pilot = A.Fake<Pilot>();
			var pilotDto = A.Fake<PilotDto>();

			A.CallTo(() => _pilotRepository.PilotExists(pilotId)).WithAnyArguments().Returns(true);

			A.CallTo(() => _pilotRepository.GetPilot(pilotId)).WithAnyArguments().Returns(pilot);

			var controller = new PilotController(_pilotRepository, _mapper);

			// Act
			var result = controller.GetPilot(pilotId); // Replace with the desired Armament ID

			// Assert
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(OkObjectResult));
		}

		[Fact]
		public void PilotController_GetPilotByGundam_ReturnsOk()
		{
			// Arrange
			var gundamId = 1;
			var pilot = A.Fake<Pilot>();
			var pilotDto = A.Fake<PilotDto>();

		
			A.CallTo(() => _pilotRepository.GetPilotByGundam(gundamId)).WithAnyArguments().Returns(pilot);

			A.CallTo(() => _mapper.Map<PilotDto>(pilot)).Returns(pilotDto);

			var controller = new PilotController(_pilotRepository, _mapper);

			// Act
			var result = controller.GetPilotByGundam(gundamId);

			// Assert
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(OkObjectResult));
		}

		[Fact]
		public void PilotController_GetGundamOfAPilot_ReturnsOk()
		{
			var pilotId = 1;
			var gundam = A.Fake<Gundam>();
			var gundamDto = A.Fake<GundamDto>();

			A.CallTo(() => _pilotRepository.PilotExists(pilotId)).Returns(true);

			A.CallTo(() => _pilotRepository.GetGundamOfAPilot(pilotId)).WithAnyArguments().Returns(gundam);

			A.CallTo(() => _mapper.Map<GundamDto>(gundam)).Returns(gundamDto);

			var controller = new PilotController(_pilotRepository, _mapper);

			// Act

			var result = controller.GetGundamOfAPilot(pilotId);

			// Assert
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(OkObjectResult));
		}
	}
}
