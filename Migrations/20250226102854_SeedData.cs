using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISC_BT2.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Interns",
                columns: new[] { "Id", "CitizenIdentification", "Cvfile", "DateOfBirth", "FullTime", "ImageData", "InternAddress", "InternEnabled", "InternMail", "InternName", "InternSpecialized", "Internable", "JobFields", "Major", "Note", "TelephoneNum", "University" },
                values: new object[] { 4, "6677889900", "phamthid_cv.pdf", null, true, null, "99 Đường GHI, Hải Phòng", true, "phamthid@example.com", "Phạm Thị D", 4, true, "AI Engineer", "Trí tuệ nhân tạo", "Học xuất sắc ngành AI", "0321654987", "Đại học Công nghệ Thông tin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { 4, "Manager" });

            migrationBuilder.InsertData(
                table: "AllowAccesses",
                columns: new[] { "Id", "AccessProperties", "RoleId", "TableName" },
                values: new object[] { 3, "InternName, InternMail, University, JobFields", 4, "Intern" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DateOfBirth", "Fullname", "PasswordHash", "RoleId", "Username" },
                values: new object[] { 4, null, null, "manager123", 4, "manager" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AllowAccesses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Interns",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4);
        }
    }
}
