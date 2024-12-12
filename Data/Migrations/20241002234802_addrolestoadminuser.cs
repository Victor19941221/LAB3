using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab3.Data.Migrations
{
    /// <inheritdoc />
    public partial class addrolestoadminuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [AspNetUserRoles] (UserId, RoleId)\r\nSELECT '0a2c8e08-6f21-47bb-87ae-5b2daaeb9981', Id \r\nFROM [AspNetRoles]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [AspNetUserRoles] WHERE UserId='0a2c8e08-6f21-47bb-87ae-5b2daaeb9981'");
        }
    }
}
