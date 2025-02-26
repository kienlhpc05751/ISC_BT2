using ISC_BT2.Models;
using Microsoft.EntityFrameworkCore;

namespace ISC_BT2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AllowAccess> AllowAccesses { get; set; }
        public DbSet<Intern> Interns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed dữ liệu bảng Role
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "EnterpriseUser" },
                new Role { RoleId = 3, RoleName = "Intern" }
            );

            // Seed dữ liệu bảng User
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "admin", PasswordHash = "admin123", RoleId = 1 },
                new User { UserId = 2, Username = "enterprise_user", PasswordHash = "user123", RoleId = 2 },
                new User { UserId = 3, Username = "intern_user", PasswordHash = "intern123", RoleId = 3 }
            );

            // Seed dữ liệu bảng AllowAccess
            modelBuilder.Entity<AllowAccess>().HasData(
                new AllowAccess { Id = 1, RoleId = 2, TableName = "Intern", AccessProperties = "InternName, DateOfBirth, University, Major" },
                new AllowAccess { Id = 2, RoleId = 3, TableName = "Intern", AccessProperties = "InternName, Major" }
            );

            // Seed dữ liệu bảng Intern
            modelBuilder.Entity<Intern>().HasData(
                new Intern
                {
                    Id = 1,
                    InternName = "Nguyễn Văn A",
                    InternAddress = "123 Đường ABC, TP. HCM",
                    ImageData = null, // Mảng byte rỗng để tránh lỗ, // Chưa có dữ liệu hình ảnh
                    // DateOfBirth = new DateTime(2000, 5, 20, 0, 0, 0, DateTimeKind.Utc),
                    DateOfBirth = null,
                    InternMail = "nguyenvana@example.com",
                    University = "Đại học Bách Khoa",
                    CitizenIdentification = "123456789",
                    Major = "Công nghệ thông tin",
                    Internable = true,
                    Cvfile = "nguyenvana_cv.pdf",
                    InternSpecialized = 1,
                    TelephoneNum = "0123456789",
                    FullTime = true,
                    InternEnabled = true,
                    Note = "Ứng viên có kinh nghiệm về .NET",
                    JobFields = "Backend Developer"
                },
                new Intern
                {
                    Id = 2,
                    InternName = "Trần Thị B",
                    InternAddress = "456 Đường XYZ, Hà Nội",
                    ImageData = null,
                    // DateOfBirth = new DateTime(2000, 5, 20, 0, 0, 0, DateTimeKind.Utc),
                    DateOfBirth = null,

                    InternMail = "tranthib@example.com",
                    University = "Đại học Khoa học Tự nhiên",
                    CitizenIdentification = "987654321",
                    Major = "Khoa học dữ liệu",
                    Internable = true,
                    Cvfile = "tranthib_cv.pdf",
                    InternSpecialized = 2,
                    TelephoneNum = "0987654321",
                    FullTime = false,
                    InternEnabled = true,
                    Note = "Quan tâm đến trí tuệ nhân tạo",
                    JobFields = "Data Scientist"
                },
                new Intern
                {
                    Id = 3,
                    InternName = "Lê Văn C",
                    InternAddress = "789 Đường DEF, Đà Nẵng",
                    ImageData = null,
                    DateOfBirth = null,
                    InternMail = "levanc@example.com",
                    University = "Đại học Sư phạm Kỹ thuật",
                    CitizenIdentification = "1122334455",
                    Major = "Hệ thống thông tin",
                    Internable = false,
                    Cvfile = "levanc_cv.pdf",
                    InternSpecialized = 3,
                    TelephoneNum = "0912345678",
                    FullTime = true,
                    InternEnabled = false,
                    Note = "Đã có kinh nghiệm làm việc tại công ty khác",
                    JobFields = "IT Support"
                }
            );

        }

    }
}
