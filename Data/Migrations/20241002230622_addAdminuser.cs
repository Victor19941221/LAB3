using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab3.Data.Migrations
{
    /// <inheritdoc />
    public partial class addAdminuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [Gender], [Age]) VALUES (N'0a2c8e08-6f21-47bb-87ae-5b2daaeb9981', N'admin', N'ADMIN', N'admin@test.com', N'ADMIN@TEST.COM', 0, N'AQAAAAIAAYagAAAAEF1tAbVLF85x3xg1AaAoB9NmheeNCPfwPTa7l/psm2R2mLHOCq4Z0ADeTF+K20f41A==', N'KYPRPYQL3AJBNQ76H6K3OJTA3IIFHH47', N'8562435d-be0c-423f-a9a7-3549d7892e3f', NULL, 0, 0, NULL, 1, 0, N'Admin', N'Adminsson', N'Male', 35)\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [AspNetUsers] WHERE Id='0a2c8e08-6f21-47bb-87ae-5b2daaeb9981'");
        }
    }
}
