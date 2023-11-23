using System;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Configurations
{
	public class ComisariaConfiguration : IEntityTypeConfiguration<Comisaria>
	{
		public void Configure(EntityTypeBuilder<Comisaria> builder)
		{
			builder.ToTable("Comisaria");

            /*Corregir si tabla tiene multiples claves*/
            builder.HasKey(a => a.IdComisaria).HasName("PK_Comisaria");
        }
	}
}
