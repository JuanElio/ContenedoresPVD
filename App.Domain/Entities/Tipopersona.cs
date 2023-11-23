using System;

namespace App.Domain.Entities
{
	public class TipoPersona
	{
		#region Properties
		/// <summary>
		/// Gets or sets the CodigoTipoPersona value.
		/// </summary>
		public string CodigoTipoPersona {get; set;} 

		/// <summary>
		/// Gets or sets the Descripcion value.
		/// </summary>
		public string? Descripcion {get; set;} 

		/// <summary>
		/// Gets or sets the Estado value.
		/// </summary>
		public string? Estado {get; set;} 

		#endregion
	}
}
