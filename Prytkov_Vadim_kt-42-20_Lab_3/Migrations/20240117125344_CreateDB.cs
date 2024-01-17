using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prytkov_Vadim_kt_42_20_Lab_3.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicDegrees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicDegrees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cd_departments",
                columns: table => new
                {
                    depart_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор кафедры")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_dep_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Наименование кафедры"),
                    c_dep_date = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Дата создания"),
                    c_dep_count = table.Column<int>(type: "int", nullable: false, comment: "Кол-во преподавателей"),
                    c_dep_teach_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор заместителя")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_departments_department_id", x => x.depart_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_teachers",
                columns: table => new
                {
                    teach_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор преподавателя")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_teach_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Имя"),
                    c_teach_secname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Фамилия"),
                    c_teach_thirdname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Отчество"),
                    c_teach_dep_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор кафедры"),
                    c_teach_acdeg_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор степени"),
                    c_teach_pos_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_teachers_teacher_id", x => x.teach_id);
                    table.ForeignKey(
                        name: "fk_f_acdeg_id",
                        column: x => x.c_teach_acdeg_id,
                        principalTable: "AcademicDegrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_dep_id",
                        column: x => x.c_teach_dep_id,
                        principalTable: "cd_departments",
                        principalColumn: "depart_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_posit_id",
                        column: x => x.c_teach_pos_id,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_disciplines",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор дисциплины")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_dis_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Имя"),
                    c_dis_teach_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор преподавателя"),
                    c_dis_load_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор нагрузки")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_disciplines_discipline_id", x => x.discipline_id);
                    table.ForeignKey(
                        name: "fk_f_teach_id",
                        column: x => x.c_dis_teach_id,
                        principalTable: "cd_teachers",
                        principalColumn: "teach_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_load",
                columns: table => new
                {
                    load_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор нагрузки")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_load_hours = table.Column<int>(type: "int", nullable: false, comment: "Время, ч."),
                    c_load_teach_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор преподавателя"),
                    c_load_dep_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор кафедры"),
                    c_load_dis_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор дисциплины")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_load_load_id", x => x.load_id);
                    table.ForeignKey(
                        name: "fk_f1_dep_id",
                        column: x => x.c_load_dep_id,
                        principalTable: "cd_departments",
                        principalColumn: "depart_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f1_teach_id",
                        column: x => x.c_load_teach_id,
                        principalTable: "cd_teachers",
                        principalColumn: "teach_id");
                    table.ForeignKey(
                        name: "fk_f_dis_id",
                        column: x => x.c_load_dis_id,
                        principalTable: "cd_disciplines",
                        principalColumn: "discipline_id");
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_departments_fk_f2_teach_id",
                table: "cd_departments",
                column: "c_dep_teach_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_disciplines_fk_f_load_id",
                table: "cd_disciplines",
                column: "c_dis_load_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_disciplines_fk_f_teach_id",
                table: "cd_disciplines",
                column: "c_dis_teach_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_load_fk_f_dis_id",
                table: "cd_load",
                column: "c_load_dis_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_load_fk_f1_dep_id",
                table: "cd_load",
                column: "c_load_dep_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_load_fk_f1_teach_id",
                table: "cd_load",
                column: "c_load_teach_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teachers_fk_f_acdeg_id",
                table: "cd_teachers",
                column: "c_teach_acdeg_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teachers_fk_f_dep_id",
                table: "cd_teachers",
                column: "c_teach_dep_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teachers_fk_f_posit_id",
                table: "cd_teachers",
                column: "c_teach_pos_id");

            migrationBuilder.AddForeignKey(
                name: "fk_f2_teach_id",
                table: "cd_departments",
                column: "c_dep_teach_id",
                principalTable: "cd_teachers",
                principalColumn: "teach_id");

            migrationBuilder.AddForeignKey(
                name: "fk_f_load_id",
                table: "cd_disciplines",
                column: "c_dis_load_id",
                principalTable: "cd_load",
                principalColumn: "load_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_f2_teach_id",
                table: "cd_departments");

            migrationBuilder.DropForeignKey(
                name: "fk_f_teach_id",
                table: "cd_disciplines");

            migrationBuilder.DropForeignKey(
                name: "fk_f1_teach_id",
                table: "cd_load");

            migrationBuilder.DropForeignKey(
                name: "fk_f_load_id",
                table: "cd_disciplines");

            migrationBuilder.DropTable(
                name: "cd_teachers");

            migrationBuilder.DropTable(
                name: "AcademicDegrees");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "cd_load");

            migrationBuilder.DropTable(
                name: "cd_departments");

            migrationBuilder.DropTable(
                name: "cd_disciplines");
        }
    }
}
