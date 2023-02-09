using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFuncionario.Data.Migrations
{
    public partial class sistema01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Empresa",
                table: "ValeRefeicao");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "ValeRefeicao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.EmpresaId);
                });

            migrationBuilder.CreateTable(
                name: "Situacao",
                columns: table => new
                {
                    SituacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situacao", x => x.SituacaoId);
                });

            migrationBuilder.CreateTable(
                name: "ValeTransporte",
                columns: table => new
                {
                    ValeTransporteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Qtde = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValeTransporte", x => x.ValeTransporteId);
                    table.ForeignKey(
                        name: "FK_ValeTransporte_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ValeTransporte_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Frequencia",
                columns: table => new
                {
                    FrequenciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    SituacaoId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequencia", x => x.FrequenciaId);
                    table.ForeignKey(
                        name: "FK_Frequencia_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Frequencia_Situacao_SituacaoId",
                        column: x => x.SituacaoId,
                        principalTable: "Situacao",
                        principalColumn: "SituacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ValeRefeicao_EmpresaId",
                table: "ValeRefeicao",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Frequencia_FuncionarioId",
                table: "Frequencia",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Frequencia_SituacaoId",
                table: "Frequencia",
                column: "SituacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ValeTransporte_EmpresaId",
                table: "ValeTransporte",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_ValeTransporte_FuncionarioId",
                table: "ValeTransporte",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ValeRefeicao_Empresa_EmpresaId",
                table: "ValeRefeicao",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "EmpresaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ValeRefeicao_Empresa_EmpresaId",
                table: "ValeRefeicao");

            migrationBuilder.DropTable(
                name: "Frequencia");

            migrationBuilder.DropTable(
                name: "ValeTransporte");

            migrationBuilder.DropTable(
                name: "Situacao");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropIndex(
                name: "IX_ValeRefeicao_EmpresaId",
                table: "ValeRefeicao");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "ValeRefeicao");

            migrationBuilder.AddColumn<string>(
                name: "Empresa",
                table: "ValeRefeicao",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
