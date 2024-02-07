﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using infrutructure;
using Teacherinfrutructure;

#nullable disable

namespace infrutructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240108175301_init1")]
    partial class init1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TeacherDomain.Entities.Manager.Manager", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("TeacherDomain.Entities.Teacher.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("TeacherDomain.Entities.Vacation.Vacation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Days")
                        .HasColumnType("int");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("YearId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.HasIndex("TeacherId");

                    b.HasIndex("YearId");

                    b.ToTable("Vacations");
                });

            modelBuilder.Entity("TeacherDomain.Entities.Warning.Warning", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Warnings");
                });

            modelBuilder.Entity("TeacherDomain.Entities.YearVacation.Year", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("YearId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Year");
                });

            modelBuilder.Entity("TeacherDomain.Entities.Vacation.Vacation", b =>
                {
                    b.HasOne("TeacherDomain.Entities.Manager.Manager", "Manager")
                        .WithMany("Vacations")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeacherDomain.Entities.Teacher.Teacher", "Teacher")
                        .WithMany("Vacations")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeacherDomain.Entities.YearVacation.Year", "Year")
                        .WithMany("Vacations")
                        .HasForeignKey("YearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");

                    b.Navigation("Teacher");

                    b.Navigation("Year");
                });

            modelBuilder.Entity("TeacherDomain.Entities.Warning.Warning", b =>
                {
                    b.HasOne("TeacherDomain.Entities.Manager.Manager", "Manager")
                        .WithMany("Warnings")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeacherDomain.Entities.Teacher.Teacher", "Teacher")
                        .WithMany("Warnings")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("TeacherDomain.Entities.Manager.Manager", b =>
                {
                    b.Navigation("Vacations");

                    b.Navigation("Warnings");
                });

            modelBuilder.Entity("TeacherDomain.Entities.Teacher.Teacher", b =>
                {
                    b.Navigation("Vacations");

                    b.Navigation("Warnings");
                });

            modelBuilder.Entity("TeacherDomain.Entities.YearVacation.Year", b =>
                {
                    b.Navigation("Vacations");
                });
#pragma warning restore 612, 618
        }
    }
}
