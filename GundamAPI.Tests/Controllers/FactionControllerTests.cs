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
	public class FactionControllerTests
	{
		private readonly IFactionRepository _factionRepository;
		private readonly IMapper _mapper;
        public FactionControllerTests()
        {
            _factionRepository = A.Fake<IFactionRepository>();
            _mapper = A.Fake<IMapper>();
        }

		[Fact]
		public void FactionController_GetFactions_ReturnsOk()
		{
			// Arrange
			var factions = A.Fake<ICollection<FactionDto>>();
			var factionList = A.Fake<List<FactionDto>>();
			A.CallTo(() => _mapper.Map<List<FactionDto>>(factions)).Returns(factionList);
			var controller = new FactionController(_factionRepository, _mapper);

			// Act
			var result = controller.GetFactions();

			// Assert
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(OkObjectResult));
		}

		[Fact]
		public void FactionController_GetFaction_ReturnsOk()
		{
			// Arrange
			// Create a fake Armament object
			var factionId = 1;
			var faction = A.Fake<Faction>();
			var factionDto = A.Fake<FactionDto>();

			A.CallTo(() => _factionRepository.FactionExists(factionId)).WithAnyArguments().Returns(true);

			A.CallTo(() => _factionRepository.GetFaction(factionId)).WithAnyArguments().Returns(faction);

			var controller = new FactionController(_factionRepository, _mapper);

			// Act
			var result = controller.GetFaction(1); // Replace with the desired Faction ID

			// Assert
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(OkObjectResult));
		}

		[Fact]
		public void FactionController_GetFactionByPilot_ReturnsOk()
		{
			// Arrange
			var pilotId = 1;
			var faction = A.Fake<Faction>();
			var factionDto = A.Fake<FactionDto>();

			A.CallTo(() => _factionRepository.GetFactionByPilot(pilotId)).Returns(faction);

			A.CallTo(() => _mapper.Map<FactionDto>(faction)).Returns(factionDto);

			var controller = new FactionController(_factionRepository, _mapper);

			// Act

			var result = controller.GetFactionByPilot(pilotId);

			// Assert

			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(OkObjectResult));
		}

		[Fact]
		public void FactionController_GetPilotsByFaction_ReturnsOk()
		{
			// Arrange
			var factionId = 1;
			var pilots = A.CollectionOfFake<Pilot>(3);
			var pilotDtos = A.CollectionOfFake<PilotDto>(3);

			A.CallTo(() => _factionRepository.FactionExists(factionId)).Returns(true);

			A.CallTo(() => _factionRepository.GetPilotsFromAFaction(factionId)).Returns(pilots);

			A.CallTo(() => _mapper.Map<PilotDto>(A<Pilot>._)).ReturnsNextFromSequence(pilotDtos.ToArray());
			
			var controller = new FactionController(_factionRepository, _mapper);
			// Act

			var result = controller.GetPilotsFromAFaction(factionId);

			// Assert
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(OkObjectResult));
		}


	}
}
