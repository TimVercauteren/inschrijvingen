using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace InschrijvingPietieterken.Migrations
{
    public partial class intpost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_inschrijving_KindId",
                table: "inschrijving");

            migrationBuilder.AlterColumn<string>(
                name: "Postcode",
                table: "adressen",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_inschrijving_KindId",
                table: "inschrijving",
                column: "KindId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_inschrijving_KindId",
                table: "inschrijving");

            migrationBuilder.AlterColumn<int>(
                name: "Postcode",
                table: "adressen",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_inschrijving_KindId",
                table: "inschrijving",
                column: "KindId",
                unique: true);
        }
    }
}
