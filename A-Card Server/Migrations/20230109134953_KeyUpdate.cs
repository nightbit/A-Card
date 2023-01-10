using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace A_Card_Server.Migrations
{
    public partial class KeyUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalOwner");

            migrationBuilder.AddColumn<string>(
                name: "ownerssn",
                table: "Animals",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_ownerssn",
                table: "Animals",
                column: "ownerssn");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Owners_ownerssn",
                table: "Animals",
                column: "ownerssn",
                principalTable: "Owners",
                principalColumn: "ssn",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Owners_ownerssn",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_ownerssn",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "ownerssn",
                table: "Animals");

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
    }
}
