using System;
using System.Collections.Generic;

namespace API.PruebasPolly.Models;

public partial class PgstbMaterial
{
    public Guid CodMaterial { get; set; }

    public string? DscNombre { get; set; }

    public string? DscImagen { get; set; }

    public string? FlagActivo { get; set; }

    public string? DscUsuarioCreacion { get; set; }

    public DateTime FchRegistro { get; set; }

    public string? DscUsuarioUpd { get; set; }

    public DateTime FchUpd { get; set; }

    public Guid CodCategoriaMaterial { get; set; }

    public Guid CodTipoMaterial { get; set; }

    public Guid CodMarcaMaterial { get; set; }

    public Guid CodUnidadMedida { get; set; }

    public string CodSku { get; set; } = null!;

    public string? CodProductoSap { get; set; }

    public string? DscProductoParser { get; set; }

    public decimal NumOrdMaterialcemento { get; set; }

    public string? DscTipoObra { get; set; }

    public string? DscResistencia { get; set; }

    public string? DscResumenCaracteristica { get; set; }

    public string? DscSecadoFinal { get; set; }

    public virtual PgstbCategoriaMaterial CodCategoriaMaterialNavigation { get; set; } = null!;
}
