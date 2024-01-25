using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityEventManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Person_organizerid",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_organizerid",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "organizerid",
                table: "Event",
                newName: "organizerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "organizerId",
                table: "Event",
                newName: "organizerid");

            migrationBuilder.CreateIndex(
                name: "IX_Event_organizerid",
                table: "Event",
                column: "organizerid");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Person_organizerid",
                table: "Event",
                column: "organizerid",
                principalTable: "Person",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
