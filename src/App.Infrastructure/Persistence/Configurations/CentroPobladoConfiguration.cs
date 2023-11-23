using System;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Configurations
{
	public class CentroPobladoConfiguration : IEntityTypeConfiguration<CentroPoblado>
	{
		public void Configure(EntityTypeBuilder<CentroPoblado> builder)
		{
			builder.ToTable("CentroPoblado");

            /*Corregir si tabla tiene multiples claves*/
            builder.HasKey(a => a.IdCentroPoblado).HasName("PK_CentroPoblado");
        }
	}
}
