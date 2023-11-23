using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using App.Infrastructure.Interfaces;
using App.Infrastructure.Persistence.Context;
using App.Infrastructure.Utils;
using App.ModelDto.DTOs;

namespace App.Infrastructure.Repository
{
	public class ComisariaRepository : UtilRepository, IComisariaRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly string _connectionString;
		private readonly ILogger<ComisariaRepository> _logger;

		public ComisariaRepository(ApplicationDbContext context, ILogger<ComisariaRepository> logger){
			_context = context;
			_logger = logger;
			_connectionString = _context.Database.GetConnectionString();
		}

		#region Methods

		/// <summary>
		/// Saves a record to the Comisaria table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		//public async Task<int> Agregar(ComisariaDTO param)
		//{

		//	int id = 0;

		//	SqlParameter[] sqlparam = new SqlParameter[8];

		//	/*
		//	if (string.IsNullOrEmpty(param.SituacionRegistro))
		//		param.SituacionRegistro = "A";

		//	if (param.FechaCreacion == null)
		//		param.FechaCreacion = DateTime.Now;

		//	if( string.IsNullOrEmpty(param.GuidRegistro))
		//		param.GuidRegistro = System.Guid.NewGuid().ToString();
		//	*/

		//	sqlparam[0] = new SqlParameter("@IdComisaria",this.SetDbInt(param.IdComisaria));
		//	sqlparam[1] = new SqlParameter("@NombreComisaria",this.SetDb_NO_DEFINIDO(param.NombreComisaria));
		//	sqlparam[2] = new SqlParameter("@Estado",this.SetDbString(param.Estado));
		//	sqlparam[3] = new SqlParameter("@Direccion",this.SetDb_NO_DEFINIDO(param.Direccion));
		//	sqlparam[4] = new SqlParameter("@Tipo",this.SetDbString(param.Tipo));
		//	sqlparam[5] = new SqlParameter("@Observacion",this.SetDb_NO_DEFINIDO(param.Observacion));
		//	sqlparam[6] = new SqlParameter("@UbigeoInei",this.SetDbString(param.UbigeoInei));
		//	sqlparam[7] = new SqlParameter("@UbigeoReniec",this.SetDbString(param.UbigeoReniec));

		//	await using (SqlConnection connection = new(_connectionString))
		//	{

		//		SqlCommand command = new SqlCommand();
		//		command.Connection = connection;
		//		command.CommandText = "app_comisaria_agregar";
		//		command.CommandType = CommandType.StoredProcedure;
		//		command.Parameters.AddRange(sqlparam);

		//		// Open the connection and execute the reader.
		//		await connection.OpenAsync();

		//		/*await command.ExecuteNonQueryAsync();*/
		//		var retorno = await command.ExecuteScalarAsync();

		//		if (retorno != null) id = Convert.ToInt32(retorno);

		//	}

		//	return id;

		//}

		/// <summary>
		/// Saves a record to the Comisaria table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		//public async Task Actualizar(ComisariaDTO param)
		//{

		//	/*if (param.FechaModificacion == null) param.FechaModificacion = DateTime.Now;*/

		//	SqlParameter[] sqlparam = new SqlParameter[8];

		//	sqlparam[0] = new SqlParameter("@IdComisaria",this.SetDbInt(param.IdComisaria));
		//	sqlparam[1] = new SqlParameter("@NombreComisaria",this.SetDb_NO_DEFINIDO(param.NombreComisaria));
		//	sqlparam[2] = new SqlParameter("@Estado",this.SetDbString(param.Estado));
		//	sqlparam[3] = new SqlParameter("@Direccion",this.SetDb_NO_DEFINIDO(param.Direccion));
		//	sqlparam[4] = new SqlParameter("@Tipo",this.SetDbString(param.Tipo));
		//	sqlparam[5] = new SqlParameter("@Observacion",this.SetDb_NO_DEFINIDO(param.Observacion));
		//	sqlparam[6] = new SqlParameter("@UbigeoInei",this.SetDbString(param.UbigeoInei));
		//	sqlparam[7] = new SqlParameter("@UbigeoReniec",this.SetDbString(param.UbigeoReniec));

		//	await using (SqlConnection connection = new(_connectionString))
		//	{

