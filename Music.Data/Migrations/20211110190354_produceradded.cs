using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWeb.Data.Migrations
{
    public partial class produceradded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Producers_ProducerId",
                table: "Musics");

            migrationBuilder.AlterColumn<int>(
                name: "ProducerId",
                table: "Musics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Producers_ProducerId",
                table: "Musics",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "ProducerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Producers_ProducerId",
                table: "Musics");

            migrationBuilder.AlterColumn<int>(
                name: "ProducerId",
                table: "Musics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Producers_ProducerId",
                table: "Musics",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "ProducerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
