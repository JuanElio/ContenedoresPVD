using System;

namespace App.Domain.Entities
{
	public class Provincia
	{
		#region Properties
		/// <summary>
		/// Gets or sets the IdProvincia value.
		/// </summary>
		public int IdProvincia {get; set;} 

		/// <summary>
		/// Gets or sets the CodigoProvinciaReniec value.
		/// </summary>
		public string? CodigoProvinciaReniec {get; set;} 

		/// <summary>
		/// Gets or sets the CodigoProvinciaInei value.
		/// </summary>
		public string? CodigoProvinciaInei {get; set;} 

		/// <summary>
		/// Gets or sets the NombreProvincia value.
		/// </summary>
		public string? NombreProvincia {get; set;} 

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
