using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class companycontactchanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyContactcMail",
                table: "CompanyContacts");

            migrationBuilder.RenameColumn(
                name: "CompanyContactPhoneNo",
                table: "CompanyContacts",
                newName: "CompanyContactIcon");

            migrationBuilder.RenameColumn(
                name: "CompanyContactAddress",
                table: "CompanyContacts",
                newName: "CompanyContactDetail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyContactIcon",
                table: "CompanyContacts",
                newName: "CompanyContactPhoneNo");

            migrationBuilder.RenameColumn(
                name: "CompanyContactDetail",
                table: "CompanyContacts",
                newName: "CompanyContactAddress");

            migrationBuilder.AddColumn<string>(
                name: "CompanyContactcMail",
                table: "CompanyContacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
