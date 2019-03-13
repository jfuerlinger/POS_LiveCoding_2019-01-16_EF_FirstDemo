using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDemoLiveCoding.Persistence.Migrations
{
    public partial class SeedTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Teams(Name) VALUES('Ferrari')");
            migrationBuilder.Sql("INSERT INTO Teams(Name) VALUES('Mercedes')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Teams");
        }
    }
}
