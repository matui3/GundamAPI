using AutoMapper;
using GundamAPI.Dto;
using GundamAPI.Models;

namespace GundamAPI.Helper
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles() 
		{
			CreateMap<Armament, ArmamentDto>();
			CreateMap<Faction, FactionDto>();
			CreateMap<Feature, FeatureDto>();
			CreateMap<Gundam, GundamDto>();
			CreateMap<Pilot, PilotDto>();
			CreateMap<Review, ReviewDto>();
			CreateMap<Reviewer, ReviewerDto>();
			CreateMap<Show, ShowDto>();
		}
	}
}
