﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WhyNotEarth.Meredith.Persistence;

namespace WhyNotEarth.Meredith.Persistence.Migrations
{
    [DbContext(typeof(MeredithDbContext))]
    [Migration("20190728194029_AddReservationCreatedDate")]
    partial class AddReservationCreatedDate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BackgroundUrl");

                    b.Property<string>("CallToAction");

                    b.Property<string>("CallToActionUrl");

                    b.Property<int>("CardType");

                    b.Property<int>("Order");

                    b.Property<int>("PageId");

                    b.Property<string>("PosterUrl");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("PageId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Slug");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Order");

                    b.Property<int>("PageId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("PageId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.Amenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RoomTypeId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Amenities","ModuleHotel");
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.Bed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BedType");

                    b.Property<int>("Count");

                    b.Property<int>("RoomTypeId");

                    b.HasKey("Id");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Beds","ModuleHotel");
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Capacity");

                    b.Property<int?>("CompanyId");

                    b.Property<string>("GettingAround");

                    b.Property<string>("Location");

                    b.Property<int>("PageId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PageId")
                        .IsUnique();

                    b.ToTable("Hotels","ModuleHotel");
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("Created");

                    b.Property<int>("ReservationId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.HasIndex("UserId");

                    b.ToTable("Payments","ModuleHotel");
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.Price", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric(5, 2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("RoomTypeId");

                    b.HasKey("Id");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Prices","ModuleHotel");
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric(5, 2)");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("End")
                        .HasColumnType("date");

                    b.Property<int>("RoomId");

                    b.Property<DateTime>("Start")
                        .HasColumnType("date");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations","ModuleHotel");
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Number")
                        .HasMaxLength(16);

                    b.Property<int>("RoomTypeId");

                    b.HasKey("Id");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Rooms","ModuleHotel");
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HotelId");

                    b.Property<string>("Name")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("RoomTypes","ModuleHotel");
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.Rule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HotelId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Rules","ModuleHotel");
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.Space", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HotelId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Spaces","ModuleHotel");
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BackgroundImage");

                    b.Property<string>("CallToAction");

                    b.Property<string>("CallToActionLink");

                    b.Property<int?>("CategoryId");

                    b.Property<int>("CompanyId");

                    b.Property<string>("Custom")
                        .HasColumnType("jsonb");

                    b.Property<string>("Description");

                    b.Property<string>("FeaturedImage");

                    b.Property<string>("Header");

                    b.Property<string>("Name");

                    b.Property<string>("Slug");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Role", b =>
                {
                    b.Property<int>("Id")
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
                        .HasName("RoleNameIndex");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.StripeAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken")
                        .HasMaxLength(64);

                    b.Property<int>("CompanyId");

                    b.Property<bool>("LiveMode");

                    b.Property<string>("RefreshToken")
                        .HasMaxLength(64);

                    b.Property<string>("Scope")
                        .HasMaxLength(32);

                    b.Property<string>("StripePublishableKey")
                        .HasMaxLength(64);

                    b.Property<string>("StripeUserId")
                        .HasMaxLength(64);

                    b.Property<string>("TokenType")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("StripeAccounts");
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.StripeOAuthRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("StripeOAuthRequests");
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

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

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("WhyNotEarth.Meredith.Data.Entity.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("WhyNotEarth.Meredith.Data.Entity.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("WhyNotEarth.Meredith.Data.Entity.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("WhyNotEarth.Meredith.Data.Entity.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WhyNotEarth.Meredith.Data.Entity.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("WhyNotEarth.Meredith.Data.Entity.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Card", b =>
                {
                    b.HasOne("WhyNotEarth.Meredith.Data.Entity.Models.Page", "Page")
                        .WithMany("Cards")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Image", b =>
                {
                    b.HasOne("WhyNotEarth.Meredith.Data.Entity.Models.Page", "Page")
                        .WithMany("Images")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.Amenity", b =>
                {
                    b.HasOne("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.RoomType", "RoomType")
                        .WithMany("Amenities")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.Bed", b =>
                {
                    b.HasOne("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.RoomType", "RoomType")
                        .WithMany("Beds")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.Hotel", b =>
                {
                    b.HasOne("WhyNotEarth.Meredith.Data.Entity.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("WhyNotEarth.Meredith.Data.Entity.Models.Page", "Page")
                        .WithOne("Hotel")
                        .HasForeignKey("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.Hotel", "PageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.Payment", b =>
                {
                    b.HasOne("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.Reservation", "Reservation")
                        .WithMany("Payments")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WhyNotEarth.Meredith.Data.Entity.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.Price", b =>
                {
                    b.HasOne("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.RoomType", "RoomType")
                        .WithMany("Prices")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.Reservation", b =>
                {
                    b.HasOne("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.Room", "Room")
                        .WithMany("Reservations")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WhyNotEarth.Meredith.Data.Entity.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.Room", b =>
                {
                    b.HasOne("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.RoomType", b =>
                {
                    b.HasOne("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.Hotel", "Hotel")
                        .WithMany("RoomTypes")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.Rule", b =>
                {
                    b.HasOne("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.Hotel", "Hotel")
                        .WithMany("Rules")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.Space", b =>
                {
                    b.HasOne("WhyNotEarth.Meredith.Data.Entity.Models.Modules.Hotel.Hotel", "Hotel")
                        .WithMany("Spaces")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.Page", b =>
                {
                    b.HasOne("WhyNotEarth.Meredith.Data.Entity.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("WhyNotEarth.Meredith.Data.Entity.Models.Company", "Company")
                        .WithMany("Pages")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.StripeAccount", b =>
                {
                    b.HasOne("WhyNotEarth.Meredith.Data.Entity.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WhyNotEarth.Meredith.Data.Entity.Models.StripeOAuthRequest", b =>
                {
                    b.HasOne("WhyNotEarth.Meredith.Data.Entity.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
