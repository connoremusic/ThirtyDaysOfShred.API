﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThirtyDaysOfShred.API.Data;

#nullable disable

namespace ThirtyDaysOfShred.API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221008034456_Tab-Favorite-Entity-Added")]
    partial class TabFavoriteEntityAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.GuitarTab", b =>
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

                    b.Property<int>("NumberOfFavorites")
                        .HasColumnType("int");

                    b.Property<int?>("PracticeRoutineId")
                        .HasColumnType("int");

                    b.Property<int>("SkillLevel")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PracticeRoutineId");

                    b.ToTable("GuitarTabs");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.GuitarTabFavorite", b =>
                {
                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<int>("GuitarTabId")
                        .HasColumnType("int");

                    b.HasKey("AppUserId", "GuitarTabId");

                    b.HasIndex("GuitarTabId");

                    b.ToTable("FavoriteGuitarTabs");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.GuitarTabTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("GuitarTabId")
                        .HasColumnType("int");

                    b.Property<string>("TagName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GuitarTabId");

                    b.ToTable("GuitarTabTags");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.TabPreviewImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GuitarTabId")
                        .HasColumnType("int");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GuitarTabId")
                        .IsUnique();

                    b.ToTable("TabPreviewImage");
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

                    b.Property<int?>("PracticeRoutineId")
                        .HasColumnType("int");

                    b.Property<int>("SkillLevel")
                        .HasColumnType("int");

                    b.Property<string>("VideoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PracticeRoutineId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Lessons.LessonTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("LessonId")
                        .HasColumnType("int");

                    b.Property<string>("TagName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("LessonTags");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.PracticeRoutines.PracticeRoutine", b =>
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

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.PracticeRoutines.PracticeRoutineTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PracticeRoutineId")
                        .HasColumnType("int");

                    b.Property<string>("TagName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PracticeRoutineId");

                    b.ToTable("PracticeRoutineTags");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Users.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Influences")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KnownAs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Users.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Goal");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Users.ProfilePhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.ToTable("ProfilePhoto");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.GuitarTab", b =>
                {
                    b.HasOne("ThirtyDaysOfShred.API.Entities.PracticeRoutines.PracticeRoutine", null)
                        .WithMany("Tabs")
                        .HasForeignKey("PracticeRoutineId");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.GuitarTabFavorite", b =>
                {
                    b.HasOne("ThirtyDaysOfShred.API.Entities.Users.AppUser", "AppUser")
                        .WithMany("FavoriteTabs")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ThirtyDaysOfShred.API.Entities.GuitarTabs.GuitarTab", "GuitarTab")
                        .WithMany("FavoritedByUser")
                        .HasForeignKey("GuitarTabId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("GuitarTab");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.GuitarTabTag", b =>
                {
                    b.HasOne("ThirtyDaysOfShred.API.Entities.GuitarTabs.GuitarTab", null)
                        .WithMany("Tags")
                        .HasForeignKey("GuitarTabId");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.TabPreviewImage", b =>
                {
                    b.HasOne("ThirtyDaysOfShred.API.Entities.GuitarTabs.GuitarTab", "GuitarTab")
                        .WithOne("PreviewImage")
                        .HasForeignKey("ThirtyDaysOfShred.API.Entities.GuitarTabs.TabPreviewImage", "GuitarTabId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GuitarTab");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Lessons.Lesson", b =>
                {
                    b.HasOne("ThirtyDaysOfShred.API.Entities.PracticeRoutines.PracticeRoutine", null)
                        .WithMany("Lessons")
                        .HasForeignKey("PracticeRoutineId");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Lessons.LessonTag", b =>
                {
                    b.HasOne("ThirtyDaysOfShred.API.Entities.Lessons.Lesson", null)
                        .WithMany("Tags")
                        .HasForeignKey("LessonId");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.PracticeRoutines.PracticeRoutine", b =>
                {
                    b.HasOne("ThirtyDaysOfShred.API.Entities.Users.AppUser", "AppUser")
                        .WithMany("PracticeRoutines")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.PracticeRoutines.PracticeRoutineTag", b =>
                {
                    b.HasOne("ThirtyDaysOfShred.API.Entities.PracticeRoutines.PracticeRoutine", "PracticeRoutine")
                        .WithMany("Tags")
                        .HasForeignKey("PracticeRoutineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PracticeRoutine");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Users.Goal", b =>
                {
                    b.HasOne("ThirtyDaysOfShred.API.Entities.Users.AppUser", "AppUser")
                        .WithMany("Goals")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Users.ProfilePhoto", b =>
                {
                    b.HasOne("ThirtyDaysOfShred.API.Entities.Users.AppUser", "AppUser")
                        .WithOne("ProfilePhoto")
                        .HasForeignKey("ThirtyDaysOfShred.API.Entities.Users.ProfilePhoto", "AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.GuitarTab", b =>
                {
                    b.Navigation("FavoritedByUser");

                    b.Navigation("PreviewImage");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Lessons.Lesson", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.PracticeRoutines.PracticeRoutine", b =>
                {
                    b.Navigation("Lessons");

                    b.Navigation("Tabs");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Users.AppUser", b =>
                {
                    b.Navigation("FavoriteTabs");

                    b.Navigation("Goals");

                    b.Navigation("PracticeRoutines");

                    b.Navigation("ProfilePhoto");
                });
#pragma warning restore 612, 618
        }
    }
}
