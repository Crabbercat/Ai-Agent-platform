using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AI_Agent_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "ImagePath", "IsActive", "Name", "PaymentTypeId", "SupplierId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 5, 11, 11, 57, 38, 904, DateTimeKind.Local).AddTicks(1138), "Tư vấn tự động", null, true, "AI Chatbot", 1, 1 },
                    { 2, 2, new DateTime(2025, 5, 11, 11, 57, 38, 905, DateTimeKind.Local).AddTicks(4289), "Phân tích dữ liệu", null, true, "Data Analyzer", 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Discriminator", "Email", "FullName", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 11, 11, 57, 38, 906, DateTimeKind.Local).AddTicks(5047), "User", "admin@example.com", "Admin User", "adminhash", "Admin", "admin" },
                    { 2, new DateTime(2025, 5, 11, 11, 57, 38, 906, DateTimeKind.Local).AddTicks(5406), "User", "user1@example.com", "User One", "user1hash", "User", "user1" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CompanyName", "CompanyWebsite", "CreatedAt", "Discriminator", "Email", "FullName", "PasswordHash", "Role", "Status", "Username" },
                values: new object[] { 3, "Cty AI", "https://ai-company.com", new DateTime(2025, 5, 11, 11, 57, 38, 906, DateTimeKind.Local).AddTicks(6056), "Supplier", "supplier1@example.com", "Supplier One", "supplierhash", "Supplier", true, "supplier1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Discriminator", "Email", "FullName", "PasswordHash", "Role", "Username" },
                values: new object[] { 4, new DateTime(2025, 5, 11, 11, 57, 38, 906, DateTimeKind.Local).AddTicks(8021), "Staff", "staff1@example.com", "Staff One", "staffhash", "Staff", "staff1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
