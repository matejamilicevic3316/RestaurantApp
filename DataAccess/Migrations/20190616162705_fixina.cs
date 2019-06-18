using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class fixina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article_types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant_Sectors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant_Sectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(maxLength: 5, nullable: false),
                    IdArtical_type = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Article_types_IdArtical_type",
                        column: x => x.IdArtical_type,
                        principalTable: "Article_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(nullable: true),
                    IdRestaurant_sector = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tables_Restaurant_Sectors_IdRestaurant_sector",
                        column: x => x.IdRestaurant_sector,
                        principalTable: "Restaurant_Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Waiters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false, defaultValue: false),
                    FirstName = table.Column<string>(maxLength: 15, nullable: false),
                    LastName = table.Column<string>(maxLength: 15, nullable: false),
                    IdRole = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waiters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Waiters_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false, defaultValue: false),
                    IdTable = table.Column<int>(nullable: false),
                    IdWaiter = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    IsPaid = table.Column<bool>(nullable: false, defaultValue: false),
                    IsStorned = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Tables_IdTable",
                        column: x => x.IdTable,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Waiters_IdWaiter",
                        column: x => x.IdWaiter,
                        principalTable: "Waiters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderArticles",
                columns: table => new
                {
                    IdOrder = table.Column<int>(nullable: false),
                    IdArticle = table.Column<int>(nullable: false),
                    ArticlesNumber = table.Column<int>(nullable: false),
                    ArticlePrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderArticles", x => new { x.IdArticle, x.IdOrder });
                    table.ForeignKey(
                        name: "FK_OrderArticles_Articles_IdArticle",
                        column: x => x.IdArticle,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderArticles_Orders_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Article_types",
                columns: new[] { "Id", "ModifiedAt", "Name" },
                values: new object[] { 1, null, "Coffee" });

            migrationBuilder.InsertData(
                table: "Restaurant_Sectors",
                columns: new[] { "Id", "ModifiedAt", "Name" },
                values: new object[] { 1, null, "Garden" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ModifiedAt", "Name" },
                values: new object[] { 1, null, "Manager" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "IdArtical_type", "Image", "ModifiedAt", "Name", "Price" },
                values: new object[] { 1, 1, null, null, "Mocca", 150.0 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "IdRestaurant_sector", "ModifiedAt", "Name" },
                values: new object[] { 1, 1, null, "Table1-Garden" });

            migrationBuilder.InsertData(
                table: "Waiters",
                columns: new[] { "Id", "Email", "FirstName", "IdRole", "LastName", "ModifiedAt", "Password" },
                values: new object[] { 1, "matejamilicevic97@gmail.com", "John", 1, "Stockton", null, "mailman1" });

            migrationBuilder.CreateIndex(
                name: "IX_Article_types_Name",
                table: "Article_types",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_IdArtical_type",
                table: "Articles",
                column: "IdArtical_type");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Name",
                table: "Articles",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderArticles_IdOrder",
                table: "OrderArticles",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdTable",
                table: "Orders",
                column: "IdTable");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdWaiter",
                table: "Orders",
                column: "IdWaiter");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_Sectors_Name",
                table: "Restaurant_Sectors",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_IdRestaurant_sector",
                table: "Tables",
                column: "IdRestaurant_sector");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_Name",
                table: "Tables",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Waiters_IdRole",
                table: "Waiters",
                column: "IdRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderArticles");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Article_types");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Waiters");

            migrationBuilder.DropTable(
                name: "Restaurant_Sectors");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
