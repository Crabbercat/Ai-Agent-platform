using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AI_Agent_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTPHDiscriminator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

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
        }
    }
}
