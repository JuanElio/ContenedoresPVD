using System;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Configurations
{
	public class ColegioConfiguration : IEntityTypeConfiguration<Colegio>
	{
		public void Configure(EntityTypeBuilder<Colegio> builder)
		{
			builder.ToTable("Colegio");

            /*Corregir si tabla tiene multiples claves*/
            builder.HasKey(a => a.IdColegio).HasName("PK_Colegio");
        }
	}
}
