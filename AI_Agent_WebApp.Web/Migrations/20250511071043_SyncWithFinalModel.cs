using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AI_Agent_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class SyncWithFinalModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "StaffId",
                table: "SystemLogs",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Articles",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemLogs_UserId",
                table: "SystemLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AgentId",
                table: "Reviews",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AgentId",
                table: "Articles",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Categories_CategoryId",
                table: "Agents",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_PaymentTypes_PaymentTypeId",
                table: "Agents",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Users_SupplierId",
                table: "Agents",
                column: "SupplierId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Agents_AgentId",
                table: "Articles",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Users_UserId",
                table: "Articles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Agents_AgentId",
                table: "Reviews",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemLogs_Users_UserId",
                table: "SystemLogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Categories_CategoryId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Agents_PaymentTypes_PaymentTypeId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Users_SupplierId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Agents_AgentId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Users_UserId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Agents_AgentId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemLogs_Users_UserId",
                table: "SystemLogs");

            migrationBuilder.DropIndex(
                name: "IX_SystemLogs_UserId",
                table: "SystemLogs");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_AgentId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Articles_AgentId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_UserId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Agents_CategoryId",
                table: "Agents");

            migrationBuilder.DropIndex(
                name: "IX_Agents_PaymentTypeId",
                table: "Agents");

            migrationBuilder.DropIndex(
                name: "IX_Agents_SupplierId",
                table: "Agents");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "SystemLogs",
                newName: "StaffId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Articles",
                newName: "AuthorId");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CompanyName", "CompanyWebsite", "CreatedAt", "Discriminator", "Email", "FullName", "PasswordHash", "Role", "Status", "Username" },
                values: new object[] { 3, "Cty AI", "https://ai-company.com", new DateTime(2024, 1, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), "Supplier", "supplier1@example.com", "Supplier One", "supplierhash", "Supplier", true, "supplier1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Discriminator", "Email", "FullName", "PasswordHash", "Role", "Username" },
                values: new object[] { 4, new DateTime(2024, 1, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Staff", "staff1@example.com", "Staff One", "staffhash", "Staff", "staff1" });
        }
    }
}
