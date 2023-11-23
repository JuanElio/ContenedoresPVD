using System;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Configurations
{
	public class CalendarioConfiguration : IEntityTypeConfiguration<Calendario>
	{
		public void Configure(EntityTypeBuilder<Calendario> builder)
		{
			builder.ToTable("Calendario");

			/*Corregir si tabla tiene multiples claves*/
			builder.HasKey(a => a.Fecha).HasName("PK_Calendario");
		}
	}
}
