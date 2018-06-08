using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace InschrijvingPietieterken.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adressen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bus = table.Column<string>(nullable: true),
                    Gemeente = table.Column<string>(nullable: true),
                    Huisnummer = table.Column<string>(nullable: true),
                    Postcode = table.Column<int>(nullable: false),
                    Straat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adressen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "medisch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AanpakKind = table.Column<string>(nullable: true),
                    Allergieen = table.Column<string>(nullable: true),
                    AndereAandodeningen = table.Column<string>(nullable: true),
                    Astma = table.Column<bool>(nullable: false),
                    BelemmeringenSport = table.Column<string>(nullable: true),
                    Epilepsie = table.Column<bool>(nullable: false),
                    FotosAllowed = table.Column<bool>(nullable: false),
                    Geneesmiddelen = table.Column<bool>(nullable: false),
                    GeneesmiddelenLijst = table.Column<string>(nullable: true),
                    Hartkwaal = table.Column<bool>(nullable: false),
                    Huidaandoening = table.Column<bool>(nullable: false),
                    HuisArtsNaam = table.Column<string>(nullable: true),
                    HuisArtsTelefoon = table.Column<string>(nullable: true),
                    KanSporten = table.Column<bool>(nullable: false),
                    KanZwemmen = table.Column<bool>(nullable: false),
                    PijnStillersAllowed = table.Column<bool>(nullable: false),
                    Suikerziekte = table.Column<bool>(nullable: false),
                    VaccinatieKindEnGezin = table.Column<bool>(nullable: false),
                    ZiekteIngreep = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medisch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "personen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true),
                    Voornaam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "kinderen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AfhaalPersoon = table.Column<string>(nullable: true),
                    BroersZussen = table.Column<string>(nullable: true),
                    GeboorteDatum = table.Column<DateTime>(nullable: false),
                    PersoonId = table.Column<int>(nullable: true),
                    ZelfNaarHuis = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kinderen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kinderen_personen_PersoonId",
                        column: x => x.PersoonId,
                        principalTable: "personen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ouders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdresId = table.Column<int>(nullable: true),
                    Email1 = table.Column<string>(nullable: true),
                    Email2 = table.Column<string>(nullable: true),
                    NoodTelefoon = table.Column<string>(nullable: true),
                    Ouder1Id = table.Column<int>(nullable: true),
                    Ouder2Id = table.Column<int>(nullable: true),
                    Telefoon1 = table.Column<string>(nullable: true),
                    Telefoon2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ouders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ouders_adressen_AdresId",
                        column: x => x.AdresId,
                        principalTable: "adressen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ouders_personen_Ouder1Id",
                        column: x => x.Ouder1Id,
                        principalTable: "personen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ouders_personen_Ouder2Id",
                        column: x => x.Ouder2Id,
                        principalTable: "personen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inschrijving",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KindId = table.Column<int>(nullable: false),
                    MedischId = table.Column<int>(nullable: false),
                    OudersId = table.Column<int>(nullable: false),
                    OverigeInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inschrijving", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inschrijving_kinderen_KindId",
                        column: x => x.KindId,
                        principalTable: "kinderen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inschrijving_medisch_MedischId",
                        column: x => x.MedischId,
                        principalTable: "medisch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inschrijving_ouders_OudersId",
                        column: x => x.OudersId,
                        principalTable: "ouders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_inschrijving_KindId",
                table: "inschrijving",
                column: "KindId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inschrijving_MedischId",
                table: "inschrijving",
                column: "MedischId");

            migrationBuilder.CreateIndex(
                name: "IX_inschrijving_OudersId",
                table: "inschrijving",
                column: "OudersId");

            migrationBuilder.CreateIndex(
                name: "IX_kinderen_PersoonId",
                table: "kinderen",
                column: "PersoonId");

            migrationBuilder.CreateIndex(
                name: "IX_ouders_AdresId",
                table: "ouders",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_ouders_Ouder1Id",
                table: "ouders",
                column: "Ouder1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ouders_Ouder2Id",
                table: "ouders",
                column: "Ouder2Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inschrijving");

            migrationBuilder.DropTable(
                name: "kinderen");

            migrationBuilder.DropTable(
                name: "medisch");

            migrationBuilder.DropTable(
                name: "ouders");

            migrationBuilder.DropTable(
                name: "adressen");

            migrationBuilder.DropTable(
                name: "personen");
        }
    }
}
