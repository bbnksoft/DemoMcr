using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Product.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedAt", "CreatedBy", "Description", "IsActive", "IsDeleted", "Name", "Price", "SKU", "StockQuantity", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Electronics", new DateTime(2025, 12, 7, 6, 41, 45, 131, DateTimeKind.Utc).AddTicks(9318), null, "Ergonomic wireless mouse with 6 buttons", true, false, "Wireless Mouse", 29.99m, "WM-001", 150, null, null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Electronics", new DateTime(2025, 12, 7, 6, 41, 45, 131, DateTimeKind.Utc).AddTicks(9326), null, "RGB mechanical keyboard with Cherry MX switches", true, false, "Mechanical Keyboard", 89.99m, "KB-002", 75, null, null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Accessories", new DateTime(2025, 12, 7, 6, 41, 45, 131, DateTimeKind.Utc).AddTicks(9329), null, "7-in-1 USB-C hub with HDMI and card reader", true, false, "USB-C Hub", 45.99m, "HUB-003", 200, null, null },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Accessories", new DateTime(2025, 12, 7, 6, 41, 45, 131, DateTimeKind.Utc).AddTicks(9332), null, "Adjustable aluminum laptop stand", true, false, "Laptop Stand", 39.99m, "LS-004", 120, null, null },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Electronics", new DateTime(2025, 12, 7, 6, 41, 45, 131, DateTimeKind.Utc).AddTicks(9341), null, "1080p HD webcam with built-in microphone", true, false, "Webcam HD", 69.99m, "WC-005", 90, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));
        }
    }
}
