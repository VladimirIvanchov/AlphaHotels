﻿// <auto-generated />
using System;
using AlphaHotel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlphaHotel.Data.Migrations
{
    [DbContext(typeof(AlphaHotelDbContext))]
    [Migration("20190525060702_addedBusinessToEachAccount")]
    partial class addedBusinessToEachAccount
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AlphaHotel.Models.Business", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("Businesses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Location = "1, Bulgaraa Blvd., Sofia 1421, Bulgaria",
                            Name = "Hilton Sofia"
                        },
                        new
                        {
                            Id = 2,
                            Location = "100, James Bourchier Blvd., Sofia 1407, Bulgaria",
                            Name = "Marinela Sofia"
                        },
                        new
                        {
                            Id = 3,
                            Location = "64, Tsarigradsko shosse Blvd., Sofia 1784, Bulgaria",
                            Name = "Metropolitan Hotel"
                        });
                });

            modelBuilder.Entity("AlphaHotel.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "TODO"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Maintenance"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Urgent"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Event"
                        });
                });

            modelBuilder.Entity("AlphaHotel.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<int>("BusinessId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<int>("Rate");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.ToTable("Feedbacks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Ivan",
                            BusinessId = 1,
                            CreatedOn = new DateTime(2019, 5, 23, 17, 40, 44, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Rate = 5,
                            Text = "One of the best hotels ever!!!"
                        },
                        new
                        {
                            Id = 2,
                            BusinessId = 2,
                            CreatedOn = new DateTime(2019, 5, 22, 13, 51, 34, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Rate = 4,
                            Text = "Perfect disco"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Petar",
                            BusinessId = 3,
                            CreatedOn = new DateTime(2019, 5, 21, 20, 39, 44, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Rate = 4,
                            Text = "Good breakfast"
                        });
                });

            modelBuilder.Entity("AlphaHotel.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorId")
                        .IsRequired();

                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("LogBookId");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LogBookId");

                    b.HasIndex("StatusId");

                    b.ToTable("Logs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = "45488c85-6e76-4280-9acb-d81be65aca3b",
                            CategoryId = 1,
                            CreatedOn = new DateTime(2019, 5, 23, 17, 40, 44, 0, DateTimeKind.Unspecified),
                            Description = "Problem with the toilet in room 405",
                            IsDeleted = false,
                            LogBookId = 1,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = "45488c85-6e76-4280-9acb-d81be65aca3b",
                            CategoryId = 2,
                            CreatedOn = new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Broken chair in the fish part.",
                            IsDeleted = false,
                            LogBookId = 2,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = "45488c85-6e76-4280-9acb-d81be65aca3b",
                            CategoryId = 3,
                            CreatedOn = new DateTime(2019, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Problem with the sauna.",
                            IsDeleted = false,
                            LogBookId = 3,
                            StatusId = 2
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = "45488c85-6e76-4280-9acb-d81be65aca3b",
                            CategoryId = 1,
                            CreatedOn = new DateTime(2019, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Problem with mirror in room 209",
                            IsDeleted = false,
                            LogBookId = 4,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = "45488c85-6e76-4280-9acb-d81be65aca3b",
                            CategoryId = 2,
                            CreatedOn = new DateTime(2019, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Broken table in the italian part.",
                            IsDeleted = false,
                            LogBookId = 5,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 6,
                            AuthorId = "45488c85-6e76-4280-9acb-d81be65aca3b",
                            CategoryId = 3,
                            CreatedOn = new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Problem with the jacuzzi.",
                            IsDeleted = false,
                            LogBookId = 6,
                            StatusId = 2
                        },
                        new
                        {
                            Id = 7,
                            AuthorId = "45488c85-6e76-4280-9acb-d81be65aca3b",
                            CategoryId = 1,
                            CreatedOn = new DateTime(2019, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Problem with the door of room 302",
                            IsDeleted = false,
                            LogBookId = 7,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 8,
                            AuthorId = "45488c85-6e76-4280-9acb-d81be65aca3b",
                            CategoryId = 2,
                            CreatedOn = new DateTime(2019, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Broken chair in the fish part.",
                            IsDeleted = false,
                            LogBookId = 8,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 9,
                            AuthorId = "45488c85-6e76-4280-9acb-d81be65aca3b",
                            CategoryId = 3,
                            CreatedOn = new DateTime(2019, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Problem with the sauna.",
                            IsDeleted = false,
                            LogBookId = 9,
                            StatusId = 2
                        });
                });

            modelBuilder.Entity("AlphaHotel.Models.LogBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusinessId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.ToTable("LogBooks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BusinessId = 1,
                            Name = "Hotel Part"
                        },
                        new
                        {
                            Id = 2,
                            BusinessId = 1,
                            Name = "Restaurant"
                        },
                        new
                        {
                            Id = 3,
                            BusinessId = 1,
                            Name = "Spa"
                        },
                        new
                        {
                            Id = 4,
                            BusinessId = 2,
                            Name = "Hotel Part"
                        },
                        new
                        {
                            Id = 5,
                            BusinessId = 2,
                            Name = "Restaurant"
                        },
                        new
                        {
                            Id = 6,
                            BusinessId = 2,
                            Name = "Spa"
                        },
                        new
                        {
                            Id = 7,
                            BusinessId = 3,
                            Name = "Hotel Part"
                        },
                        new
                        {
                            Id = 8,
                            BusinessId = 3,
                            Name = "Restaurant"
                        },
                        new
                        {
                            Id = 9,
                            BusinessId = 3,
                            Name = "Spa"
                        });
                });

            modelBuilder.Entity("AlphaHotel.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Pending"
                        },
                        new
                        {
                            Id = 2,
                            Type = "In Progress"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Done"
                        });
                });

            modelBuilder.Entity("AlphaHotel.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int?>("BusinessId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("AlphaHotel.Models.UsersLogbooks", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("LogBookId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedOn");

                    b.HasKey("UserId", "LogBookId");

                    b.HasIndex("LogBookId");

                    b.ToTable("UsersLogbooks");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AlphaHotel.Models.Feedback", b =>
                {
                    b.HasOne("AlphaHotel.Models.Business", "Business")
                        .WithMany("Feedbacks")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AlphaHotel.Models.Log", b =>
                {
                    b.HasOne("AlphaHotel.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AlphaHotel.Models.Category", "Category")
                        .WithMany("Logs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AlphaHotel.Models.LogBook", "LogBook")
                        .WithMany("Logs")
                        .HasForeignKey("LogBookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AlphaHotel.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AlphaHotel.Models.LogBook", b =>
                {
                    b.HasOne("AlphaHotel.Models.Business", "Business")
                        .WithMany("LogBooks")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AlphaHotel.Models.User", b =>
                {
                    b.HasOne("AlphaHotel.Models.Business", "Business")
                        .WithMany("Accounts")
                        .HasForeignKey("BusinessId");
                });

            modelBuilder.Entity("AlphaHotel.Models.UsersLogbooks", b =>
                {
                    b.HasOne("AlphaHotel.Models.LogBook", "LogBook")
                        .WithMany("ManagersLogbooks")
                        .HasForeignKey("LogBookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AlphaHotel.Models.User", "User")
                        .WithMany("UsersLogbooks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AlphaHotel.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AlphaHotel.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AlphaHotel.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AlphaHotel.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}