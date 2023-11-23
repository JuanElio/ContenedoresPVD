namespace App.ModelDto.DTOs
{
    public class ClienteRequestDTO
    {
        #region Properties
        /// <summary>
        /// Gets or sets the IdCliente value.
        /// </summary>
        public int IdCliente { get; set; }

        /// <summary>
        /// Gets or sets the RazonSocial value.
        /// </summary>
        public string? RazonSocial { get; set; }

        /// <summary>
        /// Gets or sets the TipoDocumento value.
        /// </summary>
        public string? TipoDocumento { get; set; }

        /// <summary>
        /// Gets or sets the EroDocumento value.
        /// </summary>
        public string? NumeroDocumento { get; set; }

        /// <summary>
        /// Gets or sets the Direccion value.
        /// </summary>
        public string? Direccion { get; set; }

        /// <summary>
        /// Gets or sets the FechaIngreso value.
        /// </summary>
        public string? FechaIngreso { get; set; }

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
