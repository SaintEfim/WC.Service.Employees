﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WC.Service.Employees.Data.PostgreSql.Context;

#nullable disable

namespace WC.Service.Employees.Data.PostgreSql.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20250309102131_Add_new_index")]
    partial class Add_new_index
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WC.Service.Employees.Data.Models.ColleagueEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ColleagueEmployeeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ColleagueEmployeeId");

                    b.HasIndex("EmployeeId", "ColleagueEmployeeId")
                        .IsUnique();

                    b.ToTable("Colleagues");
                });

            modelBuilder.Entity("WC.Service.Employees.Data.Models.EmployeeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.Property<Guid>("PositionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WC.Service.Employees.Data.Models.PositionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("WC.Service.Employees.Data.Models.ColleagueEntity", b =>
                {
                    b.HasOne("WC.Service.Employees.Data.Models.EmployeeEntity", "ColleagueEmployee")
                        .WithMany()
                        .HasForeignKey("ColleagueEmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WC.Service.Employees.Data.Models.EmployeeEntity", "Employee")
                        .WithMany("Colleagues")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ColleagueEmployee");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("WC.Service.Employees.Data.Models.EmployeeEntity", b =>
                {
                    b.HasOne("WC.Service.Employees.Data.Models.PositionEntity", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });

            modelBuilder.Entity("WC.Service.Employees.Data.Models.EmployeeEntity", b =>
                {
                    b.Navigation("Colleagues");
                });

            modelBuilder.Entity("WC.Service.Employees.Data.Models.PositionEntity", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
