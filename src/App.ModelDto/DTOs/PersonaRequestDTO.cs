namespace App.ModelDto.DTOs
{
    public class PersonaRequestDTO
    {
        #region Properties
        /// <summary>
        /// Gets or sets the IdPersona value.
        /// </summary>
        public int IdPersona { get; set; }

        /// <summary>
        /// Gets or sets the Nombres value.
        /// </summary>
        public string? Nombres { get; set; }

        /// <summary>
        /// Gets or sets the ApellidoPaterno value.
        /// </summary>
        public string? ApellidoPaterno { get; set; }

        /// <summary>
        /// Gets or sets the ApellidoMaterno value.
        /// </summary>
        public string? ApellidoMaterno { get; set; }

        /// <summary>
        /// Gets or sets the Dni value.
        /// </summary>
        public string? Dni { get; set; }

        /// <summary>
        /// Gets or sets the Direccion value.
        /// </summary>
        public string? Direccion { get; set; }

        /// <summary>
        /// Gets or sets the FechaIngreso value.
        /// </summary>
        public string FechaIngreso { get; set; }

        /// <summary>
        /// Gets or sets the GuidRegistro value.
        /// </summary>
        public string? GuidRegistro { get; set; }

        /// <summary>
        /// Gets or sets the SituacionRegistro value.
        /// </summary>
        public string? SituacionRegistro { get; set; }

        /// <summary>
        /// Gets or sets the Creador value.
        /// </summary>
        public string? Creador { get; set; }

        #endregion
    }
}
