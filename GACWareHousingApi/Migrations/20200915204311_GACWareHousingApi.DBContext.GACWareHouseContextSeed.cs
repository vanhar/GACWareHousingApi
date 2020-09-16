using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GACWareHousingApi.Migrations
{
    public partial class GACWareHousingApiDBContextGACWareHouseContextSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerCode", "Address", "CompanyCode", "CreatedBy", "CreatedOn", "Email", "FirstName", "IsDeleted", "LastName", "ModifiedBy", "ModifiedOn", "PhoneNumber" },
                values: new object[,]
                {
                    { "C000001", "UAE", "GAC", "System", new DateTime(2020, 9, 16, 2, 13, 6, 55, DateTimeKind.Local).AddTicks(8460), "customerA@gmail.com", "Customer A", false, null, "System", new DateTime(2020, 9, 16, 2, 13, 6, 58, DateTimeKind.Local).AddTicks(8301), "919676000101" },
                    { "C000002", "UAE", "GAC", "System", new DateTime(2020, 9, 16, 2, 13, 6, 59, DateTimeKind.Local).AddTicks(346), "customerB@gmail.com", "Customer B", false, null, "System", new DateTime(2020, 9, 16, 2, 13, 6, 59, DateTimeKind.Local).AddTicks(364), "919676000102" }
                });

            migrationBuilder.InsertData(
                table: "Manfacturers",
                columns: new[] { "ManfacturerCode", "Address", "CreatedBy", "CreatedOn", "Email", "FirstName", "IsDeleted", "LastName", "ModifiedBy", "ModifiedOn", "PhoneNumber", "Rating" },
                values: new object[] { "M000001", "UAE", "System", new DateTime(2020, 9, 16, 2, 13, 6, 62, DateTimeKind.Local).AddTicks(7581), "manfacturerA@gmail.com", "Manfacturer A", false, null, "System", new DateTime(2020, 9, 16, 2, 13, 6, 62, DateTimeKind.Local).AddTicks(7627), "919676000101", 0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductCode", "CreatedBy", "CreatedOn", "Dimensions", "IsDeleted", "ManfacturerCode", "ModifiedBy", "ModifiedOn", "Price", "ProductName", "UOM" },
                values: new object[,]
                {
                    { "P000001", "System", new DateTime(2020, 9, 16, 2, 13, 6, 63, DateTimeKind.Local).AddTicks(3308), "50 X 20 X 100", false, "M000001", "System", new DateTime(2020, 9, 16, 2, 13, 6, 63, DateTimeKind.Local).AddTicks(3325), 25.5f, "Product A", "PC" },
                    { "P000002", "System", new DateTime(2020, 9, 16, 2, 13, 6, 63, DateTimeKind.Local).AddTicks(3511), "50 X 20 X 90", false, "M000001", "System", new DateTime(2020, 9, 16, 2, 13, 6, 63, DateTimeKind.Local).AddTicks(3516), 30.5f, "Product B", "PC" },
                    { "P000003", "System", new DateTime(2020, 9, 16, 2, 13, 6, 63, DateTimeKind.Local).AddTicks(3524), "50 X 20 X 70", false, "M000001", "System", new DateTime(2020, 9, 16, 2, 13, 6, 63, DateTimeKind.Local).AddTicks(3527), 35.5f, "Product C", "PC" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerCode",
                keyValue: "C000001");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerCode",
                keyValue: "C000002");

            migrationBuilder.DeleteData(
                table: "Manfacturers",
                keyColumn: "ManfacturerCode",
                keyValue: "M000001");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductCode",
                keyValue: "P000001");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductCode",
                keyValue: "P000002");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductCode",
                keyValue: "P000003");
        }
    }
}
