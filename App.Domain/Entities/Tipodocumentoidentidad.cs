using System;

namespace App.Domain.Entities
{
	public class TipoDocumentoIdentidad
	{
		#region Properties
		/// <summary>
		/// Gets or sets the CodigoTipoIdentidad value.
		/// </summary>
		public string CodigoTipoIdentidad {get; set;} 

		/// <summary>
		/// Gets or sets the DescripcionTipoIdentidad value.
		/// </summary>
		public string? DescripcionTipoIdentidad {get; set;} 

		/// <summary>
		/// Gets or sets the DescripcionCorta value.
		/// </summary>
		public string? DescripcionCorta {get; set;} 

		/// <summary>
		/// Gets or sets the Estado value.
		/// </summary>
		public string? Estado {get; set;} 

		#endregion
	}
}
