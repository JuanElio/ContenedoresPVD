using System;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Configurations
{
	public class TipoDispositivoConfiguration : IEntityTypeConfiguration<TipoDispositivo>
	{
		public void Configure(EntityTypeBuilder<TipoDispositivo> builder)
		{
			builder.ToTable("TipoDispositivo");

            /*Corregir si tabla tiene multiples claves*/
            builder.HasKey(a => a.CodigoTipoDispositivo).HasName("PK_TipoDispositivo");
            

        }
	}
}
