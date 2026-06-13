using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KisaanApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kisans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalZameen = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OwnZameen = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LeaseZameen = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FreeZameen = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalLeaseAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LeaseAmountPerAcre = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fasals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcreUsed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SowingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HarvestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KisanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fasals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fasals_Kisans_KisanId",
                        column: x => x.KisanId,
                        principalTable: "Kisans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ozars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    KisanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ozars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ozars_Kisans_KisanId",
                        column: x => x.KisanId,
                        principalTable: "Kisans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zameens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalAcre = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsLease = table.Column<bool>(type: "bit", nullable: false),
                    LeaseAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LeaseAmountPerAcre = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KisanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zameens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zameens_Kisans_KisanId",
                        column: x => x.KisanId,
                        principalTable: "Kisans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fasals_KisanId",
                table: "Fasals",
                column: "KisanId");

            migrationBuilder.CreateIndex(
                name: "IX_Ozars_KisanId",
                table: "Ozars",
                column: "KisanId");

            migrationBuilder.CreateIndex(
                name: "IX_Zameens_KisanId",
                table: "Zameens",
                column: "KisanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fasals");

            migrationBuilder.DropTable(
                name: "Ozars");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Zameens");

            migrationBuilder.DropTable(
                name: "Kisans");
        }
    }
}
