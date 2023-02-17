using System;
using System.Collections.Generic;

namespace API.PruebasPolly.Models;

public partial class PgstbCategoriaMaterial
{
    public Guid CodCategoriaMaterial { get; set; }

    public string? DscNombre { get; set; }

    public string? DscImagen { get; set; }

    public string? FlagActivo { get; set; }

    public string? CodCategoriaSap { get; set; }

    public int NumOrden { get; set; }

    public virtual ICollection<PgstbMaterial> PgstbMaterials { get; } = new List<PgstbMaterial>();
}
