using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC1.Migrations
{
    public partial class q : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    IdLanguage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.IdLanguage);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LanguagePerson",
                columns: table => new
                {
                    LanguagesIdLanguage = table.Column<int>(type: "int", nullable: false),
                    peopleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguagePerson", x => new { x.LanguagesIdLanguage, x.peopleId });
                    table.ForeignKey(
                        name: "FK_LanguagePerson_Language_LanguagesIdLanguage",
                        column: x => x.LanguagesIdLanguage,
                        principalTable: "Language",
                        principalColumn: "IdLanguage",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguagePerson_Person_peopleId",
                        column: x => x.peopleId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "IdLanguage", "Name" },
                values: new object[,]
                {
                    { 1, "En" },
                    { 2, "Sv" },
                    { 3, "Fr" },
                    { 4, "Fa" },
                    { 5, "Ar" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "City", "First_name", "Last_name", "Tel" },
                values: new object[,]
                {
                    { 1, "Jakarta", "Gary", "Ortiz", "07395539" },
                    { 2, "Matheu", "Albert", "Williamson", "0739439" },
                    { 3, "Beacon", "Mildred", "Fuller", "07378539" },
                    { 4, "Calen", "Russell", "Robinson", "07323539" },
                    { 5, "Tehran", "Laura", "Harper", "07395659" },
                    { 6, "Mantorp", "Larry", "Sanders", "07395539" },
                    { 7, "Saint-Maximin", "Michael", "Rice", "073955546" },
                    { 8, "Nickerson", "Sara", "Harris", "07395556" },
                    { 9, "Dippach", "Phyllis", "Webb", "073955576" },
                    { 10, "Floresta", "Roger", "Alvarez", "073955321" },
                    { 11, "Alpine", "Maria", "Carpenter", "0739551234" },
                    { 12, "Hochborn", "Lori", "Edwards", "073955353" },
                    { 13, "Dundee", "Phillip", "Mitchell", "0739553321" },
                    { 14, "Chenove", "Craig", "Lopez", "0739551249" },
                    { 15, "Mauritius", "Marie", "George", "073955234" },
                    { 16, "Amapa", "Jean", "Duncan", "07395541" },
                    { 17, "Arauca", "Kimberly", "Butler", "073955412" },
                    { 18, "Argolis", "Heather", "Ramirez", "073951234" },
                    { 19, "Fejer", "Jason", "Sanders", "073955214" },
                    { 20, "Eastern", "Juan", "Evans", "073955214" }
                });

            migrationBuilder.InsertData(
                table: "LanguagePerson",
                columns: new[] { "LanguagesIdLanguage", "peopleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 1, 6 },
                    { 1, 9 },
                    { 1, 12 },
                    { 1, 13 },
                    { 1, 14 },
                    { 1, 15 },
                    { 1, 18 },
                    { 1, 19 },
                    { 1, 20 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 10 },
                    { 2, 11 },
                    { 2, 12 },
                    { 2, 14 },
                    { 2, 15 },
                    { 3, 13 },
                    { 3, 15 },
                    { 3, 16 },
                    { 4, 12 },
                    { 4, 13 },
                    { 4, 14 },
                    { 4, 17 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguagePerson_peopleId",
                table: "LanguagePerson",
                column: "peopleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguagePerson");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
