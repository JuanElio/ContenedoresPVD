using System;

namespace App.Domain.Entities
{
	public class DispositivoLegal
	{
		#region Properties
		/// <summary>
		/// Gets or sets the IdDispositivoLegal value.
		/// </summary>
		public int IdDispositivoLegal {get; set;} 

		/// <summary>
		/// Gets or sets the CodigoTipoDispositivo value.
		/// </summary>
		public string CodigoTipoDispositivo {get; set;} 

		/// <summary>
		/// Gets or sets the Nombre value.
		/// </summary>
		public string? Nombre {get; set;} 

		/// <summary>
		/// Gets or sets the FechaPublicacion value.
		/// </summary>
		public DateTime? FechaPublicacion {get; set;} 

		/// <summary>
		/// Gets or sets the IdDispositivoLegalPadre value.
		/// </summary>
		public int? IdDispositivoLegalPadre {get; set;} 

		#endregion
	}
}
