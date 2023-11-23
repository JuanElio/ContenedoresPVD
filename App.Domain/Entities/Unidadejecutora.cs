using System;

namespace App.Domain.Entities
{
	public class UnidadEjecutora
	{
		#region Properties
		/// <summary>
		/// Gets or sets the IdUnidadEjecutora value.
		/// </summary>
		public int IdUnidadEjecutora {get; set;} 

		/// <summary>
		/// Gets or sets the CodigoUnidadEjecutora value.
		/// </summary>
		public string? CodigoUnidadEjecutora {get; set;} 

		/// <summary>
		/// Gets or sets the Descripcion value.
		/// </summary>
		public string? Descripcion {get; set;} 

		/// <summary>
		/// Gets or sets the UbigeoReniec value.
		/// </summary>
		public string? UbigeoReniec {get; set;}
        public string? UbigeoInei { get; set; }

        #endregion
    }
}
