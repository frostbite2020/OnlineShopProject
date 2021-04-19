using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class Migration9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_UserProperties_UserPropertyId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_UserPropertyId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "UserPropertyId",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "TransactionIndexId",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TransactionIndexs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserPropertyId = table.Column<int>(nullable: false),
                    TransactionGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionIndexs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionIndexs_UserProperties_UserPropertyId",
                        column: x => x.UserPropertyId,
                        principalTable: "UserProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionIndexId",
                table: "Transactions",
                column: "TransactionIndexId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionIndexs_UserPropertyId",
                table: "TransactionIndexs",
                column: "UserPropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionIndexs_TransactionIndexId",
                table: "Transactions",
                column: "TransactionIndexId",
                principalTable: "TransactionIndexs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionIndexs_TransactionIndexId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "TransactionIndexs");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_TransactionIndexId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionIndexId",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "UserPropertyId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserPropertyId",
                table: "Transactions",
                column: "UserPropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_UserProperties_UserPropertyId",
                table: "Transactions",
                column: "UserPropertyId",
                principalTable: "UserProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
