using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomCovid19.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RankName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subdivisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubdivisionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subdivisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vaccine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VaccineName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubdivisionId = table.Column<int>(type: "int", nullable: true),
                    RankId = table.Column<int>(type: "int", nullable: true),
                    PositionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Ranks_RankId",
                        column: x => x.RankId,
                        principalTable: "Ranks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Subdivisions_SubdivisionId",
                        column: x => x.SubdivisionId,
                        principalTable: "Subdivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeVaccineJunctions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: true),
                    VaccineId = table.Column<int>(type: "int", nullable: true),
                    DateFirstComponent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateSecondComponent = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeVaccineJunctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeVaccineJunctions_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeVaccineJunctions_Vaccine_VaccineId",
                        column: x => x.VaccineId,
                        principalTable: "Vaccine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "PositionName" },
                values: new object[,]
                {
                    { 1, "начальник академии" },
                    { 15, "курсант" },
                    { 14, "профессор" },
                    { 13, "доцент" },
                    { 12, "старший инспектор по особым поручениям" },
                    { 11, "старший инспектор" },
                    { 9, "старший преподаватель" },
                    { 10, "старший преподаватель-методист" },
                    { 7, "преподаватель" },
                    { 6, "заместитель начальника кафедры" },
                    { 5, "начальник кафедры" },
                    { 4, "заместитель начальника курса" },
                    { 3, "начальник курса" },
                    { 2, "заместитель начальника академии" },
                    { 8, "преподаватель-методист" }
                });

            migrationBuilder.InsertData(
                table: "Ranks",
                columns: new[] { "Id", "RankName" },
                values: new object[,]
                {
                    { 8, "капитан милиции" },
                    { 11, "полковник милиции" },
                    { 10, "подполковник милиции" },
                    { 9, "майор милиции" },
                    { 7, "старший лейтенант милиции" },
                    { 1, "рядовой милиции" },
                    { 5, "старшина милиции" },
                    { 4, "старший сержант милиции" },
                    { 3, "сержант милиции" },
                    { 2, "младший сержант милиции" },
                    { 6, "лейтенант милиции" }
                });

            migrationBuilder.InsertData(
                table: "Subdivisions",
                columns: new[] { "Id", "SubdivisionName" },
                values: new object[,]
                {
                    { 1, "отдел кадров" },
                    { 2, "отдел образовательных информационных технологий" },
                    { 3, "учебно-методическое управление" }
                });

            migrationBuilder.InsertData(
                table: "Vaccine",
                columns: new[] { "Id", "VaccineName" },
                values: new object[,]
                {
                    { 2, "SARS-CoV-2 - Китай" },
                    { 1, "Спутник V - Росия" },
                    { 3, "Спутник Лайт - Росия" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FIO", "PositionId", "RankId", "SubdivisionId" },
                values: new object[,]
                {
                    { 4L, "Гейц Людмила Николаевна", 11, 8, 1 },
                    { 5L, "Костян Елена Григорьевна", 11, 8, 1 },
                    { 6L, "Бедункевич Марина Александровна", 12, 10, 1 },
                    { 1L, "Гурко Павел Михайлович", 8, 9, 2 },
                    { 2L, "Левенко Евгений Юрьевич", 10, 10, 2 },
                    { 3L, "Гуркский Вадим Михайлович", 10, 10, 2 },
                    { 7L, "Райкова Екатерина Александровна", 10, 10, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RankId",
                table: "Employees",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SubdivisionId",
                table: "Employees",
                column: "SubdivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeVaccineJunctions_EmployeeId",
                table: "EmployeeVaccineJunctions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeVaccineJunctions_VaccineId",
                table: "EmployeeVaccineJunctions",
                column: "VaccineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeVaccineJunctions");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Vaccine");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Ranks");

            migrationBuilder.DropTable(
                name: "Subdivisions");
        }
    }
}
