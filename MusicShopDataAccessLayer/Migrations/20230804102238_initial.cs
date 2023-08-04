using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicShopDataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAutho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PassWordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PassWordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAutho", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Singer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedYear = table.Column<int>(type: "int", nullable: false),
                    RecordCompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecordCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyYear = table.Column<int>(type: "int", nullable: false),
                    CompanyValue = table.Column<int>(type: "int", nullable: false),
                    AlbumId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecordCompanies_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedDate", "Email", "Name", "Phone", "UpdatedDate" },
                values: new object[,]
                {
                    { 100, new DateTime(2023, 8, 4, 13, 22, 37, 876, DateTimeKind.Local).AddTicks(7663), "ceren@gmail.com", "Ceren", "1234567890", null },
                    { 101, new DateTime(2023, 8, 4, 13, 22, 37, 876, DateTimeKind.Local).AddTicks(7666), "tuana2@gmail.com", "Tuana", "9876543210", null }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "CreatedDate", "CreatedYear", "CustomerId", "Name", "RecordCompanyName", "Singer", "UpdatedDate" },
                values: new object[,]
                {
                    { 1000, new DateTime(2023, 8, 4, 13, 22, 37, 876, DateTimeKind.Local).AddTicks(7370), 2021, 100, "UltraVolence", "Atlanta", "Lana", null },
                    { 1001, new DateTime(2023, 8, 4, 13, 22, 37, 876, DateTimeKind.Local).AddTicks(7382), 2022, 101, "NormanFW", "Parental", "Lana", null }
                });

            migrationBuilder.InsertData(
                table: "RecordCompanies",
                columns: new[] { "Id", "AlbumId", "CompanyValue", "CompanyYear", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 10, 1000, 1000000, 1990, new DateTime(2023, 8, 4, 13, 22, 37, 876, DateTimeKind.Local).AddTicks(7812), "Atlanta", null },
                    { 11, 1001, 2000000, 2000, new DateTime(2023, 8, 4, 13, 22, 37, 876, DateTimeKind.Local).AddTicks(7815), "Parental", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_CustomerId",
                table: "Albums",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordCompanies_AlbumId",
                table: "RecordCompanies",
                column: "AlbumId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecordCompanies");

            migrationBuilder.DropTable(
                name: "UserAutho");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
