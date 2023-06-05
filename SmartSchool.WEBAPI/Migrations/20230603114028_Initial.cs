using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSchool.WEBAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Couses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Couses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enroll = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Register = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentCouses",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CouseId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    courseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCouses", x => new { x.StudentId, x.CouseId });
                    table.ForeignKey(
                        name: "FK_StudentCouses_Couses_courseId",
                        column: x => x.courseId,
                        principalTable: "Couses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentCouses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Workload = table.Column<int>(type: "int", nullable: false),
                    PreRequisiteId = table.Column<int>(type: "int", nullable: true),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subjects_Couses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Couses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subjects_subjects_PreRequisiteId",
                        column: x => x.PreRequisiteId,
                        principalTable: "subjects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_subjects_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubjects",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubjects", x => new { x.StudentId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_StudentSubjects_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubjects_subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Couses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tecnologia da Informação" },
                    { 2, "Sistemas de Informação" },
                    { 3, "Ciência da Computação" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Active", "BirthDate", "EndDate", "Enroll", "Name", "StartDate", "Surname", "Telephone" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Marta", new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6665), "Kent", "33225555" },
                    { 2, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Paula", new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6691), "Isabela", "3354288" },
                    { 3, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "Laura", new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6699), "Antonia", "55668899" },
                    { 4, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, "Luiza", new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6705), "Maria", "6565659" },
                    { 5, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, "Lucas", new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6711), "Machado", "565685415" },
                    { 6, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, "Pedro", new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6721), "Alvares", "456454545" },
                    { 7, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, "Paulo", new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6729), "José", "9874512" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Active", "EndDate", "Name", "Register", "StartDate", "Surname", "Telephone" },
                values: new object[,]
                {
                    { 1, true, null, "Lauro", 1, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6115), "Oliveira", null },
                    { 2, true, null, "Roberto", 2, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6195), "Soares", null },
                    { 3, true, null, "Ronaldo", 3, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6199), "Marconi", null },
                    { 4, true, null, "Rodrigo", 4, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6202), "Carvalho", null },
                    { 5, true, null, "Alexandre", 5, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6205), "Montanha", null }
                });

            migrationBuilder.InsertData(
                table: "subjects",
                columns: new[] { "Id", "CourseId", "Name", "PreRequisiteId", "TeacherId", "Workload" },
                values: new object[,]
                {
                    { 1, 1, "Matemática", null, 1, 0 },
                    { 2, 3, "Matemática", null, 1, 0 },
                    { 3, 3, "Física", null, 2, 0 },
                    { 4, 1, "Português", null, 3, 0 },
                    { 5, 1, "Inglês", null, 4, 0 },
                    { 6, 2, "Inglês", null, 4, 0 },
                    { 7, 3, "Inglês", null, 4, 0 },
                    { 8, 1, "Programação", null, 5, 0 },
                    { 9, 2, "Programação", null, 5, 0 },
                    { 10, 3, "Programação", null, 5, 0 }
                });

            migrationBuilder.InsertData(
                table: "StudentSubjects",
                columns: new[] { "StudentId", "SubjectId", "EndDate", "Grade", "StartDate" },
                values: new object[,]
                {
                    { 1, 2, null, null, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6779) },
                    { 1, 4, null, null, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6788) },
                    { 1, 5, null, null, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6791) },
                    { 2, 1, null, null, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6793) },
                    { 2, 2, null, null, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6797) },
                    { 2, 5, null, null, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6801) },
                    { 3, 1, null, null, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6804) },
                    { 3, 2, null, null, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6807) },
                    { 3, 3, null, null, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6810) },
                    { 4, 1, null, null, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6815) },
                    { 4, 4, null, null, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6818) },
                    { 4, 5, null, null, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6821) },
                    { 5, 4, null, null, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6823) },
                    { 5, 5, null, null, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6826) },
                    { 6, 1, null, null, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6830) },
                    { 6, 2, null, null, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6833) },
                    { 6, 3, null, null, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6836) },
                    { 6, 4, null, null, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6841) },
                    { 7, 1, null, null, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6844) },
                    { 7, 2, null, null, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6847) },
                    { 7, 3, null, null, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6850) },
                    { 7, 4, null, null, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6853) },
                    { 7, 5, null, null, new DateTime(2023, 6, 3, 12, 40, 27, 124, DateTimeKind.Local).AddTicks(6857) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCouses_courseId",
                table: "StudentCouses",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_SubjectId",
                table: "StudentSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_subjects_CourseId",
                table: "subjects",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_subjects_PreRequisiteId",
                table: "subjects",
                column: "PreRequisiteId");

            migrationBuilder.CreateIndex(
                name: "IX_subjects_TeacherId",
                table: "subjects",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCouses");

            migrationBuilder.DropTable(
                name: "StudentSubjects");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.DropTable(
                name: "Couses");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
