using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AI_Agent_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAgentSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImagePath", "Name" },
                values: new object[] { "Công cụ AI cho đồ họa và UX/UI", "wwwroot/images/agents/NovaFlux.png", "NovaFlux" });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImagePath", "Name", "SupplierId" },
                values: new object[] { "Công cụ AI hỗ trợ công trình học thuật", "wwwroot/images/agents/QuantaNova.png", "QuantaNova", 1 });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "ImagePath", "IsActive", "Name", "PaymentTypeId", "SupplierId" },
                values: new object[,]
                {
                    { 3, 3, new DateTime(2024, 1, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), "Phân tích và mô phỏng dữ liệu khoa học", "wwwroot/images/agents/ByteWarden.png", true, "ByteWarden", 3, 1 },
                    { 4, 4, new DateTime(2024, 1, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "AI quản lý lịch trình và nhắc việc", "wwwroot/images/agents/EchoPulse.png", true, "EchoPulse", 4, 1 },
                    { 5, 5, new DateTime(2024, 1, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Hỗ trợ phát triển phần mềm thông minh", "wwwroot/images/agents/ZenithBot.png", true, "ZenithBot", 1, 1 },
                    { 6, 6, new DateTime(2024, 1, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "AI hỗ trợ ra quyết định từ dữ liệu", "wwwroot/images/agents/AstroSage.png", true, "AstroSage", 2, 1 },
                    { 7, 7, new DateTime(2024, 1, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), "Chiến lược tiếp thị được tối ưu bằng AI", "wwwroot/images/agents/GlimmerAI.png", true, "GlimmerAI", 3, 1 },
                    { 8, 8, new DateTime(2024, 1, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), "AI viết nội dung và tạo ý tưởng sáng tạo", "wwwroot/images/agents/OrbitalNest.png", true, "OrbitalNest", 4, 1 },
                    { 9, 9, new DateTime(2024, 1, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), "Nhận diện và phản hồi giọng nói tự nhiên", "wwwroot/images/agents/Synthara.png", true, "Synthara", 1, 1 },
                    { 10, 10, new DateTime(2024, 1, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), "Hỗ trợ đầu tư và quản lý tài chính cá nhân", "wwwroot/images/agents/ChronaEdge.png", true, "ChronaEdge", 2, 1 },
                    { 11, 1, new DateTime(2024, 1, 11, 8, 0, 0, 0, DateTimeKind.Unspecified), "Công cụ AI cho đồ họa và UX/UI", "wwwroot/images/agents/VantaSpark.png", true, "VantaSpark", 3, 1 },
                    { 12, 2, new DateTime(2024, 1, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), "Phân tích và tổng hợp tài liệu nhanh chóng", "wwwroot/images/agents/LucidForge.png", true, "LucidForge", 4, 1 },
                    { 13, 3, new DateTime(2024, 1, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), "Tăng hiệu quả nghiên cứu khoa học", "wwwroot/images/agents/NeuraWhirl.png", true, "NeuraWhirl", 1, 1 },
                    { 14, 4, new DateTime(2024, 1, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), "Trợ lý ảo cá nhân thông minh", "wwwroot/images/agents/PrismShift.png", true, "PrismShift", 2, 1 },
                    { 15, 5, new DateTime(2024, 1, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), "Tăng tốc viết mã và kiểm tra lỗi", "wwwroot/images/agents/HexaTune.png", true, "HexaTune", 3, 1 },
                    { 16, 6, new DateTime(2024, 1, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), "AI hỗ trợ ra quyết định từ dữ liệu", "wwwroot/images/agents/default-agent.png", true, "OmniScribe", 4, 1 },
                    { 17, 7, new DateTime(2024, 1, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), "Phân tích thị trường và hành vi khách hàng", "wwwroot/images/agents/default-agent.png", true, "AeroMind", 1, 1 },
                    { 18, 8, new DateTime(2024, 1, 18, 8, 0, 0, 0, DateTimeKind.Unspecified), "Trợ lý sáng tạo cho viết bài và video", "wwwroot/images/agents/default-agent.png", true, "PulseCraft", 2, 1 },
                    { 19, 9, new DateTime(2024, 1, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), "Nhận diện và phản hồi giọng nói tự nhiên", "wwwroot/images/agents/default-agent.png", true, "TerraByte", 3, 1 },
                    { 20, 10, new DateTime(2024, 1, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), "Theo dõi dòng tiền và lập kế hoạch tài chính", "wwwroot/images/agents/default-agent.png", true, "NexonNode", 4, 1 },
                    { 21, 1, new DateTime(2024, 1, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), "Hỗ trợ thiết kế sáng tạo chuyên nghiệp", "wwwroot/images/agents/default-agent.png", true, "StellarWeave", 1, 1 },
                    { 22, 2, new DateTime(2024, 1, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), "Công cụ AI hỗ trợ công trình học thuật", "wwwroot/images/agents/default-agent.png", true, "QuirkBot", 2, 1 },
                    { 23, 3, new DateTime(2024, 1, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), "Hỗ trợ khám phá khoa học bằng AI", "wwwroot/images/agents/default-agent.png", true, "CodeRipple", 3, 1 },
                    { 24, 4, new DateTime(2024, 1, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), "Trợ lý ảo cá nhân thông minh", "wwwroot/images/agents/default-agent.png", true, "VoxenCore", 4, 1 },
                    { 25, 5, new DateTime(2024, 1, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), "Tăng tốc viết mã và kiểm tra lỗi", "wwwroot/images/agents/default-agent.png", true, "MindLoom", 1, 1 },
                    { 26, 6, new DateTime(2024, 1, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), "Phân tích dữ liệu chuyên sâu bằng AI", "wwwroot/images/agents/default-agent.png", true, "KairoUnit", 2, 1 },
                    { 27, 7, new DateTime(2024, 1, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), "Phân tích thị trường và hành vi khách hàng", "wwwroot/images/agents/default-agent.png", true, "LumenQuest", 3, 1 },
                    { 28, 8, new DateTime(2024, 1, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), "Trợ lý sáng tạo cho viết bài và video", "wwwroot/images/agents/default-agent.png", true, "RiftSync", 4, 1 },
                    { 29, 9, new DateTime(2024, 1, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), "Nhận diện và phản hồi giọng nói tự nhiên", "wwwroot/images/agents/default-agent.png", true, "CerebraLink", 1, 1 },
                    { 30, 10, new DateTime(2024, 1, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), "Tư vấn và phân tích tài chính bằng AI", "wwwroot/images/agents/default-agent.png", true, "HaloNest", 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImagePath", "Name" },
                values: new object[] { "Tư vấn tự động", null, "AI Chatbot" });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImagePath", "Name", "SupplierId" },
                values: new object[] { "Phân tích dữ liệu", null, "Data Analyzer", 2 });
        }
    }
}
