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
    [Migration("20230809223938_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FactCheck84.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("AuthorStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AuthorStatusId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("FactCheck84.Models.AuthorStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("AuthorStatuses");
                });

            modelBuilder.Entity("FactCheck84.Models.RedactedWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NewWord")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Word")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<bool>("isHidden")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("RedactedWords");
                });

            modelBuilder.Entity("FactCheck84.Models.Text", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("CensoredContent")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TextStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("TextStatusId");

                    b.ToTable("Texts");
                });

            modelBuilder.Entity("FactCheck84.Models.TextRedactedWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("RedactedWordId")
                        .HasColumnType("int");

                    b.Property<int>("TextId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RedactedWordId");

                    b.HasIndex("TextId");

                    b.ToTable("TextRedactedWord");
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

            modelBuilder.Entity("FactCheck84.Models.Author", b =>
                {
                    b.HasOne("FactCheck84.Models.AuthorStatus", "AuthorStatus")
                        .WithMany()
                        .HasForeignKey("AuthorStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthorStatus");
                });

            modelBuilder.Entity("FactCheck84.Models.Text", b =>
                {
                    b.HasOne("FactCheck84.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FactCheck84.Models.TextStatus", "TextStatus")
                        .WithMany()
                        .HasForeignKey("TextStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("TextStatus");
                });

            modelBuilder.Entity("FactCheck84.Models.TextRedactedWord", b =>
                {
                    b.HasOne("FactCheck84.Models.RedactedWord", "RedactedWord")
                        .WithMany()
                        .HasForeignKey("RedactedWordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FactCheck84.Models.Text", "Text")
                        .WithMany("TextRedactedWords")
                        .HasForeignKey("TextId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RedactedWord");

                    b.Navigation("Text");
                });

            modelBuilder.Entity("FactCheck84.Models.Text", b =>
                {
                    b.Navigation("TextRedactedWords");
                });
#pragma warning restore 612, 618
        }
    }
}