using System;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Configurations
{
	public class TipoInversionConfiguration : IEntityTypeConfiguration<TipoInversion>
	{
		public void Configure(EntityTypeBuilder<TipoInversion> builder)
		{
			builder.ToTable("TipoInversion");

			/*Corregir si tabla tiene multiples claves*/
			builder.HasKey(a => a.CodigoInversion).HasName("PK_Tipoinversion");
		}
	}
}
