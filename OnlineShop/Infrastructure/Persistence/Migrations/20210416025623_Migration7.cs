using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class Migration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Product",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CartId",
                table: "Transactions",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Carts_CartId",
                table: "Transactions",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Carts_CartId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CartId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "Product",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Transactions",
                type: "decimal(14, 2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
