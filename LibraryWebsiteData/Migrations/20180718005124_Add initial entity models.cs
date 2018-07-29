using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWebsiteData.Migrations
{
    public partial class Addinitialentitymodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "homeLibraryBranchID",
                table: "Patrons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "libraryCardID",
                table: "Patrons",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LibraryBranches",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Telephone = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    openDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryBranches", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LibraryCards",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fees = table.Column<decimal>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryCards", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BranchHours",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchID = table.Column<int>(nullable: true),
                    dayOfWeek = table.Column<int>(nullable: false),
                    openTime = table.Column<int>(nullable: false),
                    closeTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchHours", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BranchHours_LibraryBranches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "LibraryBranches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LibraryAssets",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    StatusID = table.Column<int>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    imageURL = table.Column<string>(nullable: true),
                    numberOfCopies = table.Column<int>(nullable: false),
                    LocationID = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    ISBN = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    DeweyIndex = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryAssets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LibraryAssets_LibraryBranches_LocationID",
                        column: x => x.LocationID,
                        principalTable: "LibraryBranches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LibraryAssets_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckoutHistories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LibraryAssetID = table.Column<int>(nullable: false),
                    LibraryCardID = table.Column<int>(nullable: false),
                    CheckedOut = table.Column<DateTime>(nullable: false),
                    CheckedIn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CheckoutHistories_LibraryAssets_LibraryAssetID",
                        column: x => x.LibraryAssetID,
                        principalTable: "LibraryAssets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckoutHistories_LibraryCards_LibraryCardID",
                        column: x => x.LibraryCardID,
                        principalTable: "LibraryCards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Checkouts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    libraryAssetID = table.Column<int>(nullable: false),
                    LibraryCardID = table.Column<int>(nullable: true),
                    Since = table.Column<DateTime>(nullable: false),
                    Until = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkouts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Checkouts_LibraryCards_LibraryCardID",
                        column: x => x.LibraryCardID,
                        principalTable: "LibraryCards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Checkouts_LibraryAssets_libraryAssetID",
                        column: x => x.libraryAssetID,
                        principalTable: "LibraryAssets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Holds",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LibraryAssetID = table.Column<int>(nullable: true),
                    LibraryCarrdID = table.Column<int>(nullable: true),
                    HoldPlaced = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holds", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Holds_LibraryAssets_LibraryAssetID",
                        column: x => x.LibraryAssetID,
                        principalTable: "LibraryAssets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Holds_LibraryCards_LibraryCarrdID",
                        column: x => x.LibraryCarrdID,
                        principalTable: "LibraryCards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patrons_homeLibraryBranchID",
                table: "Patrons",
                column: "homeLibraryBranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Patrons_libraryCardID",
                table: "Patrons",
                column: "libraryCardID");

            migrationBuilder.CreateIndex(
                name: "IX_BranchHours_BranchID",
                table: "BranchHours",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistories_LibraryAssetID",
                table: "CheckoutHistories",
                column: "LibraryAssetID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistories_LibraryCardID",
                table: "CheckoutHistories",
                column: "LibraryCardID");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_LibraryCardID",
                table: "Checkouts",
                column: "LibraryCardID");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_libraryAssetID",
                table: "Checkouts",
                column: "libraryAssetID");

            migrationBuilder.CreateIndex(
                name: "IX_Holds_LibraryAssetID",
                table: "Holds",
                column: "LibraryAssetID");

            migrationBuilder.CreateIndex(
                name: "IX_Holds_LibraryCarrdID",
                table: "Holds",
                column: "LibraryCarrdID");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryAssets_LocationID",
                table: "LibraryAssets",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryAssets_StatusID",
                table: "LibraryAssets",
                column: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Patrons_LibraryBranches_homeLibraryBranchID",
                table: "Patrons",
                column: "homeLibraryBranchID",
                principalTable: "LibraryBranches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patrons_LibraryCards_libraryCardID",
                table: "Patrons",
                column: "libraryCardID",
                principalTable: "LibraryCards",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patrons_LibraryBranches_homeLibraryBranchID",
                table: "Patrons");

            migrationBuilder.DropForeignKey(
                name: "FK_Patrons_LibraryCards_libraryCardID",
                table: "Patrons");

            migrationBuilder.DropTable(
                name: "BranchHours");

            migrationBuilder.DropTable(
                name: "CheckoutHistories");

            migrationBuilder.DropTable(
                name: "Checkouts");

            migrationBuilder.DropTable(
                name: "Holds");

            migrationBuilder.DropTable(
                name: "LibraryAssets");

            migrationBuilder.DropTable(
                name: "LibraryCards");

            migrationBuilder.DropTable(
                name: "LibraryBranches");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Patrons_homeLibraryBranchID",
                table: "Patrons");

            migrationBuilder.DropIndex(
                name: "IX_Patrons_libraryCardID",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "homeLibraryBranchID",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "libraryCardID",
                table: "Patrons");
        }
    }
}
