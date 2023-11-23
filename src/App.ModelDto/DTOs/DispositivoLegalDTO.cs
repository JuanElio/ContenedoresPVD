using System;

namespace App.ModelDto.DTOs
{
	public class DispositivoLegalDTO
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
        public string? DescripcionTipoDispositivo { get; set; }

        /// <summary>
        /// Gets or sets the Nombre value.
        /// </summary>
        public string? Nombre {get; set;}
        //public string? FechaPublicacionString { get; set; }

        /// <summary>
        /// Gets or sets the FechaPublicacion value.
        /// </summary>
        public DateTime? FechaPublicacion {get; set;} 

        /// <summary>
        /// Gets or sets the IdDispositivoLegalPadre value.
        /// </summary>
        public int? IdDispositivoLegalPadre { get; set;}

       
        public string? DispositivoPadre { get; set; }
        
        


        #endregion
    }

    public class DispositivoLegalAgregarDTO
    {
        #region Properties
        /// <summary>
        /// Gets or sets the IdDispositivoLegal value.
        /// </summary>
       
        public string CodigoTipoDispositivo { get; set; }

        public string? Nombre { get; set; }
       
        public DateTime? FechaPublicacion { get; set; }

       
        public int? IdDispositivoLegalPadre { get; set; }


        #endregion
    }
}
