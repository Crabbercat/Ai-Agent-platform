using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AI_Agent_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class CreateAgentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyWebsite = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agents_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agents_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agents_Users_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SystemLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Follows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    FollowedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Follows_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Follows_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Design" },
                    { 2, "Research" },
                    { 3, "Science" },
                    { 4, "Personal Assistant" },
                    { 5, "Coding" },
                    { 6, "Data Analysis" },
                    { 7, "Marketing" },
                    { 8, "Content Creation" },
                    { 9, "Voice AI Agents" },
                    { 10, "Finance" }
                });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Free" },
                    { 2, "Paid" },
                    { 3, "Paid+Free" },
                    { 4, "Deal" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Discriminator", "Email", "FullName", "PasswordHash", "Role", "Status", "Username" },
                values: new object[] { 1, new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "User", "admin@example.com", "Admin User", "qFKPx1EdqaW8uflt2o9huztsTOmY5fcLE9wBelG4Fcg=", "Admin", false, "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CompanyName", "CompanyWebsite", "CreatedAt", "Discriminator", "Email", "FullName", "PasswordHash", "Role", "Status", "Username" },
                values: new object[,]
                {
                    { 2, "Company One", "https://company1.com", new DateTime(2024, 1, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), "Supplier", "supplier1@example.com", "Supplier One", "t1LjYdBE5mbAc9+uCnVYqyD5cyhhF2wNnNZO8F47FRU=", "Supplier", true, "supplier1" },
                    { 3, "Company Two", "https://company2.com", new DateTime(2024, 1, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), "Supplier", "supplier2@example.com", "Supplier Two", "47eTMSsDhQNpFzuaBs/AJaEYcYjv+ee2Nj1nQdMMlWw=", "Supplier", true, "supplier2" },
                    { 4, "Company Three", "https://company3.com", new DateTime(2024, 1, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Supplier", "supplier3@example.com", "Supplier Three", "t+jvGkgp5HtK6hpmOGlqNfcw+HRH6tqzj4BOwfyNe1A=", "Supplier", true, "supplier3" },
                    { 5, "Company Four", "https://company4.com", new DateTime(2024, 1, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Supplier", "supplier4@example.com", "Supplier Four", "kbgmF2vN3GX4Zo/wf81beHvIY2g3Negbhcy5s/zpU2U=", "Supplier", true, "supplier4" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Discriminator", "Email", "FullName", "PasswordHash", "Role", "Status", "Username" },
                values: new object[,]
                {
                    { 6, new DateTime(2024, 1, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "User", "user2@example.com", "User Two", "ZpZ6gWC+giTdOzmzQ4vJRddTlvD3k3sqeSiyiZozL/o=", "User", false, "user2" },
                    { 7, new DateTime(2024, 1, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), "User", "user3@example.com", "User Three", "IeSjCJoNCNTeKAX3OteyKtCo0WOX3CGYzJPXexT3CuI=", "User", false, "user3" },
                    { 8, new DateTime(2024, 1, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), "User", "user4@example.com", "User Four", "hVv//jP13T++DQVC2Q00IrChsc0OqsldMG9fQ1S0BlE=", "User", false, "user4" },
                    { 9, new DateTime(2024, 1, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), "Staff", "staff1@example.com", "Staff One", "t1LjYdBE5mbAc9+uCnVYqyD5cyhhF2wNnNZO8F47FRU=", "Staff", true, "staff1" },
                    { 10, new DateTime(2024, 1, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), "Staff", "staff2@example.com", "Staff Two", "47eTMSsDhQNpFzuaBs/AJaEYcYjv+ee2Nj1nQdMMlWw=", "Staff", true, "staff2" }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "ImagePath", "IsActive", "Name", "PaymentTypeId", "SupplierId", "Url" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "Công cụ AI cho đồ họa và UX/UI", "wwwroot/images/agents/NovaFlux.png", true, "NovaFlux", 1, 2, "https://nova-flux.com" },
                    { 2, 2, new DateTime(2024, 1, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), "Công cụ AI hỗ trợ công trình học thuật", "wwwroot/images/agents/QuantaNova.png", true, "QuantaNova", 2, 2, "https://quanta-nova.com" },
                    { 3, 3, new DateTime(2024, 1, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), "Phân tích và mô phỏng dữ liệu khoa học", "wwwroot/images/agents/ByteWarden.png", true, "ByteWarden", 3, 4, "https://bytewarden.com" },
                    { 4, 4, new DateTime(2024, 1, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "AI quản lý lịch trình và nhắc việc", "wwwroot/images/agents/EchoPulse.png", true, "EchoPulse", 4, 5, "https://echo-pulse.com" },
                    { 5, 5, new DateTime(2024, 1, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Hỗ trợ phát triển phần mềm thông minh", "wwwroot/images/agents/ZenithBot.png", true, "ZenithBot", 1, 2, "https://zenith-bot.com" },
                    { 6, 6, new DateTime(2024, 1, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "AI hỗ trợ ra quyết định từ dữ liệu", "wwwroot/images/agents/AstroSage.png", true, "AstroSage", 2, 3, "https://astro-sage.com" },
                    { 7, 7, new DateTime(2024, 1, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), "Chiến lược tiếp thị được tối ưu bằng AI", "wwwroot/images/agents/GlimmerAI.png", true, "GlimmerAI", 3, 4, "https://glimmer-ai.com" },
                    { 8, 8, new DateTime(2024, 1, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), "AI viết nội dung và tạo ý tưởng sáng tạo", "wwwroot/images/agents/OrbitalNest.png", true, "OrbitalNest", 4, 5, "https://orbital-nest.com" },
                    { 9, 9, new DateTime(2024, 1, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), "Nhận diện và phản hồi giọng nói tự nhiên", "wwwroot/images/agents/Synthara.png", true, "Synthara", 1, 2, "https://synthara.com" },
                    { 10, 10, new DateTime(2024, 1, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), "Hỗ trợ đầu tư và quản lý tài chính cá nhân", "wwwroot/images/agents/ChronaEdge.png", true, "ChronaEdge", 2, 3, "https://chrona-edge.com" },
                    { 11, 1, new DateTime(2024, 1, 11, 8, 0, 0, 0, DateTimeKind.Unspecified), "Công cụ AI cho đồ họa và UX/UI", "wwwroot/images/agents/VantaSpark.png", true, "VantaSpark", 3, 4, "https://vanta-spark.com" },
                    { 12, 2, new DateTime(2024, 1, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), "Phân tích và tổng hợp tài liệu nhanh chóng", "wwwroot/images/agents/LucidForge.png", true, "LucidForge", 4, 5, "https://lucidforge.com" },
                    { 13, 3, new DateTime(2024, 1, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), "Tăng hiệu quả nghiên cứu khoa học", "wwwroot/images/agents/NeuraWhirl.png", true, "NeuraWhirl", 1, 2, "https://neura-whirl.com" },
                    { 14, 4, new DateTime(2024, 1, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), "Trợ lý ảo cá nhân thông minh", "wwwroot/images/agents/PrismShift.png", true, "PrismShift", 2, 3, "https://prism-shift.com" },
                    { 15, 5, new DateTime(2024, 1, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), "Tăng tốc viết mã và kiểm tra lỗi", "wwwroot/images/agents/HexaTune.png", true, "HexaTune", 3, 4, "https://hexa-tune.com" },
                    { 16, 6, new DateTime(2024, 1, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), "AI hỗ trợ ra quyết định từ dữ liệu", "wwwroot/images/agents/default-agent.png", true, "OmniScribe", 4, 5, "https://omni-scribe.com" },
                    { 17, 7, new DateTime(2024, 1, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), "Phân tích thị trường và hành vi khách hàng", "wwwroot/images/agents/default-agent.png", true, "AeroMind", 1, 2, "https://aero-mind.com" },
                    { 18, 8, new DateTime(2024, 1, 18, 8, 0, 0, 0, DateTimeKind.Unspecified), "Trợ lý sáng tạo cho viết bài và video", "wwwroot/images/agents/default-agent.png", true, "PulseCraft", 2, 3, "https://pulse-craft.com" },
                    { 19, 9, new DateTime(2024, 1, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), "Nhận diện và phản hồi giọng nói tự nhiên", "wwwroot/images/agents/default-agent.png", true, "TerraByte", 3, 4, "https://terra-byte.com" },
                    { 20, 10, new DateTime(2024, 1, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), "Theo dõi dòng tiền và lập kế hoạch tài chính", "wwwroot/images/agents/default-agent.png", true, "NexonNode", 4, 5, "https://nexon-node.com" },
                    { 21, 1, new DateTime(2024, 1, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), "Hỗ trợ thiết kế sáng tạo chuyên nghiệp", "wwwroot/images/agents/default-agent.png", true, "StellarWeave", 1, 2, "https://stellar-weave.com" },
                    { 22, 2, new DateTime(2024, 1, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), "Công cụ AI hỗ trợ công trình học thuật", "wwwroot/images/agents/default-agent.png", true, "QuirkBot", 2, 3, "https://quirk-bot.com" },
                    { 23, 3, new DateTime(2024, 1, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), "Hỗ trợ khám phá khoa học bằng AI", "wwwroot/images/agents/default-agent.png", true, "CodeRipple", 3, 4, "https://code-ripple.com" },
                    { 24, 4, new DateTime(2024, 1, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), "Trợ lý ảo cá nhân thông minh", "wwwroot/images/agents/default-agent.png", true, "VoxenCore", 4, 5, "https://voxen-core.com" },
                    { 25, 5, new DateTime(2024, 1, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), "Tăng tốc viết mã và kiểm tra lỗi", "wwwroot/images/agents/default-agent.png", true, "MindLoom", 1, 2, "https://mind-loom.com" },
                    { 26, 6, new DateTime(2024, 1, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), "Phân tích dữ liệu chuyên sâu bằng AI", "wwwroot/images/agents/default-agent.png", true, "KairoUnit", 2, 3, "https://kairo-unit.com" },
                    { 27, 7, new DateTime(2024, 1, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), "Phân tích thị trường và hành vi khách hàng", "wwwroot/images/agents/default-agent.png", true, "LumenQuest", 3, 4, "https://lumen-quest.com" },
                    { 28, 8, new DateTime(2024, 1, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Trợ lý sáng tạo cho viết bài và video", "wwwroot/images/agents/default-agent.png", true, "RiftSync", 4, 5, "https://rift-sync.com" },
                    { 29, 9, new DateTime(2024, 1, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), "Nhận diện và phản hồi giọng nói tự nhiên", "wwwroot/images/agents/default-agent.png", true, "CerebraLink", 1, 2, "https://cerebra-link.com" },
                    { 30, 10, new DateTime(2024, 1, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), "Tư vấn và phân tích tài chính bằng AI", "wwwroot/images/agents/default-agent.png", true, "HaloNest", 2, 3, "https://halo-nest.com" }
                });

            migrationBuilder.InsertData(
                table: "Follows",
                columns: new[] { "Id", "AgentId", "FollowedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 2, 2, new DateTime(2024, 2, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 3, 1, new DateTime(2024, 2, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 4, 3, new DateTime(2024, 2, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_CategoryId",
                table: "Agents",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_PaymentTypeId",
                table: "Agents",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_SupplierId",
                table: "Agents",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AgentId",
                table: "Articles",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_AgentId",
                table: "Follows",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_UserId_AgentId",
                table: "Follows",
                columns: new[] { "UserId", "AgentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AgentId",
                table: "Reviews",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemLogs_UserId",
                table: "SystemLogs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Follows");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "SystemLogs");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
