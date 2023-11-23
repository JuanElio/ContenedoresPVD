using System;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Configurations
{
	public class TipoDocumentalConfiguration : IEntityTypeConfiguration<TipoDocumental>
	{
		public void Configure(EntityTypeBuilder<TipoDocumental> builder)
		{
			builder.ToTable("TipoDocumental");

			/*Corregir si tabla tiene multiples claves*/
			builder.HasKey(a => a.IdTipoDocumental).HasName("PK_Tipodocumental");
		}
	}
}
