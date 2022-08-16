using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageBoard.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(30) CHARACTER SET utf8mb4", maxLength: 30, nullable: false),
                    Comment = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    User = table.Column<string>(type: "varchar(30) CHARACTER SET utf8mb4", maxLength: 30, nullable: false),
                    PostDate = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Comment", "Name", "PostDate", "User" },
                values: new object[] { 1, "Burritos!!", "Lunch Crew", "16 August 2022", "Employee_03" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Comment", "Name", "PostDate", "User" },
                values: new object[] { 2, "VAR sucks", "Soccer", "16 August 2022", "Employee_02" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Comment", "Name", "PostDate", "User" },
                values: new object[] { 3, "Play OW2!!", "Gamers", "16 August 2022", "Employee_03" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
