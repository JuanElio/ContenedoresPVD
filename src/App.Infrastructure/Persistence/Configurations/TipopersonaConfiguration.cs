using System;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Configurations
{
	public class TipoPersonaConfiguration : IEntityTypeConfiguration<TipoPersona>
	{
		public void Configure(EntityTypeBuilder<TipoPersona> builder)
		{
			builder.ToTable("TipoPersona");

			/*Corregir si tabla tiene multiples claves*/
			builder.HasKey(a => a.CodigoTipoPersona).HasName("PK_Tipopersona");
		}
	}
}
