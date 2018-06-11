﻿// <auto-generated />
using InschrijvingPietieterken.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace InschrijvingPietieterken.Migrations
{
    [DbContext(typeof(EntityContext))]
    partial class EntityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InschrijvenPietieterken.Entities.Adres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bus");

                    b.Property<string>("Gemeente");

                    b.Property<string>("Huisnummer");

                    b.Property<string>("Postcode");

                    b.Property<string>("Straat");

                    b.HasKey("Id");

                    b.ToTable("adressen");
                });

            modelBuilder.Entity("InschrijvenPietieterken.Entities.Auth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("User");

                    b.HasKey("Id");

                    b.ToTable("Authentication");
                });

            modelBuilder.Entity("InschrijvingPietieterken.Entities.Inschrijving", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("KindId");

                    b.Property<int>("MedischId");

                    b.Property<int>("OudersId");

                    b.Property<string>("OverigeInfo");

                    b.HasKey("Id");

                    b.HasIndex("KindId");

                    b.HasIndex("MedischId");

                    b.HasIndex("OudersId");

                    b.ToTable("inschrijving");
                });

            modelBuilder.Entity("InschrijvingPietieterken.Entities.Kind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AfhaalPersoon");

                    b.Property<string>("BroersZussen");

                    b.Property<DateTime>("GeboorteDatum");

                    b.Property<int?>("PersoonId");

                    b.Property<bool>("ZelfNaarHuis");

                    b.HasKey("Id");

                    b.HasIndex("PersoonId");

                    b.ToTable("kinderen");
                });

            modelBuilder.Entity("InschrijvingPietieterken.Entities.Medisch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AanpakKind");

                    b.Property<string>("Allergieen");

                    b.Property<string>("AndereAandoeningen");

                    b.Property<bool>("Astma");

                    b.Property<string>("BelemmeringenSport");

                    b.Property<bool>("Epilepsie");

                    b.Property<bool>("FotosAllowed");

                    b.Property<bool>("Geneesmiddelen");

                    b.Property<string>("GeneesmiddelenLijst");

                    b.Property<bool>("Hartkwaal");

                    b.Property<bool>("Huidaandoening");

                    b.Property<string>("HuisArtsNaam");

                    b.Property<string>("HuisArtsTelefoon");

                    b.Property<bool>("KanSporten");

                    b.Property<bool>("KanZwemmen");

                    b.Property<bool>("PijnStillersAllowed");

                    b.Property<bool>("Suikerziekte");

                    b.Property<bool>("VaccinatieKindEnGezin");

                    b.Property<string>("ZiekteIngreep");

                    b.HasKey("Id");

                    b.ToTable("medisch");
                });

            modelBuilder.Entity("InschrijvingPietieterken.Entities.Ouders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AdresId");

                    b.Property<string>("Email1");

                    b.Property<string>("Email2");

                    b.Property<string>("NoodTelefoon");

                    b.Property<int?>("Ouder1Id");

                    b.Property<int?>("Ouder2Id");

                    b.Property<string>("Telefoon1");

                    b.Property<string>("Telefoon2");

                    b.HasKey("Id");

                    b.HasIndex("AdresId");

                    b.HasIndex("Ouder1Id");

                    b.HasIndex("Ouder2Id");

                    b.ToTable("ouders");
                });

            modelBuilder.Entity("InschrijvingPietieterken.Entities.Persoon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naam");

                    b.Property<string>("Voornaam");

                    b.HasKey("Id");

                    b.ToTable("personen");
                });

            modelBuilder.Entity("InschrijvingPietieterken.Entities.Inschrijving", b =>
                {
                    b.HasOne("InschrijvingPietieterken.Entities.Kind", "Kind")
                        .WithMany()
                        .HasForeignKey("KindId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InschrijvingPietieterken.Entities.Medisch", "Medisch")
                        .WithMany()
                        .HasForeignKey("MedischId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InschrijvingPietieterken.Entities.Ouders", "Ouders")
                        .WithMany()
                        .HasForeignKey("OudersId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InschrijvingPietieterken.Entities.Kind", b =>
                {
                    b.HasOne("InschrijvingPietieterken.Entities.Persoon", "Persoon")
                        .WithMany()
                        .HasForeignKey("PersoonId");
                });

            modelBuilder.Entity("InschrijvingPietieterken.Entities.Ouders", b =>
                {
                    b.HasOne("InschrijvenPietieterken.Entities.Adres", "Adres")
                        .WithMany()
                        .HasForeignKey("AdresId");

                    b.HasOne("InschrijvingPietieterken.Entities.Persoon", "Ouder1")
                        .WithMany()
                        .HasForeignKey("Ouder1Id");

                    b.HasOne("InschrijvingPietieterken.Entities.Persoon", "Ouder2")
                        .WithMany()
                        .HasForeignKey("Ouder2Id");
                });
#pragma warning restore 612, 618
        }
    }
}
