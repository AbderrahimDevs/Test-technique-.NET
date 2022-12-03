using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_technique.Migrations
{
    public partial class InitialDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidatures",
                columns: table => new
                {
                    CondidatureID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NiveauEtude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbrAnneesExperience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DernierEmployeur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatures", x => x.CondidatureID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidatures");
        }
    }
}
