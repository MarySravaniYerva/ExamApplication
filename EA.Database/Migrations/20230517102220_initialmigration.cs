using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EA.Database.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasicDetails",
                columns: table => new
                {
                    BasicDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnrollId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aadhaar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicDetails", x => x.BasicDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "EducationalDetails",
                columns: table => new
                {
                    EducationDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnrollId = table.Column<int>(type: "int", nullable: false),
                    MetriculationBoard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetriculationRollNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfPassingOfMetriculation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GPAOfMetriculation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntermediateBoard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntermediateRollNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfPassingOfIntermediate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GPAOfIntermediate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Graduation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GraduationRollNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfPassingOfGraduation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GPAOfGraduation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalDetails", x => x.EducationDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AadharNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollId);
                });

            migrationBuilder.CreateTable(
                name: "OtpIdentityVerifications",
                columns: table => new
                {
                    OtpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OTPHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OTPSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OTPType = table.Column<byte>(type: "tinyint", nullable: false),
                    IsOTPVerified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpIdentityVerifications", x => x.OtpId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasicDetails");

            migrationBuilder.DropTable(
                name: "EducationalDetails");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "OtpIdentityVerifications");
        }
    }
}
