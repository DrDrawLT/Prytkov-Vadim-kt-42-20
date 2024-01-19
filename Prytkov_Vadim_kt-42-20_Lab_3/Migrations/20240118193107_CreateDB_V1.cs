using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prytkov_Vadim_kt_42_20_Lab_3.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB_V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicDegrees",
                columns: table => new
                {
                    ad_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор должности")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_ad_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Имя")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_academicDegrees_ad_id", x => x.ad_id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    depart_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор кафедры")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_depart_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Имя"),
                    c_depart_date = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Дата создания кафедры"),
                    c_depart_count = table.Column<int>(type: "int", nullable: false, comment: "Кол-во преподавателей"),
                    c_depart_teach = table.Column<int>(type: "int", nullable: false, comment: "Заместитель кафедры")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_derts_depart_id", x => x.depart_id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    discip_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор дисциплины")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_discip_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Имя"),
                    c_discip_teach = table.Column<int>(type: "int", nullable: false, comment: "Id преподавателя"),
                    c_discip_load = table.Column<int>(type: "int", nullable: false, comment: "Id нагрузки")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_disciplines_discip_id", x => x.discip_id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    position_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор должности")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_position_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Имя")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_positions_position_id", x => x.position_id);
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
                        principalColumn: "ad_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_dep_id",
                        column: x => x.c_teach_dep_id,
                        principalTable: "Departments",
                        principalColumn: "depart_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_posit_id",
                        column: x => x.c_teach_pos_id,
                        principalTable: "Positions",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoadPerHour",
                columns: table => new
                {
                    load_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор нагрузки")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_load_hours = table.Column<int>(type: "int", nullable: false, comment: "Время, ч."),
                    c_load_teach_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор преподавателя"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    c_load_dis_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор дисциплины"),
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    c_load_depart_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор кафедры"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_load_load_id", x => x.load_id);
                    table.ForeignKey(
                        name: "FK_LoadPerHour_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "depart_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoadPerHour_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "discip_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoadPerHour_cd_teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "cd_teachers",
                        principalColumn: "teach_id",
                        onDelete: ReferentialAction.NoAction);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_LoadPerHour_DepartmentId",
                table: "LoadPerHour",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadPerHour_DisciplineId",
                table: "LoadPerHour",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadPerHour_TeacherId",
                table: "LoadPerHour",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoadPerHour");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "cd_teachers");

            migrationBuilder.DropTable(
                name: "AcademicDegrees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
