﻿// <auto-generated />
using System;
using DomraSinForms.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DomraSinForms.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240529125831_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DomraSinForms.Domain.Models.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FormAnswersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FormAnswersId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("DomraSinForms.Domain.Models.Form", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("DomraSinForms.Domain.Models.FormAnswers", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FormId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.HasIndex("UserId");

                    b.ToTable("FormAnswers");
                });

            modelBuilder.Entity("DomraSinForms.Domain.Models.FormItem", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<Guid>("FormId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("FormItems");

                    b.HasDiscriminator<string>("Discriminator").HasValue("FormItem");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DomraSinForms.Domain.Models.FormItems.QuestionOption", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<Guid>("ScoreTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("ScoreTypeId");

                    b.ToTable("QuestionOptions");
                });

            modelBuilder.Entity("DomraSinForms.Domain.Models.ScoreType", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FormId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("ScoreTypes");
                });

            modelBuilder.Entity("DomraSinForms.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FormId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("Verified")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DomraSinForms.Domain.Models.FormItems.PictureItem", b =>
                {
                    b.HasBaseType("DomraSinForms.Domain.Models.FormItem");

                    b.Property<string>("AltText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("PictureItem");
                });

            modelBuilder.Entity("DomraSinForms.Domain.Models.FormItems.Question", b =>
                {
                    b.HasBaseType("DomraSinForms.Domain.Models.FormItem");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("bit");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Question");
                });

            modelBuilder.Entity("DomraSinForms.Domain.Models.Answer", b =>
                {
                    b.HasOne("DomraSinForms.Domain.Models.FormAnswers", null)
                        .WithMany("Answers")
                        .HasForeignKey("FormAnswersId");

                    b.HasOne("DomraSinForms.Domain.Models.FormItems.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("DomraSinForms.Domain.Models.Form", b =>
                {
                    b.HasOne("DomraSinForms.Domain.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("DomraSinForms.Domain.Models.FormAnswers", b =>
                {
                    b.HasOne("DomraSinForms.Domain.Models.Form", "Form")
                        .WithMany()
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomraSinForms.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Form");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DomraSinForms.Domain.Models.FormItem", b =>
                {
                    b.HasOne("DomraSinForms.Domain.Models.Form", "Form")
                        .WithMany("Items")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Form");
                });

            modelBuilder.Entity("DomraSinForms.Domain.Models.FormItems.QuestionOption", b =>
                {
                    b.HasOne("DomraSinForms.Domain.Models.FormItems.Question", null)
                        .WithMany("Options")
                        .HasForeignKey("QuestionId");

                    b.HasOne("DomraSinForms.Domain.Models.ScoreType", "ScoreType")
                        .WithMany()
                        .HasForeignKey("ScoreTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ScoreType");
                });

            modelBuilder.Entity("DomraSinForms.Domain.Models.ScoreType", b =>
                {
                    b.HasOne("DomraSinForms.Domain.Models.Form", "Form")
                        .WithMany()
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Form");
                });

            modelBuilder.Entity("DomraSinForms.Domain.Models.User", b =>
                {
                    b.HasOne("DomraSinForms.Domain.Models.Form", null)
                        .WithMany("Redactors")
                        .HasForeignKey("FormId");
                });

            modelBuilder.Entity("DomraSinForms.Domain.Models.Form", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("Redactors");
                });

            modelBuilder.Entity("DomraSinForms.Domain.Models.FormAnswers", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("DomraSinForms.Domain.Models.FormItems.Question", b =>
                {
                    b.Navigation("Options");
                });
#pragma warning restore 612, 618
        }
    }
}