using Microsoft.EntityFrameworkCore;

namespace server.Models;

[Keyless]
public class HomeCentroLucro
{
    public long? IdCentro { get; set; }

    public long? IdExercicio { get; set; }

    public String? CentroCodigo { get; set; }

    public String? CentroNome { get; set; }

    public String? Usuario { get; set; }

    public int? NivelAtual { get; set; }

    public int? NivelTotal { get; set; }

    public String? Situacao { get; set; }

    public String? SituacaoBgColor { get; set; }
}