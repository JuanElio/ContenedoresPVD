using System;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Configurations
{
	public class UnidadejecutoraConfiguration : IEntityTypeConfiguration<UnidadEjecutora>
	{
		public void Configure(EntityTypeBuilder<UnidadEjecutora> builder)
		{
			builder.ToTable("UnidadEjecutora");

			/*Corregir si tabla tiene multiples claves*/
			builder.HasKey(a => a.IdUnidadEjecutora).HasName("PK_Unidadejecutora");
		}
	}
}
