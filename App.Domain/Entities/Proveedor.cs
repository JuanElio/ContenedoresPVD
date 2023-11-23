using System;

namespace App.Domain.Entities
{
	public class Proveedor
	{
		#region Properties
		/// <summary>
		/// Gets or sets the IdProveedor value.
		/// </summary>
		public int IdProveedor {get; set;} 

		/// <summary>
		/// Gets or sets the Codigo value.
		/// </summary>
		public string? Codigo {get; set;} 

		/// <summary>
		/// Gets or sets the RazonSocial value.
		/// </summary>
		public string? RazonSocial {get; set;} 

		/// <summary>
		/// Gets or sets the FechaIngreso value.
		/// </summary>
		public DateTime? FechaIngreso {get; set;} 

		/// <summary>
		/// Gets or sets the Ruc value.
		/// </summary>
		public string? Ruc {get; set;} 

		/// <summary>
		/// Gets or sets the GuidRegistro value.
		/// </summary>
		public string? GuidRegistro {get; set;} 

		/// <summary>
		/// Gets or sets the SituacionRegistro value.
		/// </summary>
		public string? SituacionRegistro {get; set;} 

		/// <summary>
		/// Gets or sets the Creador value.
		/// </summary>
		public string? Creador {get; set;} 

		/// <summary>
		/// Gets or sets the FechaCreacion value.
		/// </summary>
		public DateTime? FechaCreacion {get; set;} 

		/// <summary>
		/// Gets or sets the Modificador value.
		/// </summary>
		public string? Modificador {get; set;} 

		/// <summary>
		/// Gets or sets the FechaModificacion value.
		/// </summary>
		public DateTime? FechaModificacion {get; set;} 

		#endregion
	}
}
