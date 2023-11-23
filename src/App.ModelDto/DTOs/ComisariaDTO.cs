using System;

namespace App.ModelDto.DTOs
{
	public class ComisariaDTO
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
        //public int totalPagina { get; set; }

        #endregion
    }
    public class ComisariaListaDTO
    {
        public int? TotalPaginas { get; set; }
        public int? TotalRegistros { get; set; }
        public ComisariaDTO? Comisaria { get; set; }
        public List<ComisariaDTO>? ListaComisariaDTO { get; set; }
    }
}
