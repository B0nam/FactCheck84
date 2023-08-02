﻿// <auto-generated />
using System;
using FactCheck84.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FactCheck84.Migrations
{
    [DbContext(typeof(FactCheck84Context))]
    [Migration("20230802185050_RedactedWords")]
    partial class RedactedWords
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("FactCheck84.Models.CensorChief", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CensorChiefRolesId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CensorChiefRolesId");

                    b.HasIndex("UserId");

                    b.ToTable("CensorChiefs");
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

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FactCheck84.Models.CensorChief", b =>
                {
                    b.HasOne("FactCheck84.Models.CensorChiefRoles", "CensorChiefRoles")
                        .WithMany()
                        .HasForeignKey("CensorChiefRolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FactCheck84.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CensorChiefRoles");

                    b.Navigation("User");
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

            modelBuilder.Entity("FactCheck84.Models.User", b =>
                {
                    b.HasOne("FactCheck84.Models.AccountStatus", "accountStatus")
                        .WithMany()
                        .HasForeignKey("AccountStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("accountStatus");
                });
#pragma warning restore 612, 618
        }
    }
}
