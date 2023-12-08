using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantApp.Migrations
{
    /// <inheritdoc />
    public partial class zadnja : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jela_Restorani_restoran_id",
                table: "Jela");

            migrationBuilder.AlterColumn<int>(
                name: "restoran_id",
                table: "Jela",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Jela_Restorani_restoran_id",
                table: "Jela",
                column: "restoran_id",
                principalTable: "Restorani",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jela_Restorani_restoran_id",
                table: "Jela");

            migrationBuilder.AlterColumn<int>(
                name: "restoran_id",
                table: "Jela",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Jela_Restorani_restoran_id",
                table: "Jela",
                column: "restoran_id",
                principalTable: "Restorani",
                principalColumn: "Id");
        }
    }
}
