using System;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Configurations
{
	public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
	{
		public void Configure(EntityTypeBuilder<Departamento> builder)
		{
			builder.ToTable("Departamento");

			/*Corregir si tabla tiene multiples claves*/
			builder.HasKey(a => a.IdDepartamento).HasName("PK_Departamento");
		}
	}
}
