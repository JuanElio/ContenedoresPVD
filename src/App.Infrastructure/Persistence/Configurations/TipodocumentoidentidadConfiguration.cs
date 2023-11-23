using System;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Configurations
{
	public class TipoDocumentoIdentidadConfiguration : IEntityTypeConfiguration<TipoDocumentoIdentidad>
	{
		public void Configure(EntityTypeBuilder<TipoDocumentoIdentidad> builder)
		{
			builder.ToTable("TipoDocumentoIdentidad");

			/*Corregir si tabla tiene multiples claves*/
			builder.HasKey(a => a.CodigoTipoIdentidad).HasName("PK_Tipodocumentoidentidad");
		}
	}
}
