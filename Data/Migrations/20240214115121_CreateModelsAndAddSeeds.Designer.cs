﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240214115121_CreateModelsAndAddSeeds")]
    partial class CreateModelsAndAddSeeds
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entity.Lookups.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Student",
                            Name = "Student"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Teacher",
                            Name = "Teacher"
                        });
                });

            modelBuilder.Entity("Entity.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Math Math Math",
                            Name = "Math"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Science Science Science",
                            Name = "Science"
                        },
                        new
                        {
                            Id = 3,
                            Description = "History History History ",
                            Name = "History"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Spanish Spanish",
                            Name = "Spanish"
                        });
                });

            modelBuilder.Entity("Entity.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ServiceStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Universities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Location = "Amman",
                            Name = "JU",
                            ServiceStartDate = new DateTime(1965, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Location = "Irbid",
                            Name = "JUST",
                            ServiceStartDate = new DateTime(1985, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Entity.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("UniversityId")
                        .HasColumnType("int");

                    b.Property<int?>("UniverstityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UniversityId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Ali@gmail.com",
                            FirstName = "Ali",
                            LastName = "Yousef",
                            PasswordHash = "123",
                            RoleId = 1,
                            UniverstityId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "Ammar@gmail.com",
                            FirstName = "Ammar",
                            LastName = "Ahmed",
                            PasswordHash = "123",
                            RoleId = 1,
                            UniverstityId = 1
                        },
                        new
                        {
                            Id = 3,
                            Email = "Hosny@gmail.com",
                            FirstName = "Hosny",
                            LastName = "Tamer",
                            PasswordHash = "123",
                            RoleId = 2,
                            UniverstityId = 1
                        },
                        new
                        {
                            Id = 4,
                            Email = "Majed@gmail.com",
                            FirstName = "Majed",
                            LastName = "Saed",
                            PasswordHash = "123",
                            RoleId = 1,
                            UniverstityId = 1
                        },
                        new
                        {
                            Id = 5,
                            Email = "Khaled@gmail.com",
                            FirstName = "Khaled",
                            LastName = "Jaber",
                            PasswordHash = "123",
                            RoleId = 1,
                            UniverstityId = 1
                        });
                });

            modelBuilder.Entity("Entity.Models.UserCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCourse");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 2,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 3,
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            CourseId = 3,
                            UserId = 2
                        },
                        new
                        {
                            Id = 5,
                            CourseId = 4,
                            UserId = 2
                        },
                        new
                        {
                            Id = 6,
                            CourseId = 1,
                            UserId = 3
                        },
                        new
                        {
                            Id = 7,
                            CourseId = 3,
                            UserId = 3
                        },
                        new
                        {
                            Id = 8,
                            CourseId = 4,
                            UserId = 3
                        },
                        new
                        {
                            Id = 9,
                            CourseId = 1,
                            UserId = 4
                        },
                        new
                        {
                            Id = 10,
                            CourseId = 2,
                            UserId = 4
                        },
                        new
                        {
                            Id = 11,
                            CourseId = 4,
                            UserId = 4
                        },
                        new
                        {
                            Id = 12,
                            CourseId = 2,
                            UserId = 5
                        });
                });

            modelBuilder.Entity("Entity.Models.User", b =>
                {
                    b.HasOne("Entity.Lookups.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Models.University", "University")
                        .WithMany("Users")
                        .HasForeignKey("UniversityId");

                    b.Navigation("Role");

                    b.Navigation("University");
                });

            modelBuilder.Entity("Entity.Models.UserCourse", b =>
                {
                    b.HasOne("Entity.Models.Course", "Course")
                        .WithMany("UserCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Models.User", "User")
                        .WithMany("UserCourses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entity.Lookups.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Entity.Models.Course", b =>
                {
                    b.Navigation("UserCourses");
                });

            modelBuilder.Entity("Entity.Models.University", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Entity.Models.User", b =>
                {
                    b.Navigation("UserCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
