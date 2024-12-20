﻿// <auto-generated />
using ManyToMany_EF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ManyToMany_EF.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241026194353_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.Property<int>("CoursesCourseId")
                        .HasColumnType("integer");

                    b.Property<int>("StudentsStudentId")
                        .HasColumnType("integer");

                    b.HasKey("CoursesCourseId", "StudentsStudentId");

                    b.HasIndex("StudentsStudentId");

                    b.ToTable("CourseStudent");

                    b.HasData(
                        new
                        {
                            CoursesCourseId = 1,
                            StudentsStudentId = 1
                        },
                        new
                        {
                            CoursesCourseId = 1,
                            StudentsStudentId = 2
                        },
                        new
                        {
                            CoursesCourseId = 1,
                            StudentsStudentId = 3
                        },
                        new
                        {
                            CoursesCourseId = 1,
                            StudentsStudentId = 4
                        },
                        new
                        {
                            CoursesCourseId = 2,
                            StudentsStudentId = 1
                        },
                        new
                        {
                            CoursesCourseId = 2,
                            StudentsStudentId = 2
                        },
                        new
                        {
                            CoursesCourseId = 2,
                            StudentsStudentId = 3
                        });
                });

            modelBuilder.Entity("ManyToMany_EF.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CourseId"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            Title = "Intro to Physics"
                        },
                        new
                        {
                            CourseId = 2,
                            Title = "Web Development I"
                        },
                        new
                        {
                            CourseId = 3,
                            Title = "Writing I"
                        },
                        new
                        {
                            CourseId = 4,
                            Title = "History"
                        });
                });

            modelBuilder.Entity("ManyToMany_EF.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StudentId"));

                    b.Property<string>("FinancialAid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("StudentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            FinancialAid = "Passed",
                            Name = "John Doe"
                        },
                        new
                        {
                            StudentId = 2,
                            FinancialAid = "Passed",
                            Name = "Chris Brown"
                        },
                        new
                        {
                            StudentId = 3,
                            FinancialAid = "Passed",
                            Name = "Anne Reid"
                        },
                        new
                        {
                            StudentId = 4,
                            FinancialAid = "Passed",
                            Name = "Kyle Thomas"
                        });
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.HasOne("ManyToMany_EF.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManyToMany_EF.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsStudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
