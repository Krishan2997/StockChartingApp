﻿// <auto-generated />
using System;
using CompanyAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CompanyAPI.Data.Migrations
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20210617184313_IPOsUpdatedAgain")]
    partial class IPOsUpdatedAgain
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CompanyAPI.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Line1")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Line2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("CompanyAPI.Entities.Companies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brief")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ceo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sector")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StockCode")
                        .HasColumnType("int");

                    b.Property<int>("Turnover")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("CompanyAPI.Entities.IPOs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("PricePerShare")
                        .HasColumnType("bigint");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TotalNumberOfShares")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId")
                        .IsUnique();

                    b.ToTable("IPOs");
                });

            modelBuilder.Entity("CompanyAPI.Entities.StockExchanges", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brief")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ContactAddressId")
                        .HasColumnType("int");

                    b.Property<int>("IPOsId")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StockExchangeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContactAddressId");

                    b.HasIndex("IPOsId");

                    b.ToTable("StockExchanges");
                });

            modelBuilder.Entity("CompanyAPI.Entities.IPOs", b =>
                {
                    b.HasOne("CompanyAPI.Entities.Companies", "Company")
                        .WithOne("IPOs")
                        .HasForeignKey("CompanyAPI.Entities.IPOs", "CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("CompanyAPI.Entities.StockExchanges", b =>
                {
                    b.HasOne("CompanyAPI.Entities.Address", "ContactAddress")
                        .WithMany()
                        .HasForeignKey("ContactAddressId");

                    b.HasOne("CompanyAPI.Entities.IPOs", "IPOs")
                        .WithMany("StockExchanges")
                        .HasForeignKey("IPOsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactAddress");

                    b.Navigation("IPOs");
                });

            modelBuilder.Entity("CompanyAPI.Entities.Companies", b =>
                {
                    b.Navigation("IPOs");
                });

            modelBuilder.Entity("CompanyAPI.Entities.IPOs", b =>
                {
                    b.Navigation("StockExchanges");
                });
#pragma warning restore 612, 618
        }
    }
}
