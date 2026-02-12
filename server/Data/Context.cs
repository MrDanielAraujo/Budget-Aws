using EntityFramework.Exceptions.SqlServer;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data;

public class Context : DbContext
{
      //public Context(DbContextOptions<Context> options) : base(options) { }
            
      public DbSet<Exercicio>? Exercicio { get; set; }
      public DbSet<LancamentoTipo>? LancamentoTipo { get; set; }
      public DbSet<ContaContabilClassificacao>? ContaContabilClassificacao{ get; set; }
      
      public DbSet<ContaContabilPrestadores>? ContaContabilPrestadores{ get; set; }
      public DbSet<ContaContabilFormula>? ContaContabilFormula{ get; set; }
      public DbSet<ContaContabil>? ContaContabil{ get; set; }
      
      public DbSet<CentroClasse>? CentroClasse{ get; set; }
      
      public DbSet<CentroDiretoria>? CentroDiretoria{ get; set; }
      
      public DbSet<CentroCategoria>? CentroCategoria{ get; set; }
      
      public DbSet<CentroEmpresa>? CentroEmpresa{ get; set; }
      
      public DbSet<CentroFilial>? CentroFilial{ get; set; }
      
      public DbSet<CentroLucro>? CentroLucro{ get; set; }
      
      public DbSet<CentroCusto>? CentroCusto{ get; set; }

      public DbSet<FuncionarioCargo>? FuncionarioCargo{ get; set; }
      
      public DbSet<FuncionarioContratacao>? FuncionarioContratacao{ get; set; }
      
      public DbSet<FuncionarioDependente>? FuncionarioDependente{ get; set; }
      
      public DbSet<Funcionario>? Funcionario{ get; set; }
      
      public DbSet<ComboSeparador>? ComboSeparador{ get; set; }
      
      public DbSet<ComboInformacoes>? ComboInformacoes{ get; set; }
      
      public DbSet<Parametro>? Parametro{ get; set; }
      
      public DbSet<CentroCustoSituacao>? CentroCustoSituacao{ get; set; }
      public DbSet<CentroLucroSituacao>? CentroLucroSituacao{ get; set; }
      
      public DbSet<CentroCustoUsuario>? CentroCustoUsuario{ get; set; }
      
      public DbSet<CentroLucroUsuario>? CentroLucroUsuario{ get; set; }
      
      public DbSet<CentroStatus>? CentroStatus{ get; set; }
      
      public DbSet<Mercado>? Mercado{ get; set; }
      
      public DbSet<Produto>? Produto{ get; set; }
      
      public DbSet<CentroCustoLancamento> CentroCustoLancamento { get; set; }
      
      protected override void OnModelCreating(ModelBuilder builder)
      {
            //builder.HasDefaultSchema("dbo_budget");
            
            base.OnModelCreating(builder);
      }
      
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
            
            optionsBuilder.UseSqlite("Data Source=Banco.sqlite");
            //optionsBuilder.UseSqlServer(
            //      "data source=10.235.1.121\\QA;initial catalog=controladoriaqa;persist security info=True;user id=SistemasBD;password=<>j97jy123;MultipleActiveResultSets=True;TrustServerCertificate=True;App=EntityFramework");
                  
            //optionsBuilder.UseExceptionProcessor();
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
      }
      
}