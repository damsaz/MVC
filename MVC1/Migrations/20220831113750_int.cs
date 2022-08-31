using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC1.Migrations
{
    public partial class @int : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Country", "First_name", "Last_name", "Tel" },
                values: new object[,]
                {
                    { 1, "Indonesia", "Gary", "Ortiz", "07395539" },
                    { 2, "China", "Albert", "Williamson", "0739439" },
                    { 3, "Peru", "Mildred", "Fuller", "07378539" },
                    { 4, "Belarus", "Russell", "Robinson", "07323539" },
                    { 5, "Philippines", "Laura", "Harper", "07395659" },
                    { 6, "China", "Larry", "Sanders", "07395539" },
                    { 7, "Philippines", "Michael", "Rice", "073955546" },
                    { 8, "Indonesia", "Sara", "Harris", "07395556" },
                    { 9, "China", "Phyllis", "Webb", "073955576" },
                    { 10, "Finland", "Roger", "Alvarez", "073955321" },
                    { 11, "Sweden", "Maria", "Carpenter", "0739551234" },
                    { 12, "Russia", "Lori", "Edwards", "073955353" },
                    { 13, "Russia", "Phillip", "Mitchell", "0739553321" },
                    { 14, "Indonesia", "Craig", "Lopez", "0739551249" },
                    { 15, "Mauritius", "Marie", "George", "073955234" },
                    { 16, "Norway", "Jean", "Duncan", "07395541" },
                    { 17, "Sweden", "Kimberly", "Butler", "073955412" },
                    { 18, "Indonesia", "Heather", "Ramirez", "073951234" },
                    { 19, "Canada", "Jason", "Sanders", "073955214" },
                    { 20, "Philippines", "Juan", "Evans", "073955214" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
