using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDemoLiveCoding.Persistence.Migrations
{
    public partial class AddTeamTableAndRemoveTeamStringColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Team",
                table: "Drivers");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Drivers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_TeamId",
                table: "Drivers",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Teams_TeamId",
                table: "Drivers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Teams_TeamId",
                table: "Drivers");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_TeamId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Drivers");

            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "Drivers",
                nullable: true);
        }
    }
}
