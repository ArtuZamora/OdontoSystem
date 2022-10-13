using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessLogic.Migrations
{
    public partial class Alltables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Constraints",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelectDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constraints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    RiskDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CellPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelectDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Duration = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Odontogram",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToothNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PatientId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odontogram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odontogram_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PatientId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientHistory_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientRecord",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RFC = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Hospitalizations = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CurrentMedicTx = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CoagulationP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RespiratoryP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Trauma = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Allergies = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SystemicDiseases = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DentalHistory = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AlcoholicDrinks = table.Column<bool>(type: "bit", nullable: false),
                    Diagnostic = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Extractions = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    WisdomTeeht = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Prosthodontics = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PanoramicRx = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CephalometricRx = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PeriapicalRx = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TypeDentalClean = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TxDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TxPrev = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Midlines = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Diastemas = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BiteType = table.Column<int>(type: "int", nullable: true),
                    Crowding = table.Column<bool>(type: "bit", nullable: true),
                    Habits = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PatientId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientRecord_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TreatmentId = table.Column<long>(type: "bigint", nullable: false),
                    PatientId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agenda_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agenda_Treatment_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreatmentId = table.Column<long>(type: "bigint", nullable: false),
                    AgendaId = table.Column<long>(type: "bigint", nullable: false),
                    PatientId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentHistory_Agenda_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentHistory_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentHistory_Treatment_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_PatientId",
                table: "Agenda",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_TreatmentId",
                table: "Agenda",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentHistory_AgendaId",
                table: "AppointmentHistory",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentHistory_PatientId",
                table: "AppointmentHistory",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentHistory_TreatmentId",
                table: "AppointmentHistory",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Odontogram_PatientId",
                table: "Odontogram",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientHistory_PatientId",
                table: "PatientHistory",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRecord_PatientId",
                table: "PatientRecord",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentHistory");

            migrationBuilder.DropTable(
                name: "Constraints");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Odontogram");

            migrationBuilder.DropTable(
                name: "PatientHistory");

            migrationBuilder.DropTable(
                name: "PatientRecord");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Treatment");
        }
    }
}
