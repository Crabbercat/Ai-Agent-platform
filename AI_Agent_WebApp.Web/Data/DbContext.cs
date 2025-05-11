// DbContext.cs
// Cấu hình EF Core DbContext

using Microsoft.EntityFrameworkCore;
using AI_Agent_WebApp.Models.Entities; 
namespace AI_Agent_WebApp.Data 
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<SystemLog> SystemLogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Thiết lập các khóa chính
            modelBuilder.Entity<Agent>().HasKey(a => a.Id);
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<PaymentType>().HasKey(p => p.Id);
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Article>().HasKey(a => a.Id);
            modelBuilder.Entity<Review>().HasKey(r => r.Id);
            modelBuilder.Entity<SystemLog>().HasKey(s => s.Id);

            // Thiết lập các khóa ngoại
            modelBuilder.Entity<Agent>()
                .HasOne(a => a.Category)
                .WithMany()
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Agent>()
                .HasOne(a => a.PaymentType)
                .WithMany()
                .HasForeignKey(a => a.PaymentTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Agent>()
                .HasOne(a => a.Supplier)
                .WithMany()
                .HasForeignKey(a => a.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            // Ràng buộc cho Article: mỗi Article thuộc về một Agent và một User
            modelBuilder.Entity<Article>()
                .HasOne(a => a.Agent)
                .WithMany()
                .HasForeignKey(a => a.AgentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Article>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Ràng buộc cho Review: mỗi Review thuộc về một Agent và một User
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Agent)
                .WithMany()
                .HasForeignKey(r => r.AgentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Ràng buộc cho SystemLog: mỗi SystemLog thuộc về một User
            modelBuilder.Entity<SystemLog>()
                .HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            // Seed data cho bảng User
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Email = "admin@example.com", PasswordHash = "adminhash", FullName = "Admin User", Role = "Admin", CreatedAt = new DateTime(2024, 1, 1, 8, 0, 0) },
                // Suppliers (ensure these Ids match all Agent.SupplierId references)
                new User { Id = 2, Username = "supplier1", Email = "supplier1@example.com", PasswordHash = "supplier1hash", FullName = "Supplier One", Role = "Supplier", CreatedAt = new DateTime(2024, 1, 2, 8, 0, 0) },
                new User { Id = 3, Username = "supplier2", Email = "supplier2@example.com", PasswordHash = "supplier2hash", FullName = "Supplier Two", Role = "Supplier", CreatedAt = new DateTime(2024, 1, 3, 8, 0, 0) },
                new User { Id = 4, Username = "supplier3", Email = "supplier3@example.com", PasswordHash = "supplier3hash", FullName = "Supplier Three", Role = "Supplier", CreatedAt = new DateTime(2024, 1, 4, 8, 0, 0) },
                new User { Id = 5, Username = "supplier4", Email = "supplier4@example.com", PasswordHash = "supplier4hash", FullName = "Supplier Four", Role = "Supplier", CreatedAt = new DateTime(2024, 1, 5, 8, 0, 0) },
                // Regular users
                new User { Id = 6, Username = "user2", Email = "user2@example.com", PasswordHash = "user2hash", FullName = "User Two", Role = "User", CreatedAt = new DateTime(2024, 1, 6, 8, 0, 0) },
                new User { Id = 7, Username = "user3", Email = "user3@example.com", PasswordHash = "user3hash", FullName = "User Three", Role = "User", CreatedAt = new DateTime(2024, 1, 7, 8, 0, 0) },
                new User { Id = 8, Username = "user4", Email = "user4@example.com", PasswordHash = "user4hash", FullName = "User Four", Role = "User", CreatedAt = new DateTime(2024, 1, 8, 8, 0, 0) }
            );
            // Seed data cho bảng Agent
            modelBuilder.Entity<Agent>().HasData(
                new Agent { Id = 1, Name = "NovaFlux", Description = "Công cụ AI cho đồ họa và UX/UI", SupplierId = 2, CategoryId = 1, PaymentTypeId = 1, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 8, 0, 0), ImagePath = "wwwroot/images/agents/NovaFlux.png" },
                new Agent { Id = 2, Name = "QuantaNova", Description = "Công cụ AI hỗ trợ công trình học thuật", SupplierId = 2, CategoryId = 2, PaymentTypeId = 2, IsActive = true, CreatedAt = new DateTime(2024, 1, 2, 8, 0, 0), ImagePath = "wwwroot/images/agents/QuantaNova.png" },
                new Agent { Id = 3, Name = "ByteWarden", Description = "Phân tích và mô phỏng dữ liệu khoa học", SupplierId = 4, CategoryId = 3, PaymentTypeId = 3, IsActive = true, CreatedAt = new DateTime(2024, 1, 3, 8, 0, 0), ImagePath = "wwwroot/images/agents/ByteWarden.png" },
                new Agent { Id = 4, Name = "EchoPulse", Description = "AI quản lý lịch trình và nhắc việc", SupplierId = 5, CategoryId = 4, PaymentTypeId = 4, IsActive = true, CreatedAt = new DateTime(2024, 1, 4, 8, 0, 0), ImagePath = "wwwroot/images/agents/EchoPulse.png" },
                new Agent { Id = 5, Name = "ZenithBot", Description = "Hỗ trợ phát triển phần mềm thông minh", SupplierId = 2, CategoryId = 5, PaymentTypeId = 1, IsActive = true, CreatedAt = new DateTime(2024, 1, 5, 8, 0, 0), ImagePath = "wwwroot/images/agents/ZenithBot.png" },
                new Agent { Id = 6, Name = "AstroSage", Description = "AI hỗ trợ ra quyết định từ dữ liệu", SupplierId = 3, CategoryId = 6, PaymentTypeId = 2, IsActive = true, CreatedAt = new DateTime(2024, 1, 6, 8, 0, 0), ImagePath = "wwwroot/images/agents/AstroSage.png" },
                new Agent { Id = 7, Name = "GlimmerAI", Description = "Chiến lược tiếp thị được tối ưu bằng AI", SupplierId = 4, CategoryId = 7, PaymentTypeId = 3, IsActive = true, CreatedAt = new DateTime(2024, 1, 7, 8, 0, 0), ImagePath = "wwwroot/images/agents/GlimmerAI.png" },
                new Agent { Id = 8, Name = "OrbitalNest", Description = "AI viết nội dung và tạo ý tưởng sáng tạo", SupplierId = 5, CategoryId = 8, PaymentTypeId = 4, IsActive = true, CreatedAt = new DateTime(2024, 1, 8, 8, 0, 0), ImagePath = "wwwroot/images/agents/OrbitalNest.png" },
                new Agent { Id = 9, Name = "Synthara", Description = "Nhận diện và phản hồi giọng nói tự nhiên", SupplierId = 2, CategoryId = 9, PaymentTypeId = 1, IsActive = true, CreatedAt = new DateTime(2024, 1, 9, 8, 0, 0), ImagePath = "wwwroot/images/agents/Synthara.png" },
                new Agent { Id = 10, Name = "ChronaEdge", Description = "Hỗ trợ đầu tư và quản lý tài chính cá nhân", SupplierId = 3, CategoryId = 10, PaymentTypeId = 2, IsActive = true, CreatedAt = new DateTime(2024, 1, 10, 8, 0, 0), ImagePath = "wwwroot/images/agents/ChronaEdge.png" },
                new Agent { Id = 11, Name = "VantaSpark", Description = "Công cụ AI cho đồ họa và UX/UI", SupplierId = 4, CategoryId = 1, PaymentTypeId = 3, IsActive = true, CreatedAt = new DateTime(2024, 1, 11, 8, 0, 0), ImagePath = "wwwroot/images/agents/VantaSpark.png" },
                new Agent { Id = 12, Name = "LucidForge", Description = "Phân tích và tổng hợp tài liệu nhanh chóng", SupplierId = 5, CategoryId = 2, PaymentTypeId = 4, IsActive = true, CreatedAt = new DateTime(2024, 1, 12, 8, 0, 0), ImagePath = "wwwroot/images/agents/LucidForge.png" },
                new Agent { Id = 13, Name = "NeuraWhirl", Description = "Tăng hiệu quả nghiên cứu khoa học", SupplierId = 2, CategoryId = 3, PaymentTypeId = 1, IsActive = true, CreatedAt = new DateTime(2024, 1, 13, 8, 0, 0), ImagePath = "wwwroot/images/agents/NeuraWhirl.png" },
                new Agent { Id = 14, Name = "PrismShift", Description = "Trợ lý ảo cá nhân thông minh", SupplierId = 3, CategoryId = 4, PaymentTypeId = 2, IsActive = true, CreatedAt = new DateTime(2024, 1, 14, 8, 0, 0), ImagePath = "wwwroot/images/agents/PrismShift.png" },
                new Agent { Id = 15, Name = "HexaTune", Description = "Tăng tốc viết mã và kiểm tra lỗi", SupplierId = 4, CategoryId = 5, PaymentTypeId = 3, IsActive = true, CreatedAt = new DateTime(2024, 1, 15, 8, 0, 0), ImagePath = "wwwroot/images/agents/HexaTune.png" },
                new Agent { Id = 16, Name = "OmniScribe", Description = "AI hỗ trợ ra quyết định từ dữ liệu", SupplierId = 5, CategoryId = 6, PaymentTypeId = 4, IsActive = true, CreatedAt = new DateTime(2024, 1, 16, 8, 0, 0), ImagePath = "wwwroot/images/agents/default-agent.png" },
                new Agent { Id = 17, Name = "AeroMind", Description = "Phân tích thị trường và hành vi khách hàng", SupplierId = 2, CategoryId = 7, PaymentTypeId = 1, IsActive = true, CreatedAt = new DateTime(2024, 1, 17, 8, 0, 0), ImagePath = "wwwroot/images/agents/default-agent.png" },
                new Agent { Id = 18, Name = "PulseCraft", Description = "Trợ lý sáng tạo cho viết bài và video", SupplierId = 3, CategoryId = 8, PaymentTypeId = 2, IsActive = true, CreatedAt = new DateTime(2024, 1, 18, 8, 0, 0), ImagePath = "wwwroot/images/agents/default-agent.png" },
                new Agent { Id = 19, Name = "TerraByte", Description = "Nhận diện và phản hồi giọng nói tự nhiên", SupplierId = 4, CategoryId = 9, PaymentTypeId = 3, IsActive = true, CreatedAt = new DateTime(2024, 1, 19, 8, 0, 0), ImagePath = "wwwroot/images/agents/default-agent.png" },
                new Agent { Id = 20, Name = "NexonNode", Description = "Theo dõi dòng tiền và lập kế hoạch tài chính", SupplierId = 5, CategoryId = 10, PaymentTypeId = 4, IsActive = true, CreatedAt = new DateTime(2024, 1, 20, 8, 0, 0), ImagePath = "wwwroot/images/agents/default-agent.png" },
                new Agent { Id = 21, Name = "StellarWeave", Description = "Hỗ trợ thiết kế sáng tạo chuyên nghiệp", SupplierId = 2, CategoryId = 1, PaymentTypeId = 1, IsActive = true, CreatedAt = new DateTime(2024, 1, 21, 8, 0, 0), ImagePath = "wwwroot/images/agents/default-agent.png" },
                new Agent { Id = 22, Name = "QuirkBot", Description = "Công cụ AI hỗ trợ công trình học thuật", SupplierId = 3, CategoryId = 2, PaymentTypeId = 2, IsActive = true, CreatedAt = new DateTime(2024, 1, 22, 8, 0, 0), ImagePath = "wwwroot/images/agents/default-agent.png" },
                new Agent { Id = 23, Name = "CodeRipple", Description = "Hỗ trợ khám phá khoa học bằng AI", SupplierId = 4, CategoryId = 3, PaymentTypeId = 3, IsActive = true, CreatedAt = new DateTime(2024, 1, 23, 8, 0, 0), ImagePath = "wwwroot/images/agents/default-agent.png" },
                new Agent { Id = 24, Name = "VoxenCore", Description = "Trợ lý ảo cá nhân thông minh", SupplierId = 5, CategoryId = 4, PaymentTypeId = 4, IsActive = true, CreatedAt = new DateTime(2024, 1, 24, 8, 0, 0), ImagePath = "wwwroot/images/agents/default-agent.png" },
                new Agent { Id = 25, Name = "MindLoom", Description = "Tăng tốc viết mã và kiểm tra lỗi", SupplierId = 2, CategoryId = 5, PaymentTypeId = 1, IsActive = true, CreatedAt = new DateTime(2024, 1, 25, 8, 0, 0), ImagePath = "wwwroot/images/agents/default-agent.png" },
                new Agent { Id = 26, Name = "KairoUnit", Description = "Phân tích dữ liệu chuyên sâu bằng AI", SupplierId = 3, CategoryId = 6, PaymentTypeId = 2, IsActive = true, CreatedAt = new DateTime(2024, 1, 26, 8, 0, 0), ImagePath = "wwwroot/images/agents/default-agent.png" },
                new Agent { Id = 27, Name = "LumenQuest", Description = "Phân tích thị trường và hành vi khách hàng", SupplierId = 4, CategoryId = 7, PaymentTypeId = 3, IsActive = true, CreatedAt = new DateTime(2024, 1, 27, 8, 0, 0), ImagePath = "wwwroot/images/agents/default-agent.png" },
                new Agent { Id = 28, Name = "RiftSync", Description = "Trợ lý sáng tạo cho viết bài và video", SupplierId = 5, CategoryId = 8, PaymentTypeId = 4, IsActive = true, CreatedAt = new DateTime(2024, 1, 28, 8, 0, 0), ImagePath = "wwwroot/images/agents/default-agent.png" },
                new Agent { Id = 29, Name = "CerebraLink", Description = "Nhận diện và phản hồi giọng nói tự nhiên", SupplierId = 2, CategoryId = 9, PaymentTypeId = 1, IsActive = true, CreatedAt = new DateTime(2024, 1, 29, 8, 0, 0), ImagePath = "wwwroot/images/agents/default-agent.png" },
                new Agent { Id = 30, Name = "HaloNest", Description = "Tư vấn và phân tích tài chính bằng AI", SupplierId = 3, CategoryId = 10, PaymentTypeId = 2, IsActive = true, CreatedAt = new DateTime(2024, 1, 30, 8, 0, 0), ImagePath = "wwwroot/images/agents/default-agent.png" }
            );
            // Seed data cho bảng Category
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Design" },
                new Category { Id = 2, Name = "Research" },
                new Category { Id = 3, Name = "Science" },
                new Category { Id = 4, Name = "Personal Assistant" },
                new Category { Id = 5, Name = "Coding" },
                new Category { Id = 6, Name = "Data Analysis" },
                new Category { Id = 7, Name = "Marketing" },
                new Category { Id = 8, Name = "Content Creation" },
                new Category { Id = 9, Name = "Voice AI Agents" },
                new Category { Id = 10, Name = "Finance" }
            );
            // Seed data cho bảng PaymentType
            modelBuilder.Entity<PaymentType>().HasData(
                new PaymentType { Id = 1, Name = "Free" },
                new PaymentType { Id = 2, Name = "Paid" },
                new PaymentType { Id = 3, Name = "Paid+Free" },
                new PaymentType { Id = 4, Name = "Deal" }
            );

            // Cấu hình các trường Id tự động tăng
            modelBuilder.Entity<Agent>().Property(a => a.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Article>().Property(a => a.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(u => u.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Review>().Property(r => r.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<SystemLog>().Property(s => s.Id).ValueGeneratedOnAdd();

            // Cấu hình quan hệ, ràng buộc, seed data nếu cần
        }
    }
}
