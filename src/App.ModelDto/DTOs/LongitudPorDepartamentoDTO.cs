using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repository
{
    public class LongitudPorDepartamentoDTO
    {
        #region Properties
        /// <summary>
        public string? NombreDepartamento { get; set; }
        public string? CodigoDep { get; set; }
        public string? Tipo { get; set; }

        public Decimal? Kilometro { get; set; }
        public Decimal? Porcentaje { get; set; }

        #endregion
    }
}
