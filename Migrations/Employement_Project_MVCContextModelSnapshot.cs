﻿// <auto-generated />
using System;
using Employement_Project_MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Employement_Project_MVC.Migrations
{
    [DbContext(typeof(Employement_Project_MVCContext))]
    partial class Employement_Project_MVCContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Employement_Project_MVC.Models.Apply_Job_Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Candidate_DetailId")
                        .HasColumnType("int");

                    b.Property<string>("Candidate_availabilities")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Candidate_notice_period")
                        .HasColumnType("datetime2");

                    b.Property<int>("Job_DetailId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Candidate_DetailId");

                    b.HasIndex("Job_DetailId");

                    b.ToTable("Apply_Job_Detail");
                });

            modelBuilder.Entity("Employement_Project_MVC.Models.Candidate_Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DOB_of_candidate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email_address_of_candidate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile_no_of_candidate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_of_candidate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Candidate_Detail");
                });

            modelBuilder.Entity("Employement_Project_MVC.Models.Employer_Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address_of_employer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date_of_establishment")
                        .HasColumnType("datetime2");

                    b.Property<string>("Employer_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employer_Detail");
                });

            modelBuilder.Entity("Employement_Project_MVC.Models.Job_Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Employer_DetailId")
                        .HasColumnType("int");

                    b.Property<string>("Job_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Job_role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Job_salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Job_type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Employer_DetailId");

                    b.ToTable("Job_Detail");
                });

            modelBuilder.Entity("Employement_Project_MVC.Models.Apply_Job_Detail", b =>
                {
                    b.HasOne("Employement_Project_MVC.Models.Candidate_Detail", "Candidate_Detail")
                        .WithMany()
                        .HasForeignKey("Candidate_DetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Employement_Project_MVC.Models.Job_Detail", "Job_Detail")
                        .WithMany()
                        .HasForeignKey("Job_DetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate_Detail");

                    b.Navigation("Job_Detail");
                });

            modelBuilder.Entity("Employement_Project_MVC.Models.Job_Detail", b =>
                {
                    b.HasOne("Employement_Project_MVC.Models.Employer_Detail", "Employer_Detail")
                        .WithMany()
                        .HasForeignKey("Employer_DetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employer_Detail");
                });
#pragma warning restore 612, 618
        }
    }
}
