using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "BorrowingRecords",
                columns: table => new
                {
                    BorrowingRecordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    BookID = table.Column<int>(type: "int", nullable: false),
                    BorrowingDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ReturnDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Fine = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowingRecords", x => x.BorrowingRecordID);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    PublisherID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.PublisherID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "PublisherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book_Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookID = table.Column<int>(type: "int", nullable: false),
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Authors_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Authors_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherID", "Address", "ContactInfo", "Name" },
                values: new object[,]
                {
                    { 60879689, "314 Buckridge Skyway, Santoston, Mongolia", "dolores", "Jaime Bosco DDS" },
                    { 186057027, "3940 Maxine Estates, South Biankaton, Saudi Arabia", "similique", "Mr. Bridget Heidenreich" },
                    { 216533798, "37416 Jacobson Ford, Port Janessa, Lebanon", "vero", "Miss Bridget Jacobs" },
                    { 510953556, "51040 Odie Junction, Hoegermouth, Iceland", "error", "Lewis Kub Jr." },
                    { 535545999, "0303 Legros Crossing, North Alyce, Cape Verde", "assumenda", "Edgar Bradtke Sr." },
                    { 599614909, "082 Dietrich Villages, West Coletown, Kenya", "et", "Irving Fay IV" },
                    { 908859332, "6376 Skiles Square, Sydniehaven, Tajikistan", "voluptatem", "Miss Marsha Padberg" },
                    { 1297037168, "450 Malachi Knolls, Carsonshire, Turkmenistan", "numquam", "Austin Conn Sr." },
                    { 1358387376, "1687 Rogahn Shores, East Bridget, Dominican Republic", "velit", "Virgil Ullrich I" },
                    { 1618525778, "487 Prohaska Divide, Gloverfort, Dominica", "ipsum", "Jean Rath MD" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "Address", "Email", "Name" },
                values: new object[,]
                {
                    { 75006683, "98966 Hermiston Spurs, Mckenzieshire, India", "Timmothy_Kohler94@gmail.com", "Timmothy" },
                    { 170213284, "817 Margie Overpass, Coltenshire, Solomon Islands", "Karolann_Johnston98@hotmail.com", "Karolann" },
                    { 317271775, "769 Catalina Tunnel, West Chauncey, Cook Islands", "Avery.McCullough@yahoo.com", "Avery" },
                    { 592055310, "66536 Myrtice Club, Lake Armando, Honduras", "Gisselle.Kling@hotmail.com", "Gisselle" },
                    { 649330134, "964 Olson Forges, North Ariel, Guernsey", "Jolie_Price61@gmail.com", "Jolie" },
                    { 701810709, "59611 Gleason Lake, Blockstad, Holy See (Vatican City State)", "Yesenia.Bauch55@hotmail.com", "Yesenia" },
                    { 703229907, "41166 Beer Green, South Berta, Nepal", "Bart_Lynch@hotmail.com", "Bart" },
                    { 787100287, "59782 Schamberger Lock, South Brooks, Jordan", "Elian92@yahoo.com", "Elian" },
                    { 902293180, "71123 Zulauf Roads, Corkerystad, Senegal", "Deshaun.Deckow@yahoo.com", "Deshaun" },
                    { 995126933, "756 Rempel Walk, Adamsport, Cameroon", "Caitlyn65@hotmail.com", "Caitlyn" },
                    { 1026195953, "917 Keely Islands, Luisaburgh, Oman", "Leland.Lemke16@hotmail.com", "Leland" },
                    { 1138232414, "386 Brook Loaf, Rafaelview, Tanzania", "Alisa.Hamill@gmail.com", "Alisa" },
                    { 1273409234, "183 Levi Glens, Leuschkechester, Mozambique", "Kailey83@hotmail.com", "Kailey" },
                    { 1284904246, "96687 Hammes Viaduct, South Kaceyview, Georgia", "Verda9@hotmail.com", "Verda" },
                    { 1467749207, "48838 Ruthie Mission, Altafort, Portugal", "Cory1@gmail.com", "Cory" },
                    { 1592058934, "712 Zulauf Terrace, Clarissaside, Gibraltar", "Jennie_Brown@hotmail.com", "Jennie" },
                    { 1885394238, "05309 Effertz Fork, Hilpertburgh, Guatemala", "Gregoria23@hotmail.com", "Gregoria" },
                    { 1951741350, "77127 Natasha Divide, Lake Brenda, Vanuatu", "Trevor69@hotmail.com", "Trevor" },
                    { 2001296433, "43943 Araceli Grove, Estrellamouth, Timor-Leste", "Meredith50@yahoo.com", "Meredith" },
                    { 2045646957, "53304 Josh Cliffs, Bradtkeport, South Africa", "Myrtie12@hotmail.com", "Myrtie" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_Authors_AuthorID",
                table: "Book_Authors",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Authors_BookID",
                table: "Book_Authors",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book_Authors");

            migrationBuilder.DropTable(
                name: "BorrowingRecords");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
