using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class Migration12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "UserProperties");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UserProperties",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "UserProperties",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "UserProperties",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "UserProperties");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "UserProperties");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "UserProperties");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "UserProperties",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
