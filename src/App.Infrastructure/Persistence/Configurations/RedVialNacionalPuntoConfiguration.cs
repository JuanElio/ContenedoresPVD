using System;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Configurations
{
	public class RedVialNacionalPuntoConfiguration : IEntityTypeConfiguration<RedVialNacionalPunto>
	{
		public void Configure(EntityTypeBuilder<RedVialNacionalPunto> builder)
		{
			builder.ToTable("RedVialNacionalPunto");

            /*Corregir si tabla tiene multiples claves*/
            builder.HasKey(a => a.IdRedVialNacionalPunto).HasName("PK_RedVialNacionalPunto");
        }
	}
}
