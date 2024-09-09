using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinimalAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    YearOfRelease = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvaliable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "Author", "Description", "Genre", "IsAvaliable", "Title", "YearOfRelease" },
                values: new object[,]
                {
                    { 1, "J.K. Rowling", "The first book in the Harry Potter series. Introducing the young wizard Harry Potter.", "Fantasy", true, "Harry Potter and the Sorcerer's Stone", 1997 },
                    { 2, "George R.R. Martin", "The first book in the A Song of Ice and Fire series, where the struggle for the Iron Throne begins", "Fantasy", false, "A Game of Thrones", 1996 },
                    { 3, "J.R.R. Tolkien", "The first book in the Lord of the Rings trilogy, where the journey of the One Ring begins.", "Fantasy", true, "The Fellowship of the Ring", 1954 },
                    { 4, "F. Scott Fitzgerald", "A novel that critiques the American dream through the tragic story of Jay Gatsby", "Classic Fiction", true, "The Great Gatsby", 1925 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
