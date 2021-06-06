using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog_Site_Core.Migrations
{
    public partial class updatemaincommentmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subCommentD_mainCommentD_subCommentId",
                table: "subCommentD");

            migrationBuilder.DropIndex(
                name: "IX_subCommentD_subCommentId",
                table: "subCommentD");

            migrationBuilder.DropColumn(
                name: "subCommentId",
                table: "subCommentD");

            migrationBuilder.DropColumn(
                name: "subCommentId",
                table: "mainCommentD");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "subCommentId",
                table: "subCommentD",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "subCommentId",
                table: "mainCommentD",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_subCommentD_subCommentId",
                table: "subCommentD",
                column: "subCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_subCommentD_mainCommentD_subCommentId",
                table: "subCommentD",
                column: "subCommentId",
                principalTable: "mainCommentD",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
