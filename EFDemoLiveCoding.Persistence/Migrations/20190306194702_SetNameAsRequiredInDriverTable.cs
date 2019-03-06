using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDemoLiveCoding.Persistence.Migrations
{
    public partial class SetNameAsRequiredInDriverTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Drivers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Drivers",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
