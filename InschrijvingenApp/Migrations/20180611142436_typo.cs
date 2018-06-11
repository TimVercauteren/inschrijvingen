using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace InschrijvingPietieterken.Migrations
{
    public partial class typo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AndereAandodeningen",
                table: "medisch",
                newName: "AndereAandoeningen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AndereAandoeningen",
                table: "medisch",
                newName: "AndereAandodeningen");
        }
    }
}
