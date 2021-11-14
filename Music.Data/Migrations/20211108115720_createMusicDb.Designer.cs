﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicWeb.Data.Context;

namespace MusicWeb.Data.Migrations
{
    [DbContext(typeof(MusicDbContext))]
    [Migration("20211108115720_createMusicDb")]
    partial class createMusicDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ArtistMusic", b =>
                {
                    b.Property<int>("ArtistsArtistId")
                        .HasColumnType("int");

                    b.Property<int>("MusicsMusicId")
                        .HasColumnType("int");

                    b.HasKey("ArtistsArtistId", "MusicsMusicId");

                    b.HasIndex("MusicsMusicId");

                    b.ToTable("ArtistMusic");
                });

            modelBuilder.Entity("MusicWeb.Core.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArtistName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtistId");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("MusicWeb.Core.Models.Music", b =>
                {
                    b.Property<int>("MusicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MusicName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MusicId");

                    b.ToTable("Musics");
                });

            modelBuilder.Entity("ArtistMusic", b =>
                {
                    b.HasOne("MusicWeb.Core.Models.Artist", null)
                        .WithMany()
                        .HasForeignKey("ArtistsArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicWeb.Core.Models.Music", null)
                        .WithMany()
                        .HasForeignKey("MusicsMusicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}