using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Antivirus.Migrations
{
    /// <inheritdoc />
    public partial class AtributoLogoInstitution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "institutions",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "institutions");
        }
    }
}
