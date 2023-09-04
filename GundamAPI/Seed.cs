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
                    new Faction { Id = 1, Name = "Faction A" },
                    new Faction { Id = 2, Name = "Faction B" });
                context.SaveChanges();
           }

           if (!context.Shows.Any())
            {
                context.Shows.AddRange(
                    new Show { Id = 1, Name = "Show 1", Episodes = 1, ReleaseDate = new DateTime() },
                    new Show { Id = 2, Name = "Show 2", Episodes = 1, ReleaseDate = new DateTime() });
            }
           if (!context.Pilots.Any())
            {
                var factionA = context.Factions.Where(f => f.Id == 1).FirstOrDefault();
                var factionB = context.Factions.Where(f => f.Id == 2).FirstOrDefault();

                var showA = context.Shows.Where(s => s.Id == 1).FirstOrDefault();
                var showB = context.Shows.Where(s => s.Id == 2).FirstOrDefault();

                context.Pilots.AddRange(
                    new Pilot { Id = 1, Name = "Pilot 1", FactionId = factionA.Id, ShowId = showA.Id },
                    new Pilot { Id = 2, Name = "Pilot 2", FactionId = factionB.Id, ShowId = showB.Id });
                context.SaveChanges();
            }

           if (!context.Reviewers.Any())
            {
                context.Reviewers.AddRange(
                    new Reviewer { Id = 1, Name = "Reviewer 1" },
                    new Reviewer { Id = 2, Name = "Reviewer 2" });
                context.SaveChanges();
            }

           if (!context.Reviews.Any())
            {
                var reviewerA = context.Reviewers.Where(r => r.Id == 1).FirstOrDefault();
                var reviewerB = context.Reviewers.Where(r => r.Id == 2).FirstOrDefault();

                context.Reviews.AddRange(
                    new Review { Id = 1, Title = "Review 1", Text = "Good" },
                    new Review { Id = 2, Title = "Review 2", Text = "Good" });
                context.SaveChanges();
            }


           if (!context.Gundams.Any())
            {
				var factionA = context.Factions.Where(f => f.Id == 1).FirstOrDefault();
				var factionB = context.Factions.Where(f => f.Id == 2).FirstOrDefault();

				var showA = context.Shows.Where(s => s.Id == 1).FirstOrDefault();
				var showB = context.Shows.Where(s => s.Id == 2).FirstOrDefault();

                var pilotA = context.Pilots.Where(p => p.Id == 1).FirstOrDefault();
                var pilotB = context.Pilots.Where(p => p.Id == 2).FirstOrDefault();

                context.Gundams.AddRange(
                    new Gundam { Id = 1, })
			}
        }
    }
}
