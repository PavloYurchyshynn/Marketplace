using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marketplace.DataAccess.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_CustomerInfos_CustomerInfoId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Products_ProductId",
                table: "Carts");

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

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Comments_CommentId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentMethodId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ProductId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CustomerInfoId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CustomerInfoId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Products",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CommentId",
                table: "Products",
                newName: "IX_Products_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                newName: "IX_Products_CartId");

            migrationBuilder.RenameColumn(
                name: "PromocodeId",
                table: "Orders",
                newName: "CustomerInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_PromocodeId",
                table: "Orders",
                newName: "IX_Orders_CustomerInfoId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "CustomerInfos",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerInfos_OrderId",
                table: "CustomerInfos",
                newName: "IX_CustomerInfos_AddressId");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Promocodes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "PaymentMethods",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Promocodes_OrderId",
                table: "Promocodes",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_OrderId",
                table: "PaymentMethods",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ProductId",
                table: "Categories",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Products_ProductId",
                table: "Categories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Products_ProductId",
                table: "Comments",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerInfos_Addresses_AddressId",
                table: "CustomerInfos",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CustomerInfos_CustomerInfoId",
                table: "Orders",
                column: "CustomerInfoId",
                principalTable: "CustomerInfos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethods_Orders_OrderId",
                table: "PaymentMethods",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Carts_CartId",
                table: "Products",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Promocodes_Orders_OrderId",
                table: "Promocodes",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Products_ProductId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Products_ProductId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInfos_Addresses_AddressId",
                table: "CustomerInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CustomerInfos_CustomerInfoId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethods_Orders_OrderId",
                table: "PaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Carts_CartId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Promocodes_Orders_OrderId",
                table: "Promocodes");

            migrationBuilder.DropIndex(
                name: "IX_Promocodes_OrderId",
                table: "Promocodes");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethods_OrderId",
                table: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ProductId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ProductId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Promocodes");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Products",
                newName: "CommentId");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_OrderId",
                table: "Products",
                newName: "IX_Products_CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CartId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameColumn(
                name: "CustomerInfoId",
                table: "Orders",
                newName: "PromocodeId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerInfoId",
                table: "Orders",
                newName: "IX_Orders_PromocodeId");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "CustomerInfos",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerInfos_AddressId",
                table: "CustomerInfos",
                newName: "IX_CustomerInfos_OrderId");

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentMethodId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerInfoId",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentMethodId",
                table: "Orders",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductId",
                table: "Carts",
                column: "ProductId");

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
                name: "FK_Carts_Products_ProductId",
                table: "Carts",
                column: "ProductId",
                principalTable: "Products",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Comments_CommentId",
                table: "Products",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }
    }
}
