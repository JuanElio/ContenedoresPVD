using App.Infrastructure.Repository;
using System;

namespace App.ModelDto.DTOs
{
	public class RedVialNacionalDTO
	{
		#region Properties
		/// <summary>
		/// Gets or sets the IdRedVialNacional value.
		/// </summary>
		public int IdRedVialNacional {get; set;} 

		/// <summary>
		/// Gets or sets the Ruta value.
		/// </summary>
		public string? Ruta {get; set;} 

		/// <summary>
		/// Gets or sets the Longitud value.
		/// </summary>
		public Double? Longitud {get; set;} 

		/// <summary>
		/// Gets or sets the Sentido value.
		/// </summary>
		public string? Sentido {get; set;} 

		/// <summary>
		/// Gets or sets the Superficie value.
		/// </summary>
		public string? Superficie {get; set;} 

		/// <summary>
		/// Gets or sets the Estado value.
		/// </summary>
		public string? Estado {get; set;} 

		/// <summary>
		/// Gets or sets the Orientacion value.
		/// </summary>
		public string? Orientacion {get; set;} 

		/// <summary>
		/// Gets or sets the BaseLegal value.
		/// </summary>
		public string? BaseLegal {get; set;} 

		/// <summary>
		/// Gets or sets the Trayectoria value.
		/// </summary>
		public string? Trayectoria {get; set;} 

		/// <summary>
		/// Gets or sets the UbigeoReniec value.
		/// </summary>
		public string? UbigeoReniec {get; set;}


        

        #endregion
    }
    public class RedVialNacionalListasDTO
    {
        #region Properties
        /// <summary>
        /// Gets or sets the IdRedVialNacional value.
        /// </summary>
      

        public List<SuperficieRodaduraDTO>? ListaSuperficieRodadura { get; set; }
        public List<LongitudPorDepartamentoDTO>? LongitudPorDepartamentoDTO { get; set; }
        public List<RedVialNacionalPuntoPobladoDTO>? RedVialNacionalPuntoPobladoDTO { get; set; }


        #endregion
    }
}
