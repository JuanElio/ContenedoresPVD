using System;

namespace App.Domain.Entities
{
	public class RedVialNacionalPunto
	{
		#region Properties
		/// <summary>
		/// Gets or sets the IdRedVialNacionalPunto value.
		/// </summary>
		public int IdRedVialNacionalPunto {get; set;} 

		/// <summary>
		/// Gets or sets the Ruta value.
		/// </summary>
		public string? Ruta {get; set;} 

		/// <summary>
		/// Gets or sets the NombrePoblado value.
		/// </summary>
		public string? NombrePoblado {get; set;} 

		/// <summary>
		/// Gets or sets the BaseLegal value.
		/// </summary>
		public string? BaseLegal {get; set;} 

		/// <summary>
		/// Gets or sets the Orden value.
		/// </summary>
		public int? Orden {get; set;} 

		/// <summary>
		/// Gets or sets the Longitud value.
		/// </summary>
		public Double? Longitud {get; set;} 

		/// <summary>
		/// Gets or sets the Latitud value.
		/// </summary>
		public Double? Latitud {get; set;} 

		/// <summary>
		/// Gets or sets the UbigeoReniec value.
		/// </summary>
		public string? UbigeoReniec {get; set;} 

		#endregion
	}
}
