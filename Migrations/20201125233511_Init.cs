using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DotnetWebAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarCategories",
                columns: table => new
                {
                    CarCategoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCategories", x => x.CarCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    ConditionsId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.ConditionsId);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DriverNick = table.Column<string>(type: "text", nullable: false),
                    FavouriteNumber = table.Column<int>(type: "integer", nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    TrackId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrackName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.TrackId);
                });

            migrationBuilder.CreateTable(
                name: "CarCarCategory",
                columns: table => new
                {
                    CarCategoryId = table.Column<int>(type: "integer", nullable: false),
                    CarsCarId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCarCategory", x => new { x.CarCategoryId, x.CarsCarId });
                    table.ForeignKey(
                        name: "FK_CarCarCategory_CarCategories_CarCategoryId",
                        column: x => x.CarCategoryId,
                        principalTable: "CarCategories",
                        principalColumn: "CarCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarCarCategory_Cars_CarsCarId",
                        column: x => x.CarsCarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rallies",
                columns: table => new
                {
                    RallyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RallyName = table.Column<string>(type: "text", nullable: false),
                    EventDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CarCategoryId = table.Column<int>(type: "integer", nullable: true),
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rallies", x => x.RallyId);
                    table.ForeignKey(
                        name: "FK_Rallies_CarCategories_CarCategoryId",
                        column: x => x.CarCategoryId,
                        principalTable: "CarCategories",
                        principalColumn: "CarCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rallies_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RallyEntries",
                columns: table => new
                {
                    RallyEntryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartingNumber = table.Column<int>(type: "integer", nullable: false),
                    CarId = table.Column<int>(type: "integer", nullable: false),
                    DriverId = table.Column<int>(type: "integer", nullable: false),
                    RallyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RallyEntries", x => x.RallyEntryId);
                    table.ForeignKey(
                        name: "FK_RallyEntries_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RallyEntries_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RallyEntries_Rallies_RallyId",
                        column: x => x.RallyId,
                        principalTable: "Rallies",
                        principalColumn: "RallyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    StageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RallyId = table.Column<int>(type: "integer", nullable: false),
                    TrackId = table.Column<int>(type: "integer", nullable: false),
                    ConditionsId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.StageId);
                    table.ForeignKey(
                        name: "FK_Stages_Conditions_ConditionsId",
                        column: x => x.ConditionsId,
                        principalTable: "Conditions",
                        principalColumn: "ConditionsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stages_Rallies_RallyId",
                        column: x => x.RallyId,
                        principalTable: "Rallies",
                        principalColumn: "RallyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stages_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    ResultId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Time = table.Column<TimeSpan>(type: "interval", nullable: false),
                    DNF = table.Column<bool>(type: "boolean", nullable: false),
                    RallyEntryId = table.Column<int>(type: "integer", nullable: false),
                    StageId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.ResultId);
                    table.ForeignKey(
                        name: "FK_Results_RallyEntries_RallyEntryId",
                        column: x => x.RallyEntryId,
                        principalTable: "RallyEntries",
                        principalColumn: "RallyEntryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_Stages_StageId",
                        column: x => x.StageId,
                        principalTable: "Stages",
                        principalColumn: "StageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarCarCategory_CarsCarId",
                table: "CarCarCategory",
                column: "CarsCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rallies_CarCategoryId",
                table: "Rallies",
                column: "CarCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Rallies_OrderId",
                table: "Rallies",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_RallyEntries_CarId",
                table: "RallyEntries",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_RallyEntries_DriverId",
                table: "RallyEntries",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_RallyEntries_RallyId",
                table: "RallyEntries",
                column: "RallyId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_RallyEntryId",
                table: "Results",
                column: "RallyEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_StageId",
                table: "Results",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Stages_ConditionsId",
                table: "Stages",
                column: "ConditionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Stages_RallyId",
                table: "Stages",
                column: "RallyId");

            migrationBuilder.CreateIndex(
                name: "IX_Stages_TrackId",
                table: "Stages",
                column: "TrackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarCarCategory");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "RallyEntries");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "Rallies");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "CarCategories");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
