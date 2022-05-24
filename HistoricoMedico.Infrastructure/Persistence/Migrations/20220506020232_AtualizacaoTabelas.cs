using Microsoft.EntityFrameworkCore.Migrations;

namespace HistoricoMedico.Infrastructure.Persistence.Migrations
{
    public partial class AtualizacaoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dependente_Usuarios_UsuarioId",
                table: "Dependente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dependente",
                table: "Dependente");

            migrationBuilder.DropIndex(
                name: "IX_Dependente_UsuarioId",
                table: "Dependente");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Dependente");

            migrationBuilder.RenameTable(
                name: "Dependente",
                newName: "Dependentes");

            migrationBuilder.AddColumn<int>(
                name: "DadosClinicoId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Medicos",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dependentes",
                table: "Dependentes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DadosClinico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoSanguineo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Altura = table.Column<float>(type: "real", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    Doenca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alergia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medicacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosClinico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DadosClinicoId",
                table: "Usuarios",
                column: "DadosClinicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EnderecoId",
                table: "Usuarios",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_EnderecoId",
                table: "Medicos",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependentes_IdUsuario",
                table: "Dependentes",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Dependentes_Usuarios_IdUsuario",
                table: "Dependentes",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicos_Endereco_EnderecoId",
                table: "Medicos",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_DadosClinico_DadosClinicoId",
                table: "Usuarios",
                column: "DadosClinicoId",
                principalTable: "DadosClinico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Endereco_EnderecoId",
                table: "Usuarios",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dependentes_Usuarios_IdUsuario",
                table: "Dependentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicos_Endereco_EnderecoId",
                table: "Medicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_DadosClinico_DadosClinicoId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Endereco_EnderecoId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "DadosClinico");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_DadosClinicoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_EnderecoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Medicos_EnderecoId",
                table: "Medicos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dependentes",
                table: "Dependentes");

            migrationBuilder.DropIndex(
                name: "IX_Dependentes_IdUsuario",
                table: "Dependentes");

            migrationBuilder.DropColumn(
                name: "DadosClinicoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Medicos");

            migrationBuilder.RenameTable(
                name: "Dependentes",
                newName: "Dependente");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Dependente",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dependente",
                table: "Dependente",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Dependente_UsuarioId",
                table: "Dependente",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dependente_Usuarios_UsuarioId",
                table: "Dependente",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
