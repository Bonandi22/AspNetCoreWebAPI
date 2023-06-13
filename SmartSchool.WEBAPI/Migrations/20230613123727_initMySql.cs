using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSchool.WEBAPI.Migrations
{
    public partial class initMySql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Couses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Couses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Enroll = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telephone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Register = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telephone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudentCouses",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CouseId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudentSubjects",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                    { 1, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Marta", new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8084), "Kent", "33225555" },
                    { 2, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Paula", new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8122), "Isabela", "3354288" },
                    { 3, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "Laura", new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8141), "Antonia", "55668899" },
                    { 4, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, "Luiza", new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8160), "Maria", "6565659" },
                    { 5, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, "Lucas", new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8179), "Machado", "565685415" },
                    { 6, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, "Pedro", new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8201), "Alvares", "456454545" },
                    { 7, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, "Paulo", new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8221), "José", "9874512" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Active", "EndDate", "Name", "Register", "StartDate", "Surname", "Telephone" },
                values: new object[,]
                {
                    { 1, true, null, "Lauro", 1, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(7540), "Oliveira", null },
                    { 2, true, null, "Roberto", 2, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(7702), "Soares", null },
                    { 3, true, null, "Ronaldo", 3, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(7709), "Marconi", null },
                    { 4, true, null, "Rodrigo", 4, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(7720), "Carvalho", null },
                    { 5, true, null, "Alexandre", 5, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(7728), "Montanha", null }
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
                    { 1, 2, null, null, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8300) },
                    { 1, 4, null, null, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8318) },
                    { 1, 5, null, null, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8333) },
                    { 2, 1, null, null, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8336) },
                    { 2, 2, null, null, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8343) },
                    { 2, 5, null, null, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8354) },
                    { 3, 1, null, null, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8361) },
                    { 3, 2, null, null, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8371) },
                    { 3, 3, null, null, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8374) },
                    { 4, 1, null, null, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8390) },
                    { 4, 4, null, null, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8393) },
                    { 4, 5, null, null, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8400) },
                    { 5, 4, null, null, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8409) },
                    { 5, 5, null, null, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8413) },
                    { 6, 1, null, null, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8419) },
                    { 6, 2, null, null, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8430) },
                    { 6, 3, null, null, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8433) },
                    { 6, 4, null, null, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8443) },
                    { 7, 1, null, null, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8451) },
                    { 7, 2, null, null, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8456) },
                    { 7, 3, null, null, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8464) },
                    { 7, 4, null, null, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8470) },
                    { 7, 5, null, null, new DateTime(2023, 6, 13, 13, 37, 26, 388, DateTimeKind.Local).AddTicks(8473) }
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
