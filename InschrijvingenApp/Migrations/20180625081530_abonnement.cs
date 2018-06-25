using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace InschrijvenPietieterken.Migrations
{
    public partial class abonnement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HeeftMaandAbonnement",
                table: "inschrijving",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeeftMaandAbonnement",
                table: "inschrijving");
        }
    }
}
