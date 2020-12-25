using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace UserProduct.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IdentityNumber = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EMailAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateDate", "Description", "IsActive", "IsDeleted", "Name", "Price", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 25, 2, 8, 10, 928, DateTimeKind.Local).AddTicks(665), "P1 Description...", true, false, "P1", 12.33m, null },
                    { 15, new DateTime(2020, 12, 25, 2, 8, 10, 928, DateTimeKind.Local).AddTicks(6517), "P15 Description...", true, false, "P15", 26.33m, null },
                    { 14, new DateTime(2020, 12, 25, 2, 8, 10, 928, DateTimeKind.Local).AddTicks(6507), "P14 Description...", true, false, "P14", 25.33m, null },
                    { 13, new DateTime(2020, 12, 25, 2, 8, 10, 928, DateTimeKind.Local).AddTicks(6496), "P13 Description...", true, false, "P13", 24.33m, null },
                    { 12, new DateTime(2020, 12, 25, 2, 8, 10, 928, DateTimeKind.Local).AddTicks(6486), "P12 Description...", true, false, "P12", 23.33m, null },
                    { 11, new DateTime(2020, 12, 25, 2, 8, 10, 928, DateTimeKind.Local).AddTicks(6475), "P11 Description...", true, false, "P11", 22.33m, null },
                    { 10, new DateTime(2020, 12, 25, 2, 8, 10, 928, DateTimeKind.Local).AddTicks(6464), "P10 Description...", true, false, "P10", 21.33m, null },
                    { 9, new DateTime(2020, 12, 25, 2, 8, 10, 928, DateTimeKind.Local).AddTicks(6454), "P9 Description...", true, false, "P9", 20.33m, null },
                    { 7, new DateTime(2020, 12, 25, 2, 8, 10, 928, DateTimeKind.Local).AddTicks(6433), "P7 Description...", true, false, "P7", 18.33m, null },
                    { 6, new DateTime(2020, 12, 25, 2, 8, 10, 928, DateTimeKind.Local).AddTicks(6422), "P6 Description...", true, false, "P6", 17.33m, null },
                    { 5, new DateTime(2020, 12, 25, 2, 8, 10, 928, DateTimeKind.Local).AddTicks(6405), "P5 Description...", true, false, "P5", 16.33m, null },
                    { 4, new DateTime(2020, 12, 25, 2, 8, 10, 928, DateTimeKind.Local).AddTicks(6394), "P4 Description...", true, false, "P4", 15.33m, null },
                    { 3, new DateTime(2020, 12, 25, 2, 8, 10, 928, DateTimeKind.Local).AddTicks(6380), "P3 Description...", true, false, "P3", 14.33m, null },
                    { 2, new DateTime(2020, 12, 25, 2, 8, 10, 928, DateTimeKind.Local).AddTicks(6175), "P2 Description...", true, false, "P2", 13.33m, null },
                    { 8, new DateTime(2020, 12, 25, 2, 8, 10, 928, DateTimeKind.Local).AddTicks(6443), "P8 Description...", true, false, "P8", 19.33m, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "EMailAddress", "FirstName", "IdentityNumber", "IsActive", "IsDeleted", "LastName", "PhoneNumber", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 25, 2, 8, 10, 917, DateTimeKind.Local).AddTicks(8564), "test@test.test", "Ahmet", "11111111111", true, false, "Ekmekci", "5555555555", null },
                    { 2, new DateTime(2020, 12, 25, 2, 8, 10, 922, DateTimeKind.Local).AddTicks(5459), "testtest@test.test", "XXX", "22222222222", true, false, "YYY", "5445555555", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductId",
                table: "Carts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
