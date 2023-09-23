using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GundamAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviewers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviewers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Episodes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gundams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactionId = table.Column<int>(type: "int", nullable: false),
                    PilotId = table.Column<int>(type: "int", nullable: false),
                    ShowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gundams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gundams_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gundams_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArmamentGundam",
                columns: table => new
                {
                    ArmamentsId = table.Column<int>(type: "int", nullable: false),
                    GundamsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmamentGundam", x => new { x.ArmamentsId, x.GundamsId });
                    table.ForeignKey(
                        name: "FK_ArmamentGundam_Armaments_ArmamentsId",
                        column: x => x.ArmamentsId,
                        principalTable: "Armaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmamentGundam_Gundams_GundamsId",
                        column: x => x.GundamsId,
                        principalTable: "Gundams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeatureGundam",
                columns: table => new
                {
                    FeaturesId = table.Column<int>(type: "int", nullable: false),
                    GundamsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureGundam", x => new { x.FeaturesId, x.GundamsId });
                    table.ForeignKey(
                        name: "FK_FeatureGundam_Features_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeatureGundam_Gundams_GundamsId",
                        column: x => x.GundamsId,
                        principalTable: "Gundams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GundamArmaments",
                columns: table => new
                {
                    GundamId = table.Column<int>(type: "int", nullable: false),
                    ArmamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GundamArmaments", x => new { x.GundamId, x.ArmamentId });
                    table.ForeignKey(
                        name: "FK_GundamArmaments_Armaments_GundamId",
                        column: x => x.GundamId,
                        principalTable: "Armaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GundamArmaments_Gundams_ArmamentId",
                        column: x => x.ArmamentId,
                        principalTable: "Gundams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GundamFeatures",
                columns: table => new
                {
                    GundamId = table.Column<int>(type: "int", nullable: false),
                    FeatureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GundamFeatures", x => new { x.GundamId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_GundamFeatures_Features_GundamId",
                        column: x => x.GundamId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GundamFeatures_Gundams_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Gundams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pilots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GundamId = table.Column<int>(type: "int", nullable: false),
                    ShowId = table.Column<int>(type: "int", nullable: false),
                    FactionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pilots_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pilots_Gundams_GundamId",
                        column: x => x.GundamId,
                        principalTable: "Gundams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pilots_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewerId = table.Column<int>(type: "int", nullable: false),
                    GundamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Gundams_GundamId",
                        column: x => x.GundamId,
                        principalTable: "Gundams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Reviewers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "Reviewers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArmamentGundam_GundamsId",
                table: "ArmamentGundam",
                column: "GundamsId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureGundam_GundamsId",
                table: "FeatureGundam",
                column: "GundamsId");

            migrationBuilder.CreateIndex(
                name: "IX_GundamArmaments_ArmamentId",
                table: "GundamArmaments",
                column: "ArmamentId");

            migrationBuilder.CreateIndex(
                name: "IX_GundamFeatures_FeatureId",
                table: "GundamFeatures",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Gundams_FactionId",
                table: "Gundams",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Gundams_ShowId",
                table: "Gundams",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Pilots_FactionId",
                table: "Pilots",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Pilots_GundamId",
                table: "Pilots",
                column: "GundamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pilots_ShowId",
                table: "Pilots",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_GundamId",
                table: "Reviews",
                column: "GundamId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewerId",
                table: "Reviews",
                column: "ReviewerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArmamentGundam");

            migrationBuilder.DropTable(
                name: "FeatureGundam");

            migrationBuilder.DropTable(
                name: "GundamArmaments");

            migrationBuilder.DropTable(
                name: "GundamFeatures");

            migrationBuilder.DropTable(
                name: "Pilots");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Armaments");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Gundams");

            migrationBuilder.DropTable(
                name: "Reviewers");

            migrationBuilder.DropTable(
                name: "Factions");

            migrationBuilder.DropTable(
                name: "Shows");
        }
    }
}
