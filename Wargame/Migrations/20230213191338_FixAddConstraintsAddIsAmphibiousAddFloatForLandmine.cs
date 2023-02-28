using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wargame.Migrations
{
    /// <inheritdoc />
    public partial class FixAddConstraintsAddIsAmphibiousAddFloatForLandmine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Types",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Stealth",
                table: "Tanks",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "Tanks",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Optics",
                table: "Tanks",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tanks",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Tanks",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAmphibious",
                table: "Tanks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Properties",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Movements",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Flag",
                table: "Countries",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Armaments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Landmine",
                table: "Armaments",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Armaments",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Caliber",
                table: "Armaments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Types_Name",
                table: "Types",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Tanks_Name",
                table: "Tanks",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Roles_Name",
                table: "Roles",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Properties_Name",
                table: "Properties",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Movements_Name",
                table: "Movements",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Countries_Name",
                table: "Countries",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Armaments_Name",
                table: "Armaments",
                column: "Name");

            migrationBuilder.AddCheckConstraint(
                name: "BackArmor",
                table: "Tanks",
                sql: "BackArmor >= 0 AND BackArmor <= 400");

            migrationBuilder.AddCheckConstraint(
                name: "FrontArmor",
                table: "Tanks",
                sql: "FrontArmor >= 0 AND FrontArmor <= 400");

            migrationBuilder.AddCheckConstraint(
                name: "Fuel",
                table: "Tanks",
                sql: "Fuel >= 0 AND Fuel <= 2500");

            migrationBuilder.AddCheckConstraint(
                name: "Price",
                table: "Tanks",
                sql: "Price >= 0 AND Price <= 200");

            migrationBuilder.AddCheckConstraint(
                name: "Range1",
                table: "Tanks",
                sql: "Range >= 0 AND Range <= 1000");

            migrationBuilder.AddCheckConstraint(
                name: "RoadSpeed",
                table: "Tanks",
                sql: "RoadSpeed >= 0 AND RoadSpeed <= 150");

            migrationBuilder.AddCheckConstraint(
                name: "SideArmor",
                table: "Tanks",
                sql: "SideArmor >= 0 AND SideArmor <= 3000");

            migrationBuilder.AddCheckConstraint(
                name: "Speed",
                table: "Tanks",
                sql: "Speed >= 0 AND Speed <= 120");

            migrationBuilder.AddCheckConstraint(
                name: "Strenght",
                table: "Tanks",
                sql: "Strenght >= 0 AND Strenght <= 10");

            migrationBuilder.AddCheckConstraint(
                name: "UpperArmor",
                table: "Tanks",
                sql: "UpperArmor >= 0 AND UpperArmor <= 3000");

            migrationBuilder.AddCheckConstraint(
                name: "Year",
                table: "Tanks",
                sql: "Year >= 1940 AND Year <= 2010");

            migrationBuilder.AddCheckConstraint(
                name: "Accuracy",
                table: "Armaments",
                sql: "Accuracy >= 0 AND Accuracy <= 100");

            migrationBuilder.AddCheckConstraint(
                name: "ArmorPenetration",
                table: "Armaments",
                sql: "ArmorPenetration >= 0 AND ArmorPenetration <= 30");

            migrationBuilder.AddCheckConstraint(
                name: "Landmine",
                table: "Armaments",
                sql: "Landmine >= 0 AND Landmine <= 10");

            migrationBuilder.AddCheckConstraint(
                name: "Range",
                table: "Armaments",
                sql: "Range >= 0 AND Range <= 3000");

            migrationBuilder.AddCheckConstraint(
                name: "RangeAircraft",
                table: "Armaments",
                sql: "RangeAircraft >= 0 AND RangeAircraft <= 3000");

            migrationBuilder.AddCheckConstraint(
                name: "RangeHelicopter",
                table: "Armaments",
                sql: "RangeHelicopter >= 0 AND RangeHelicopter <= 3000");

            migrationBuilder.AddCheckConstraint(
                name: "RateOfFire",
                table: "Armaments",
                sql: "RateOfFire >= 0 AND RateOfFire <= 3000");

            migrationBuilder.AddCheckConstraint(
                name: "Stability",
                table: "Armaments",
                sql: "Stability >= 0 AND Stability <= 100");

            migrationBuilder.AddCheckConstraint(
                name: "Suppression",
                table: "Armaments",
                sql: "Suppression >= 0 AND Suppression <= 400");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Types_Name",
                table: "Types");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Tanks_Name",
                table: "Tanks");

            migrationBuilder.DropCheckConstraint(
                name: "BackArmor",
                table: "Tanks");

            migrationBuilder.DropCheckConstraint(
                name: "FrontArmor",
                table: "Tanks");

            migrationBuilder.DropCheckConstraint(
                name: "Fuel",
                table: "Tanks");

            migrationBuilder.DropCheckConstraint(
                name: "Price",
                table: "Tanks");

            migrationBuilder.DropCheckConstraint(
                name: "Range1",
                table: "Tanks");

            migrationBuilder.DropCheckConstraint(
                name: "RoadSpeed",
                table: "Tanks");

            migrationBuilder.DropCheckConstraint(
                name: "SideArmor",
                table: "Tanks");

            migrationBuilder.DropCheckConstraint(
                name: "Speed",
                table: "Tanks");

            migrationBuilder.DropCheckConstraint(
                name: "Strenght",
                table: "Tanks");

            migrationBuilder.DropCheckConstraint(
                name: "UpperArmor",
                table: "Tanks");

            migrationBuilder.DropCheckConstraint(
                name: "Year",
                table: "Tanks");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Roles_Name",
                table: "Roles");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Properties_Name",
                table: "Properties");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Movements_Name",
                table: "Movements");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Countries_Name",
                table: "Countries");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Armaments_Name",
                table: "Armaments");

            migrationBuilder.DropCheckConstraint(
                name: "Accuracy",
                table: "Armaments");

            migrationBuilder.DropCheckConstraint(
                name: "ArmorPenetration",
                table: "Armaments");

            migrationBuilder.DropCheckConstraint(
                name: "Landmine",
                table: "Armaments");

            migrationBuilder.DropCheckConstraint(
                name: "Range",
                table: "Armaments");

            migrationBuilder.DropCheckConstraint(
                name: "RangeAircraft",
                table: "Armaments");

            migrationBuilder.DropCheckConstraint(
                name: "RangeHelicopter",
                table: "Armaments");

            migrationBuilder.DropCheckConstraint(
                name: "RateOfFire",
                table: "Armaments");

            migrationBuilder.DropCheckConstraint(
                name: "Stability",
                table: "Armaments");

            migrationBuilder.DropCheckConstraint(
                name: "Suppression",
                table: "Armaments");

            migrationBuilder.DropColumn(
                name: "IsAmphibious",
                table: "Tanks");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Types",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Stealth",
                table: "Tanks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "Tanks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Optics",
                table: "Tanks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tanks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Tanks",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Movements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Flag",
                table: "Countries",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Armaments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Landmine",
                table: "Armaments",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Armaments",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Caliber",
                table: "Armaments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
