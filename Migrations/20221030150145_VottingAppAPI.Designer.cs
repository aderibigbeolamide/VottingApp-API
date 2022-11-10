﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VottingAPI.Data;

#nullable disable

namespace VottingAPI.Migrations
{
    [DbContext(typeof(VottingAppApiContext))]
    [Migration("20221030150145_VottingAppAPI")]
    partial class VottingAppAPI
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("VottingAPI.Model.Contestant", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ElectionId")
                        .HasColumnType("int");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("VoteCount")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("ElectionId");

                    b.HasIndex("PositionId");

                    b.HasIndex("StudentId");

                    b.ToTable("Contestants");
                });

            modelBuilder.Entity("VottingAPI.Model.Election", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ElectionName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDisplay")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("id");

                    b.ToTable("Elections");
                });

            modelBuilder.Entity("VottingAPI.Model.ElectoralOfficer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModified")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NextOfKin")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("ElectoralOfficers");
                });

            modelBuilder.Entity("VottingAPI.Model.Position", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ElectionId")
                        .HasColumnType("int");

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("ElectionId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("VottingAPI.Model.Student", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("Contestantid")
                        .HasColumnType("int");

                    b.Property<string>("Course")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModified")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("MatricNo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NextOfKin")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("Voterid")
                        .HasColumnType("int");

                    b.Property<bool>("isApproved")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("id");

                    b.HasIndex("Contestantid");

                    b.HasIndex("Voterid");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("VottingAPI.Model.Vote", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ContestantId")
                        .HasColumnType("int");

                    b.Property<string>("ContestantName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ElectionId")
                        .HasColumnType("int");

                    b.Property<string>("ElectionName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Studentid")
                        .HasColumnType("int");

                    b.Property<int>("VoterId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("ContestantId");

                    b.HasIndex("ElectionId");

                    b.HasIndex("Studentid");

                    b.HasIndex("VoterId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("VottingAPI.Model.Voter", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CastVote")
                        .HasColumnType("int");

                    b.Property<int>("ElectionId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("ElectionId");

                    b.HasIndex("StudentId");

                    b.ToTable("Voters");
                });

            modelBuilder.Entity("VottingAPI.Model.Contestant", b =>
                {
                    b.HasOne("VottingAPI.Model.Election", "Election")
                        .WithMany()
                        .HasForeignKey("ElectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VottingAPI.Model.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VottingAPI.Model.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Election");

                    b.Navigation("Position");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("VottingAPI.Model.Position", b =>
                {
                    b.HasOne("VottingAPI.Model.Election", "Election")
                        .WithMany("PositionId")
                        .HasForeignKey("ElectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Election");
                });

            modelBuilder.Entity("VottingAPI.Model.Student", b =>
                {
                    b.HasOne("VottingAPI.Model.Contestant", null)
                        .WithMany("Students")
                        .HasForeignKey("Contestantid");

                    b.HasOne("VottingAPI.Model.Voter", null)
                        .WithMany("Students")
                        .HasForeignKey("Voterid");
                });

            modelBuilder.Entity("VottingAPI.Model.Vote", b =>
                {
                    b.HasOne("VottingAPI.Model.Contestant", "Contestant")
                        .WithMany()
                        .HasForeignKey("ContestantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VottingAPI.Model.Election", "Election")
                        .WithMany()
                        .HasForeignKey("ElectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VottingAPI.Model.Student", "Student")
                        .WithMany()
                        .HasForeignKey("Studentid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VottingAPI.Model.Voter", "Voter")
                        .WithMany()
                        .HasForeignKey("VoterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contestant");

                    b.Navigation("Election");

                    b.Navigation("Student");

                    b.Navigation("Voter");
                });

            modelBuilder.Entity("VottingAPI.Model.Voter", b =>
                {
                    b.HasOne("VottingAPI.Model.Election", "Election")
                        .WithMany()
                        .HasForeignKey("ElectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VottingAPI.Model.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Election");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("VottingAPI.Model.Contestant", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("VottingAPI.Model.Election", b =>
                {
                    b.Navigation("PositionId");
                });

            modelBuilder.Entity("VottingAPI.Model.Voter", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
