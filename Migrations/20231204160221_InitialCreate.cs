using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace taxex_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "m_country",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kd_country = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_harbour",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_country = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_harbour", x => x.id);
                    table.ForeignKey(
                        name: "FK_m_harbour_m_country_id_country",
                        column: x => x.id_country,
                        principalTable: "m_country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "m_country",
                columns: new[] { "id", "kd_country", "name" },
                values: new object[,]
                {
                    { 1, "ID", "Indonesia" },
                    { 2, "SG", "Singapore" },
                    { 3, "IR", "Iraq" },
                    { 4, "MY", "Malaysia" },
                    { 5, "PH", "Philippines" }
                });

            migrationBuilder.InsertData(
                table: "m_harbour",
                columns: new[] { "id", "id_country", "name" },
                values: new object[,]
                {
                    { 111, 2, "Jurong" },
                    { 112, 2, "Marina" },
                    { 113, 2, "Keppel" },
                    { 114, 1, "Merak" },
                    { 115, 1, "Batam" },
                    { 116, 3, "Klang" },
                    { 117, 4, "Flous" },
                    { 118, 5, "Rafles" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_m_harbour_id_country",
                table: "m_harbour",
                column: "id_country");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "m_harbour");

            migrationBuilder.DropTable(
                name: "m_country");
        }
    }
}
