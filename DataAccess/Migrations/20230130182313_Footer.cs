using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Footer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FooterDetails",
                columns: table => new
                {
                    FooterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogoUrl = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    FbUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IgUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TwtUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    YtUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TipsTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipsDetail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooterDetails", x => x.FooterId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FooterDetails");
        }
    }
}
