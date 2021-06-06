using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog_Site_Core.Migrations
{
    public partial class A : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mainCommentD_postModelD_CommentId",
                table: "mainCommentD");

            migrationBuilder.DropIndex(
                name: "IX_mainCommentD_CommentId",
                table: "mainCommentD");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "postModelD");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "mainCommentD");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "postModelD",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "mainCommentD",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_mainCommentD_CommentId",
                table: "mainCommentD",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_mainCommentD_postModelD_CommentId",
                table: "mainCommentD",
                column: "CommentId",
                principalTable: "postModelD",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
