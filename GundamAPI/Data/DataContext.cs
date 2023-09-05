using Microsoft.EntityFrameworkCore;
using GundamAPI.Models;

namespace GundamAPI.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<Armament> Armaments { get; set; }
		public DbSet<Faction> Factions { get; set; }
		public DbSet<Feature> Features { get; set; }
		public DbSet<Gundam> Gundams { get; set; }
		public DbSet<Pilot> Pilots { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<Reviewer> Reviewers { get; set; }
		public DbSet<Show> Shows { get; set; }
		public DbSet<GundamArmament> GundamArmaments { get; set; }
		public DbSet<GundamFeature> GundamFeatures { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<GundamArmament>()
				.HasKey(ga => new { ga.GundamId, ga.ArmamentId });
			modelBuilder.Entity<GundamArmament>()
				.HasOne(g => g.Gundam).WithMany(ga => ga.GundamArmaments)
				.HasForeignKey(a => a.ArmamentId);
			modelBuilder.Entity<GundamArmament>()
				.HasOne(a => a.Armaments).WithMany(ga => ga.GundamArmaments)
				.HasForeignKey(g => g.GundamId);
		
			modelBuilder.Entity<GundamFeature>()
				.HasKey(gf => new { gf.GundamId, gf.FeatureId });
			modelBuilder.Entity<GundamFeature>()
				.HasOne(g => g.Gundam).WithMany(gf => gf.GundamFeatures)
				.HasForeignKey(f => f.FeatureId);
			modelBuilder.Entity<GundamFeature>()
				.HasOne(f => f.Feature).WithMany(gf => gf.GundamFeatures)
				.HasForeignKey(g => g.GundamId);

			modelBuilder.Entity<Gundam>()
				.HasOne(g => g.Pilot)
				.WithOne(p => p.Gundam)
				.HasForeignKey<Pilot>(p => p.GundamId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Gundam>()
				.HasMany(g => g.Reviews)
				.WithOne(p => p.Gundam)
				.HasForeignKey(g => g.GundamId);

			modelBuilder.Entity<Show>()
				.HasMany(s => s.Gundams)
				.WithOne(s => s.Show)
				.HasForeignKey(s => s.ShowId);

			modelBuilder.Entity<Show>()
				.HasMany(s => s.Pilots)
				.WithOne(s => s.Show)
				.HasForeignKey(s => s.ShowId);

			modelBuilder.Entity<Pilot>()
				.HasOne(p => p.Gundam)
				.WithOne(g => g.Pilot)
				.IsRequired(false);

			modelBuilder.Entity<Pilot>()
				.HasOne(p => p.Faction)
				.WithMany(f => f.Pilots)
				.HasForeignKey(p => p.FactionId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Pilot>()
				.HasOne(p => p.Show)
				.WithMany(s => s.Pilots)
				.HasForeignKey(p => p.ShowId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Faction>()
				.HasMany(f => f.Gundams)
				.WithOne(g => g.Faction)
				.HasForeignKey(g => g.FactionId);

			modelBuilder.Entity<Faction>()
				.HasMany(f => f.Pilots)
				.WithOne(g => g.Faction)
				.HasForeignKey(g => g.FactionId);

			modelBuilder.Entity<Reviewer>()
				.HasMany(r => r.Reviews)
				.WithOne(r => r.Reviewer)
				.HasForeignKey(r => r.ReviewerId)
				.OnDelete(DeleteBehavior.Restrict);
			
		}
	}
}
