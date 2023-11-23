
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infraestruture.Configurations
{
    public class ArticuloConfiguration : IEntityTypeConfiguration<Articulo>
    {
        public void Configure(EntityTypeBuilder<Articulo> builder)
        {
            builder.ToTable("ARTICULO");

            builder.HasKey(a => a.IdArticulo)
                   .HasName("PK_Articulo");

            builder.Property(a => a.Nombre).HasMaxLength(100);
            builder.Property(a => a.UnidadMedida).HasMaxLength(10);
            builder.Property(a => a.SituacionRegistro).HasMaxLength(1);
            builder.Property(a => a.GuidRegistro).HasMaxLength(100);

            //builder.Property(a => a.TipoOrden)
            //    .HasMaxLength(3)
            //    .HasColumnName("vchTipoOrden");

            //builder.Property(a => a.CodOPublicacion)
            //    .HasColumnName("numCodOPublicacion")
            //    .HasColumnType("numeric(18, 0)");

            //builder.Property(a => a.CodPuntoVenta)
            //    .HasMaxLength(4)
            //    .HasColumnName("vchCodPuntoVenta");

            //builder.Property(a => a.UsuDescuento)
            //    .HasColumnName("numUsuDescuento");

            //builder.Property(a => a.CodAgencia)
            //    .HasColumnName("numCodAgencia");

            //builder.Property(a => a.CodCliente)
            //    .HasColumnName("numCodCliente")
            //    .HasColumnType("numeric(18, 0)");

            //builder.Property(a => a.FlagClienteAgencia)
            //    .HasColumnName("intFlagClienteAgencia");

            //builder.Property(a => a.Estado)
            //    .HasColumnName("vchEstado")
            //    .HasMaxLength(2);

            //builder.Property(a => a.FormaPago)
            //    .HasColumnName("vchFormaPago")
            //    .HasMaxLength(3).HasDefaultValue("C00");

            //builder.Property(a => a.FlagProforma)
            //    .HasColumnName("intFlagProforma")
            //    .HasMaxLength(1)
            //    .HasDefaultValue("N");

            //builder.Property(a => a.TipComprobante)
            //    .HasColumnName("vchTipComprobante")
            //    .HasMaxLength(2);

            //builder.Property(a => a.TipoProforma)
            //    .HasColumnName("vchTipoProforma")
            //    .HasMaxLength(2);

            //builder.Property(a => a.MontoBruto)
            //    .HasColumnName("numMontoBruto")
            //    .HasColumnType("numeric(15,4)");

            //builder.Property(a => a.MontoDescuento)
            //    .HasColumnName("numMontoDescuento")
            //    .HasColumnType("numeric(15,4)");

            //builder.Property(a => a.MontoRecargo)
            //    .HasColumnName("numMontoRecargo")
            //    .HasColumnType("numeric(15,4)");

            //builder.Property(a => a.SubTotal)
            //    .HasColumnName("numSubTotal")
            //    .HasColumnType("numeric(15,4)");

            //builder.Property(a => a.MontoIGV)
            //    .HasColumnName("numMontoIGV")
            //    .HasColumnType("numeric(15,4)");

            //builder.Property(a => a.MontoTotal)
            //    .HasColumnName("numMontoTotal")
            //    .HasColumnType("numeric(15,4)");

            //builder.Property(a => a.SituacionRegistro)
            //    .HasColumnName("chrSituacionRegistro")
            //    .HasMaxLength(1)
            //    .HasDefaultValue("A");

            //builder.Property(a => a.Creador)
            //    .HasColumnName("vchCreador")
            //    .HasMaxLength(16);


            //builder.Property(e => e.FechaCreacion)
            //    .HasColumnType("datetime")
            //    .HasColumnName("dtmFechaCreacion")
            //    .HasDefaultValueSql("(getdate())");

            //builder.Property(a => a.Modificador)
            //    .HasColumnName("vchModificador")
            //    .HasMaxLength(16);

            //builder.Property(e => e.FechaModificacion)
            //    .HasColumnType("datetime")
            //    .HasColumnName("dtmFechaModificacion");
            //builder.Property(a => a.CodTransOperador)
            //    .HasColumnName("numCodTransOperador")
            //    .HasColumnType("numeric(18,0)");

            //builder.Property(a => a.TotalNetoContado)
            //    .HasColumnName("numTotalNetoContado")
            //    .HasColumnType("numeric(15,4)");

            //builder.Property(a => a.TotalNetoCredito)
            //    .HasColumnName("numTotalNetoCredito")
            //    .HasColumnType("numeric(15,4)");

            //builder.Property(a => a.OrdenVenta)
            //    .HasColumnName("vchOrdenVenta")
            //    .HasMaxLength(32);

            //builder.Property(a => a.TipoCambio)
            //    .HasColumnName("numTipoCambio")
            //    .HasColumnType("numeric(9,4)");

            //builder.Property(a => a.Renovacion)
            //    .HasColumnName("intIndRenovacion");

            //builder.Property(a => a.DispModificado)
            //    .HasColumnName("vchDispModificado")
            //    .HasMaxLength(128).HasDefaultValue("");

            //builder.Property(a => a.Efectos)
            //    .HasColumnName("vchefectos")
            //    .HasMaxLength(128);

            //builder.Property(a => a.TransaccionWeb)
            //    .HasColumnName("numTransaccionWeb");

            //builder.Property(a => a.EstadoVentaWeb)
            //    .HasColumnName("vchEstadoVentaWeb")
            //    .HasMaxLength(1);

            //builder.Property(a => a.PendienteOrden)
            //    .HasColumnName("chrPendienteOrden")
            //    .HasMaxLength(1)
            //    .HasDefaultValue("S");

            //builder.Property(a => a.FlagReposicion)
            //    .HasColumnName("chrFlagReposicion")
            //    .HasMaxLength(1).HasDefaultValue("N");
            //builder.Property(a => a.FlagAvisoComercial)
            //    .HasColumnName("chrFlagAvisoComercial")
            //    .HasMaxLength(1).HasDefaultValue("N");

            //builder.Property(a => a.FlagAuxilioJudicial)
            //    .HasColumnName("chrFlagAuxilioJudicial")
            //    .HasMaxLength(1).HasDefaultValue("N");

            //builder.Property(a => a.FlagTransferido)
            //    .HasColumnName("chrFlagTransferido")
            //    .HasMaxLength(1).HasDefaultValue("N");

            //builder.Property(a => a.FlagSuscripcion)
            //    .HasColumnName("chrFlagSuscripcion")
            //    .HasMaxLength(1).HasDefaultValue("N");

            //builder.Property(a => a.CodOVenta)
            //    .HasColumnName("vchCodOVenta")
            //    .HasMaxLength(256);

            //builder.Property(a => a.TipoSuscripcion)
            //    .HasColumnName("chrTipoSuscripcion")
            //    .HasMaxLength(2);
            //builder.Property(a => a.CodAlmacen)
            //    .HasColumnName("vchCodAlmacen")
            //    .HasMaxLength(8);

            //builder.Property(a => a.CodMoneda)
            //    .HasColumnName("vchCodMoneda")
            //    .HasMaxLength(6).HasDefaultValue("SOL");

            //builder.Property(a => a.TipoTablaG)
            //    .HasColumnName("intTipoTablaG");

            //builder.Property(a => a.TipoBaseLegalG)
            //    .HasColumnName("intTipoBaseLegalG");

            //builder.Property(a => a.FlagPgaWeb)
            //    .HasColumnName("chrFlagPgaWeb")
            //    .HasMaxLength(6).HasDefaultValue("N");

            //builder.Property(a => a.CodclienteEnt)
            //    .HasColumnName("vchCodclienteEnt")
            //    .HasMaxLength(6).HasDefaultValue("");

            //builder.Property(a => a.GuidRegistro)
            //    .HasColumnName("vchGuidRegistro")
            //    .HasMaxLength(100);

            //builder.Property(a => a.Referencia)
            //    .HasColumnName("vchReferencia")
            //    .HasMaxLength(100);

            //builder.Property(a => a.RutaCliente)
            //    .HasColumnName("vchRutaCliente")
            //    .HasMaxLength(20);


        }

    }


}
