using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using server.Shared.ComboBox;
using server.Shared.Crudl;

namespace server.Models;

public class CentroFilial : ICrud
{
      [Key]
      public long? Id { get; set; }

      [Required]
      public string Codigo { get; set; }

      [Required]
      public string Nome { get; set; }
      
      [ForeignKey("Empresa")]
      public long? IdEmpresa { get; set; }
    
      public virtual CentroEmpresa? Empresa { get; set; }
      
      public virtual List<ComboBox> Empresas { get; set; } = [];
}