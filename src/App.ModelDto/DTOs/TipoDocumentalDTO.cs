using System;

namespace App.ModelDto.DTOs
{
	public class TipoDocumentalDTO
	{
		#region Properties
		/// <summary>
		/// Gets or sets the IdTipoDocumental value.
		/// </summary>
		public int IdTipoDocumental {get; set;} 

		/// <summary>
		/// Gets or sets the Descripcion value.
		/// </summary>
		public string? Descripcion {get; set;} 

		/// <summary>
		/// Gets or sets the Sigla value.
		/// </summary>
		public string? Sigla {get; set;} 

		/// <summary>
		/// Gets or sets the FlagEntrada value.
		/// </summary>
		public int? FlagEntrada {get; set;} 

		/// <summary>
		/// Gets or sets the FlagInterno value.
		/// </summary>
		public int? FlagInterno {get; set;} 

		/// <summary>
		/// Gets or sets the FlagSalida value.
		/// </summary>
		public int? FlagSalida {get; set;} 

		/// <summary>
		/// Gets or sets the DocEsp value.
		/// </summary>
		public int? DocEsp {get; set;} 

		/// <summary>
		/// Gets or sets the FlagWeb value.
		/// </summary>
		public int? FlagWeb {get; set;} 

		/// <summary>
		/// Gets or sets the Anexo value.
		/// </summary>
		public string? Anexo {get; set;} 

		/// <summary>
		/// Gets or sets the CodigoPide value.
		/// </summary>
		public string? CodigoPide {get; set;} 

		/// <summary>
		/// Gets or sets the FlagSalidaGeneral value.
		/// </summary>
		public bool? FlagSalidaGeneral {get; set;} 

		/// <summary>
		/// Gets or sets the FlagInternoAPersonal value.
		/// </summary>
		public bool? FlagInternoAPersonal {get; set;} 

		/// <summary>
		/// Gets or sets the FlagPersonalGeneral value.
		/// </summary>
		public bool? FlagPersonalGeneral {get; set;} 

		/// <summary>
		/// Gets or sets the FlagPersonal value.
		/// </summary>
		public bool? FlagPersonal {get; set;} 

		/// <summary>
		/// Gets or sets the FlagEstado value.
		/// </summary>
		public string? Estado {get; set;} 

		#endregion
	}
}
