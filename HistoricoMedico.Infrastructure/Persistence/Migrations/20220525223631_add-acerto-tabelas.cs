using Microsoft.EntityFrameworkCore.Migrations;

namespace HistoricoMedico.Infrastructure.Persistence.Migrations
{
    public partial class addacertotabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosClinicos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DadosClinicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alergia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Altura = table.Column<float>(type: "real", nullable: false),
                    Doenca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Medicacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    TipoSanguineo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosClinicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DadosClinicos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DadosClinicos_IdUsuario",
                table: "DadosClinicos",
                column: "IdUsuario",
                unique: true);
        }
    }
}
