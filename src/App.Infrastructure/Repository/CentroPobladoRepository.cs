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
	public class CentroPobladoRepository : UtilRepository, ICentroPobladoRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly string _connectionString;
		private readonly ILogger<CentroPobladoRepository> _logger;

		public CentroPobladoRepository(ApplicationDbContext context, ILogger<CentroPobladoRepository> logger){
			_context = context;
			_logger = logger;
			_connectionString = _context.Database.GetConnectionString();
		}

		#region Methods

		/// <summary>
		/// Saves a record to the CentroPoblado table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<int> Agregar(CentroPobladoDTO param)
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

			sqlparam[0] = new SqlParameter("@IdCentroPoblado",this.SetDbInt(param.IdCentroPoblado));
			sqlparam[1] = new SqlParameter("@CodigoCentroPoblado",this.SetDbString(param.CodigoCentroPoblado));
			sqlparam[2] = new SqlParameter("@NombreCentroPoblado",this.SetDbString(param.NombreCentroPoblado));
			sqlparam[3] = new SqlParameter("@RegionNatural",this.SetDbString(param.RegionNatural));
			sqlparam[4] = new SqlParameter("@Categoria",this.SetDbString(param.Categoria));
			sqlparam[5] = new SqlParameter("@Tipo",this.SetDbString(param.Tipo));
			sqlparam[6] = new SqlParameter("@Longitud",this.SetDbFloat(param.Longitud));
			sqlparam[7] = new SqlParameter("@Latitud",this.SetDbFloat(param.Latitud));
			sqlparam[8] = new SqlParameter("@Altitud",this.SetDbInt(param.Altitud));
			sqlparam[9] = new SqlParameter("@CantidadVivienda",this.SetDbInt(param.CantidadVivienda));
			sqlparam[10] = new SqlParameter("@CantidadHogar",this.SetDbInt(param.CantidadHogar));
			sqlparam[11] = new SqlParameter("@PoblacionVulnerable",this.SetDbInt(param.PoblacionVulnerable));
			sqlparam[12] = new SqlParameter("@PoblacionTotal",this.SetDbInt(param.PoblacionTotal));
			sqlparam[13] = new SqlParameter("@TotalHombres",this.SetDbInt(param.TotalHombres));
			sqlparam[14] = new SqlParameter("@TotalMujeres",this.SetDbInt(param.TotalMujeres));
			sqlparam[15] = new SqlParameter("@UbigeoReniec",this.SetDbString(param.UbigeoReniec));
			sqlparam[16] = new SqlParameter("@UbigeoInei",this.SetDbString(param.UbigeoInei));

			await using (SqlConnection connection = new(_connectionString))
			{

				SqlCommand command = new SqlCommand();
				command.Connection = connection;
				command.CommandText = "app_centropoblado_agregar";
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
		/// Saves a record to the CentroPoblado table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task Actualizar(CentroPobladoDTO param)
		{

			/*if (param.FechaModificacion == null) param.FechaModificacion = DateTime.Now;*/

			SqlParameter[] sqlparam = new SqlParameter[17];

			sqlparam[0] = new SqlParameter("@IdCentroPoblado",this.SetDbInt(param.IdCentroPoblado));
			sqlparam[1] = new SqlParameter("@CodigoCentroPoblado",this.SetDbString(param.CodigoCentroPoblado));
			sqlparam[2] = new SqlParameter("@NombreCentroPoblado",this.SetDbString(param.NombreCentroPoblado));
			sqlparam[3] = new SqlParameter("@RegionNatural",this.SetDbString(param.RegionNatural));
			sqlparam[4] = new SqlParameter("@Categoria",this.SetDbString(param.Categoria));
			sqlparam[5] = new SqlParameter("@Tipo",this.SetDbString(param.Tipo));
			sqlparam[6] = new SqlParameter("@Longitud",this.SetDbFloat(param.Longitud));
			sqlparam[7] = new SqlParameter("@Latitud",this.SetDbFloat(param.Latitud));
			sqlparam[8] = new SqlParameter("@Altitud",this.SetDbInt(param.Altitud));
			sqlparam[9] = new SqlParameter("@CantidadVivienda",this.SetDbInt(param.CantidadVivienda));
			sqlparam[10] = new SqlParameter("@CantidadHogar",this.SetDbInt(param.CantidadHogar));
			sqlparam[11] = new SqlParameter("@PoblacionVulnerable",this.SetDbInt(param.PoblacionVulnerable));
			sqlparam[12] = new SqlParameter("@PoblacionTotal",this.SetDbInt(param.PoblacionTotal));
			sqlparam[13] = new SqlParameter("@TotalHombres",this.SetDbInt(param.TotalHombres));
			sqlparam[14] = new SqlParameter("@TotalMujeres",this.SetDbInt(param.TotalMujeres));
			sqlparam[15] = new SqlParameter("@UbigeoReniec",this.SetDbString(param.UbigeoReniec));
			sqlparam[16] = new SqlParameter("@UbigeoInei",this.SetDbString(param.UbigeoInei));

			await using (SqlConnection connection = new(_connectionString))
			{

				SqlCommand command = new SqlCommand();
				command.Connection = connection;
				command.CommandText = "app_centropoblado_actualizar";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddRange(sqlparam);

				// Open the connection and execute the reader.
				await connection.OpenAsync();

				await command.ExecuteNonQueryAsync();
			}
		}

		/// <summary>
		/// Delete a record to the CentroPoblado table.
		/// </summary>
		public async Task Eliminar(int param)
		{

			SqlParameter[] sqlparam = new SqlParameter[1];

			sqlparam[0] = new SqlParameter("@",param );

			await using (SqlConnection connection = new(_connectionString))
			{

				SqlCommand command = new SqlCommand();
				command.Connection = connection;
				command.CommandText = "app_centropoblado_eliminar";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddRange(sqlparam);

				// Open the connection and execute the reader.
				await connection.OpenAsync();

				await command.ExecuteNonQueryAsync();

			}
		}

		/// <summary>
		/// Selects all records from the CentroPoblado table.
		/// </summary>
		public async Task<CentroPobladoListaDTO> Listar(int numeropagina, int cantfilas, string nombre, string ubigeoReniec, string ubigeoInei)
		{

			List<CentroPobladoDTO> lista = new List<CentroPobladoDTO>();
			CentroPobladoListaDTO centroPobladoListaDTO = new CentroPobladoListaDTO();

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
				command.CommandText = "app_centropoblado_listar";
				command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(sqlparam);

                //Open the connection and execute the reader.
                await connection.OpenAsync();
				using (SqlDataReader reader = await command.ExecuteReaderAsync()) {

					if (reader.HasRows) {

						while (reader.Read()) {

                            CentroPobladoDTO registro = new CentroPobladoDTO();

							CreateMap(registro, reader);

							lista.Add(registro);
						}
					}
					reader.Close();
				}
                centroPobladoListaDTO.ListaCentroPobladoDTO = lista;
                centroPobladoListaDTO.TotalPaginas = (int)sqlparam[5].Value;
                centroPobladoListaDTO.TotalRegistros = (int)sqlparam[6].Value;
                //sqlparam[5].Value;

            }
			return centroPobladoListaDTO;

		}
		/// <summary>
		/// Set records from the CentroPoblado table.
		/// </summary>
		public void CreateMap (CentroPobladoDTO registro, SqlDataReader reader)
		{
			registro.IdCentroPoblado = this.GetDbInt(reader, "IdCentroPoblado");
			registro.CodigoCentroPoblado = this.GetDbString(reader, "CodigoCentroPoblado");
			registro.NombreCentroPoblado = this.GetDbString(reader, "NombreCentroPoblado");
			registro.RegionNatural = this.GetDbString(reader, "RegionNatural");
			registro.Categoria = this.GetDbString(reader, "Categoria");
			registro.Tipo = this.GetDbString(reader, "Tipo");
			registro.Longitud = this.GetDbFloat(reader, "Longitud");
			registro.Latitud = this.GetDbFloat(reader, "Latitud");
			registro.Altitud = this.GetDbInt(reader, "Altitud");
			registro.CantidadVivienda = this.GetDbInt(reader, "CantidadVivienda");
			registro.CantidadHogar = this.GetDbInt(reader, "CantidadHogar");
			registro.PoblacionVulnerable = this.GetDbInt(reader, "PoblacionVulnerable");
			registro.PoblacionTotal = this.GetDbInt(reader, "PoblacionTotal");
			registro.TotalHombres = this.GetDbInt(reader, "TotalHombres");
			registro.TotalMujeres = this.GetDbInt(reader, "TotalMujeres");
			registro.UbigeoReniec = this.GetDbString(reader, "UbigeoReniec");
			registro.UbigeoInei = this.GetDbString(reader, "UbigeoInei");
            //registro.totalPagina = this.GetDbInt(reader, "totalPagina");
        }

		#endregion
	}
}
