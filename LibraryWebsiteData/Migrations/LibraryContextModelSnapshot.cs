﻿// <auto-generated />
using System;
using LibraryWebsiteData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryWebsiteData.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibraryWebsiteData.Models.BranchHours", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BranchID");

                    b.Property<int>("closeTime");

                    b.Property<int>("dayOfWeek");

                    b.Property<int>("openTime");

                    b.HasKey("ID");

                    b.HasIndex("BranchID");

                    b.ToTable("BranchHours");
                });

            modelBuilder.Entity("LibraryWebsiteData.Models.Checkout", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LibraryCardID");

                    b.Property<DateTime>("Since");

                    b.Property<DateTime>("Until");

                    b.Property<int>("libraryAssetID");

                    b.HasKey("ID");

                    b.HasIndex("LibraryCardID");

                    b.HasIndex("libraryAssetID");

                    b.ToTable("Checkouts");
                });

            modelBuilder.Entity("LibraryWebsiteData.Models.CheckoutHistory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CheckedIn");

                    b.Property<DateTime>("CheckedOut");

                    b.Property<int>("LibraryAssetID");

                    b.Property<int>("LibraryCardID");

                    b.HasKey("ID");

                    b.HasIndex("LibraryAssetID");

                    b.HasIndex("LibraryCardID");

                    b.ToTable("CheckoutHistories");
                });

            modelBuilder.Entity("LibraryWebsiteData.Models.Holds", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("HoldPlaced");

                    b.Property<int?>("LibraryAssetID");

                    b.Property<int?>("LibraryCarrdID");

                    b.HasKey("ID");

                    b.HasIndex("LibraryAssetID");

                    b.HasIndex("LibraryCarrdID");

                    b.ToTable("Holds");
                });

            modelBuilder.Entity("LibraryWebsiteData.Models.LibraryAsset", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cost");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int?>("LocationID");

                    b.Property<int>("StatusID");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("Year");

                    b.Property<string>("imageURL");

                    b.Property<int>("numberOfCopies");

                    b.HasKey("ID");

                    b.HasIndex("LocationID");

                    b.HasIndex("StatusID");

                    b.ToTable("LibraryAssets");

                    b.HasDiscriminator<string>("Discriminator").HasValue("LibraryAsset");
                });

            modelBuilder.Entity("LibraryWebsiteData.Models.LibraryBranch", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Telephone")
                        .IsRequired();

                    b.Property<DateTime>("openDate");

                    b.HasKey("ID");

                    b.ToTable("LibraryBranches");
                });

            modelBuilder.Entity("LibraryWebsiteData.Models.LibraryCard", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<decimal>("Fees");

                    b.HasKey("ID");

                    b.ToTable("LibraryCards");
                });

            modelBuilder.Entity("LibraryWebsiteData.Models.Patron", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("dateOfBirth");

                    b.Property<string>("firstName");

                    b.Property<int?>("homeLibraryBranchID");

                    b.Property<string>("lastName");

                    b.Property<int?>("libraryCardID");

                    b.Property<string>("telephoneNumber");

                    b.HasKey("id");

                    b.HasIndex("homeLibraryBranchID");

                    b.HasIndex("libraryCardID");

                    b.ToTable("Patrons");
                });

            modelBuilder.Entity("LibraryWebsiteData.Models.Status", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("LibraryWebsiteData.Models.Book", b =>
                {
                    b.HasBaseType("LibraryWebsiteData.Models.LibraryAsset");

                    b.Property<string>("Author")
                        .IsRequired();

                    b.Property<string>("DeweyIndex")
                        .IsRequired();

                    b.Property<string>("ISBN")
                        .IsRequired();

                    b.ToTable("Book");

                    b.HasDiscriminator().HasValue("Book");
                });

            modelBuilder.Entity("LibraryWebsiteData.Models.Video", b =>
                {
                    b.HasBaseType("LibraryWebsiteData.Models.LibraryAsset");

                    b.Property<string>("Director")
                        .IsRequired();

                    b.ToTable("Video");

                    b.HasDiscriminator().HasValue("Video");
                });

            modelBuilder.Entity("LibraryWebsiteData.Models.BranchHours", b =>
                {
                    b.HasOne("LibraryWebsiteData.Models.LibraryBranch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchID");
                });

            modelBuilder.Entity("LibraryWebsiteData.Models.Checkout", b =>
                {
                    b.HasOne("LibraryWebsiteData.Models.LibraryCard", "LibraryCard")
                        .WithMany("Checkouts")
                        .HasForeignKey("LibraryCardID");

                    b.HasOne("LibraryWebsiteData.Models.LibraryAsset", "libraryAsset")
                        .WithMany()
                        .HasForeignKey("libraryAssetID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LibraryWebsiteData.Models.CheckoutHistory", b =>
                {
                    b.HasOne("LibraryWebsiteData.Models.LibraryAsset", "LibraryAsset")
                        .WithMany()
                        .HasForeignKey("LibraryAssetID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LibraryWebsiteData.Models.LibraryCard", "LibraryCard")
                        .WithMany()
                        .HasForeignKey("LibraryCardID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LibraryWebsiteData.Models.Holds", b =>
                {
                    b.HasOne("LibraryWebsiteData.Models.LibraryAsset", "LibraryAsset")
                        .WithMany()
                        .HasForeignKey("LibraryAssetID");

                    b.HasOne("LibraryWebsiteData.Models.LibraryCard", "LibraryCarrd")
                        .WithMany()
                        .HasForeignKey("LibraryCarrdID");
                });

            modelBuilder.Entity("LibraryWebsiteData.Models.LibraryAsset", b =>
                {
                    b.HasOne("LibraryWebsiteData.Models.LibraryBranch", "Location")
                        .WithMany()
                        .HasForeignKey("LocationID");

                    b.HasOne("LibraryWebsiteData.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LibraryWebsiteData.Models.Patron", b =>
                {
                    b.HasOne("LibraryWebsiteData.Models.LibraryBranch", "homeLibraryBranch")
                        .WithMany()
                        .HasForeignKey("homeLibraryBranchID");

                    b.HasOne("LibraryWebsiteData.Models.LibraryCard", "libraryCard")
                        .WithMany()
                        .HasForeignKey("libraryCardID");
                });
#pragma warning restore 612, 618
        }
    }
}
