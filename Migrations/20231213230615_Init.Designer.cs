﻿// <auto-generated />
using System;
using Cafe;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cafe.Migrations
{
    [DbContext(typeof(CafeDbContext))]
    [Migration("20231213230615_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cafe.Entities.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsAvailiable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsAvailiable = true,
                            Name = "Barbequ",
                            Price = 22.5
                        },
                        new
                        {
                            Id = 2,
                            IsAvailiable = true,
                            Name = "Hinkali",
                            Price = 45.0
                        },
                        new
                        {
                            Id = 3,
                            IsAvailiable = true,
                            Name = "Soup Harcho",
                            Price = 11.4
                        });
                });

            modelBuilder.Entity("Cafe.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TableId")
                        .HasColumnType("int");

                    b.Property<int?>("WaiterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TableId");

                    b.HasIndex("WaiterId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Cafe.Entities.OrderPosition", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "MenuItemId");

                    b.HasIndex("MenuItemId");

                    b.ToTable("OrderPositions");
                });

            modelBuilder.Entity("Cafe.Entities.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Status = 2
                        },
                        new
                        {
                            Id = 2,
                            Status = 2
                        },
                        new
                        {
                            Id = 3,
                            Status = 2
                        });
                });

            modelBuilder.Entity("Cafe.Entities.Waiter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Waiters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Tom",
                            Surname = "White"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bob",
                            Surname = "Jenkins"
                        });
                });

            modelBuilder.Entity("Cafe.Entities.Order", b =>
                {
                    b.HasOne("Cafe.Entities.Table", "Table")
                        .WithMany()
                        .HasForeignKey("TableId");

                    b.HasOne("Cafe.Entities.Waiter", "Waiter")
                        .WithMany("Orders")
                        .HasForeignKey("WaiterId");

                    b.Navigation("Table");

                    b.Navigation("Waiter");
                });

            modelBuilder.Entity("Cafe.Entities.OrderPosition", b =>
                {
                    b.HasOne("Cafe.Entities.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cafe.Entities.Order", "Order")
                        .WithMany("Positions")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Cafe.Entities.Order", b =>
                {
                    b.Navigation("Positions");
                });

            modelBuilder.Entity("Cafe.Entities.Waiter", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
