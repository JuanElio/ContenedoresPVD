using System;

namespace App.ModelDto.DTOs
{
	public class PersonaDTO
	{
		#region Properties
		/// <summary>
		/// Gets or sets the IdPersona value.
		/// </summary>
		public int IdPersona {get; set;} 

		/// <summary>
		/// Gets or sets the CodigoTipoIdentidad value.
		/// </summary>
		public string CodigoTipoIdentidad {get; set;} 

		/// <summary>
		/// Gets or sets the EroDocumento value.
		/// </summary>
		public string? NumeroDocumento { get; set;} 

		/// <summary>
		/// Gets or sets the ApellidoPaterno value.
		/// </summary>
		public string? ApellidoPaterno {get; set;} 

		/// <summary>
		/// Gets or sets the ApellidoMaterno value.
		/// </summary>
		public string? ApellidoMaterno {get; set;} 

		/// <summary>
		/// Gets or sets the Nombres value.
		/// </summary>
		public string? Nombres {get; set;} 

		/// <summary>
		/// Gets or sets the Sexo value.
		/// </summary>
		public string? Sexo {get; set;} 

		/// <summary>
		/// Gets or sets the Telefono value.
		/// </summary>
		public string? Telefono {get; set;} 

		/// <summary>
		/// Gets or sets the CodigoTipoPersona value.
		/// </summary>
		public string CodigoTipoPersona {get; set;} 

		/// <summary>
		/// Gets or sets the NombreCompleto value.
		/// </summary>
		public string? NombreCompleto {get; set;} 

		/// <summary>
		/// Gets or sets the Estado value.
		/// </summary>
		public string? Estado {get; set;} 

		/// <summary>
		/// Gets or sets the CodigoAfp value.
		/// </summary>
		public string? CodigoAfp {get; set;} 

		/// <summary>
		/// Gets or sets the FechaCreacion value.
		/// </summary>
		public DateTime? FechaCreacion {get; set;}
        //public int totalPagina { get; set; }

        #endregion
    }

    public class PersonaListaDTO
    {
        public int? TotalPaginas { get; set; }
        public int? TotalRegistros { get; set; }
        public PersonaDTO? Persona { get; set; }
        public List<PersonaDTO>? ListaPersonaDTO { get; set; }
    }
}
