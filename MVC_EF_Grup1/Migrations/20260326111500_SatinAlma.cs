using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_EF_Grup1.Migrations
{
    /// <inheritdoc />
    public partial class SatinAlma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aracs_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelYili = table.Column<int>(type: "int", nullable: false),
                    Marka = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Plaka = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aracs_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musteris_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MusteriSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteris_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SatinAlmas_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriID = table.Column<int>(type: "int", nullable: false),
                    AracID = table.Column<int>(type: "int", nullable: false),
                    AlimFiyati = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AlimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatinAlmas_", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SatinAlmas__Aracs__AracID",
                        column: x => x.AracID,
                        principalTable: "Aracs_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SatinAlmas__Musteris__MusteriID",
                        column: x => x.MusteriID,
                        principalTable: "Musteris_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmas__AracID",
                table: "SatinAlmas_",
                column: "AracID");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmas__MusteriID",
                table: "SatinAlmas_",
                column: "MusteriID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SatinAlmas_");

            migrationBuilder.DropTable(
                name: "Aracs_");

            migrationBuilder.DropTable(
                name: "Musteris_");
        }
    }
}
