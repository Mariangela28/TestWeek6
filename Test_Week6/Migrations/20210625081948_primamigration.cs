using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_Week6.Migrations
{
    public partial class primamigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    CF = table.Column<string>(type: "nchar(16)", fixedLength: true, maxLength: 16, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.CF);
                });

            migrationBuilder.CreateTable(
                name: "Car Policy",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateStipulates = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuredAmmount = table.Column<float>(type: "real", nullable: false),
                    MonthlyInstallment = table.Column<float>(type: "real", nullable: false),
                    ClientCF = table.Column<string>(type: "nchar(16)", nullable: true),
                    CarPolicy_type = table.Column<int>(type: "int", nullable: false),
                    YearsInsured = table.Column<int>(type: "int", nullable: true),
                    Plate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Piston = table.Column<int>(type: "int", nullable: true),
                    PercentageCovered = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car Policy", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Car Policy_Client_ClientCF",
                        column: x => x.ClientCF,
                        principalTable: "Client",
                        principalColumn: "CF",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car Policy_ClientCF",
                table: "Car Policy",
                column: "ClientCF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car Policy");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
