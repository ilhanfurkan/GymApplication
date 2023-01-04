using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class admineklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    adminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adminName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    adminPassword = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    adminType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.adminId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");
        }
    }
}
