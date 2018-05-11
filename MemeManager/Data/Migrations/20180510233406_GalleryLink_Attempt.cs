using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MemeManager.Data.Migrations
{
    public partial class GalleryLink_Attempt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Meme",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Meme",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Meme",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meme_ImageId",
                table: "Meme",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meme_GalleryImages_ImageId",
                table: "Meme",
                column: "ImageId",
                principalTable: "GalleryImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meme_GalleryImages_ImageId",
                table: "Meme");

            migrationBuilder.DropIndex(
                name: "IX_Meme_ImageId",
                table: "Meme");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Meme");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Meme",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Meme",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
