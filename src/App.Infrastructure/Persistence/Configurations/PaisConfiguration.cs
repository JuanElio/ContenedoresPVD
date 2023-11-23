using System;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Configurations
{
	public class PaisConfiguration : IEntityTypeConfiguration<Pais>
	{
		public void Configure(EntityTypeBuilder<Pais> builder)
		{
			builder.ToTable("Pais");

			/*Corregir si tabla tiene multiples claves*/
			builder.HasKey(a => a.IdPais).HasName("PK_Pais");
		}
	}
}
