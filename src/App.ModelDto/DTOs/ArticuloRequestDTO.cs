﻿namespace App.ModelDto.DTOs
{
    public class ArticuloRequestDTO
    {
        #region Properties
        /// <summary>
        /// Gets or sets the IdArticulo value.
        /// </summary>
        public int IdArticulo { get; set; }

        /// <summary>
        /// Gets or sets the Codigo value.
        /// </summary>
        public string? Codigo { get; set; }

        /// <summary>
        /// Gets or sets the Nombre value.
        /// </summary>
        public string? Nombre { get; set; }

        /// <summary>
        /// Gets or sets the UnidadMedida value.
        /// </summary>
        public string? UnidadMedida { get; set; }

        /// <summary>
        /// Gets or sets the Precio value.
        /// </summary>
        public decimal? Precio { get; set; }

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
