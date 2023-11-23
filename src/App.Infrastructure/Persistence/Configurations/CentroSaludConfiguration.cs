using System;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Configurations
{
	public class CentroSaludConfiguration : IEntityTypeConfiguration<CentroSalud>
	{
		public void Configure(EntityTypeBuilder<CentroSalud> builder)
		{
			builder.ToTable("CentroSalud");

            /*Corregir si tabla tiene multiples claves*/
            builder.HasKey(a => a.IdCentroSalud).HasName("PK_CentroSalud");
        }
	}
}
