using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rubrica.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCityWithSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Contacts",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.UniqueConstraint("AK_City_Name", x => x.Name);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Milano" },
                    { 2, "Roma" },
                    { 3, "Napoli" },
                    { 4, "Torino" },
                    { 5, "Firenze" },
                    { 6, "Venezia" },
                    { 7, "Bologna" },
                    { 8, "Genova" },
                    { 9, "Palermo" },
                    { 10, "Bari" },
                    { 11, "Parigi" },
                    { 12, "Londra" },
                    { 13, "Madrid" },
                    { 14, "Barcellona" },
                    { 15, "Berlino" },
                    { 16, "Monaco" },
                    { 17, "Amsterdam" },
                    { 18, "Vienna" },
                    { 19, "Zurigo" },
                    { 20, "Stoccolma" },
                    { 21, "Copenhagen" },
                    { 22, "Oslo" },
                    { 23, "Helsinki" },
                    { 24, "Dublino" },
                    { 25, "Lisbona" },
                    { 26, "Atene" },
                    { 27, "Praga" },
                    { 28, "Budapest" },
                    { 29, "Varsavia" },
                    { 30, "Mosca" },
                    { 31, "Tokyo" },
                    { 32, "Pechino" },
                    { 33, "Shanghai" },
                    { 34, "Seoul" },
                    { 35, "Mumbai" },
                    { 36, "Nuova Delhi" },
                    { 37, "Bangkok" },
                    { 38, "Singapore" },
                    { 39, "Sydney" },
                    { 40, "Melbourne" },
                    { 41, "New York" },
                    { 42, "Los Angeles" },
                    { 43, "Chicago" },
                    { 44, "San Francisco" },
                    { 45, "Toronto" },
                    { 46, "Vancouver" },
                    { 47, "Città del Messico" },
                    { 48, "San Paolo" },
                    { 49, "Buenos Aires" },
                    { 50, "Il Cairo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_City",
                table: "Contacts",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_City_Name",
                table: "City",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_City_City",
                table: "Contacts",
                column: "City",
                principalTable: "City",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_City_City",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_City",
                table: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);
        }
    }
}
