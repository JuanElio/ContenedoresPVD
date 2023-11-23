using System;

namespace App.ModelDto.DTOs
{
	public class UnidadEjecutoraDTO
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
		//public int totalPagina { get; set; }

        #endregion
    }

    public class UnidadEjecutoraListaDTO
    {
        public int? TotalPaginas { get; set; }
        public int? TotalRegistros { get; set; }
        public UnidadEjecutoraDTO? UnidadEjecutora { get; set; }
        public List<UnidadEjecutoraDTO>? ListaUnidadEjecutoraDTO { get; set; }
    }
}
