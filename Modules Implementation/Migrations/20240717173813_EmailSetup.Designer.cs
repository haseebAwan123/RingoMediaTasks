﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Modules_Implementation.Context;

#nullable disable

namespace Modules_Implementation.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240717173813_EmailSetup")]
    partial class EmailSetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Modules_Implementation.Models.Departments", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentID"), 1L, 1);

                    b.Property<string>("DepartmentLogo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentDepartmentID")
                        .HasColumnType("int");

                    b.HasKey("DepartmentID");

                    b.HasIndex("ParentDepartmentID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Modules_Implementation.Models.Reminders", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Reminders");
                });

            modelBuilder.Entity("Modules_Implementation.Models.SubDepartments", b =>
                {
                    b.Property<int>("SubDepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubDepartmentID"), 1L, 1);

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("SubDepartmentLogo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubDepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubDepartmentID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("SubDepartments");
                });

            modelBuilder.Entity("Modules_Implementation.Models.Departments", b =>
                {
                    b.HasOne("Modules_Implementation.Models.Departments", "ParentDepartment")
                        .WithMany()
                        .HasForeignKey("ParentDepartmentID");

                    b.Navigation("ParentDepartment");
                });

            modelBuilder.Entity("Modules_Implementation.Models.SubDepartments", b =>
                {
                    b.HasOne("Modules_Implementation.Models.Departments", "Department")
                        .WithMany("SubDepartments")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Modules_Implementation.Models.Departments", b =>
                {
                    b.Navigation("SubDepartments");
                });
#pragma warning restore 612, 618
        }
    }
}
