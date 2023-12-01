using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoopManagement.Migrations
{
    /// <inheritdoc />
    public partial class newdelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Person_PersonID",
                table: "Contacts");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Person_PersonID",
                table: "Contacts",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Person_PersonID",
                table: "Contacts");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Person_PersonID",
                table: "Contacts",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
