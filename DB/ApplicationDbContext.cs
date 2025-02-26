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

            //  Seed dữ liệu bảng Role
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "EnterpriseUser" },
                new Role { RoleId = 3, RoleName = "Intern" },
                new Role { RoleId = 4, RoleName = "Manager" }  // Thêm vai trò Manager
            );

            // Seed dữ liệu bảng User
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "admin", PasswordHash = "admin123", RoleId = 1 },
                new User { UserId = 2, Username = "enterprise_user", PasswordHash = "user123", RoleId = 2 },
                new User { UserId = 3, Username = "intern_user", PasswordHash = "intern123", RoleId = 3 },
                new User { UserId = 4, Username = "manager", PasswordHash = "manager123", RoleId = 4 }  // Thêm Manager
            );

            //  Seed dữ liệu bảng AllowAccess
            modelBuilder.Entity<AllowAccess>().HasData(
                new AllowAccess { Id = 1, RoleId = 2, TableName = "Intern", AccessProperties = "InternName, DateOfBirth, University, Major" },
                new AllowAccess { Id = 2, RoleId = 3, TableName = "Intern", AccessProperties = "InternName, Major" },
                new AllowAccess { Id = 3, RoleId = 4, TableName = "Intern", AccessProperties = "InternName, InternMail, University, JobFields" }  // Manager có thêm quyền
            );

            //  Seed dữ liệu bảng Intern với nhiều dữ liệu hơn
            modelBuilder.Entity<Intern>().HasData(
                new Intern
                {
                    Id = 1,
                    InternName = "Nguyễn Văn A",
                    InternAddress = "123 Đường ABC, TP. HCM",
                    ImageData = null,
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
                },
                new Intern
                {
                    Id = 4,
                    InternName = "Phạm Thị D",
                    InternAddress = "99 Đường GHI, Hải Phòng",
                    ImageData = null,
                    DateOfBirth = null,
                    InternMail = "phamthid@example.com",
                    University = "Đại học Công nghệ Thông tin",
                    CitizenIdentification = "6677889900",
                    Major = "Trí tuệ nhân tạo",
                    Internable = true,
                    Cvfile = "phamthid_cv.pdf",
                    InternSpecialized = 4,
                    TelephoneNum = "0321654987",
                    FullTime = true,
                    InternEnabled = true,
                    Note = "Học xuất sắc ngành AI",
                    JobFields = "AI Engineer"
                }
            );
        }


    }
}
