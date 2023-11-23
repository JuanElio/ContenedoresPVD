using System;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Configurations
{
	public class ProvinciaConfiguration : IEntityTypeConfiguration<Provincia>
	{
		public void Configure(EntityTypeBuilder<Provincia> builder)
		{
			builder.ToTable("Provincia");

			/*Corregir si tabla tiene multiples claves*/
			builder.HasKey(a => a.IdProvincia).HasName("PK_Provincia");
		}
	}
}
