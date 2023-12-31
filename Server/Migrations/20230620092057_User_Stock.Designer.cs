﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proj_APBD.Server.Contexts;

#nullable disable

namespace Proj_APBD.Server.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230620092057_User_Stock")]
    partial class User_Stock
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proj_APBD.Server.Models.Stock", b =>
                {
                    b.Property<string>("Ticker")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Ticker");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("Proj_APBD.Server.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3b3ebc7d-fa9a-4f1a-aea2-0e022aefddeb"),
                            Password = "AQAAAAIAAYagAAAAEEJO4LuCMB1w3MPT/+ZpuSIsBse2HRuBfi01fS3Wnk9dlahVlaPT52diyojD3QsN7g==",
                            Username = "Admin"
                        });
                });

            modelBuilder.Entity("Proj_APBD.Server.Models.UserStock", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StockTicker")
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("UserId", "StockTicker");

                    b.HasIndex("StockTicker");

                    b.ToTable("User_Stock");
                });

            modelBuilder.Entity("Proj_APBD.Server.Models.UserStock", b =>
                {
                    b.HasOne("Proj_APBD.Server.Models.Stock", "Stock")
                        .WithMany("UserStocks")
                        .HasForeignKey("StockTicker")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proj_APBD.Server.Models.User", "User")
                        .WithMany("UserStocks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Proj_APBD.Server.Models.Stock", b =>
                {
                    b.Navigation("UserStocks");
                });

            modelBuilder.Entity("Proj_APBD.Server.Models.User", b =>
                {
                    b.Navigation("UserStocks");
                });
#pragma warning restore 612, 618
        }
    }
}
