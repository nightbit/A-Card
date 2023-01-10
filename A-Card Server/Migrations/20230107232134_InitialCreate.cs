using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace A_Card_Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    uuid = table.Column<string>(type: "varchar(255)", nullable: false),
                    name = table.Column<string>(type: "longtext", nullable: false),
                    species = table.Column<string>(type: "longtext", nullable: false),
                    birthday = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    chip = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    ssn = table.Column<string>(type: "varchar(255)", nullable: false),
                    firstname = table.Column<string>(type: "longtext", nullable: false),
                    lastname = table.Column<string>(type: "longtext", nullable: false),
                    email = table.Column<string>(type: "longtext", nullable: false),
                    phone = table.Column<string>(type: "longtext", nullable: false),
                    password = table.Column<string>(type: "longtext", nullable: false),
                    birthday = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    streetAndNumber = table.Column<string>(type: "longtext", nullable: false),
                    zip = table.Column<string>(type: "longtext", nullable: false),
                    city = table.Column<string>(type: "longtext", nullable: false),
                    country = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.ssn);
                });

            migrationBuilder.CreateTable(
                name: "AnimalOwner",
                columns: table => new
                {
                    Animalsuuid = table.Column<string>(type: "varchar(255)", nullable: false),
                    Ownersssn = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalOwner", x => new { x.Animalsuuid, x.Ownersssn });
                    table.ForeignKey(
                        name: "FK_AnimalOwner_Animals_Animalsuuid",
                        column: x => x.Animalsuuid,
                        principalTable: "Animals",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalOwner_Owners_Ownersssn",
                        column: x => x.Ownersssn,
                        principalTable: "Owners",
                        principalColumn: "ssn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalOwner_Ownersssn",
                table: "AnimalOwner",
                column: "Ownersssn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalOwner");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
