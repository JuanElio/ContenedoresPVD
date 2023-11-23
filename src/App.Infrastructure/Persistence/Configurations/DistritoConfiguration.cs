using System;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Configurations
{
	public class DistritoConfiguration : IEntityTypeConfiguration<Distrito>
	{
		public void Configure(EntityTypeBuilder<Distrito> builder)
		{
			builder.ToTable("Distrito");

			/*Corregir si tabla tiene multiples claves*/
			builder.HasKey(a => a.IdDistrito).HasName("PK_Distrito");
		}
	}
}
