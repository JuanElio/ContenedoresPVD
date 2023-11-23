using System;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Configurations
{
	public class DispositivoLegalConfiguration : IEntityTypeConfiguration<DispositivoLegal>
	{
		public void Configure(EntityTypeBuilder<DispositivoLegal> builder)
		{
			builder.ToTable("DispositivoLegal");

			/*Corregir si tabla tiene multiples claves*/
			builder.HasKey(a => a.CodigoTipoDispositivo).HasName("PK_Dispositivolegal");
			builder.HasKey(a => a.IdDispositivoLegal).HasName("PK_Dispositivolegal");
		}
	}
}
