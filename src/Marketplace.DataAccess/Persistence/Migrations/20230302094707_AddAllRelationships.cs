using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marketplace.DataAccess.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAllRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CustomerInfos",
                newName: "User_Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "User_Id");

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentMethodId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentMethod_Id",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Product_Id",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PromocodeId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Promocode_Id",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "CustomerInfos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Order_Id",
                table: "CustomerInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerInfoId",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerInfo_Id",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentMethodId",
                table: "Orders",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PromocodeId",
                table: "Orders",
                column: "PromocodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInfos_OrderId",
                table: "CustomerInfos",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerInfoId",
                table: "Addresses",
                column: "CustomerInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_CustomerInfos_CustomerInfoId",
                table: "Addresses",
                column: "CustomerInfoId",
                principalTable: "CustomerInfos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerInfos_Orders_OrderId",
                table: "CustomerInfos",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PaymentMethods_PaymentMethodId",
                table: "Orders",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Promocodes_PromocodeId",
                table: "Orders",
                column: "PromocodeId",
                principalTable: "Promocodes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_CustomerInfos_CustomerInfoId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInfos_Orders_OrderId",
                table: "CustomerInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentMethods_PaymentMethodId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Promocodes_PromocodeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentMethodId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PromocodeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_CustomerInfos_OrderId",
                table: "CustomerInfos");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CustomerInfoId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentMethod_Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Product_Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PromocodeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Promocode_Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "CustomerInfos");

            migrationBuilder.DropColumn(
                name: "Order_Id",
                table: "CustomerInfos");

            migrationBuilder.DropColumn(
                name: "CustomerInfoId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CustomerInfo_Id",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "CustomerInfos",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Comments",
                newName: "UserId");
        }
    }
}
