﻿// <auto-generated />
using System;
using A_Card_Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace A_Card_Server.Migrations
{
    [DbContext(typeof(ACardContext))]
    partial class ACardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("A_Card_Server.Models.Animal", b =>
                {
                    b.Property<string>("uuid")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("chip")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ownerssn")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("species")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("uuid");

                    b.HasIndex("ownerssn");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("A_Card_Server.Models.Owner", b =>
                {
                    b.Property<string>("ssn")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("firstname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("streetAndNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("zip")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ssn");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("A_Card_Server.Models.Animal", b =>
                {
                    b.HasOne("A_Card_Server.Models.Owner", "owner")
                        .WithMany("Animals")
                        .HasForeignKey("ownerssn")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("owner");
                });

            modelBuilder.Entity("A_Card_Server.Models.Owner", b =>
                {
                    b.Navigation("Animals");
                });
#pragma warning restore 612, 618
        }
    }
}