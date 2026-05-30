using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.API.Migrations
{
    public partial class SeededDefaultUserandRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d9d71ed-e29a-40c1-82ff-d6c8440daa26", "45a961aa-8aea-4584-bf49-cc2f590f84c4", "User", "USER" },
                    { "9fc78a51-c80e-43ad-b26e-c7bb709f14e8", "2532b09e-98b9-460a-86d9-47def6083b71", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5f1136f4-93a8-4bbf-9018-b70a90486d5a", 0, "133766b7-d8ce-45de-98e9-d94940f3d52d", "user@bookstor.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEPTh/tw0XmfRJNR5hhOQLp1gvfyAPt9Ert3J8G9iRrk9LVxqVYDXtTmP24AN0pmkhg==", null, false, "62d2a2d8-db68-4d9c-b798-9dbf00a25c6d", false, "user@bookstor.com" },
                    { "a8d47df2-90dc-4df0-af1e-2b9cf2189c6c", 0, "965c2abe-462b-4ea2-9fb6-6f162aac7d6e", "admin@bookstor.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEJa0exZEOzCjw2IcipBDYiG7NNvBmFJFy91bDMo9Y+u7Vjhu9uSVnr+JkdLZnD5NtQ==", null, false, "168d2b51-4462-4f97-a799-f24df7716eff", false, "admin@bookstor.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1d9d71ed-e29a-40c1-82ff-d6c8440daa26", "5f1136f4-93a8-4bbf-9018-b70a90486d5a" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9fc78a51-c80e-43ad-b26e-c7bb709f14e8", "a8d47df2-90dc-4df0-af1e-2b9cf2189c6c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1d9d71ed-e29a-40c1-82ff-d6c8440daa26", "5f1136f4-93a8-4bbf-9018-b70a90486d5a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9fc78a51-c80e-43ad-b26e-c7bb709f14e8", "a8d47df2-90dc-4df0-af1e-2b9cf2189c6c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d9d71ed-e29a-40c1-82ff-d6c8440daa26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fc78a51-c80e-43ad-b26e-c7bb709f14e8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5f1136f4-93a8-4bbf-9018-b70a90486d5a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a8d47df2-90dc-4df0-af1e-2b9cf2189c6c");
        }
    }
}