		//		SqlCommand command = new SqlCommand();
		//		command.Connection = connection;
		//		command.CommandText = "app_comisaria_actualizar";
		//		command.CommandType = CommandType.StoredProcedure;
		//		command.Parameters.AddRange(sqlparam);

		//		// Open the connection and execute the reader.
		//		await connection.OpenAsync();

		//		await command.ExecuteNonQueryAsync();
		//	}
		//}

		///// <summary>
		///// Delete a record to the Comisaria table.
		///// </summary>
		//public async Task Eliminar(int param)
		//{

		//	SqlParameter[] sqlparam = new SqlParameter[1];

		//	sqlparam[0] = new SqlParameter("@",param );

		//	await using (SqlConnection connection = new(_connectionString))
		//	{

		//		SqlCommand command = new SqlCommand();
		//		command.Connection = connection;
		//		command.CommandText = "app_comisaria_eliminar";
		//		command.CommandType = CommandType.StoredProcedure;
		//		command.Parameters.AddRange(sqlparam);

		//		// Open the connection and execute the reader.
		//		await connection.OpenAsync();

		//		await command.ExecuteNonQueryAsync();

		//	}
		//}

		/// <summary>
		/// Selects all records from the Comisaria table.
		/// </summary>
		public async Task<ComisariaListaDTO> Listar(int numeropagina, int cantfilas, string nombre, string ubigeoReniec, string ubigeoInei)
		{

			List<ComisariaDTO> lista = new List<ComisariaDTO>();
            ComisariaListaDTO comisariaListaDTO = new ComisariaListaDTO();

            SqlParameter[] sqlparam = new SqlParameter[7];

            sqlparam[0] = new SqlParameter("@numeropagina", this.SetDbInt(numeropagina));
            sqlparam[1] = new SqlParameter("@cantfilas", this.SetDbInt(cantfilas));
            sqlparam[2] = new SqlParameter("@nombre", this.SetDbString(nombre));
            sqlparam[3] = new SqlParameter("@ubigeoReniec", this.SetDbString(ubigeoReniec));
            sqlparam[4] = new SqlParameter("@ubigeoInei", this.SetDbString(ubigeoInei));
            sqlparam[5] = new SqlParameter("@piPagTotPag", SqlDbType.Int);
            sqlparam[5].Direction = ParameterDirection.Output;
            sqlparam[6] = new SqlParameter("@piPagTotReg", SqlDbType.Int);
            sqlparam[6].Direction = ParameterDirection.Output;

            await using (SqlConnection connection = new SqlConnection(_connectionString))
			{

				//Create the command and set its properties.
				SqlCommand command = new SqlCommand();
				command.Connection = connection;
				command.CommandText = "app_comisaria_listar";
				command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(sqlparam);

                //Open the connection and execute the reader.
                await connection.OpenAsync();
				using (SqlDataReader reader = await command.ExecuteReaderAsync()) {

					if (reader.HasRows) {

						while (reader.Read()) {

							ComisariaDTO registro = new ComisariaDTO();

							CreateMap(registro, reader);

							lista.Add(registro);
						}
					}
					reader.Close();
				}
                comisariaListaDTO.ListaComisariaDTO = lista;
                comisariaListaDTO.TotalPaginas = (int)sqlparam[5].Value;
                comisariaListaDTO.TotalRegistros = (int)sqlparam[6].Value;
            }
			return comisariaListaDTO;

		}
		/// <summary>
		/// Set records from the Comisaria table.
		/// </summary>
		public void CreateMap (ComisariaDTO registro, SqlDataReader reader)
		{
			registro.IdComisaria = this.GetDbInt(reader, "IdComisaria");
			registro.NombreComisaria = this.GetDbString(reader, "NombreComisaria");
			registro.Estado = this.GetDbString(reader, "Estado");
			registro.Direccion = this.GetDbString(reader, "Direccion");
			registro.Tipo = this.GetDbString(reader, "Tipo");
			registro.Observacion = this.GetDbString(reader, "Observacion");
			registro.UbigeoInei = this.GetDbString(reader, "UbigeoInei");
			registro.UbigeoReniec = this.GetDbString(reader, "UbigeoReniec");
            //registro.totalPagina = this.GetDbInt(reader, "totalPagina");
        }

		#endregion
	}
}
