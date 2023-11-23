using System;

namespace App.Domain.Entities
{
	public class Pais
	{
		#region Properties
		/// <summary>
		/// Gets or sets the IdPais value.
		/// </summary>
		public int IdPais {get; set;} 

		/// <summary>
		/// Gets or sets the Codigo value.
		/// </summary>
		public string? Codigo {get; set;} 

		/// <summary>
		/// Gets or sets the NombrePais value.
		/// </summary>
		public string? NombrePais {get; set;} 

		#endregion
	}
}
