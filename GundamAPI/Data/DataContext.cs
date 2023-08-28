﻿using Microsoft.EntityFrameworkCore;
using GundamAPI.Models;

namespace GundamAPI.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<Armaments> Armaments { get; set; }
		public DbSet<Faction> Factions { get; set; }
		public DbSet<Features> Features { get; set; }
		public DbSet<Gundam> Gundams { get; set; }
		public DbSet<Pilot> Pilots { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<Reviewer> Reviewers { get; set; }
		public DbSet<Show> Shows { get; set; }
		public DbSet<GundamArmament> GundamArmaments { get; set; }
		public DbSet<GundamFeatures> GundamFeatures { get; set; }

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
		
			modelBuilder.Entity<GundamFeatures>()
				.HasKey(gf => new { gf.GundamId, gf.FeatureId });
			modelBuilder.Entity<GundamFeatures>()
				.HasOne(g => g.Gundam).WithMany(gf => gf.GundamFeatures)
				.HasForeignKey(f => f.FeatureId);
			modelBuilder.Entity<GundamFeatures>()
				.HasOne(f => f.Features).WithMany(gf => gf.GundamFeatures)
				.HasForeignKey(g => g.GundamId);
		}
	}
}
