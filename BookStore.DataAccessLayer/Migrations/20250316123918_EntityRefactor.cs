using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.DataAccessLayer.Migrations
{
    public partial class EntityRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Writers_WriterId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Writers");

            migrationBuilder.DropIndex(
                name: "IX_Products_WriterId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WriterId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Products",
                newName: "ProductWriterName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Features",
                newName: "Writer");

            migrationBuilder.RenameColumn(
                name: "BookName",
                table: "Features",
                newName: "ProductName");

            migrationBuilder.AddColumn<string>(
                name: "ProductDescription",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductAbout",
                table: "Features",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "ProductPrice",
                table: "Features",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    QuoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WriterQuote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quotedtext = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.QuoteId);
                });

            migrationBuilder.CreateTable(
                name: "Subscribes",
                columns: table => new
                {
                    SubscribeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mail = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribes", x => x.SubscribeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "Subscribes");

            migrationBuilder.DropColumn(
                name: "ProductDescription",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductImageUrl",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductAbout",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "Features");

            migrationBuilder.RenameColumn(
                name: "ProductWriterName",
                table: "Products",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "Writer",
                table: "Features",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Features",
                newName: "BookName");

            migrationBuilder.AddColumn<int>(
                name: "WriterId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Writers",
                columns: table => new
                {
                    WriterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writers", x => x.WriterId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_WriterId",
                table: "Products",
                column: "WriterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Writers_WriterId",
                table: "Products",
                column: "WriterId",
                principalTable: "Writers",
                principalColumn: "WriterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
