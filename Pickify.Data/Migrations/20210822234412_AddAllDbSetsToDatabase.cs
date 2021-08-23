using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pickify.Data.Migrations
{
    public partial class AddAllDbSetsToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    HouseNumber = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Street = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 125, nullable: false),
                    CategoryName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shippers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 125, nullable: false),
                    CompanyName = table.Column<string>(type: "TEXT", maxLength: 125, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 125, nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AddressId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 125, nullable: false),
                    CompanyName = table.Column<string>(type: "TEXT", maxLength: 125, nullable: false),
                    ContactFirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ContactLastName = table.Column<string>(type: "TEXT", nullable: true),
                    ContactTitle = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    AddressId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 125, nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    SupplierId = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryId = table.Column<string>(type: "TEXT", maxLength: 125, nullable: true),
                    UnitPrice = table.Column<double>(type: "REAL", nullable: false),
                    UnitWeight = table.Column<decimal>(type: "TEXT", nullable: false),
                    QuantityPerUnit = table.Column<int>(type: "INTEGER", nullable: false),
                    QuantityInStock = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    SalesTax = table.Column<double>(type: "REAL", nullable: false),
                    TotalAmount = table.Column<double>(type: "REAL", nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ShipDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RequireDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<string>(type: "TEXT", nullable: true),
                    ShipperId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Shippers_ShipperId",
                        column: x => x.ShipperId,
                        principalTable: "Shippers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    OrderId = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ProductId = table.Column<string>(type: "TEXT", maxLength: 125, nullable: false),
                    UnitPrice = table.Column<double>(type: "REAL", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    PaymentMethod = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipperId",
                table: "Orders",
                column: "ShipperId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_AddressId",
                table: "Suppliers",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Shippers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
