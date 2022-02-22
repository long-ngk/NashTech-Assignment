using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace General.DataAccess.Migrations
{
    public partial class UpdateNameOfProductCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_productCategories_ProductCategoryCategoryID",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productCategories",
                table: "productCategories");

            migrationBuilder.RenameTable(
                name: "productCategories",
                newName: "ProductCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryCategoryID",
                table: "Products",
                column: "ProductCategoryCategoryID",
                principalTable: "ProductCategories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryCategoryID",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories");

            migrationBuilder.RenameTable(
                name: "ProductCategories",
                newName: "productCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productCategories",
                table: "productCategories",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_productCategories_ProductCategoryCategoryID",
                table: "Products",
                column: "ProductCategoryCategoryID",
                principalTable: "productCategories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
