using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityEventManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Event",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "organizerid",
                table: "Event",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Person_organizerid",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_organizerid",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "organizerid",
                table: "Event");
        }
    }
}
