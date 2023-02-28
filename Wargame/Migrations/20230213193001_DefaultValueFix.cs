using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wargame.Migrations
{
    /// <inheritdoc />
    public partial class DefaultValueFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Stealth",
                table: "Tanks",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "Bad",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "Tanks",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "Small",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Optics",
                table: "Tanks",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "Bad",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Caliber",
                table: "Armaments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "Unknown",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Stealth",
                table: "Tanks",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldDefaultValue: "Bad");

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "Tanks",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldDefaultValue: "Small");

            migrationBuilder.AlterColumn<string>(
                name: "Optics",
                table: "Tanks",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldDefaultValue: "Bad");

            migrationBuilder.AlterColumn<string>(
                name: "Caliber",
                table: "Armaments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "Unknown");
        }
    }
}
