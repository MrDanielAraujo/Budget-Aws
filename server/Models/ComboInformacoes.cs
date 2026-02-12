using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using server.Shared.ComboBox;
using server.Shared.Crudl;

namespace server.Models;

public class ComboInformacoes : ICrud
{
      [Key]
      public long? Id { get; set; }

      public string Nome { get; set; }

      [ForeignKey("CentroCusto")]
      public long? IdCentroCusto { get; set; }

      [ForeignKey("ComboInformacoesSeparacao")]
      public long? IdComboInformacoesSeparacao { get; set; }

      public virtual CentroCusto? CentroCusto { get; set; }

      public virtual ComboSeparador? ComboInformacoesSeparacao { get; set; }

      public virtual List<ComboBox> CentroCustos { get; set; } = new List<ComboBox>();

      public virtual List<ComboBox> ComboInformacoesSeparacoes { get; set; } = new List<ComboBox>();
}