using System;

namespace App.Domain.Entities
{
	public class Calendario
	{
		#region Properties
		/// <summary>
		/// Gets or sets the Fecha value.
		/// </summary>
		public DateTime Fecha {get; set;} 

		/// <summary>
		/// Gets or sets the EsFeriado value.
		/// </summary>
		public bool? EsFeriado {get; set;} 

		/// <summary>
		/// Gets or sets the EsFindeSemana value.
		/// </summary>
		public bool? EsFindeSemana {get; set;} 

		#endregion
	}
}
