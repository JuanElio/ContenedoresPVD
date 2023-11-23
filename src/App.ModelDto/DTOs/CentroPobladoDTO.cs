using System;

namespace App.ModelDto.DTOs
{
	public class CentroPobladoDTO
	{
		#region Properties
		/// <summary>
		/// Gets or sets the IdCentroPoblado value.
		/// </summary>
		public int? IdCentroPoblado {get; set;} 

		/// <summary>
		/// Gets or sets the CodigoCentroPoblado value.
		/// </summary>
		public string? CodigoCentroPoblado {get; set;} 

		/// <summary>
		/// Gets or sets the NombreCentroPoblado value.
		/// </summary>
		public string? NombreCentroPoblado {get; set;} 

		/// <summary>
		/// Gets or sets the RegionNatural value.
		/// </summary>
		public string? RegionNatural {get; set;} 

		/// <summary>
		/// Gets or sets the Categoria value.
		/// </summary>
		public string? Categoria {get; set;} 

		/// <summary>
		/// Gets or sets the Tipo value.
		/// </summary>
		public string? Tipo {get; set;} 

		/// <summary>
		/// Gets or sets the Longitud value.
		/// </summary>
		public float? Longitud {get; set;} 

		/// <summary>
		/// Gets or sets the Latitud value.
		/// </summary>
		public float? Latitud {get; set;} 

		/// <summary>
		/// Gets or sets the Altitud value.
		/// </summary>
		public int? Altitud {get; set;} 

		/// <summary>
		/// Gets or sets the CantidadVivienda value.
		/// </summary>
		public int? CantidadVivienda {get; set;} 

		/// <summary>
		/// Gets or sets the CantidadHogar value.
		/// </summary>
		public int? CantidadHogar {get; set;} 

		/// <summary>
		/// Gets or sets the PoblacionVulnerable value.
		/// </summary>
		public int? PoblacionVulnerable {get; set;} 

		/// <summary>
		/// Gets or sets the PoblacionTotal value.
		/// </summary>
		public int? PoblacionTotal {get; set;} 

		/// <summary>
		/// Gets or sets the TotalHombres value.
		/// </summary>
		public int? TotalHombres {get; set;} 

		/// <summary>
		/// Gets or sets the TotalMujeres value.
		/// </summary>
		public int? TotalMujeres {get; set;} 

		/// <summary>
		/// Gets or sets the UbigeoReniec value.
		/// </summary>
		public string? UbigeoReniec {get; set;} 

		/// <summary>
		/// Gets or sets the UbigeoInei value.
		/// </summary>
		public string? UbigeoInei {get; set;}
        //public int totalPagina { get; set; }



        #endregion
    }

    public class CentroPobladoListaDTO
	{
        public int? TotalPaginas { get; set; }
        public int? TotalRegistros { get; set; }
        public CentroPobladoDTO? CentroPoblado { get; set; }
        public List<CentroPobladoDTO>? ListaCentroPobladoDTO { get; set; }
    }
}
