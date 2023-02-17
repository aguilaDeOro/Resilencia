using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.PruebasPolly.Models;

public partial class PgsContext : DbContext
{
    public PgsContext()
    {
    }

    public PgsContext(DbContextOptions<PgsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PgstbCategoriaMaterial> PgstbCategoriaMaterials { get; set; }

    public virtual DbSet<PgstbMaterial> PgstbMaterials { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SRVDEVSQL04;Initial Catalog=PGS;User Id=USDSTIC1;Password=$#DaT4D3v#$;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PgstbCategoriaMaterial>(entity =>
        {
            entity.HasKey(e => e.CodCategoriaMaterial).HasName("PK_CATEGORIA_MATERIAL");

            entity.ToTable("PGSTB_CATEGORIA_MATERIAL");

            entity.Property(e => e.CodCategoriaMaterial)
                .ValueGeneratedNever()
                .HasColumnName("COD_CATEGORIA_MATERIAL");
            entity.Property(e => e.CodCategoriaSap)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("COD_CATEGORIA_SAP");
            entity.Property(e => e.DscImagen)
                .HasMaxLength(200)
                .HasColumnName("DSC_IMAGEN");
            entity.Property(e => e.DscNombre)
                .HasMaxLength(50)
                .HasColumnName("DSC_NOMBRE");
            entity.Property(e => e.FlagActivo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("FLAG_ACTIVO");
            entity.Property(e => e.NumOrden).HasColumnName("NUM_ORDEN");
        });

        modelBuilder.Entity<PgstbMaterial>(entity =>
        {
            entity.HasKey(e => e.CodMaterial).HasName("PK_MATERIAL");

            entity.ToTable("PGSTB_MATERIAL");

            entity.HasIndex(e => e.CodCategoriaMaterial, "IX_PGSTB_MATERIAL_COD_CATEGORIA_MATERIAL");

            entity.HasIndex(e => e.CodMarcaMaterial, "IX_PGSTB_MATERIAL_COD_MARCA_MATERIAL");

            entity.HasIndex(e => e.CodSku, "IX_PGSTB_MATERIAL_COD_SKU").IsUnique();

            entity.HasIndex(e => e.CodTipoMaterial, "IX_PGSTB_MATERIAL_COD_TIPO_MATERIAL");

            entity.HasIndex(e => e.CodUnidadMedida, "IX_PGSTB_MATERIAL_COD_UNIDAD_MEDIDA");

            entity.Property(e => e.CodMaterial)
                .ValueGeneratedNever()
                .HasColumnName("COD_MATERIAL");
            entity.Property(e => e.CodCategoriaMaterial).HasColumnName("COD_CATEGORIA_MATERIAL");
            entity.Property(e => e.CodMarcaMaterial).HasColumnName("COD_MARCA_MATERIAL");
            entity.Property(e => e.CodProductoSap)
                .HasMaxLength(70)
                .HasColumnName("COD_PRODUCTO_SAP");
            entity.Property(e => e.CodSku)
                .HasMaxLength(90)
                .HasColumnName("COD_SKU");
            entity.Property(e => e.CodTipoMaterial).HasColumnName("COD_TIPO_MATERIAL");
            entity.Property(e => e.CodUnidadMedida).HasColumnName("COD_UNIDAD_MEDIDA");
            entity.Property(e => e.DscImagen)
                .HasMaxLength(200)
                .HasColumnName("DSC_IMAGEN");
            entity.Property(e => e.DscNombre)
                .HasMaxLength(300)
                .HasColumnName("DSC_NOMBRE");
            entity.Property(e => e.DscProductoParser)
                .HasMaxLength(300)
                .HasColumnName("DSC_PRODUCTO_PARSER");
            entity.Property(e => e.DscResistencia)
                .HasMaxLength(200)
                .HasColumnName("DSC_RESISTENCIA");
            entity.Property(e => e.DscResumenCaracteristica)
                .HasMaxLength(900)
                .HasColumnName("DSC_RESUMEN_CARACTERISTICA");
            entity.Property(e => e.DscSecadoFinal)
                .HasMaxLength(200)
                .HasColumnName("DSC_SECADO_FINAL");
            entity.Property(e => e.DscTipoObra)
                .HasMaxLength(900)
                .HasColumnName("DSC_TIPO_OBRA");
            entity.Property(e => e.DscUsuarioCreacion)
                .HasMaxLength(50)
                .HasColumnName("DSC_USUARIO_CREACION");
            entity.Property(e => e.DscUsuarioUpd)
                .HasMaxLength(50)
                .HasColumnName("DSC_USUARIO_UPD");
            entity.Property(e => e.FchRegistro)
                .HasColumnType("datetime")
                .HasColumnName("FCH_REGISTRO");
            entity.Property(e => e.FchUpd)
                .HasColumnType("datetime")
                .HasColumnName("FCH_UPD");
            entity.Property(e => e.FlagActivo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("FLAG_ACTIVO");
            entity.Property(e => e.NumOrdMaterialcemento)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NUM_ORD_MATERIALCEMENTO");

            entity.HasOne(d => d.CodCategoriaMaterialNavigation).WithMany(p => p.PgstbMaterials)
                .HasForeignKey(d => d.CodCategoriaMaterial)
                .HasConstraintName("FK_PGSTB_MATERIAL_PGSTB_CATEGORIA_MATERIAL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
