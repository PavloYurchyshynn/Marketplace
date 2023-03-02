﻿// <auto-generated />
using System;
using Marketplace.DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Marketplace.DataAccess.Persistence.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230302094707_AddAllRelationships")]
    partial class AddAllRelationships
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Marketplace.Core.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CustomerInfoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerInfo_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("HomeNumber")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerInfoId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Marketplace.Core.Entities.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Product_Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Marketplace.Core.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Marketplace.Core.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("User_Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Marketplace.Core.Entities.CustomerInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LaseUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Order_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("User_Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("CustomerInfos");
                });

            modelBuilder.Entity("Marketplace.Core.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeliveryAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PaymentMethodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PaymentMethod_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Product_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PromocodeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Promocode_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentMethodId");

                    b.HasIndex("ProductId");

                    b.HasIndex("PromocodeId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Marketplace.Core.Entities.PaymentMethod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("Marketplace.Core.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Category_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CommentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Comment_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CommentId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Marketplace.Core.Entities.Promocode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiscountPercent")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Promocodes");
                });

            modelBuilder.Entity("Marketplace.Core.Entities.Address", b =>
                {
                    b.HasOne("Marketplace.Core.Entities.CustomerInfo", "CustomerInfo")
                        .WithMany("Address")
                        .HasForeignKey("CustomerInfoId");

                    b.Navigation("CustomerInfo");
                });

            modelBuilder.Entity("Marketplace.Core.Entities.Cart", b =>
                {
                    b.HasOne("Marketplace.Core.Entities.Product", "Product")
                        .WithMany("Cart")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Marketplace.Core.Entities.CustomerInfo", b =>
                {
                    b.HasOne("Marketplace.Core.Entities.Order", "Order")
                        .WithMany("CustomerInfo")
                        .HasForeignKey("OrderId");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Marketplace.Core.Entities.Order", b =>
                {
                    b.HasOne("Marketplace.Core.Entities.PaymentMethod", "PaymentMethod")
                        .WithMany("Order")
                        .HasForeignKey("PaymentMethodId");

                    b.HasOne("Marketplace.Core.Entities.Product", "Product")
                        .WithMany("Order")
                        .HasForeignKey("ProductId");

                    b.HasOne("Marketplace.Core.Entities.Promocode", "Promocode")
                        .WithMany("Order")
                        .HasForeignKey("PromocodeId");

                    b.Navigation("PaymentMethod");

                    b.Navigation("Product");

                    b.Navigation("Promocode");
                });

            modelBuilder.Entity("Marketplace.Core.Entities.Product", b =>
                {
                    b.HasOne("Marketplace.Core.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.HasOne("Marketplace.Core.Entities.Comment", "Comment")
                        .WithMany("Products")
                        .HasForeignKey("CommentId");

                    b.Navigation("Category");

                    b.Navigation("Comment");
                });

            modelBuilder.Entity("Marketplace.Core.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Marketplace.Core.Entities.Comment", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Marketplace.Core.Entities.CustomerInfo", b =>
                {
                    b.Navigation("Address");
                });

            modelBuilder.Entity("Marketplace.Core.Entities.Order", b =>
                {
                    b.Navigation("CustomerInfo");
                });

            modelBuilder.Entity("Marketplace.Core.Entities.PaymentMethod", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("Marketplace.Core.Entities.Product", b =>
                {
                    b.Navigation("Cart");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Marketplace.Core.Entities.Promocode", b =>
                {
                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
