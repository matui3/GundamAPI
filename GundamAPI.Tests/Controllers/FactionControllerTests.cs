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
			var armamentDto = A.Fake<FactionDto>();

			A.CallTo(() => _factionRepository.FactionExists(factionId)).WithAnyArguments().Returns(true);

			A.CallTo(() => _factionRepository.GetFaction(factionId)).WithAnyArguments().Returns(faction);

			var controller = new FactionController(_factionRepository, _mapper);

			// Act
			var result = controller.GetFaction(1); // Replace with the desired Armament ID

			// Assert
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(OkObjectResult));
		}

		
	}
}
