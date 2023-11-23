using System;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Configurations
{
	public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
	{
		public void Configure(EntityTypeBuilder<Persona> builder)
		{
			builder.ToTable("Persona");

			/*Corregir si tabla tiene multiples claves*/
			//builder.HasKey(a => a.CodigoTipoPersona).HasName("PK_Persona");
			//builder.HasKey(a => a.CodigoTipoIdentidad).HasName("PK_Persona");
			builder.HasKey(a => a.IdPersona).HasName("PK_Persona");
		}
	}
}
