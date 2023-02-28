using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wargame.Migrations
{
    /// <inheritdoc />
    public partial class addCaliberAndFuelFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Range",
                table: "Tanks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Fuel",
                table: "Tanks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Caliber",
                table: "Armaments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fuel",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "Caliber",
                table: "Armaments");

            migrationBuilder.AlterColumn<string>(
                name: "Range",
                table: "Tanks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
