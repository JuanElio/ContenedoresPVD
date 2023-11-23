using System;

namespace App.Domain.Entities
{
	public class Comisaria
	{
		#region Properties
		/// <summary>
		/// Gets or sets the IdComisaria value.
		/// </summary>
		public int? IdComisaria {get; set;} 

		/// <summary>
		/// Gets or sets the NombreComisaria value.
		/// </summary>
		public string? NombreComisaria {get; set;} 

		/// <summary>
		/// Gets or sets the Estado value.
		/// </summary>
		public string? Estado {get; set;} 

		/// <summary>
		/// Gets or sets the Direccion value.
		/// </summary>
		public string? Direccion {get; set;} 

		/// <summary>
		/// Gets or sets the Tipo value.
		/// </summary>
		public string? Tipo {get; set;} 

		/// <summary>
		/// Gets or sets the Observacion value.
		/// </summary>
		public string? Observacion {get; set;} 

		/// <summary>
		/// Gets or sets the UbigeoInei value.
		/// </summary>
		public string? UbigeoInei {get; set;} 

		/// <summary>
		/// Gets or sets the UbigeoReniec value.
		/// </summary>
		public string? UbigeoReniec {get; set;} 

		#endregion
	}
}
