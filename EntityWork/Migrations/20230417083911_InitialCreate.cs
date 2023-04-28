using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityWork.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "egitmen",
                columns: table => new
                {
                    EgitmenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egitmen", x => x.EgitmenId);
                });

            migrationBuilder.CreateTable(
                name: "kurs",
                columns: table => new
                {
                    KursId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kurs", x => x.KursId);
                });

            migrationBuilder.CreateTable(
                name: "ogrenci",
                columns: table => new
                {
                    OgrenciId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ogrenci", x => x.OgrenciId);
                });

            migrationBuilder.CreateTable(
                name: "personel",
                columns: table => new
                {
                    PersonelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personel", x => x.PersonelId);
                });

            migrationBuilder.CreateTable(
                name: "sınıf",
                columns: table => new
                {
                    SınıfId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<int>(type: "int", nullable: false),
                    Tahta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Projeksiyon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bilgisayar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sınıf", x => x.SınıfId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "egitmen");

            migrationBuilder.DropTable(
                name: "kurs");

            migrationBuilder.DropTable(
                name: "ogrenci");

            migrationBuilder.DropTable(
                name: "personel");

            migrationBuilder.DropTable(
                name: "sınıf");
        }
    }
}
