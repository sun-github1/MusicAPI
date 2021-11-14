using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWeb.Data.Migrations
{
    public partial class createMusicDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProducerId",
                table: "Musics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Artist_Musics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    MusicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist_Musics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artist_Musics_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Artist_Musics_Musics_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Musics",
                        principalColumn: "MusicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    ProducerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProducerName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.ProducerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Musics_ProducerId",
                table: "Musics",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_Artist_Musics_ArtistId",
                table: "Artist_Musics",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Artist_Musics_MusicId",
                table: "Artist_Musics",
                column: "MusicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Producers_ProducerId",
                table: "Musics",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "ProducerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Producers_ProducerId",
                table: "Musics");

            migrationBuilder.DropTable(
                name: "Artist_Musics");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropIndex(
                name: "IX_Musics_ProducerId",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "ProducerId",
                table: "Musics");
        }
    }
}
