using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RunTracker.Data.Migrations
{
    public partial class RunShoeIdnownullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Run_Shoe_ShoeId",
                table: "Run");

            migrationBuilder.AlterColumn<int>(
                name: "ShoeId",
                table: "Run",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Run_Shoe_ShoeId",
                table: "Run",
                column: "ShoeId",
                principalTable: "Shoe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Run_Shoe_ShoeId",
                table: "Run");

            migrationBuilder.AlterColumn<int>(
                name: "ShoeId",
                table: "Run",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Run_Shoe_ShoeId",
                table: "Run",
                column: "ShoeId",
                principalTable: "Shoe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
