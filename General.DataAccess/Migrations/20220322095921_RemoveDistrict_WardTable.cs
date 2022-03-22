using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace General.DataAccess.Migrations
{
    public partial class RemoveDistrict_WardTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresses_Districts_DistrictID",
                table: "UserAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresses_Wards_WardID",
                table: "UserAddresses");

            migrationBuilder.DropTable(
                name: "Wards");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropIndex(
                name: "IX_UserAddresses_DistrictID",
                table: "UserAddresses");

            migrationBuilder.DropIndex(
                name: "IX_UserAddresses_WardID",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "DistrictID",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "WardID",
                table: "UserAddresses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DistrictID",
                table: "UserAddresses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WardID",
                table: "UserAddresses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    DistrictID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CityID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.DistrictID);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wards",
                columns: table => new
                {
                    WardID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DistrictID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WardName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wards", x => x.WardID);
                    table.ForeignKey(
                        name: "FK_Wards_Districts_DistrictID",
                        column: x => x.DistrictID,
                        principalTable: "Districts",
                        principalColumn: "DistrictID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_DistrictID",
                table: "UserAddresses",
                column: "DistrictID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_WardID",
                table: "UserAddresses",
                column: "WardID");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityID",
                table: "Districts",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Wards_DistrictID",
                table: "Wards",
                column: "DistrictID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_Districts_DistrictID",
                table: "UserAddresses",
                column: "DistrictID",
                principalTable: "Districts",
                principalColumn: "DistrictID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_Wards_WardID",
                table: "UserAddresses",
                column: "WardID",
                principalTable: "Wards",
                principalColumn: "WardID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
