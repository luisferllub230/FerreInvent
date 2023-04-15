using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Infraestructure.Persistence.Migrations
{
    public partial class InvetoryAndSales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Salesid",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Salesid",
                table: "Sales",
                column: "Salesid");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Sales_Salesid",
                table: "Sales",
                column: "Salesid",
                principalTable: "Sales",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Sales_Salesid",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_Salesid",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Salesid",
                table: "Sales");
        }
    }
}
