using Microsoft.EntityFrameworkCore.Migrations;

namespace VigneshMovie.Migrations
{
    public partial class NullReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Review_CurrentReviewId",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentReviewId",
                table: "Movies",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Review_CurrentReviewId",
                table: "Movies",
                column: "CurrentReviewId",
                principalTable: "Review",
                principalColumn: "ReviewId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Review_CurrentReviewId",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentReviewId",
                table: "Movies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Review_CurrentReviewId",
                table: "Movies",
                column: "CurrentReviewId",
                principalTable: "Review",
                principalColumn: "ReviewId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
