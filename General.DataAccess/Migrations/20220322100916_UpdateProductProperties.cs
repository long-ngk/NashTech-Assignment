using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace General.DataAccess.Migrations
{
    public partial class UpdateProductProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryCategoryID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductDiscounts_ProductDiscountDiscountID",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductDiscountDiscountID",
                table: "Products",
                newName: "DiscountID");

            migrationBuilder.RenameColumn(
                name: "ProductCategoryCategoryID",
                table: "Products",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "ProdName",
                table: "Products",
                newName: "ProductName");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductDiscountDiscountID",
                table: "Products",
                newName: "IX_Products_DiscountID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductCategoryCategoryID",
                table: "Products",
                newName: "IX_Products_CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_CategoryID",
                table: "Products",
                column: "CategoryID",
                principalTable: "ProductCategories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductDiscounts_DiscountID",
                table: "Products",
                column: "DiscountID",
                principalTable: "ProductDiscounts",
                principalColumn: "DiscountID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_CategoryID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductDiscounts_DiscountID",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Products",
                newName: "ProdName");

            migrationBuilder.RenameColumn(
                name: "DiscountID",
                table: "Products",
                newName: "ProductDiscountDiscountID");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Products",
                newName: "ProductCategoryCategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_DiscountID",
                table: "Products",
                newName: "IX_Products_ProductDiscountDiscountID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                newName: "IX_Products_ProductCategoryCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryCategoryID",
                table: "Products",
                column: "ProductCategoryCategoryID",
                principalTable: "ProductCategories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductDiscounts_ProductDiscountDiscountID",
                table: "Products",
                column: "ProductDiscountDiscountID",
                principalTable: "ProductDiscounts",
                principalColumn: "DiscountID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
