using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoCentroCusto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeCentroCusto");

            migrationBuilder.DropTable(
                name: "HomeCentroLucro");

            migrationBuilder.AddColumn<long>(
                name: "NivelTotal",
                table: "CentroCusto",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NivelTotal",
                table: "CentroCusto");

            migrationBuilder.CreateTable(
                name: "HomeCentroCusto",
                columns: table => new
                {
                    CentroCodigo = table.Column<string>(type: "TEXT", nullable: true),
                    CentroNome = table.Column<string>(type: "TEXT", nullable: true),
                    IdCentro = table.Column<long>(type: "INTEGER", nullable: true),
                    IdExercicio = table.Column<long>(type: "INTEGER", nullable: true),
                    NivelAtual = table.Column<int>(type: "INTEGER", nullable: true),
                    NivelTotal = table.Column<int>(type: "INTEGER", nullable: true),
                    Situacao = table.Column<string>(type: "TEXT", nullable: true),
                    SituacaoBgColor = table.Column<string>(type: "TEXT", nullable: true),
                    Usuario = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "HomeCentroLucro",
                columns: table => new
                {
                    CentroCodigo = table.Column<string>(type: "TEXT", nullable: true),
                    CentroNome = table.Column<string>(type: "TEXT", nullable: true),
                    IdCentro = table.Column<long>(type: "INTEGER", nullable: true),
                    IdExercicio = table.Column<long>(type: "INTEGER", nullable: true),
                    NivelAtual = table.Column<int>(type: "INTEGER", nullable: true),
                    NivelTotal = table.Column<int>(type: "INTEGER", nullable: true),
                    Situacao = table.Column<string>(type: "TEXT", nullable: true),
                    SituacaoBgColor = table.Column<string>(type: "TEXT", nullable: true),
                    Usuario = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                });
        }
    }
}
