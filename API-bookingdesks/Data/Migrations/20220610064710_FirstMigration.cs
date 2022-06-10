using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_bookingdesks.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Adress = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    NumberOfDesks = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Adress", "NumberOfDesks" },
                values: new object[] { 1, "Room 1", 7 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Adress", "NumberOfDesks" },
                values: new object[] { 2, "Room 2", 7 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Adress", "NumberOfDesks" },
                values: new object[] { 3, "Room 3", 7 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Adress", "NumberOfDesks" },
                values: new object[] { 4, "Room 4", 7 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Adress", "NumberOfDesks" },
                values: new object[] { 5, "Room 5", 7 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Adress", "NumberOfDesks" },
                values: new object[] { 6, "Room 6", 7 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
