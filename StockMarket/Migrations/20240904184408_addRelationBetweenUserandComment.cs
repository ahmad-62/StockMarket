using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockMarket.Migrations
{
    /// <inheritdoc />
    public partial class addRelationBetweenUserandComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<string>(
                name: "ApplicationuserId",
                table: "comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_comments_ApplicationuserId",
                table: "comments",
                column: "ApplicationuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_AspNetUsers_ApplicationuserId",
                table: "comments",
                column: "ApplicationuserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_AspNetUsers_ApplicationuserId",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_ApplicationuserId",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "ApplicationuserId",
                table: "comments");

           
        }
    }
}
