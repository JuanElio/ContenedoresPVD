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
using App.Domain.Entities;
using App.ModelDto.DTOs;


namespace App.Infrastructure.Repository
{
	public class RedVialNacionalRepository : UtilRepository, IRedVialNacionalRepository
    {
		private readonly ApplicationDbContext _context;
        private readonly string _connectionString;
        private readonly ILogger<RedVialNacionalRepository> _logger;

        public RedVialNacionalRepository(ApplicationDbContext context, ILogger<RedVialNacionalRepository> logger)
        {
            _context = context;
            _logger = logger;
            _connectionString = _context.Database.GetConnectionString();
        }

		#region Methods

		/// <summary>
		/// Saves a record to the RedVialNacional table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<int> Agregar(RedVialNacional param)
		{
			_context.RedVialNacional.Add(param);
			await _context.SaveChangesAsync();
			return param.IdRedVialNacional;
		}

		/// <summary>
		/// Saves a record to the RedVialNacional table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task Actualizar(RedVialNacional param)
		{
			_context.ChangeTracker.Clear();
			_context.Entry(param).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

        /// <summary>
        /// Delete a record to the RedVialNacional table.
        /// </summary>
        //public async Task Eliminar(int param)
        //{
        //	var item = await _context.RedVialNacional.Where(x => x. == param).FirstOrDefaultAsync();

        //	if (item != null)
        //	{
        //		_context.Proveedor.Remove(item);
        //		await _context.SaveChangesAsync();
        //	}
        //}

        /// <summary>
        /// Selects all records from the RedVialNacional table.
        /// </summary>
        //public async Task<List<RedVialNacionalDTO>> Listar(int numeropagina, int cantfilas, string ruta)
        //{
        //          List<RedVialNacionalDTO> lista = new List<RedVialNacionalDTO>();

        //          SqlParameter[] sqlparam = new SqlParameter[3];

        //          sqlparam[0] = new SqlParameter("@numeropagina", this.SetDbInt(numeropagina));
        //          sqlparam[1] = new SqlParameter("@cantfilas", this.SetDbInt(cantfilas));
        //          sqlparam[3] = new SqlParameter("@ruta", this.SetDbString(ruta));

        //          await using (SqlConnection connection = new SqlConnection(_connectionString))
        //          {

        //              //Create the command and set its properties.
        //              SqlCommand command = new SqlCommand();
        //              command.Connection = connection;
        //              command.CommandText = "app_redvialnacional_listar";
        //              command.CommandType = CommandType.StoredProcedure;
        //              command.Parameters.AddRange(sqlparam);

        //              //Open the connection and execute the reader.
        //              await connection.OpenAsync();
        //              using (SqlDataReader reader = await command.ExecuteReaderAsync())
        //              {

        //                  if (reader.HasRows)
        //                  {

        //                      while (reader.Read())
        //                      {
        //                          RedVialNacionalDTO registro = new RedVialNacionalDTO();
        //                          CreateMap(registro, reader);

        //                          lista.Add(registro);
        //                      }
        //                  }
        //                  reader.Close();
        //              }
        //          }
        //          return lista;
        //      }

        public async Task<RedVialNacionalListasDTO> Listar( string ruta)
        {
            RedVialNacionalListasDTO objetoRedVialNacionalDTO = new RedVialNacionalListasDTO();
            //List<RedVialNacionalDTO> listaRedVialNacionalDTO = new List<RedVialNacionalDTO>();
            List<SuperficieRodaduraDTO> lista1 = new List<SuperficieRodaduraDTO>();
            List<LongitudPorDepartamentoDTO> lista2 = new List<LongitudPorDepartamentoDTO>();
            List<RedVialNacionalPuntoPobladoDTO> lista3 = new List<RedVialNacionalPuntoPobladoDTO>();

            SqlParameter[] sqlparam = new SqlParameter[1];


            sqlparam[0] = new SqlParameter("@ruta", this.SetDbString(ruta));

            await using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                //Create the command and set its properties.
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "app_redvialnacional_ruta";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(sqlparam);

                //Open the connection and execute the reader.
                await connection.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            SuperficieRodaduraDTO registro = new SuperficieRodaduraDTO();
                            CreateMapSuperficieRodadura(registro, reader);

                            lista1.Add(registro);
                        }
                    }
                    if (reader.NextResult())
                    {

                        while (reader.Read())
                        {
                            LongitudPorDepartamentoDTO registro = new LongitudPorDepartamentoDTO();
                            CreateMapLongitudPorDepartamento(registro, reader);

                            lista2.Add(registro);
                        }
                    }
                    if (reader.NextResult())
                    {

                        while (reader.Read())
                        {
                            RedVialNacionalPuntoPobladoDTO registro = new RedVialNacionalPuntoPobladoDTO();
                            CreateMapRedVialPunto(registro, reader);

                            lista3.Add(registro);
                        }
                    }
                    reader.Close();
                }
                objetoRedVialNacionalDTO.ListaSuperficieRodadura = lista1;
                objetoRedVialNacionalDTO.LongitudPorDepartamentoDTO = lista2;
                objetoRedVialNacionalDTO.RedVialNacionalPuntoPobladoDTO = lista3;
            }
            return objetoRedVialNacionalDTO;
        }
        //public async Task<List<RedVialNacional>> Listar(string ruta)
        //{
        //    return await _context.RedVialNacional.Where(x => x.Ruta == ruta).ToListAsync();
        //}

        public void CreateMap(RedVialNacionalDTO registro, SqlDataReader reader)
        {
            registro.IdRedVialNacional = this.GetDbInt(reader, "IdRedVialNacional");
            registro.Ruta = this.GetDbString(reader, "Ruta");
            registro.Longitud = this.GetDbFloat(reader, "Longitud");
            registro.Sentido = this.GetDbString(reader, "Sentido");
            registro.Superficie = this.GetDbString(reader, "Superficie");
            registro.Estado = this.GetDbString(reader, "Estado");
            registro.Orientacion = this.GetDbString(reader, "Orientacion");
            registro.BaseLegal = this.GetDbString(reader, "BaseLegal");
            registro.Trayectoria = this.GetDbString(reader, "Trayectoria");
            registro.UbigeoReniec = this.GetDbString(reader, "UbigeoReniec");
        }
        public void CreateMapSuperficieRodadura(SuperficieRodaduraDTO registro, SqlDataReader reader)
        {
            registro.Superficie = this.GetDbString(reader, "superficie");
            registro.Kilometro = this.GetDbDecimal(reader, "kilometro");
            registro.Porcentaje = this.GetDbDecimal(reader, "porcentaje");

        }

        public void CreateMapLongitudPorDepartamento(LongitudPorDepartamentoDTO registro, SqlDataReader reader)
        {
            registro.NombreDepartamento = this.GetDbString(reader, "NombreDepartamento");
            registro.CodigoDep = this.GetDbString(reader, "CodigoDep");
            registro.Tipo = this.GetDbString(reader, "Tipo");
            registro.Kilometro = this.GetDbDecimal(reader, "Kilometro");
            registro.Porcentaje = this.GetDbDecimal(reader, "Porcentaje");

        }
        public void CreateMapRedVialPunto(RedVialNacionalPuntoPobladoDTO registro, SqlDataReader reader)
        {
            registro.NombrePoblado = this.GetDbString(reader, "NombrePoblado");
            registro.Longitud = this.GetDbFloat(reader, "Longitud");
            registro.Latitud = this.GetDbFloat(reader, "Latitud");
            registro.UbigeoReniec = this.GetDbString(reader, "UbigeoReniec");

        }
        #endregion
    }
}
