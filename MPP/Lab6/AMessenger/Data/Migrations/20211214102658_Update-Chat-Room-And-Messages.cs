using Microsoft.EntityFrameworkCore.Migrations;

namespace AMessenger.Data.Migrations
{
    public partial class UpdateChatRoomAndMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRooms_AspNetUsers_ApplicationUserId",
                table: "ChatRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_ApplicationUserId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Messages",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ApplicationUserId",
                table: "Messages",
                newName: "IX_Messages_AuthorId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "ChatRooms",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatRooms_ApplicationUserId",
                table: "ChatRooms",
                newName: "IX_ChatRooms_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRooms_AspNetUsers_OwnerId",
                table: "ChatRooms",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_AuthorId",
                table: "Messages",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRooms_AspNetUsers_OwnerId",
                table: "ChatRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_AuthorId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Messages",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_AuthorId",
                table: "Messages",
                newName: "IX_Messages_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "ChatRooms",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatRooms_OwnerId",
                table: "ChatRooms",
                newName: "IX_ChatRooms_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRooms_AspNetUsers_ApplicationUserId",
                table: "ChatRooms",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_ApplicationUserId",
                table: "Messages",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
