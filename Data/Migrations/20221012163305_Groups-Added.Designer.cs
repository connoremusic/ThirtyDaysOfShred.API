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
    [Migration("20221012163305_Groups-Added")]
    partial class GroupsAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.GuitarTabs.GuitarTab", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileLocationUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfFavorites")
                        .HasColumnType("int");

                    b.Property<int>("SkillLevel")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

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
                    b.Property<int>("GuitarTabId")
                        .HasColumnType("int");

                    b.Property<string>("TagName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("GuitarTabId", "TagName");

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

                    b.Property<int>("LessonId")
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

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.PracticeRoutines.PracticeRoutineTab", b =>
                {
                    b.Property<int>("PracticeRoutineId")
                        .HasColumnType("int");

                    b.Property<int>("GuitarTabId")
                        .HasColumnType("int");

                    b.HasKey("PracticeRoutineId", "GuitarTabId");

                    b.HasIndex("GuitarTabId");

                    b.ToTable("PracticeRoutinesTabs");
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

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Users.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Users.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Influences")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KnownAs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("datetime2");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Users.AppUserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Users.Connection", b =>
                {
                    b.Property<string>("ConnectionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConnectionId");

                    b.HasIndex("GroupName");

                    b.ToTable("Connections");
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

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Users.Group", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Users.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateRead")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MessageSent")
                        .HasColumnType("datetime2");

                    b.Property<bool>("RecipientDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("RecipientId")
                        .HasColumnType("int");

                    b.Property<string>("RecipientUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SenderDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("SenderUsername")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("ThirtyDaysOfShred.API.Entities.Users.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("ThirtyDaysOfShred.API.Entities.Users.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("ThirtyDaysOfShred.API.Entities.Users.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("ThirtyDaysOfShred.API.Entities.Users.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.HasOne("ThirtyDaysOfShred.API.Entities.GuitarTabs.GuitarTab", "GuitarTab")
                        .WithMany("Tags")
                        .HasForeignKey("GuitarTabId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GuitarTab");
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
                    b.HasOne("ThirtyDaysOfShred.API.Entities.Lessons.Lesson", "Lesson")
                        .WithMany("Tags")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
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

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.PracticeRoutines.PracticeRoutineTab", b =>
                {
                    b.HasOne("ThirtyDaysOfShred.API.Entities.GuitarTabs.GuitarTab", "GuitarTab")
                        .WithMany("InPracticeRoutine")
                        .HasForeignKey("GuitarTabId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ThirtyDaysOfShred.API.Entities.PracticeRoutines.PracticeRoutine", "PracticeRoutine")
                        .WithMany("HasGuitarTab")
                        .HasForeignKey("PracticeRoutineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GuitarTab");

                    b.Navigation("PracticeRoutine");
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

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Users.AppUserRole", b =>
                {
                    b.HasOne("ThirtyDaysOfShred.API.Entities.Users.AppRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThirtyDaysOfShred.API.Entities.Users.AppUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Users.Connection", b =>
                {
                    b.HasOne("ThirtyDaysOfShred.API.Entities.Users.Group", null)
                        .WithMany("Connections")
                        .HasForeignKey("GroupName");
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

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Users.Message", b =>
                {
                    b.HasOne("ThirtyDaysOfShred.API.Entities.Users.AppUser", "Recipient")
                        .WithMany("MessagesReceived")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ThirtyDaysOfShred.API.Entities.Users.AppUser", "Sender")
                        .WithMany("MessagesSent")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Recipient");

                    b.Navigation("Sender");
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

                    b.Navigation("InPracticeRoutine");

                    b.Navigation("PreviewImage");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Lessons.Lesson", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.PracticeRoutines.PracticeRoutine", b =>
                {
                    b.Navigation("HasGuitarTab");

                    b.Navigation("Lessons");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Users.AppRole", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Users.AppUser", b =>
                {
                    b.Navigation("FavoriteTabs");

                    b.Navigation("Goals");

                    b.Navigation("MessagesReceived");

                    b.Navigation("MessagesSent");

                    b.Navigation("PracticeRoutines");

                    b.Navigation("ProfilePhoto");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("ThirtyDaysOfShred.API.Entities.Users.Group", b =>
                {
                    b.Navigation("Connections");
                });
#pragma warning restore 612, 618
        }
    }
}
