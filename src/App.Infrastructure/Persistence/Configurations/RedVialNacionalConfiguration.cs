using System;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Configurations
{
	public class RedVialNacionalConfiguration : IEntityTypeConfiguration<RedVialNacional>
	{
		public void Configure(EntityTypeBuilder<RedVialNacional> builder)
		{
			builder.ToTable("RedVialNacional");

            /*Corregir si tabla tiene multiples claves*/
            builder.HasKey(a => a.IdRedVialNacional).HasName("PK_RedVialNacional");
        }
	}
}
