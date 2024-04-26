﻿// <auto-generated />
using System;
using Mc2.CrudTest.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mc2.CrudTest.Persistence.Migrations
{
    [DbContext(typeof(FinanceDbContext))]
    [Migration("20240426065512_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Mc2.CrudTest.Domain.Models.DependentCreditNotes.DependentCreditNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CreditNumber")
                        .HasColumnType("int");

                    b.Property<int>("CreditStatus")
                        .HasColumnType("int");

                    b.Property<string>("ExternalCreditNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InvoiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("DependentCreditNotes");
                });

            modelBuilder.Entity("Mc2.CrudTest.Domain.Models.IndependentCreditNotes.IndependentCreditNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CreditNumber")
                        .HasColumnType("int");

                    b.Property<string>("ExternalCreditNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InvoiceStatus")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("IndependentCreditNote");
                });

            modelBuilder.Entity("Mc2.CrudTest.Domain.Models.Invoices.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ExternalInvoiceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InvoiceNumber")
                        .HasColumnType("int");

                    b.Property<int>("InvoiceStatus")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Mc2.CrudTest.Domain.Models.DependentCreditNotes.DependentCreditNote", b =>
                {
                    b.HasOne("Mc2.CrudTest.Domain.Models.Invoices.Invoice", "Invoice")
                        .WithMany("DependentCreditNotes")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("Mc2.CrudTest.Domain.Models.Invoices.Invoice", b =>
                {
                    b.Navigation("DependentCreditNotes");
                });
#pragma warning restore 612, 618
        }
    }
}