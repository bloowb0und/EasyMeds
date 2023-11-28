﻿// <auto-generated />
using System;
using EasyMeds.WebAPI.Core.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EasyMeds.WebAPI.Migrations
{
    [DbContext(typeof(EasyMedsDbContext))]
    [Migration("20231126184753_FixedPrescriptionNullable")]
    partial class FixedPrescriptionNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EasyMeds.WebAPI.Core.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("EasyMeds.WebAPI.Core.Entities.Medication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndTimeUTC")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Frequency")
                        .HasColumnType("integer");

                    b.Property<int>("MedicineId")
                        .HasColumnType("integer");

                    b.Property<int>("PrescriptionId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartTimeUTC")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("MedicineId");

                    b.HasIndex("PrescriptionId");

                    b.ToTable("Medications");
                });

            modelBuilder.Entity("EasyMeds.WebAPI.Core.Entities.MedicationLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MedicationId")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TimestampUTC")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("MedicationId");

                    b.ToTable("MedicationLogs");
                });

            modelBuilder.Entity("EasyMeds.WebAPI.Core.Entities.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Interactions")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SideEffects")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("EasyMeds.WebAPI.Core.Entities.Prescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DatePrescribedUTC")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<int>("Dosage")
                        .HasColumnType("integer");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("UserId");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("EasyMeds.WebAPI.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EasyMeds.WebAPI.Core.Entities.Medication", b =>
                {
                    b.HasOne("EasyMeds.WebAPI.Core.Entities.Medicine", "Medicine")
                        .WithMany("Medications")
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyMeds.WebAPI.Core.Entities.Prescription", "Prescription")
                        .WithMany("Medications")
                        .HasForeignKey("PrescriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicine");

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("EasyMeds.WebAPI.Core.Entities.MedicationLog", b =>
                {
                    b.HasOne("EasyMeds.WebAPI.Core.Entities.Medication", "Medication")
                        .WithMany("MedicationLogs")
                        .HasForeignKey("MedicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medication");
                });

            modelBuilder.Entity("EasyMeds.WebAPI.Core.Entities.Prescription", b =>
                {
                    b.HasOne("EasyMeds.WebAPI.Core.Entities.Doctor", "Doctor")
                        .WithMany("Prescriptions")
                        .HasForeignKey("DoctorId");

                    b.HasOne("EasyMeds.WebAPI.Core.Entities.User", "User")
                        .WithMany("Prescriptions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EasyMeds.WebAPI.Core.Entities.Doctor", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("EasyMeds.WebAPI.Core.Entities.Medication", b =>
                {
                    b.Navigation("MedicationLogs");
                });

            modelBuilder.Entity("EasyMeds.WebAPI.Core.Entities.Medicine", b =>
                {
                    b.Navigation("Medications");
                });

            modelBuilder.Entity("EasyMeds.WebAPI.Core.Entities.Prescription", b =>
                {
                    b.Navigation("Medications");
                });

            modelBuilder.Entity("EasyMeds.WebAPI.Core.Entities.User", b =>
                {
                    b.Navigation("Prescriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
