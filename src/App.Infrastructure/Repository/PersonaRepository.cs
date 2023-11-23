using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using App.Infrastructure.Interfaces;
using App.Infrastructure.Persistence.Context;
using App.Domain.Entities;
using App.Infrastructure.Utils;
using App.ModelDto.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App.Infrastructure.Repository
{
	public class PersonaRepository : UtilRepository, IPersonaRepository
	{
		private readonly ApplicationDbContext _context;
        private readonly string _connectionString;
        private readonly ILogger<PersonaRepository> _logger;
        public PersonaRepository(ApplicationDbContext context, ILogger<PersonaRepository> logger)
        {
			_context = context;
            _logger = logger;
            _connectionString = _context.Database.GetConnectionString();
        }

		#region Methods

		/// <summary>
		/// Saves a record to the Persona table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public async Task<int> Agregar(Persona param)
		{
			_context.Persona.Add(param);
			await _context.SaveChangesAsync();
			return param.IdPersona;
            //return param.CodigoTipoPersona;
        }

        /// <summary>
        /// Saves a record to the Persona table.
        /// returns True if value saved successfullyelse false
        /// Throw exception with message value 'EXISTS' if the data is duplicate
        /// </summary>
        public async Task Actualizar(Persona param)
		{
			_context.ChangeTracker.Clear();
			_context.Entry(param).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

        /// <summary>
        /// Delete a record to the Persona table.
        /// </summary>
        //public async Task Eliminar(int param)
        //{
        //	var item = await _context.Persona.Where(x => x.IdPersona == param).FirstOrDefaultAsync();

        //	if (item != null)
        //	{
        //		_context.Proveedor.Remove(item);
        //		await _context.SaveChangesAsync();
        //	}
        //}

        /// <summary>
        /// Selects the Single object of Persona table.
        /// </summary>
        //public async Task<Persona> ObtenerPorClave(string param)
        //{
        //	return await _context.Persona.Where(x => x.CodigoTipoPersona == param).FirstOrDefaultAsync();
        //}

        /// <summary>
        /// Selects the Single object of Persona table.
        /// </summary>
        //public async Task<Persona> ObtenerPorGuid(string guid)
        //{
        //	return await _context.Persona.Where(x => x.GuidRegistro == guid).FirstOrDefaultAsync();
        //}
        public async Task<Persona> ObtenerPorTipoNumero(string tipo, string numero)
        {
            return await _context.Persona.Where(x => x.CodigoTipoIdentidad == tipo && x.NumeroDocumento == numero).FirstOrDefaultAsync();
        }
        public async Task<List<Persona>> ObtenerPorNombres(string nombre)
        {
            return await _context.Persona.Where(x => x.NombreCompleto.Contains(nombre) ).ToListAsync();
        }

        /// <summary>
        /// Selects all records from the Persona table.
        /// </summary>
        public async Task<PersonaListaDTO> Listar(int numeropagina, int cantfilas, string nombre, string codigoTipoIdentidad, string numeroDocumento)
		{
            List<PersonaDTO> lista = new List<PersonaDTO>();
            PersonaListaDTO personaListaDTO = new PersonaListaDTO();

            SqlParameter[] sqlparam = new SqlParameter[7];

            sqlparam[0] = new SqlParameter("@numeropagina", this.SetDbInt(numeropagina));
            sqlparam[1] = new SqlParameter("@cantfilas", this.SetDbInt(cantfilas));
            sqlparam[2] = new SqlParameter("@nombreCompleto", this.SetDbString(nombre));
            sqlparam[3] = new SqlParameter("@codigoTipoIdentidad", this.SetDbString(codigoTipoIdentidad));
            sqlparam[4] = new SqlParameter("@numeroDocumento", this.SetDbString(numeroDocumento));
            sqlparam[5] = new SqlParameter("@piPagTotPag", SqlDbType.Int);
            sqlparam[5].Direction = ParameterDirection.Output;
            sqlparam[6] = new SqlParameter("@piPagTotReg", SqlDbType.Int);
            sqlparam[6].Direction = ParameterDirection.Output;

            await using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                //Create the command and set its properties.
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "app_persona_listar";
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

                            PersonaDTO registro = new PersonaDTO();

                            CreateMap(registro, reader);

                            lista.Add(registro);
                        }
                    }
                    reader.Close();
                }
                personaListaDTO.ListaPersonaDTO = lista;
                personaListaDTO.TotalPaginas = (int)sqlparam[5].Value;
                personaListaDTO.TotalRegistros = (int)sqlparam[6].Value;
            }
            return personaListaDTO;
            //return await _context.Persona.ToListAsync();
        }

        public void CreateMap(PersonaDTO registro, SqlDataReader reader)
        {
            registro.IdPersona = this.GetDbInt(reader, "IdPersona");
            registro.CodigoTipoIdentidad = this.GetDbString(reader, "CodigoTipoIdentidad");
            registro.NumeroDocumento = this.GetDbString(reader, "NumeroDocumento");
            registro.ApellidoPaterno = this.GetDbString(reader, "ApellidoPaterno");
            registro.ApellidoMaterno = this.GetDbString(reader, "ApellidoMaterno");
            registro.Nombres = this.GetDbString(reader, "Nombres");
            registro.Sexo = this.GetDbString(reader, "Sexo");
            registro.Telefono = this.GetDbString(reader, "Telefono");
            registro.CodigoTipoPersona = this.GetDbString(reader, "CodigoTipoPersona");
            registro.NombreCompleto = this.GetDbString(reader, "NombreCompleto");
            registro.Estado = this.GetDbString(reader, "Estado");
            registro.CodigoAfp = this.GetDbString(reader, "CodigoAfp");
            //registro.totalPagina = this.GetDbInt(reader, "totalPagina");

    }

        /// <summary>
        /// Selects all records from the Persona table by a foreign key.
        /// </summary>
        //public List<Persona> SelectAllByCodigoTipoIdentidad(string codigoTipoIdentidad)
        //{
        //	using (var vConn = OpenConnection())
        //	{
        //		var vParams = new DynamicParameters();
        //		vParams.Add("@CodigoTipoIdentidad", codigoTipoIdentidad);
        //		return vConn.Query<Persona>("PersonaSelectAll", vParams, commandType: CommandType.StoredProcedure).ToList();
        //	}
        //}

        /// <summary>
        /// Selects all records from the Persona table by a foreign key.
        /// </summary>
        //public List<Persona> SelectAllByCodigoTipoPersona(string codigoTipoPersona)
        //{
        //	 using (var vConn = OpenConnection())
        //		 {
        //		 var vParams = new DynamicParameters();
        //			 vParams.Add("@CodigoTipoPersona",codigoTipoPersona);
        //		 return vConn.Query<Persona>("PersonaSelectAll", vParams, commandType: CommandType.StoredProcedure).ToList();
        //		 }
        //}


        #endregion
    }
}
