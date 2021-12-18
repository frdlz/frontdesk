using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Frontdesk6.Migrations
{
    public partial class rererere : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Jabatan",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NIP",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Penempatan",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LayananFrontdesk",
                columns: table => new
                {
                    LayananFrontdeskID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaLayanan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LayananFrontdesk", x => x.LayananFrontdeskID);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    AppointmentID = table.Column<string>(nullable: false),
                    Nama = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NomorApp = table.Column<string>(nullable: true),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    Deskripsi = table.Column<string>(nullable: true),
                    Tujuan = table.Column<string>(nullable: true),
                    NamaLayanan = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ProcessDate = table.Column<DateTime>(nullable: false),
                    StatusFrontdesk = table.Column<int>(nullable: false),
                    LayananFrontdeskID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.AppointmentID);
                    table.ForeignKey(
                        name: "FK_Appointment_LayananFrontdesk_LayananFrontdeskID",
                        column: x => x.LayananFrontdeskID,
                        principalTable: "LayananFrontdesk",
                        principalColumn: "LayananFrontdeskID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_LayananFrontdeskID",
                table: "Appointment",
                column: "LayananFrontdeskID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "LayananFrontdesk");

            migrationBuilder.DropColumn(
                name: "Jabatan",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NIP",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Penempatan",
                table: "AspNetUsers");
        }
    }
}
