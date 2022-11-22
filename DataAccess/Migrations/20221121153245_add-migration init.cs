using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class addmigrationinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Hours",
                columns: table => new
                {
                    HourId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hours = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Time = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hours", x => x.HourId);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainerLogin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TrainerPassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TrainerFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TrainerLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TrainerNationalId = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    TrainerPhoneNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    TrainerMail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TrainerGender = table.Column<bool>(type: "bit", nullable: false),
                    TrainerDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.TrainerId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserLogin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTrainers",
                columns: table => new
                {
                    PacketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacketName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PacketDetail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PacketPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Right = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTrainers", x => x.PacketId);
                    table.ForeignKey(
                        name: "FK_CategoryTrainers_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryTrainers_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HourTrainers",
                columns: table => new
                {
                    SeanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quota = table.Column<int>(type: "int", nullable: false),
                    RemainingRight = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    HourId = table.Column<int>(type: "int", nullable: false),
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourTrainers", x => x.SeanceId);
                    table.ForeignKey(
                        name: "FK_HourTrainers_Hours_HourId",
                        column: x => x.HourId,
                        principalTable: "Hours",
                        principalColumn: "HourId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HourTrainers_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCategoryTrainers",
                columns: table => new
                {
                    RegistrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentType = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PacketId = table.Column<int>(type: "int", nullable: false),
                    CategoryTrainerPacketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCategoryTrainers", x => x.RegistrationId);
                    table.ForeignKey(
                        name: "FK_UserCategoryTrainers_CategoryTrainers_CategoryTrainerPacketId",
                        column: x => x.CategoryTrainerPacketId,
                        principalTable: "CategoryTrainers",
                        principalColumn: "PacketId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCategoryTrainers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserHourTrainers",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    SeanceId = table.Column<int>(type: "int", nullable: false),
                    HourTrainerSeanceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHourTrainers", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_UserHourTrainers_HourTrainers_HourTrainerSeanceId",
                        column: x => x.HourTrainerSeanceId,
                        principalTable: "HourTrainers",
                        principalColumn: "SeanceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHourTrainers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTrainers_CategoryId",
                table: "CategoryTrainers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTrainers_TrainerId",
                table: "CategoryTrainers",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_HourTrainers_HourId",
                table: "HourTrainers",
                column: "HourId");

            migrationBuilder.CreateIndex(
                name: "IX_HourTrainers_TrainerId",
                table: "HourTrainers",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategoryTrainers_CategoryTrainerPacketId",
                table: "UserCategoryTrainers",
                column: "CategoryTrainerPacketId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategoryTrainers_UserId",
                table: "UserCategoryTrainers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHourTrainers_HourTrainerSeanceId",
                table: "UserHourTrainers",
                column: "HourTrainerSeanceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHourTrainers_UserId",
                table: "UserHourTrainers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCategoryTrainers");

            migrationBuilder.DropTable(
                name: "UserHourTrainers");

            migrationBuilder.DropTable(
                name: "CategoryTrainers");

            migrationBuilder.DropTable(
                name: "HourTrainers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Hours");

            migrationBuilder.DropTable(
                name: "Trainers");
        }
    }
}
