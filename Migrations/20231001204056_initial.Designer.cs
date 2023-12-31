﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartSchool.WebAPI.Data;

#nullable disable

namespace SmartSchool.WebAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231001204056_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.22");

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Discipline", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<long>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Disciplines");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.StudentDiscipline", b =>
                {
                    b.Property<long>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("DisciplineId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentId", "DisciplineId");

                    b.HasIndex("DisciplineId");

                    b.ToTable("StudentsDisciplines");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Teacher", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Discipline", b =>
                {
                    b.HasOne("SmartSchool.WebAPI.Models.Teacher", "Teacher")
                        .WithMany("Disciplines")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.StudentDiscipline", b =>
                {
                    b.HasOne("SmartSchool.WebAPI.Models.Discipline", "Discipline")
                        .WithMany("StudentDisciplines")
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartSchool.WebAPI.Models.Student", "Student")
                        .WithMany("StudentDisciplines")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discipline");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Discipline", b =>
                {
                    b.Navigation("StudentDisciplines");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Student", b =>
                {
                    b.Navigation("StudentDisciplines");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Teacher", b =>
                {
                    b.Navigation("Disciplines");
                });
#pragma warning restore 612, 618
        }
    }
}
