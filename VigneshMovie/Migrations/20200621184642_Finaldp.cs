using Microsoft.EntityFrameworkCore.Migrations;

namespace VigneshMovie.Migrations
{
    public partial class Finaldp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Review_CurrentReviewId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_CurrentReviewId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "CurrentReviewId",
                table: "Movies");

            migrationBuilder.CreateIndex(
                name: "IX_Review_MovieId",
                table: "Review",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_PersonId",
                table: "Review",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Movies_MovieId",
                table: "Review",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Person_PersonId",
                table: "Review",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Movies_MovieId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Person_PersonId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_MovieId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_PersonId",
                table: "Review");

            migrationBuilder.AddColumn<int>(
                name: "CurrentReviewId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CurrentReviewId",
                table: "Movies",
                column: "CurrentReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Review_CurrentReviewId",
                table: "Movies",
                column: "CurrentReviewId",
                principalTable: "Review",
                principalColumn: "ReviewId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
