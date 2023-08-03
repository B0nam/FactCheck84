﻿// <auto-generated />
using System;
using FactCheck84.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FactCheck84.Migrations
{
    [DbContext(typeof(FactCheck84Context))]
    partial class FactCheck84ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FactCheck84.Models.AccountStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("AccountStatuses");
                });

            modelBuilder.Entity("FactCheck84.Models.CensorChiefRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("ManageUsers")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("ManageWords")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CensorChiefRoles");
                });

            modelBuilder.Entity("FactCheck84.Models.CriminalStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CriminalStatuses");
                });

            modelBuilder.Entity("FactCheck84.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("FactCheck84.Models.RedactedWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CensorChiefId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Word")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CensorChiefId");

                    b.ToTable("RedactedWords");
                });

            modelBuilder.Entity("FactCheck84.Models.Text", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EditorOfficerId")
                        .HasColumnType("int");

                    b.Property<string>("TextContent")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TextStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EditorOfficerId");

                    b.HasIndex("TextStatusId");

                    b.ToTable("Texts");
                });

            modelBuilder.Entity("FactCheck84.Models.TextStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TextStatuses");
                });

            modelBuilder.Entity("FactCheck84.Models.ThoughtCriminal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CriminalStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("JusticeExecuterId")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("WarrantyDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CriminalStatusId");

                    b.HasIndex("JusticeExecuterId");

                    b.HasIndex("LocationId");

                    b.HasIndex("UserId");

                    b.ToTable("ThoughtCriminals");
                });

            modelBuilder.Entity("FactCheck84.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccountStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SocialNum")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AccountStatusId");

                    b.ToTable("Users", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("FactCheck84.Models.CensorChief", b =>
                {
                    b.HasBaseType("FactCheck84.Models.User");

                    b.Property<int>("CensorChiefRolesId")
                        .HasColumnType("int");

                    b.HasIndex("CensorChiefRolesId");

                    b.ToTable("CensorChiefs", (string)null);
                });

            modelBuilder.Entity("FactCheck84.Models.EditorOfficer", b =>
                {
                    b.HasBaseType("FactCheck84.Models.User");

                    b.ToTable("EditorOfficers", (string)null);
                });

            modelBuilder.Entity("FactCheck84.Models.JusticeExecuter", b =>
                {
                    b.HasBaseType("FactCheck84.Models.User");

                    b.ToTable("JusticeExecuters", (string)null);
                });

            modelBuilder.Entity("FactCheck84.Models.RedactedWord", b =>
                {
                    b.HasOne("FactCheck84.Models.CensorChief", "CensorChief")
                        .WithMany()
                        .HasForeignKey("CensorChiefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CensorChief");
                });

            modelBuilder.Entity("FactCheck84.Models.Text", b =>
                {
                    b.HasOne("FactCheck84.Models.EditorOfficer", "EditorOfficer")
                        .WithMany()
                        .HasForeignKey("EditorOfficerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FactCheck84.Models.TextStatus", "TextStatus")
                        .WithMany()
                        .HasForeignKey("TextStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EditorOfficer");

                    b.Navigation("TextStatus");
                });

            modelBuilder.Entity("FactCheck84.Models.ThoughtCriminal", b =>
                {
                    b.HasOne("FactCheck84.Models.CriminalStatus", "CriminalStatus")
                        .WithMany()
                        .HasForeignKey("CriminalStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FactCheck84.Models.JusticeExecuter", "JusticeExecuter")
                        .WithMany()
                        .HasForeignKey("JusticeExecuterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FactCheck84.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FactCheck84.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("CriminalStatus");

                    b.Navigation("JusticeExecuter");

                    b.Navigation("Location");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FactCheck84.Models.User", b =>
                {
                    b.HasOne("FactCheck84.Models.AccountStatus", "AccountStatus")
                        .WithMany()
                        .HasForeignKey("AccountStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountStatus");
                });

            modelBuilder.Entity("FactCheck84.Models.CensorChief", b =>
                {
                    b.HasOne("FactCheck84.Models.CensorChiefRoles", "CensorChiefRoles")
                        .WithMany()
                        .HasForeignKey("CensorChiefRolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FactCheck84.Models.User", null)
                        .WithOne()
                        .HasForeignKey("FactCheck84.Models.CensorChief", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CensorChiefRoles");
                });

            modelBuilder.Entity("FactCheck84.Models.EditorOfficer", b =>
                {
                    b.HasOne("FactCheck84.Models.User", null)
                        .WithOne()
                        .HasForeignKey("FactCheck84.Models.EditorOfficer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FactCheck84.Models.JusticeExecuter", b =>
                {
                    b.HasOne("FactCheck84.Models.User", null)
                        .WithOne()
                        .HasForeignKey("FactCheck84.Models.JusticeExecuter", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
