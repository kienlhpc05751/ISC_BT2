using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ISC_BT2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InternName = table.Column<string>(type: "text", nullable: false),
                    InternAddress = table.Column<string>(type: "text", nullable: false),
                    ImageData = table.Column<byte[]>(type: "bytea", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    InternMail = table.Column<string>(type: "text", nullable: false),
                    University = table.Column<string>(type: "text", nullable: false),
                    CitizenIdentification = table.Column<string>(type: "text", nullable: false),
                    Major = table.Column<string>(type: "text", nullable: false),
                    Internable = table.Column<bool>(type: "boolean", nullable: true),
                    Cvfile = table.Column<string>(type: "text", nullable: false),
                    InternSpecialized = table.Column<int>(type: "integer", nullable: true),
                    TelephoneNum = table.Column<string>(type: "text", nullable: false),
                    FullTime = table.Column<bool>(type: "boolean", nullable: true),
                    InternEnabled = table.Column<bool>(type: "boolean", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: false),
                    JobFields = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "AllowAccesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    TableName = table.Column<string>(type: "text", nullable: false),
                    AccessProperties = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllowAccesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllowAccesses_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Fullname = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interns",
                columns: new[] { "Id", "CitizenIdentification", "Cvfile", "DateOfBirth", "FullTime", "ImageData", "InternAddress", "InternEnabled", "InternMail", "InternName", "InternSpecialized", "Internable", "JobFields", "Major", "Note", "TelephoneNum", "University" },
                values: new object[,]
                {
                    { 1, "123456789", "nguyenvana_cv.pdf", null, true, null, "123 Đường ABC, TP. HCM", true, "nguyenvana@example.com", "Nguyễn Văn A", 1, true, "Backend Developer", "Công nghệ thông tin", "Ứng viên có kinh nghiệm về .NET", "0123456789", "Đại học Bách Khoa" },
                    { 2, "987654321", "tranthib_cv.pdf", null, false, null, "456 Đường XYZ, Hà Nội", true, "tranthib@example.com", "Trần Thị B", 2, true, "Data Scientist", "Khoa học dữ liệu", "Quan tâm đến trí tuệ nhân tạo", "0987654321", "Đại học Khoa học Tự nhiên" },
                    { 3, "1122334455", "levanc_cv.pdf", null, true, null, "789 Đường DEF, Đà Nẵng", false, "levanc@example.com", "Lê Văn C", 3, false, "IT Support", "Hệ thống thông tin", "Đã có kinh nghiệm làm việc tại công ty khác", "0912345678", "Đại học Sư phạm Kỹ thuật" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "EnterpriseUser" },
                    { 3, "Intern" }
                });

            migrationBuilder.InsertData(
                table: "AllowAccesses",
                columns: new[] { "Id", "AccessProperties", "RoleId", "TableName" },
                values: new object[,]
                {
                    { 1, "InternName, DateOfBirth, University, Major", 2, "Intern" },
                    { 2, "InternName, Major", 3, "Intern" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DateOfBirth", "Fullname", "PasswordHash", "RoleId", "Username" },
                values: new object[,]
                {
                    { 1, null, null, "admin123", 1, "admin" },
                    { 2, null, null, "user123", 2, "enterprise_user" },
                    { 3, null, null, "intern123", 3, "intern_user" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllowAccesses_RoleId",
                table: "AllowAccesses",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllowAccesses");

            migrationBuilder.DropTable(
                name: "Interns");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
