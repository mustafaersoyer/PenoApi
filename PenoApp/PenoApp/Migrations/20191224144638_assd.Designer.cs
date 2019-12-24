﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PenoApp.Data;

namespace PenoApp.Migrations
{
    [DbContext(typeof(PenoContext))]
    [Migration("20191224144638_assd")]
    partial class assd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PenoApp.Models.Aca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<int>("No");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Acas");
                });

            modelBuilder.Entity("PenoApp.Models.LecAndStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LectureId");

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("LectureId");

                    b.HasIndex("StudentId");

                    b.ToTable("LecAndStudents");
                });

            modelBuilder.Entity("PenoApp.Models.Lecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AcaId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AcaId");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("PenoApp.Models.Notice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LectureId");

                    b.Property<string>("content");

                    b.HasKey("Id");

                    b.HasIndex("LectureId");

                    b.ToTable("Notices");
                });

            modelBuilder.Entity("PenoApp.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<int>("No");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("PenoApp.Models.LecAndStudent", b =>
                {
                    b.HasOne("PenoApp.Models.Lecture", "Lecture")
                        .WithMany("LecAndStudents")
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PenoApp.Models.Student", "Student")
                        .WithMany("LecAndStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PenoApp.Models.Lecture", b =>
                {
                    b.HasOne("PenoApp.Models.Aca")
                        .WithMany("Lectures")
                        .HasForeignKey("AcaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PenoApp.Models.Notice", b =>
                {
                    b.HasOne("PenoApp.Models.Lecture")
                        .WithMany("Notices")
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
