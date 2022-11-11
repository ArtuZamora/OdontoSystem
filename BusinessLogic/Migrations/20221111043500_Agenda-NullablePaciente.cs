using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessLogic.Migrations
{
    public partial class AgendaNullablePaciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Treatment_TreatmentId",
                table: "Agenda");

            migrationBuilder.AlterColumn<long>(
                name: "TreatmentId",
                table: "Agenda",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Treatment_TreatmentId",
                table: "Agenda",
                column: "TreatmentId",
                principalTable: "Treatment",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Treatment_TreatmentId",
                table: "Agenda");

            migrationBuilder.AlterColumn<long>(
                name: "TreatmentId",
                table: "Agenda",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Treatment_TreatmentId",
                table: "Agenda",
                column: "TreatmentId",
                principalTable: "Treatment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
