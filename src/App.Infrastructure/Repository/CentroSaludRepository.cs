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
	public class CentroSaludRepository : UtilRepository, ICentroSaludRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly string _connectionString;
		private readonly ILogger<CentroSaludRepository> _logger;

		public CentroSaludRepository(ApplicationDbContext context, ILogger<CentroSaludRepository> logger){
			_context = context;
			_logger = logger;
			_connectionString = _context.Database.GetConnectionString();
		}

		#region Methods

		/// <summary>
		/// Saves a record to the CentroSalud table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<int> Agregar(CentroSaludDTO param)
		{

			int id = 0;

			SqlParameter[] sqlparam = new SqlParameter[17];

			/*
			if (string.IsNullOrEmpty(param.SituacionRegistro))
				param.SituacionRegistro = "A";

			if (param.FechaCreacion == null)
				param.FechaCreacion = DateTime.Now;

			if( string.IsNullOrEmpty(param.GuidRegistro))
				param.GuidRegistro = System.Guid.NewGuid().ToString();
			*/

			sqlparam[0] = new SqlParameter("@IdCentroSalud",this.SetDbInt(param.IdCentroSalud));
			sqlparam[1] = new SqlParameter("@CodigoCentroSalud",this.SetDbString(param.CodigoCentroSalud));
			sqlparam[2] = new SqlParameter("@NombreCentroSalud",this.SetDbString(param.NombreCentroSalud));
			sqlparam[3] = new SqlParameter("@Institucion",this.SetDbString(param.Institucion));
			sqlparam[4] = new SqlParameter("@Clasificacion",this.SetDbString(param.Clasificacion));
			sqlparam[5] = new SqlParameter("@Tipo",this.SetDbString(param.Tipo));
			sqlparam[6] = new SqlParameter("@Direccion",this.SetDbString(param.Direccion));
			sqlparam[7] = new SqlParameter("@Ruc",this.SetDbString(param.Ruc));
			sqlparam[8] = new SqlParameter("@Longitud",this.SetDbFloat(param.Longitud));
			sqlparam[9] = new SqlParameter("@Latitud",this.SetDbFloat(param.Latitud));
			sqlparam[10] = new SqlParameter("@Condicion",this.SetDbString(param.Condicion));
			sqlparam[11] = new SqlParameter("@Disa",this.SetDbString(param.Disa));
			sqlparam[12] = new SqlParameter("@Categoria",this.SetDbString(param.Categoria));
			sqlparam[13] = new SqlParameter("@Horario",this.SetDbString(param.Horario));
			sqlparam[14] = new SqlParameter("@DirectorMedico",this.SetDbString(param.DirectorMedico));
			sqlparam[15] = new SqlParameter("@Telefono",this.SetDbString(param.Telefono));
			sqlparam[16] = new SqlParameter("@UbigeoInei",this.SetDbString(param.UbigeoInei));

			await using (SqlConnection connection = new(_connectionString))
			{

				SqlCommand command = new SqlCommand();
				command.Connection = connection;
				command.CommandText = "app_centrosalud_agregar";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddRange(sqlparam);

				// Open the connection and execute the reader.
				await connection.OpenAsync();

				/*await command.ExecuteNonQueryAsync();*/
				var retorno = await command.ExecuteScalarAsync();

				if (retorno != null) id = Convert.ToInt32(retorno);

			}

			return id;

		}

		/// <summary>
		/// Saves a record to the CentroSalud table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task Actualizar(CentroSaludDTO param)
		{

			/*if (param.FechaModificacion == null) param.FechaModificacion = DateTime.Now;*/

			SqlParameter[] sqlparam = new SqlParameter[17];

			sqlparam[0] = new SqlParameter("@IdCentroSalud",this.SetDbInt(param.IdCentroSalud));
			sqlparam[1] = new SqlParameter("@CodigoCentroSalud",this.SetDbString(param.CodigoCentroSalud));
			sqlparam[2] = new SqlParameter("@NombreCentroSalud",this.SetDbString(param.NombreCentroSalud));
			sqlparam[3] = new SqlParameter("@Institucion",this.SetDbString(param.Institucion));
			sqlparam[4] = new SqlParameter("@Clasificacion",this.SetDbString(param.Clasificacion));
			sqlparam[5] = new SqlParameter("@Tipo",this.SetDbString(param.Tipo));
			sqlparam[6] = new SqlParameter("@Direccion",this.SetDbString(param.Direccion));
			sqlparam[7] = new SqlParameter("@Ruc",this.SetDbString(param.Ruc));
			sqlparam[8] = new SqlParameter("@Longitud",this.SetDbFloat(param.Longitud));
			sqlparam[9] = new SqlParameter("@Latitud",this.SetDbFloat(param.Latitud));
			sqlparam[10] = new SqlParameter("@Condicion",this.SetDbString(param.Condicion));
			sqlparam[11] = new SqlParameter("@Disa",this.SetDbString(param.Disa));
			sqlparam[12] = new SqlParameter("@Categoria",this.SetDbString(param.Categoria));
			sqlparam[13] = new SqlParameter("@Horario",this.SetDbString(param.Horario));
			sqlparam[14] = new SqlParameter("@DirectorMedico",this.SetDbString(param.DirectorMedico));
			sqlparam[15] = new SqlParameter("@Telefono",this.SetDbString(param.Telefono));
			sqlparam[16] = new SqlParameter("@UbigeoInei",this.SetDbString(param.UbigeoInei));

			await using (SqlConnection connection = new(_connectionString))
			{

				SqlCommand command = new SqlCommand();
				command.Connection = connection;
				command.CommandText = "app_centrosalud_actualizar";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddRange(sqlparam);

				// Open the connection and execute the reader.
				await connection.OpenAsync();

				await command.ExecuteNonQueryAsync();
			}
		}

		/// <summary>
		/// Delete a record to the CentroSalud table.
		/// </summary>
		public async Task Eliminar(int param)
		{

			SqlParameter[] sqlparam = new SqlParameter[1];

			sqlparam[0] = new SqlParameter("@",param );

			await using (SqlConnection connection = new(_connectionString))
			{

				SqlCommand command = new SqlCommand();
				command.Connection = connection;
				command.CommandText = "app_centrosalud_eliminar";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddRange(sqlparam);

				// Open the connection and execute the reader.
				await connection.OpenAsync();

				await command.ExecuteNonQueryAsync();

			}
		}

		/// <summary>
		/// Selects all records from the CentroSalud table.
		/// </summary>
		public async Task<CentroSaludListaDTO> Listar(int numeropagina, int cantfilas,string nombre, string ubigeoReniec, string ubigeoInei)
		{

			List<CentroSaludDTO> lista = new List<CentroSaludDTO>();
            //List<CentroPobladoDTO> lista = new List<CentroPobladoDTO>();
            CentroSaludListaDTO centroSaludListaDTO = new CentroSaludListaDTO();

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
				command.CommandText = "app_centrosalud_listar";
				command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(sqlparam);

                //Open the connection and execute the reader.
                await connection.OpenAsync();
				using (SqlDataReader reader = await command.ExecuteReaderAsync()) {

					if (reader.HasRows) {

						while (reader.Read()) {

                            CentroSaludDTO registro = new CentroSaludDTO();

							CreateMap(registro, reader);

							lista.Add(registro);
						}
					}
					reader.Close();
				}
                centroSaludListaDTO.ListaCentroSaludDTO = lista;
                centroSaludListaDTO.TotalPaginas = (int)sqlparam[5].Value;
                centroSaludListaDTO.TotalRegistros = (int)sqlparam[6].Value;
            }
            return centroSaludListaDTO;

        }
		/// <summary>
		/// Set records from the CentroSalud table.
		/// </summary>
		public void CreateMap (CentroSaludDTO registro, SqlDataReader reader)
		{
			registro.IdCentroSalud = this.GetDbInt(reader, "IdCentroSalud");
			registro.CodigoCentroSalud = this.GetDbString(reader, "CodigoCentroSalud");
			registro.NombreCentroSalud = this.GetDbString(reader, "NombreCentroSalud");
			registro.Institucion = this.GetDbString(reader, "Institucion");
			registro.Clasificacion = this.GetDbString(reader, "Clasificacion");
			registro.Tipo = this.GetDbString(reader, "Tipo");
			registro.Direccion = this.GetDbString(reader, "Direccion");
			registro.Ruc = this.GetDbString(reader, "Ruc");
			registro.Longitud = this.GetDbFloat(reader, "Longitud");
			registro.Latitud = this.GetDbFloat(reader, "Latitud");
			registro.Condicion = this.GetDbString(reader, "Condicion");
			registro.Disa = this.GetDbString(reader, "Disa");
			registro.Categoria = this.GetDbString(reader, "Categoria");
			registro.Horario = this.GetDbString(reader, "Horario");
			registro.DirectorMedico = this.GetDbString(reader, "DirectorMedico");
			registro.Telefono = this.GetDbString(reader, "Telefono");
			registro.UbigeoInei = this.GetDbString(reader, "UbigeoInei");
            registro.UbigeoReniec = this.GetDbString(reader, "UbigeoReniec");
            //registro.totalPagina = this.GetDbInt(reader, "totalPagina");
        }

		#endregion
	}
}
