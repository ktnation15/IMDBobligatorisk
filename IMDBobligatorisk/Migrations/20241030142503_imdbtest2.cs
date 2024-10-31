using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMDBobligatorisk.Migrations
{
    /// <inheritdoc />
    public partial class imdbtest2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    Tconst = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TitleType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdult = table.Column<bool>(type: "bit", nullable: true),
                    StartYear = table.Column<int>(type: "int", nullable: true),
                    EndYear = table.Column<int>(type: "int", nullable: true),
                    RuntimeMinutes = table.Column<int>(type: "int", nullable: true),
                    Genres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.Tconst);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Titles");
        }
    }
}
