using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuksConnectAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "EventTitle", "Location", "TicketPrice" },
                values: new object[,]
                {
                    { 1, "AI & Tech Trends Workshop", "Merensky II Library", 50m },
                    { 2, "Tuks Music Festival", "Amphitheatre", 250m },
                    { 3, "Cultural Day Celebration", "Piazza", 20m },
                    { 4, "Career Expo 2026", "Rautenbach Hall", 0m },
                    { 5, "Intervarsity Rugby Match", "TuksStadium", 180m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
