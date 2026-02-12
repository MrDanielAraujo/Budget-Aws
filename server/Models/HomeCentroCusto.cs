using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;

namespace server.Models;

[Keyless]
public class HomeCentroCusto
{
    public long? IdCentro { get; set; }

    public long? IdExercicio { get; set; }

    public string? CentroCodigo { get; set; }

    public string? CentroNome { get; set; }

    public string? Usuario { get; set; }

    public long? NivelAtual { get; set; }

    public long? NivelTotal { get; set; }

    public string? Situacao { get; set; }

    public string? SituacaoBgColor { get; set; }
}