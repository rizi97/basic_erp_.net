using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS_ERP.Migrations
{
    /// <inheritdoc />
    public partial class AddPassColPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PatientPassword",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientPassword",
                table: "Patients");
        }
    }
}
