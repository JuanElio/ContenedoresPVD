using System;

namespace App.ModelDto.DTOs
{
	public class DepartamentoDTO
	{
		#region Properties
		/// <summary>
		/// Gets or sets the IdDepartamento value.
		/// </summary>
		public int IdDepartamento {get; set;} 

		/// <summary>
		/// Gets or sets the CodigoDepartamentoReniec value.
		/// </summary>
		public string? CodigoDepartamentoReniec {get; set;} 

		/// <summary>
		/// Gets or sets the CodigoDepartamentoInei value.
		/// </summary>
		public string? CodigoDepartamentoInei {get; set;} 

		/// <summary>
		/// Gets or sets the NombreDepartamento value.
		/// </summary>
		public string? NombreDepartamento {get; set;} 

		/// <summary>
		/// Gets or sets the CodigoIso value.
		/// </summary>
		public string? CodigoIso {get; set;} 

		/// <summary>
		/// Gets or sets the Superficie value.
		/// </summary>
		public decimal? Superficie {get; set;} 

		/// <summary>
		/// Gets or sets the PoblacionDensidad value.
		/// </summary>
		public Double? PoblacionDensidad {get; set;} 

		/// <summary>
		/// Gets or sets the Altitude value.
		/// </summary>
		public int? Altitude {get; set;} 

		/// <summary>
		/// Gets or sets the Latitude value.
		/// </summary>
		public Double? Latitude {get; set;} 

		/// <summary>
		/// Gets or sets the Longitude value.
		/// </summary>
		public Double? Longitude {get; set;} 

		#endregion
	}
}
