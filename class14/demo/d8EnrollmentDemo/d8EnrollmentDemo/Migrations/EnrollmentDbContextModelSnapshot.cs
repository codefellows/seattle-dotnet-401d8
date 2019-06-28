﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using d8EnrollmentDemo.Data;

namespace d8EnrollmentDemo.Migrations
{
    [DbContext(typeof(EnrollmentDbContext))]
    partial class EnrollmentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("d8EnrollmentDemo.Models.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseCode");

                    b.Property<decimal>("Price");

                    b.Property<int>("Technology");

                    b.HasKey("ID");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CourseCode = "dotnet-is-cool",
                            Price = 50m,
                            Technology = 1
                        },
                        new
                        {
                            ID = 2,
                            CourseCode = "java is delicious",
                            Price = 75m,
                            Technology = 2
                        },
                        new
                        {
                            ID = 3,
                            CourseCode = "The Scripting in Java is crazy",
                            Price = 100m,
                            Technology = 3
                        });
                });

            modelBuilder.Entity("d8EnrollmentDemo.Models.Enrollments", b =>
                {
                    b.Property<int>("StudentID");

                    b.Property<int>("CourseID");

                    b.HasKey("StudentID", "CourseID");

                    b.HasIndex("CourseID");

                    b.ToTable("CourseEnrollments");
                });

            modelBuilder.Entity("d8EnrollmentDemo.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("ID");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Birthdate = new DateTime(1975, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Jack",
                            LastName = "Shepard"
                        },
                        new
                        {
                            ID = 2,
                            Birthdate = new DateTime(1979, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Kate",
                            LastName = "Austin"
                        },
                        new
                        {
                            ID = 3,
                            Birthdate = new DateTime(1974, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Hugo",
                            LastName = "Reyes"
                        });
                });

            modelBuilder.Entity("d8EnrollmentDemo.Models.Transcripts", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseID");

                    b.Property<int>("Grade");

                    b.Property<bool>("Passed");

                    b.Property<int>("StudentID");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("StudentID");

                    b.ToTable("Transcripts");
                });

            modelBuilder.Entity("d8EnrollmentDemo.Models.Enrollments", b =>
                {
                    b.HasOne("d8EnrollmentDemo.Models.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("d8EnrollmentDemo.Models.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("d8EnrollmentDemo.Models.Transcripts", b =>
                {
                    b.HasOne("d8EnrollmentDemo.Models.Course", "Course")
                        .WithMany("Transcripts")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("d8EnrollmentDemo.Models.Student", "Student")
                        .WithMany("Transcripts")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
