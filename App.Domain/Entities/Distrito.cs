using System;

namespace App.Domain.Entities
{
	public class Distrito
	{
		#region Properties
		/// <summary>
		/// Gets or sets the IdDistrito value.
		/// </summary>
		public int IdDistrito {get; set;} 

		/// <summary>
		/// Gets or sets the CodigoDistritoReniec value.
		/// </summary>
		public string? CodigoDistritoReniec {get; set;} 

		/// <summary>
		/// Gets or sets the CodigoDistritoInei value.
		/// </summary>
		public string? CodigoDistritoInei {get; set;} 

		/// <summary>
		/// Gets or sets the NombreDistrito value.
		/// </summary>
		public string? NombreDistrito {get; set;} 

		/// <summary>
		/// Gets or sets the Superficie value.
		/// </summary>
		public decimal? Superficie {get; set;} 

		/// <summary>
		/// Gets or sets the PoblacionDensidad value.
		/// </summary>
		public Double? PoblacionDensidad {get; set;} 

		/// <summary>
		/// Gets or sets the Alltitude value.
		/// </summary>
		public int? Alltitude {get; set;} 

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
