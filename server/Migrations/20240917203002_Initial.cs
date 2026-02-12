using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CentroCategoria",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroCategoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CentroClasse",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroClasse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CentroDiretoria",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroDiretoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CentroEmpresa",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codigo = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    NomeReal = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroEmpresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CentroStatus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    BgColor = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComboSeparador",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Icone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboSeparador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContaContabilClassificacao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Codigo = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaContabilClassificacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContaContabilFormula",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Formula = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaContabilFormula", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContaContabilPrestadores",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaContabilPrestadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercicio",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ano = table.Column<string>(type: "TEXT", nullable: false),
                    Aberto = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioCargo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioCargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioContratacao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioContratacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeCentroCusto",
                columns: table => new
                {
                    IdCentro = table.Column<long>(type: "INTEGER", nullable: true),
                    IdExercicio = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroCodigo = table.Column<string>(type: "TEXT", nullable: true),
                    CentroNome = table.Column<string>(type: "TEXT", nullable: true),
                    Usuario = table.Column<string>(type: "TEXT", nullable: true),
                    NivelAtual = table.Column<int>(type: "INTEGER", nullable: true),
                    NivelTotal = table.Column<int>(type: "INTEGER", nullable: true),
                    Situacao = table.Column<string>(type: "TEXT", nullable: true),
                    SituacaoBgColor = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "HomeCentroLucro",
                columns: table => new
                {
                    IdCentro = table.Column<long>(type: "INTEGER", nullable: true),
                    IdExercicio = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroCodigo = table.Column<string>(type: "TEXT", nullable: true),
                    CentroNome = table.Column<string>(type: "TEXT", nullable: true),
                    Usuario = table.Column<string>(type: "TEXT", nullable: true),
                    NivelAtual = table.Column<int>(type: "INTEGER", nullable: true),
                    NivelTotal = table.Column<int>(type: "INTEGER", nullable: true),
                    Situacao = table.Column<string>(type: "TEXT", nullable: true),
                    SituacaoBgColor = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "LancamentoTipo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Codigo = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancamentoTipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mercado",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parametro",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Valor = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CentroFilial",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codigo = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    IdEmpresa = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroFilial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CentroFilial_CentroEmpresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "CentroEmpresa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContaContabil",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdContaContabilFormula = table.Column<long>(type: "INTEGER", nullable: true),
                    IdContaContabilClassificacao = table.Column<long>(type: "INTEGER", nullable: true),
                    Codigo = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Limite = table.Column<string>(type: "TEXT", nullable: false),
                    Visualizar = table.Column<bool>(type: "INTEGER", nullable: true),
                    NaoAceitaCalculo = table.Column<bool>(type: "INTEGER", nullable: true),
                    ExigeJustificativa = table.Column<bool>(type: "INTEGER", nullable: true),
                    Help = table.Column<string>(type: "TEXT", nullable: true),
                    Digito = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaContabil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContaContabil_ContaContabilClassificacao_IdContaContabilClassificacao",
                        column: x => x.IdContaContabilClassificacao,
                        principalTable: "ContaContabilClassificacao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContaContabil_ContaContabilFormula_IdContaContabilFormula",
                        column: x => x.IdContaContabilFormula,
                        principalTable: "ContaContabilFormula",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CentroLucro",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdCentroClasse = table.Column<long>(type: "INTEGER", nullable: true),
                    IdCentroEmpresa = table.Column<long>(type: "INTEGER", nullable: true),
                    IdCentroFilial = table.Column<long>(type: "INTEGER", nullable: true),
                    IdCentroDiretoria = table.Column<long>(type: "INTEGER", nullable: true),
                    IdCentroCategoria = table.Column<long>(type: "INTEGER", nullable: true),
                    Codigo = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Imposto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Pdd = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Bloqueado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroLucro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CentroLucro_CentroCategoria_IdCentroCategoria",
                        column: x => x.IdCentroCategoria,
                        principalTable: "CentroCategoria",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroLucro_CentroClasse_IdCentroClasse",
                        column: x => x.IdCentroClasse,
                        principalTable: "CentroClasse",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroLucro_CentroDiretoria_IdCentroDiretoria",
                        column: x => x.IdCentroDiretoria,
                        principalTable: "CentroDiretoria",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroLucro_CentroEmpresa_IdCentroEmpresa",
                        column: x => x.IdCentroEmpresa,
                        principalTable: "CentroEmpresa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroLucro_CentroFilial_IdCentroFilial",
                        column: x => x.IdCentroFilial,
                        principalTable: "CentroFilial",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdMercado = table.Column<long>(type: "INTEGER", nullable: true),
                    IdCentroFilial = table.Column<long>(type: "INTEGER", nullable: true),
                    Codigo = table.Column<string>(type: "TEXT", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Linha = table.Column<string>(type: "TEXT", nullable: true),
                    Custo = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_CentroFilial_IdCentroFilial",
                        column: x => x.IdCentroFilial,
                        principalTable: "CentroFilial",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Produto_Mercado_IdMercado",
                        column: x => x.IdMercado,
                        principalTable: "Mercado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CentroCusto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdCentroClasse = table.Column<long>(type: "INTEGER", nullable: true),
                    IdCentroEmpresa = table.Column<long>(type: "INTEGER", nullable: true),
                    IdCentroFilial = table.Column<long>(type: "INTEGER", nullable: true),
                    IdCentroDiretoria = table.Column<long>(type: "INTEGER", nullable: true),
                    IdCentroCategoria = table.Column<long>(type: "INTEGER", nullable: true),
                    IdCentroLucro = table.Column<long>(type: "INTEGER", nullable: true),
                    Codigo = table.Column<string>(type: "TEXT", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Bloqueado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroCusto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CentroCusto_CentroCategoria_IdCentroCategoria",
                        column: x => x.IdCentroCategoria,
                        principalTable: "CentroCategoria",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroCusto_CentroClasse_IdCentroClasse",
                        column: x => x.IdCentroClasse,
                        principalTable: "CentroClasse",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroCusto_CentroDiretoria_IdCentroDiretoria",
                        column: x => x.IdCentroDiretoria,
                        principalTable: "CentroDiretoria",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroCusto_CentroEmpresa_IdCentroEmpresa",
                        column: x => x.IdCentroEmpresa,
                        principalTable: "CentroEmpresa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroCusto_CentroFilial_IdCentroFilial",
                        column: x => x.IdCentroFilial,
                        principalTable: "CentroFilial",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroCusto_CentroLucro_IdCentroLucro",
                        column: x => x.IdCentroLucro,
                        principalTable: "CentroLucro",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CentroLucroUsuario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdCentroLucro = table.Column<long>(type: "INTEGER", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Nivel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroLucroUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CentroLucroUsuario_CentroLucro_IdCentroLucro",
                        column: x => x.IdCentroLucro,
                        principalTable: "CentroLucro",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CentroCustoLancamento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdLancamentoTipo = table.Column<long>(type: "INTEGER", nullable: true),
                    IdCentroCusto = table.Column<long>(type: "INTEGER", nullable: true),
                    IdContaContabil = table.Column<long>(type: "INTEGER", nullable: true),
                    IdExercicio = table.Column<long>(type: "INTEGER", nullable: true),
                    ValoresJaneiro = table.Column<long>(type: "INTEGER", nullable: true),
                    ValoresFevereiro = table.Column<long>(type: "INTEGER", nullable: true),
                    ValoresMarco = table.Column<long>(type: "INTEGER", nullable: true),
                    ValoresAbril = table.Column<long>(type: "INTEGER", nullable: true),
                    ValoresMaio = table.Column<long>(type: "INTEGER", nullable: true),
                    ValoresJunho = table.Column<long>(type: "INTEGER", nullable: true),
                    ValoresJulho = table.Column<long>(type: "INTEGER", nullable: true),
                    ValoresAgosto = table.Column<long>(type: "INTEGER", nullable: true),
                    ValoresSetembro = table.Column<long>(type: "INTEGER", nullable: true),
                    ValoresOutubro = table.Column<long>(type: "INTEGER", nullable: true),
                    ValoresNovembro = table.Column<long>(type: "INTEGER", nullable: true),
                    ValoresDezembro = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroCustoLancamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CentroCustoLancamento_CentroCusto_IdCentroCusto",
                        column: x => x.IdCentroCusto,
                        principalTable: "CentroCusto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroCustoLancamento_ContaContabil_IdContaContabil",
                        column: x => x.IdContaContabil,
                        principalTable: "ContaContabil",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroCustoLancamento_Exercicio_IdExercicio",
                        column: x => x.IdExercicio,
                        principalTable: "Exercicio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroCustoLancamento_LancamentoTipo_IdLancamentoTipo",
                        column: x => x.IdLancamentoTipo,
                        principalTable: "LancamentoTipo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CentroCustoUsuario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdCentroCusto = table.Column<long>(type: "INTEGER", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Nivel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroCustoUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CentroCustoUsuario_CentroCusto_IdCentroCusto",
                        column: x => x.IdCentroCusto,
                        principalTable: "CentroCusto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComboInformacoes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    IdCentroCusto = table.Column<long>(type: "INTEGER", nullable: true),
                    IdComboInformacoesSeparacao = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboInformacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComboInformacoes_CentroCusto_IdCentroCusto",
                        column: x => x.IdCentroCusto,
                        principalTable: "CentroCusto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboInformacoes_ComboSeparador_IdComboInformacoesSeparacao",
                        column: x => x.IdComboInformacoesSeparacao,
                        principalTable: "ComboSeparador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdCentroCusto = table.Column<long>(type: "INTEGER", nullable: true),
                    IdFuncionarioContratacao = table.Column<long>(type: "INTEGER", nullable: true),
                    IdFuncionarioCargo = table.Column<long>(type: "INTEGER", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    PlanoSaudeValor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Periculosidade = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionario_CentroCusto_IdCentroCusto",
                        column: x => x.IdCentroCusto,
                        principalTable: "CentroCusto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Funcionario_FuncionarioCargo_IdFuncionarioCargo",
                        column: x => x.IdFuncionarioCargo,
                        principalTable: "FuncionarioCargo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Funcionario_FuncionarioContratacao_IdFuncionarioContratacao",
                        column: x => x.IdFuncionarioContratacao,
                        principalTable: "FuncionarioContratacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CentroLucroSituacao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdExercicio = table.Column<long>(type: "INTEGER", nullable: true),
                    IdCentroLucro = table.Column<long>(type: "INTEGER", nullable: true),
                    IdCentroStatus = table.Column<long>(type: "INTEGER", nullable: true),
                    IdCentroLucroUsuario = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroLucroSituacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CentroLucroSituacao_CentroLucroUsuario_IdCentroLucroUsuario",
                        column: x => x.IdCentroLucroUsuario,
                        principalTable: "CentroLucroUsuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroLucroSituacao_CentroLucro_IdCentroLucro",
                        column: x => x.IdCentroLucro,
                        principalTable: "CentroLucro",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroLucroSituacao_CentroStatus_IdCentroStatus",
                        column: x => x.IdCentroStatus,
                        principalTable: "CentroStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroLucroSituacao_Exercicio_IdExercicio",
                        column: x => x.IdExercicio,
                        principalTable: "Exercicio",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CentroCustoSituacao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdExercicio = table.Column<long>(type: "INTEGER", nullable: true),
                    IdCentroCusto = table.Column<long>(type: "INTEGER", nullable: true),
                    Janeiro = table.Column<long>(type: "INTEGER", nullable: true),
                    Fevereiro = table.Column<long>(type: "INTEGER", nullable: true),
                    Marco = table.Column<long>(type: "INTEGER", nullable: true),
                    Abril = table.Column<long>(type: "INTEGER", nullable: true),
                    Maio = table.Column<long>(type: "INTEGER", nullable: true),
                    Junho = table.Column<long>(type: "INTEGER", nullable: true),
                    Julho = table.Column<long>(type: "INTEGER", nullable: true),
                    Agosto = table.Column<long>(type: "INTEGER", nullable: true),
                    Setembro = table.Column<long>(type: "INTEGER", nullable: true),
                    Outubro = table.Column<long>(type: "INTEGER", nullable: true),
                    Novembro = table.Column<long>(type: "INTEGER", nullable: true),
                    Dezembro = table.Column<long>(type: "INTEGER", nullable: true),
                    IdCentroStatus = table.Column<long>(type: "INTEGER", nullable: true),
                    IdCentroCustoUsuario = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroCustoSituacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CentroCustoSituacao_CentroCustoUsuario_IdCentroCustoUsuario",
                        column: x => x.IdCentroCustoUsuario,
                        principalTable: "CentroCustoUsuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroCustoSituacao_CentroCusto_IdCentroCusto",
                        column: x => x.IdCentroCusto,
                        principalTable: "CentroCusto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroCustoSituacao_CentroStatus_IdCentroStatus",
                        column: x => x.IdCentroStatus,
                        principalTable: "CentroStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroCustoSituacao_Exercicio_IdExercicio",
                        column: x => x.IdExercicio,
                        principalTable: "Exercicio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroCustoSituacao_LancamentoTipo_Abril",
                        column: x => x.Abril,
                        principalTable: "LancamentoTipo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroCustoSituacao_LancamentoTipo_Agosto",
                        column: x => x.Agosto,
                        principalTable: "LancamentoTipo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroCustoSituacao_LancamentoTipo_Dezembro",
                        column: x => x.Dezembro,
                        principalTable: "LancamentoTipo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroCustoSituacao_LancamentoTipo_Fevereiro",
                        column: x => x.Fevereiro,
                        principalTable: "LancamentoTipo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroCustoSituacao_LancamentoTipo_Janeiro",
                        column: x => x.Janeiro,
                        principalTable: "LancamentoTipo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroCustoSituacao_LancamentoTipo_Julho",
                        column: x => x.Julho,
                        principalTable: "LancamentoTipo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroCustoSituacao_LancamentoTipo_Junho",
                        column: x => x.Junho,
                        principalTable: "LancamentoTipo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroCustoSituacao_LancamentoTipo_Maio",
                        column: x => x.Maio,
                        principalTable: "LancamentoTipo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroCustoSituacao_LancamentoTipo_Marco",
                        column: x => x.Marco,
                        principalTable: "LancamentoTipo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroCustoSituacao_LancamentoTipo_Novembro",
                        column: x => x.Novembro,
                        principalTable: "LancamentoTipo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroCustoSituacao_LancamentoTipo_Outubro",
                        column: x => x.Outubro,
                        principalTable: "LancamentoTipo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CentroCustoSituacao_LancamentoTipo_Setembro",
                        column: x => x.Setembro,
                        principalTable: "LancamentoTipo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioDependente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdFuncionario = table.Column<long>(type: "INTEGER", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    PlanoSaudeValor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioDependente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuncionarioDependente_Funcionario_IdFuncionario",
                        column: x => x.IdFuncionario,
                        principalTable: "Funcionario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComboBox",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    CentroCustoId = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroCustoId1 = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroCustoId2 = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroCustoId3 = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroCustoId4 = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroCustoId5 = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroCustoLancamentoId = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroCustoLancamentoId1 = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroCustoLancamentoId2 = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroCustoLancamentoId3 = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroCustoSituacaoId = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroCustoSituacaoId1 = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroCustoSituacaoId2 = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroCustoSituacaoId3 = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroCustoSituacaoId4 = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroCustoUsuarioId = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroFilialId = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroLucroId = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroLucroId1 = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroLucroId2 = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroLucroId3 = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroLucroId4 = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroLucroSituacaoId = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroLucroSituacaoId1 = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroLucroSituacaoId2 = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroLucroSituacaoId3 = table.Column<long>(type: "INTEGER", nullable: true),
                    CentroLucroUsuarioId = table.Column<long>(type: "INTEGER", nullable: true),
                    ComboInformacoesId = table.Column<long>(type: "INTEGER", nullable: true),
                    ComboInformacoesId1 = table.Column<long>(type: "INTEGER", nullable: true),
                    ContaContabilId = table.Column<long>(type: "INTEGER", nullable: true),
                    ContaContabilId1 = table.Column<long>(type: "INTEGER", nullable: true),
                    ContaContabilId2 = table.Column<long>(type: "INTEGER", nullable: true),
                    FuncionarioDependenteId = table.Column<long>(type: "INTEGER", nullable: true),
                    FuncionarioId = table.Column<long>(type: "INTEGER", nullable: true),
                    FuncionarioId1 = table.Column<long>(type: "INTEGER", nullable: true),
                    FuncionarioId2 = table.Column<long>(type: "INTEGER", nullable: true),
                    ProdutoId = table.Column<long>(type: "INTEGER", nullable: true),
                    ProdutoId1 = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboBox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroCustoLancamento_CentroCustoLancamentoId",
                        column: x => x.CentroCustoLancamentoId,
                        principalTable: "CentroCustoLancamento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroCustoLancamento_CentroCustoLancamentoId1",
                        column: x => x.CentroCustoLancamentoId1,
                        principalTable: "CentroCustoLancamento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroCustoLancamento_CentroCustoLancamentoId2",
                        column: x => x.CentroCustoLancamentoId2,
                        principalTable: "CentroCustoLancamento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroCustoLancamento_CentroCustoLancamentoId3",
                        column: x => x.CentroCustoLancamentoId3,
                        principalTable: "CentroCustoLancamento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroCustoSituacao_CentroCustoSituacaoId",
                        column: x => x.CentroCustoSituacaoId,
                        principalTable: "CentroCustoSituacao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroCustoSituacao_CentroCustoSituacaoId1",
                        column: x => x.CentroCustoSituacaoId1,
                        principalTable: "CentroCustoSituacao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroCustoSituacao_CentroCustoSituacaoId2",
                        column: x => x.CentroCustoSituacaoId2,
                        principalTable: "CentroCustoSituacao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroCustoSituacao_CentroCustoSituacaoId3",
                        column: x => x.CentroCustoSituacaoId3,
                        principalTable: "CentroCustoSituacao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroCustoSituacao_CentroCustoSituacaoId4",
                        column: x => x.CentroCustoSituacaoId4,
                        principalTable: "CentroCustoSituacao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroCustoUsuario_CentroCustoUsuarioId",
                        column: x => x.CentroCustoUsuarioId,
                        principalTable: "CentroCustoUsuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroCusto_CentroCustoId",
                        column: x => x.CentroCustoId,
                        principalTable: "CentroCusto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroCusto_CentroCustoId1",
                        column: x => x.CentroCustoId1,
                        principalTable: "CentroCusto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroCusto_CentroCustoId2",
                        column: x => x.CentroCustoId2,
                        principalTable: "CentroCusto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroCusto_CentroCustoId3",
                        column: x => x.CentroCustoId3,
                        principalTable: "CentroCusto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroCusto_CentroCustoId4",
                        column: x => x.CentroCustoId4,
                        principalTable: "CentroCusto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroCusto_CentroCustoId5",
                        column: x => x.CentroCustoId5,
                        principalTable: "CentroCusto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroFilial_CentroFilialId",
                        column: x => x.CentroFilialId,
                        principalTable: "CentroFilial",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroLucroSituacao_CentroLucroSituacaoId",
                        column: x => x.CentroLucroSituacaoId,
                        principalTable: "CentroLucroSituacao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroLucroSituacao_CentroLucroSituacaoId1",
                        column: x => x.CentroLucroSituacaoId1,
                        principalTable: "CentroLucroSituacao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroLucroSituacao_CentroLucroSituacaoId2",
                        column: x => x.CentroLucroSituacaoId2,
                        principalTable: "CentroLucroSituacao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroLucroSituacao_CentroLucroSituacaoId3",
                        column: x => x.CentroLucroSituacaoId3,
                        principalTable: "CentroLucroSituacao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroLucroUsuario_CentroLucroUsuarioId",
                        column: x => x.CentroLucroUsuarioId,
                        principalTable: "CentroLucroUsuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroLucro_CentroLucroId",
                        column: x => x.CentroLucroId,
                        principalTable: "CentroLucro",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroLucro_CentroLucroId1",
                        column: x => x.CentroLucroId1,
                        principalTable: "CentroLucro",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroLucro_CentroLucroId2",
                        column: x => x.CentroLucroId2,
                        principalTable: "CentroLucro",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroLucro_CentroLucroId3",
                        column: x => x.CentroLucroId3,
                        principalTable: "CentroLucro",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_CentroLucro_CentroLucroId4",
                        column: x => x.CentroLucroId4,
                        principalTable: "CentroLucro",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_ComboInformacoes_ComboInformacoesId",
                        column: x => x.ComboInformacoesId,
                        principalTable: "ComboInformacoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_ComboInformacoes_ComboInformacoesId1",
                        column: x => x.ComboInformacoesId1,
                        principalTable: "ComboInformacoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_ContaContabil_ContaContabilId",
                        column: x => x.ContaContabilId,
                        principalTable: "ContaContabil",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_ContaContabil_ContaContabilId1",
                        column: x => x.ContaContabilId1,
                        principalTable: "ContaContabil",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_ContaContabil_ContaContabilId2",
                        column: x => x.ContaContabilId2,
                        principalTable: "ContaContabil",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_FuncionarioDependente_FuncionarioDependenteId",
                        column: x => x.FuncionarioDependenteId,
                        principalTable: "FuncionarioDependente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_Funcionario_FuncionarioId1",
                        column: x => x.FuncionarioId1,
                        principalTable: "Funcionario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_Funcionario_FuncionarioId2",
                        column: x => x.FuncionarioId2,
                        principalTable: "Funcionario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComboBox_Produto_ProdutoId1",
                        column: x => x.ProdutoId1,
                        principalTable: "Produto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CentroCusto_IdCentroCategoria",
                table: "CentroCusto",
                column: "IdCentroCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCusto_IdCentroClasse",
                table: "CentroCusto",
                column: "IdCentroClasse");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCusto_IdCentroDiretoria",
                table: "CentroCusto",
                column: "IdCentroDiretoria");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCusto_IdCentroEmpresa",
                table: "CentroCusto",
                column: "IdCentroEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCusto_IdCentroFilial",
                table: "CentroCusto",
                column: "IdCentroFilial");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCusto_IdCentroLucro",
                table: "CentroCusto",
                column: "IdCentroLucro");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCustoLancamento_IdCentroCusto",
                table: "CentroCustoLancamento",
                column: "IdCentroCusto");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCustoLancamento_IdContaContabil",
                table: "CentroCustoLancamento",
                column: "IdContaContabil");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCustoLancamento_IdExercicio",
                table: "CentroCustoLancamento",
                column: "IdExercicio");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCustoLancamento_IdLancamentoTipo",
                table: "CentroCustoLancamento",
                column: "IdLancamentoTipo");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCustoSituacao_Abril",
                table: "CentroCustoSituacao",
                column: "Abril");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCustoSituacao_Agosto",
                table: "CentroCustoSituacao",
                column: "Agosto");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCustoSituacao_Dezembro",
                table: "CentroCustoSituacao",
                column: "Dezembro");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCustoSituacao_Fevereiro",
                table: "CentroCustoSituacao",
                column: "Fevereiro");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCustoSituacao_IdCentroCusto",
                table: "CentroCustoSituacao",
                column: "IdCentroCusto");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCustoSituacao_IdCentroCustoUsuario",
                table: "CentroCustoSituacao",
                column: "IdCentroCustoUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCustoSituacao_IdCentroStatus",
                table: "CentroCustoSituacao",
                column: "IdCentroStatus");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCustoSituacao_IdExercicio",
                table: "CentroCustoSituacao",
                column: "IdExercicio");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCustoSituacao_Janeiro",
                table: "CentroCustoSituacao",
                column: "Janeiro");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCustoSituacao_Julho",
                table: "CentroCustoSituacao",
                column: "Julho");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCustoSituacao_Junho",
                table: "CentroCustoSituacao",
                column: "Junho");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCustoSituacao_Maio",
                table: "CentroCustoSituacao",
                column: "Maio");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCustoSituacao_Marco",
                table: "CentroCustoSituacao",
                column: "Marco");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCustoSituacao_Novembro",
                table: "CentroCustoSituacao",
                column: "Novembro");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCustoSituacao_Outubro",
                table: "CentroCustoSituacao",
                column: "Outubro");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCustoSituacao_Setembro",
                table: "CentroCustoSituacao",
                column: "Setembro");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCustoUsuario_IdCentroCusto",
                table: "CentroCustoUsuario",
                column: "IdCentroCusto");

            migrationBuilder.CreateIndex(
                name: "IX_CentroFilial_IdEmpresa",
                table: "CentroFilial",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_CentroLucro_IdCentroCategoria",
                table: "CentroLucro",
                column: "IdCentroCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_CentroLucro_IdCentroClasse",
                table: "CentroLucro",
                column: "IdCentroClasse");

            migrationBuilder.CreateIndex(
                name: "IX_CentroLucro_IdCentroDiretoria",
                table: "CentroLucro",
                column: "IdCentroDiretoria");

            migrationBuilder.CreateIndex(
                name: "IX_CentroLucro_IdCentroEmpresa",
                table: "CentroLucro",
                column: "IdCentroEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_CentroLucro_IdCentroFilial",
                table: "CentroLucro",
                column: "IdCentroFilial");

            migrationBuilder.CreateIndex(
                name: "IX_CentroLucroSituacao_IdCentroLucro",
                table: "CentroLucroSituacao",
                column: "IdCentroLucro");

            migrationBuilder.CreateIndex(
                name: "IX_CentroLucroSituacao_IdCentroLucroUsuario",
                table: "CentroLucroSituacao",
                column: "IdCentroLucroUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_CentroLucroSituacao_IdCentroStatus",
                table: "CentroLucroSituacao",
                column: "IdCentroStatus");

            migrationBuilder.CreateIndex(
                name: "IX_CentroLucroSituacao_IdExercicio",
                table: "CentroLucroSituacao",
                column: "IdExercicio");

            migrationBuilder.CreateIndex(
                name: "IX_CentroLucroUsuario_IdCentroLucro",
                table: "CentroLucroUsuario",
                column: "IdCentroLucro");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroCustoId",
                table: "ComboBox",
                column: "CentroCustoId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroCustoId1",
                table: "ComboBox",
                column: "CentroCustoId1");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroCustoId2",
                table: "ComboBox",
                column: "CentroCustoId2");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroCustoId3",
                table: "ComboBox",
                column: "CentroCustoId3");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroCustoId4",
                table: "ComboBox",
                column: "CentroCustoId4");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroCustoId5",
                table: "ComboBox",
                column: "CentroCustoId5");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroCustoLancamentoId",
                table: "ComboBox",
                column: "CentroCustoLancamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroCustoLancamentoId1",
                table: "ComboBox",
                column: "CentroCustoLancamentoId1");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroCustoLancamentoId2",
                table: "ComboBox",
                column: "CentroCustoLancamentoId2");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroCustoLancamentoId3",
                table: "ComboBox",
                column: "CentroCustoLancamentoId3");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroCustoSituacaoId",
                table: "ComboBox",
                column: "CentroCustoSituacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroCustoSituacaoId1",
                table: "ComboBox",
                column: "CentroCustoSituacaoId1");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroCustoSituacaoId2",
                table: "ComboBox",
                column: "CentroCustoSituacaoId2");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroCustoSituacaoId3",
                table: "ComboBox",
                column: "CentroCustoSituacaoId3");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroCustoSituacaoId4",
                table: "ComboBox",
                column: "CentroCustoSituacaoId4");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroCustoUsuarioId",
                table: "ComboBox",
                column: "CentroCustoUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroFilialId",
                table: "ComboBox",
                column: "CentroFilialId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroLucroId",
                table: "ComboBox",
                column: "CentroLucroId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroLucroId1",
                table: "ComboBox",
                column: "CentroLucroId1");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroLucroId2",
                table: "ComboBox",
                column: "CentroLucroId2");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroLucroId3",
                table: "ComboBox",
                column: "CentroLucroId3");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroLucroId4",
                table: "ComboBox",
                column: "CentroLucroId4");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroLucroSituacaoId",
                table: "ComboBox",
                column: "CentroLucroSituacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroLucroSituacaoId1",
                table: "ComboBox",
                column: "CentroLucroSituacaoId1");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroLucroSituacaoId2",
                table: "ComboBox",
                column: "CentroLucroSituacaoId2");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroLucroSituacaoId3",
                table: "ComboBox",
                column: "CentroLucroSituacaoId3");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_CentroLucroUsuarioId",
                table: "ComboBox",
                column: "CentroLucroUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_ComboInformacoesId",
                table: "ComboBox",
                column: "ComboInformacoesId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_ComboInformacoesId1",
                table: "ComboBox",
                column: "ComboInformacoesId1");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_ContaContabilId",
                table: "ComboBox",
                column: "ContaContabilId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_ContaContabilId1",
                table: "ComboBox",
                column: "ContaContabilId1");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_ContaContabilId2",
                table: "ComboBox",
                column: "ContaContabilId2");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_FuncionarioDependenteId",
                table: "ComboBox",
                column: "FuncionarioDependenteId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_FuncionarioId",
                table: "ComboBox",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_FuncionarioId1",
                table: "ComboBox",
                column: "FuncionarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_FuncionarioId2",
                table: "ComboBox",
                column: "FuncionarioId2");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_ProdutoId",
                table: "ComboBox",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboBox_ProdutoId1",
                table: "ComboBox",
                column: "ProdutoId1");

            migrationBuilder.CreateIndex(
                name: "IX_ComboInformacoes_IdCentroCusto",
                table: "ComboInformacoes",
                column: "IdCentroCusto");

            migrationBuilder.CreateIndex(
                name: "IX_ComboInformacoes_IdComboInformacoesSeparacao",
                table: "ComboInformacoes",
                column: "IdComboInformacoesSeparacao");

            migrationBuilder.CreateIndex(
                name: "IX_ContaContabil_IdContaContabilClassificacao",
                table: "ContaContabil",
                column: "IdContaContabilClassificacao");

            migrationBuilder.CreateIndex(
                name: "IX_ContaContabil_IdContaContabilFormula",
                table: "ContaContabil",
                column: "IdContaContabilFormula");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_IdCentroCusto",
                table: "Funcionario",
                column: "IdCentroCusto");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_IdFuncionarioCargo",
                table: "Funcionario",
                column: "IdFuncionarioCargo");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_IdFuncionarioContratacao",
                table: "Funcionario",
                column: "IdFuncionarioContratacao");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioDependente_IdFuncionario",
                table: "FuncionarioDependente",
                column: "IdFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_IdCentroFilial",
                table: "Produto",
                column: "IdCentroFilial");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_IdMercado",
                table: "Produto",
                column: "IdMercado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComboBox");

            migrationBuilder.DropTable(
                name: "ContaContabilPrestadores");

            migrationBuilder.DropTable(
                name: "HomeCentroCusto");

            migrationBuilder.DropTable(
                name: "HomeCentroLucro");

            migrationBuilder.DropTable(
                name: "Parametro");

            migrationBuilder.DropTable(
                name: "CentroCustoLancamento");

            migrationBuilder.DropTable(
                name: "CentroCustoSituacao");

            migrationBuilder.DropTable(
                name: "CentroLucroSituacao");

            migrationBuilder.DropTable(
                name: "ComboInformacoes");

            migrationBuilder.DropTable(
                name: "FuncionarioDependente");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "ContaContabil");

            migrationBuilder.DropTable(
                name: "CentroCustoUsuario");

            migrationBuilder.DropTable(
                name: "LancamentoTipo");

            migrationBuilder.DropTable(
                name: "CentroLucroUsuario");

            migrationBuilder.DropTable(
                name: "CentroStatus");

            migrationBuilder.DropTable(
                name: "Exercicio");

            migrationBuilder.DropTable(
                name: "ComboSeparador");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Mercado");

            migrationBuilder.DropTable(
                name: "ContaContabilClassificacao");

            migrationBuilder.DropTable(
                name: "ContaContabilFormula");

            migrationBuilder.DropTable(
                name: "CentroCusto");

            migrationBuilder.DropTable(
                name: "FuncionarioCargo");

            migrationBuilder.DropTable(
                name: "FuncionarioContratacao");

            migrationBuilder.DropTable(
                name: "CentroLucro");

            migrationBuilder.DropTable(
                name: "CentroCategoria");

            migrationBuilder.DropTable(
                name: "CentroClasse");

            migrationBuilder.DropTable(
                name: "CentroDiretoria");

            migrationBuilder.DropTable(
                name: "CentroFilial");

            migrationBuilder.DropTable(
                name: "CentroEmpresa");
        }
    }
}
