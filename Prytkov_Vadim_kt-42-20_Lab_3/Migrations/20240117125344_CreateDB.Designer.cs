﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prytkov_Vadim_kt_42_20_Lab_3.DB;

#nullable disable

namespace Prytkov_Vadim_kt_42_20_Lab_3.Migrations
{
    [DbContext(typeof(PrepodDBContext))]
    [Migration("20240117125344_CreateDB")]
    partial class CreateDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Prytkov_Vadim_kt_42_20_Lab_3.Models.AcademicDegrees", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AcademicDegrees");
                });

            modelBuilder.Entity("Prytkov_Vadim_kt_42_20_Lab_3.Models.Departments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("depart_id")
                        .HasComment("Идентификатор кафедры");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountTeach")
                        .HasColumnType("int")
                        .HasColumnName("c_dep_count")
                        .HasComment("Кол-во преподавателей");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("c_dep_date")
                        .HasComment("Дата создания");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_dep_name")
                        .HasComment("Наименование кафедры");

                    b.Property<int>("TeachId")
                        .HasColumnType("int")
                        .HasColumnName("c_dep_teach_id")
                        .HasComment("Идентификатор заместителя");

                    b.HasKey("Id")
                        .HasName("pk_cd_departments_department_id");

                    b.HasIndex(new[] { "TeachId" }, "idx_cd_departments_fk_f2_teach_id");

                    b.ToTable("cd_departments", (string)null);
                });

            modelBuilder.Entity("Prytkov_Vadim_kt_42_20_Lab_3.Models.Disciplines", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("discipline_id")
                        .HasComment("Идентификатор дисциплины");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LoadId")
                        .HasColumnType("int")
                        .HasColumnName("c_dis_load_id")
                        .HasComment("Идентификатор нагрузки");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_dis_name")
                        .HasComment("Имя");

                    b.Property<int>("TeachId")
                        .HasColumnType("int")
                        .HasColumnName("c_dis_teach_id")
                        .HasComment("Идентификатор преподавателя");

                    b.HasKey("Id")
                        .HasName("pk_cd_disciplines_discipline_id");

                    b.HasIndex(new[] { "LoadId" }, "idx_cd_disciplines_fk_f_load_id");

                    b.HasIndex(new[] { "TeachId" }, "idx_cd_disciplines_fk_f_teach_id");

                    b.ToTable("cd_disciplines", (string)null);
                });

            modelBuilder.Entity("Prytkov_Vadim_kt_42_20_Lab_3.Models.LoadPerHour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("load_id")
                        .HasComment("Идентификатор нагрузки");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepId")
                        .HasColumnType("int")
                        .HasColumnName("c_load_dep_id")
                        .HasComment("Идентификатор кафедры");

                    b.Property<int>("DiscipId")
                        .HasColumnType("int")
                        .HasColumnName("c_load_dis_id")
                        .HasComment("Идентификатор дисциплины");

                    b.Property<int>("Hours")
                        .HasColumnType("int")
                        .HasColumnName("c_load_hours")
                        .HasComment("Время, ч.");

                    b.Property<int>("TeachId")
                        .HasColumnType("int")
                        .HasColumnName("c_load_teach_id")
                        .HasComment("Идентификатор преподавателя");

                    b.HasKey("Id")
                        .HasName("pk_cd_load_load_id");

                    b.HasIndex(new[] { "DepId" }, "idx_cd_load_fk_f1_dep_id");

                    b.HasIndex(new[] { "TeachId" }, "idx_cd_load_fk_f1_teach_id");

                    b.HasIndex(new[] { "DiscipId" }, "idx_cd_load_fk_f_dis_id");

                    b.ToTable("cd_load", (string)null);
                });

            modelBuilder.Entity("Prytkov_Vadim_kt_42_20_Lab_3.Models.Positions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Prytkov_Vadim_kt_42_20_Lab_3.Models.Teachers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("teach_id")
                        .HasComment("Идентификатор преподавателя");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AcDegId")
                        .HasColumnType("int")
                        .HasColumnName("c_teach_acdeg_id")
                        .HasComment("Идентификатор степени");

                    b.Property<int>("DepId")
                        .HasColumnType("int")
                        .HasColumnName("c_teach_dep_id")
                        .HasComment("Идентификатор кафедры");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_teach_name")
                        .HasComment("Имя");

                    b.Property<int>("PosId")
                        .HasColumnType("int")
                        .HasColumnName("c_teach_pos_id")
                        .HasComment("Идентификатор должности");

                    b.Property<string>("SecName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_teach_secname")
                        .HasComment("Фамилия");

                    b.Property<string>("ThirdName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_teach_thirdname")
                        .HasComment("Отчество");

                    b.HasKey("Id")
                        .HasName("pk_cd_teachers_teacher_id");

                    b.HasIndex(new[] { "AcDegId" }, "idx_cd_teachers_fk_f_acdeg_id");

                    b.HasIndex(new[] { "DepId" }, "idx_cd_teachers_fk_f_dep_id");

                    b.HasIndex(new[] { "PosId" }, "idx_cd_teachers_fk_f_posit_id");

                    b.ToTable("cd_teachers", (string)null);
                });

            modelBuilder.Entity("Prytkov_Vadim_kt_42_20_Lab_3.Models.Departments", b =>
                {
                    b.HasOne("Prytkov_Vadim_kt_42_20_Lab_3.Models.Teachers", "Deputy")
                        .WithMany()
                        .HasForeignKey("TeachId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_f2_teach_id");

                    b.Navigation("Deputy");
                });

            modelBuilder.Entity("Prytkov_Vadim_kt_42_20_Lab_3.Models.Disciplines", b =>
                {
                    b.HasOne("Prytkov_Vadim_kt_42_20_Lab_3.Models.LoadPerHour", "LoadArea")
                        .WithMany()
                        .HasForeignKey("LoadId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_f_load_id");

                    b.HasOne("Prytkov_Vadim_kt_42_20_Lab_3.Models.Teachers", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_teach_id");

                    b.Navigation("LoadArea");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Prytkov_Vadim_kt_42_20_Lab_3.Models.LoadPerHour", b =>
                {
                    b.HasOne("Prytkov_Vadim_kt_42_20_Lab_3.Models.Departments", "Department")
                        .WithMany()
                        .HasForeignKey("DepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f1_dep_id");

                    b.HasOne("Prytkov_Vadim_kt_42_20_Lab_3.Models.Disciplines", "Discipline")
                        .WithMany()
                        .HasForeignKey("DiscipId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_f_dis_id");

                    b.HasOne("Prytkov_Vadim_kt_42_20_Lab_3.Models.Teachers", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeachId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_f1_teach_id");

                    b.Navigation("Department");

                    b.Navigation("Discipline");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Prytkov_Vadim_kt_42_20_Lab_3.Models.Teachers", b =>
                {
                    b.HasOne("Prytkov_Vadim_kt_42_20_Lab_3.Models.AcademicDegrees", "AcademicDegree")
                        .WithMany()
                        .HasForeignKey("AcDegId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_acdeg_id");

                    b.HasOne("Prytkov_Vadim_kt_42_20_Lab_3.Models.Departments", "Depart")
                        .WithMany()
                        .HasForeignKey("DepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_dep_id");

                    b.HasOne("Prytkov_Vadim_kt_42_20_Lab_3.Models.Positions", "Position")
                        .WithMany()
                        .HasForeignKey("PosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_posit_id");

                    b.Navigation("AcademicDegree");

                    b.Navigation("Depart");

                    b.Navigation("Position");
                });
#pragma warning restore 612, 618
        }
    }
}
