using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_EF_Grup1.Migrations
{
    /// <inheritdoc />
    public partial class AracResmi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AracResmi",
                table: "Aracs_",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AracResmi",
                table: "Aracs_");
        }
    }
}
