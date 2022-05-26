using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HistoricoMedico.Infrastructure.Persistence.Migrations
{
    public partial class DadosClinicoMedicoEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_DadosClinico_DadosClinicoId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Endereco_EnderecoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_DadosClinicoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_EnderecoId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DadosClinico",
                table: "DadosClinico");

            migrationBuilder.DropColumn(
                name: "DadosClinicoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "DadosClinico",
                newName: "DadosClinicos");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "DadosClinicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DadosClinicos",
                table: "DadosClinicos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DadosClinicos_IdUsuario",
                table: "DadosClinicos",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DadosClinicos_Usuarios_IdUsuario",
                table: "DadosClinicos",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DadosClinicos_Usuarios_IdUsuario",
                table: "DadosClinicos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DadosClinicos",
                table: "DadosClinicos");

            migrationBuilder.DropIndex(
                name: "IX_DadosClinicos_IdUsuario",
                table: "DadosClinicos");

            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "DadosClinicos");

            migrationBuilder.RenameTable(
                name: "DadosClinicos",
                newName: "DadosClinico");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_DadosClinico",
                table: "DadosClinico",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DadosClinicoId",
                table: "Usuarios",
                column: "DadosClinicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EnderecoId",
                table: "Usuarios",
                column: "EnderecoId");

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
    }
}
