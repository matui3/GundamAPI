using GundamAPI.Data;
using GundamAPI.Models;

namespace GundamAPI
{
	public class Seed
	{
		private readonly DataContext context;
        public Seed(DataContext context)
        {
            this.context = context;
        }

        public void SeedDataContext()
        {
           if (!context.Factions.Any())
           {
                context.Factions.AddRange(
                    new Faction { Name = "Faction A" },
                    new Faction { Name = "Faction B" });
                context.SaveChanges();
           }

           if (!context.Shows.Any())
            {
                context.Shows.AddRange(
                    new Show { Name = "Show 1", Episodes = 1, ReleaseDate = new DateTime() },
                    new Show { Name = "Show 2", Episodes = 1, ReleaseDate = new DateTime() });
                context.SaveChanges();
            }
           if (!context.Pilots.Any())
			{
                var factionA = context.Factions.FirstOrDefault(f => f.Id == 1);
                var factionB = context.Factions.FirstOrDefault(f => f.Id == 2);

                var showA = context.Shows.FirstOrDefault(s => s.Id == 1);
                var showB = context.Shows.FirstOrDefault(s => s.Id == 2);

                context.Pilots.AddRange(
                    new Pilot { Name = "Pilot 1", FactionId = factionA.Id, Faction = factionA, ShowId = showA.Id, Show = showA },
                    new Pilot { Name = "Pilot 2", FactionId = factionB.Id, Faction = factionB, ShowId = showB.Id, Show = showB });
                context.SaveChanges();
            }

			if (!context.Gundams.Any())
			{
				var factionA = context.Factions.FirstOrDefault(f => f.Id == 1);
				var factionB = context.Factions.FirstOrDefault(f => f.Id == 2);

				var showA = context.Shows.FirstOrDefault(s => s.Id == 1);
				var showB = context.Shows.FirstOrDefault(s => s.Id == 2);

				var pilotA = context.Pilots.FirstOrDefault(p => p.Id == 1);
				var pilotB = context.Pilots.FirstOrDefault(p => p.Id == 2);

				context.Gundams.AddRange(
					new Gundam { Model = "Gundam Model 1", FactionId = factionA.Id, Faction = factionA, ShowId = showA.Id, Show = showA, PilotId = pilotA.Id, Pilot = pilotA },
					new Gundam { Model = "Gundam Model 2", FactionId = factionB.Id, Faction = factionB, ShowId = showB.Id, Show = showB, PilotId = pilotB.Id, Pilot = pilotB });
				context.SaveChanges();
			}

			if (!context.Reviewers.Any())
			{
				context.Reviewers.AddRange(
					new Reviewer { Name = "Reviewer 1" },
					new Reviewer { Name = "Reviewer 2" });
				context.SaveChanges();
			}

			if (!context.Reviews.Any())
			{
				var reviewerA = context.Reviewers.FirstOrDefault(r => r.Id == 1);
				var reviewerB = context.Reviewers.FirstOrDefault(r => r.Id == 2);

				var gundamA = context.Gundams.FirstOrDefault(g => g.Id == 1);
				var gundamB = context.Gundams.FirstOrDefault(g => g.Id == 2);

				context.Reviews.AddRange(
					new Review { Title = "Review 1", Text = "Good", ReviewerId = reviewerA.Id, Reviewer = reviewerA, GundamId = gundamA.Id, Gundam = gundamA },
					new Review { Title = "Review 2", Text = "Good", ReviewerId = reviewerB.Id, Reviewer = reviewerB, GundamId = gundamA.Id, Gundam = gundamB });
				context.SaveChanges();
			}

			if (!context.Armaments.Any())
			{
				var gundamA = context.Gundams.FirstOrDefault(g => g.Id == 1);
				var gundamB = context.Gundams.FirstOrDefault(g => g.Id == 2);

				context.Armaments.AddRange(
					new Armament { Name = "Armament 1", Description = "Armament Description 1" },
					new Armament { Name = "Armament 2", Description = "Armament Description 2" },
					new Armament { Name = "Armament 3", Description = "Armament Description 3" },
					new Armament { Name = "Armament 4", Description = "Armament Description 4" });
				context.SaveChanges();

				var armamentA = context.Armaments.FirstOrDefault(a => a.Id == 1);
				var armamentB = context.Armaments.FirstOrDefault(a => a.Id == 2);
				var armamentC = context.Armaments.FirstOrDefault(a => a.Id == 3);
				var armamentD = context.Armaments.FirstOrDefault(a => a.Id == 4);


				gundamA.GundamArmaments.Add(new GundamArmament { ArmamentId = 1, Armaments = armamentA });
				gundamA.GundamArmaments.Add(new GundamArmament { ArmamentId = 2, Armaments = armamentB });
				gundamB.GundamArmaments.Add(new GundamArmament { ArmamentId = 3, Armaments = armamentC });
				gundamB.GundamArmaments.Add(new GundamArmament { ArmamentId = 4, Armaments = armamentD });
			}

			if (!context.Features.Any())
			{
				var gundamA = context.Gundams.FirstOrDefault(g => g.Id == 1);
				var gundamB = context.Gundams.FirstOrDefault(g => g.Id == 2);

				context.Features.AddRange(
					new Feature { Name = "Feature 1", Description = "Feature Description 1" },
					new Feature { Name = "Feature 2", Description = "Feature Description 2" },
					new Feature { Name = "Feature 3", Description = "Feature Description 3" },
					new Feature { Name = "Feature 4", Description = "Feature Description 4" });
				context.SaveChanges();

				var featureA = context.Features.FirstOrDefault(a => a.Id == 1);
				var featureB = context.Features.FirstOrDefault(a => a.Id == 2);
				var featureC = context.Features.FirstOrDefault(a => a.Id == 3);
				var featureD = context.Features.FirstOrDefault(a => a.Id == 4);


				gundamA.GundamFeatures.Add(new GundamFeature { FeatureId = 1, Feature = featureA });
				gundamA.GundamFeatures.Add(new GundamFeature { FeatureId = 2, Feature = featureA });
				gundamB.GundamFeatures.Add(new GundamFeature { FeatureId = 3, Feature = featureC });
				gundamB.GundamFeatures.Add(new GundamFeature { FeatureId = 4, Feature = featureD });
			}

			

           



		}
    }
}
