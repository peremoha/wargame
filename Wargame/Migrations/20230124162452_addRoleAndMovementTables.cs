using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wargame.Migrations
{
    /// <inheritdoc />
    public partial class addRoleAndMovementTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAmphibious",
                table: "Tanks",
                newName: "IsPrototype");

            migrationBuilder.AddColumn<int>(
                name: "MovementId",
                table: "Tanks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Tanks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Movement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_MovementId",
                table: "Tanks",
                column: "MovementId");

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_RoleId",
                table: "Tanks",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tanks_Movement_MovementId",
                table: "Tanks",
                column: "MovementId",
                principalTable: "Movement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tanks_Role_RoleId",
                table: "Tanks",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tanks_Movement_MovementId",
                table: "Tanks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tanks_Role_RoleId",
                table: "Tanks");

            migrationBuilder.DropTable(
                name: "Movement");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Tanks_MovementId",
                table: "Tanks");

            migrationBuilder.DropIndex(
                name: "IX_Tanks_RoleId",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "MovementId",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Tanks");

            migrationBuilder.RenameColumn(
                name: "IsPrototype",
                table: "Tanks",
                newName: "IsAmphibious");
        }
    }
}
