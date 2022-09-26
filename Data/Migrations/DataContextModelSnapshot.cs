﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThirtyDaysOfShred.API.Data;

#nullable disable

namespace ThirtyDaysOfShred.API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.AuthoredTabs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("AuthoredTabs");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.FavoritedTabs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("FavoritedTabs");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.GuitarTab", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AuthoredTabsId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FavoritedTabsId")
                        .HasColumnType("int");

                    b.Property<string>("FileLocationUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<int?>("LikedTabsId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfFavorites")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfLikes")
                        .HasColumnType("int");

                    b.Property<int?>("PracticeRoutineDtoId")
                        .HasColumnType("int");

                    b.Property<string>("PreviewImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SkillLevel")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthoredTabsId");

                    b.HasIndex("FavoritedTabsId");

                    b.HasIndex("LikedTabsId");

                    b.HasIndex("PracticeRoutineDtoId");

                    b.ToTable("GuitarTabs");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.LikedTabs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("LikedTabs");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.PracticeRoutineDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastPracticed")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SkillLevel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("PracticeRoutines");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("GuitarTabId")
                        .HasColumnType("int");

                    b.Property<int?>("LessonId")
                        .HasColumnType("int");

                    b.Property<int?>("PracticeRoutineDtoId")
                        .HasColumnType("int");

                    b.Property<string>("TagName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GuitarTabId");

                    b.HasIndex("LessonId");

                    b.HasIndex("PracticeRoutineDtoId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Lessons.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileLocationUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfFavorites")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfLikes")
                        .HasColumnType("int");

                    b.Property<int?>("PracticeRoutineDtoId")
                        .HasColumnType("int");

                    b.Property<int>("SkillLevel")
                        .HasColumnType("int");

                    b.Property<string>("VideoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PracticeRoutineDtoId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Users.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KnownAs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ProfileImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.AuthoredTabs", b =>
                {
                    b.HasOne("ThirtyDaysOfShred.API.Entities.Users.AppUser", "AppUser")
                        .WithMany("AuthoredTabs")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.FavoritedTabs", b =>
                {
                    b.HasOne("ThirtyDaysOfShred.API.Entities.Users.AppUser", "AppUser")
                        .WithMany("FavoriteTabs")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.GuitarTab", b =>
                {
                    b.HasOne("ThirtyDaysOfShred.API.Entities.GuitarTabs.AuthoredTabs", null)
                        .WithMany("Tabs")
                        .HasForeignKey("AuthoredTabsId");

                    b.HasOne("ThirtyDaysOfShred.API.Entities.GuitarTabs.FavoritedTabs", null)
                        .WithMany("Tabs")
                        .HasForeignKey("FavoritedTabsId");

                    b.HasOne("ThirtyDaysOfShred.API.Entities.GuitarTabs.LikedTabs", null)
                        .WithMany("Tabs")
                        .HasForeignKey("LikedTabsId");

                    b.HasOne("ThirtyDaysOfShred.API.Entities.GuitarTabs.PracticeRoutineDto", null)
                        .WithMany("Tabs")
                        .HasForeignKey("PracticeRoutineDtoId");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.LikedTabs", b =>
                {
                    b.HasOne("ThirtyDaysOfShred.API.Entities.Users.AppUser", "AppUser")
                        .WithMany("LikedTabs")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.PracticeRoutineDto", b =>
                {
                    b.HasOne("ThirtyDaysOfShred.API.Entities.Users.AppUser", "AppUser")
                        .WithMany("PracticeRoutines")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.Tag", b =>
                {
                    b.HasOne("ThirtyDaysOfShred.API.Entities.GuitarTabs.GuitarTab", null)
                        .WithMany("Tags")
                        .HasForeignKey("GuitarTabId");

                    b.HasOne("ThirtyDaysOfShred.API.Entities.Lessons.Lesson", null)
                        .WithMany("Tags")
                        .HasForeignKey("LessonId");

                    b.HasOne("ThirtyDaysOfShred.API.Entities.GuitarTabs.PracticeRoutineDto", null)
                        .WithMany("Tags")
                        .HasForeignKey("PracticeRoutineDtoId");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Lessons.Lesson", b =>
                {
                    b.HasOne("ThirtyDaysOfShred.API.Entities.GuitarTabs.PracticeRoutineDto", null)
                        .WithMany("Lessons")
                        .HasForeignKey("PracticeRoutineDtoId");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.AuthoredTabs", b =>
                {
                    b.Navigation("Tabs");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.FavoritedTabs", b =>
                {
                    b.Navigation("Tabs");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.GuitarTab", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.LikedTabs", b =>
                {
                    b.Navigation("Tabs");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.PracticeRoutineDto", b =>
                {
                    b.Navigation("Lessons");

                    b.Navigation("Tabs");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Lessons.Lesson", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Users.AppUser", b =>
                {
                    b.Navigation("AuthoredTabs");

                    b.Navigation("FavoriteTabs");

                    b.Navigation("LikedTabs");

                    b.Navigation("PracticeRoutines");
                });
#pragma warning restore 612, 618
        }
    }
}
