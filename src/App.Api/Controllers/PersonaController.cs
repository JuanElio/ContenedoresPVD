using App.Application.Interfaces;
using App.Application.Services;
using App.ModelDto.Commons;
using App.ModelDto.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;
        private readonly ILogger<PersonaController> _logger;

        public PersonaController(IPersonaService personaService, ILogger<PersonaController> logger)
        {
            _personaService = personaService;
            _logger = logger;
        }


        [HttpGet("GetListarPersonas")]
        public async Task<IActionResult> ListaPersonas(int numeropagina=1, int cantfilas=10, string nombre = "", string codigoTipoIdentidad = "", string numeroDocumento = "")
        {

            _logger.LogDebug("Ingreso en GetListarPersonas");

            var response = new ResponsePaginado<List<PersonaDTO>>();

            try
            {
                var result = await _personaService.Listar( numeropagina,  cantfilas,  nombre.Trim(),  codigoTipoIdentidad.Trim(),  numeroDocumento.Trim());
                response.Data = result.ListaPersonaDTO;
                response.TotalPaginas = result.TotalPaginas;
                response.TotalRegistros = result.TotalRegistros;

                response.IsSuccess = true;
            }
            catch (Exception ex) {
                _logger.LogError(ex.ToString());
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        //[HttpPost("Agregar")]
        //public async Task<IActionResult> Agregar(PersonaRequestDTO param)
        //{
        //    var response = new Response<int>();

        //    try
        //    {
        //        DateTime? fechaIngreso = null;

        //        if (!string.IsNullOrEmpty(param.FechaIngreso))
        //        {
        //            fechaIngreso = DateTime.ParseExact(param.FechaIngreso, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        //        }

        //        PersonaDTO persona = new PersonaDTO
        //        {
        //            Nombres = param.Nombres,
        //            ApellidoMaterno = param.ApellidoMaterno,
        //            ApellidoPaterno = param.ApellidoPaterno,
        //            NumeroDocumento = param.Dni
        //            //Direccion = param.Direccion,
        //            //FechaIngreso = fechaIngreso,
        //            //GuidRegistro = param.GuidRegistro,
        //            //Creador = param.Creador,
        //            //SituacionRegistro = "A"
        //        };

        //        var id = await _personaService.Agregar(persona);

        //        response.Data = id;
        //        response.IsSuccess = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.ToString());
        //        response.Data = 0;
        //        response.IsSuccess = false;
        //        response.Message = ex.Message;
        //    }

        //    return Ok(response);

        //}

        //[HttpGet("Obtener/{tipo}/{numero}")]
        //public async Task<IActionResult> ObtenerPorTipoNumero(string tipo, string numero)
        //{
        //    var response = new Response<PersonaDTO>();
        //    try
        //    {
        //        var result = await _personaService.ObtenerPorTipoNumero(tipo,  numero);
        //        if (result == null) return NotFound();

        //        response.Data = result;
        //        response.IsSuccess = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        string msgerror = GetErrorMessage(ex);
        //        _logger.LogError(msgerror);

        //        response.IsSuccess = false;
        //        response.Message = msgerror;
        //    }
        //    return Ok(response);
        //}
        ////ObtenerPorNombres(string nombre)
        //[HttpGet("GetListarPersonaPorNombre")]
        //public async Task<IActionResult> ObtenerPorNombres( string nombres)
        //{

        //    _logger.LogDebug("Ingreso en GetListarPersonas");

        //    var response = new Response<List<PersonaDTO>>();

        //    try
        //    {
        //        var result = await _personaService.ObtenerPorNombres(nombres);
        //        response.Data = result;
        //        response.IsSuccess = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.ToString());
        //        response.IsSuccess = false;
        //        response.Message = ex.Message;
        //    }

        //    return Ok(response);
        //}

        [NonAction]
        private static string GetErrorMessage(Exception ex)
        {
            string msgerror = ex.ToString();
            if (ex.InnerException != null)
                msgerror = msgerror + " " + ex.InnerException.Message ?? "";

            return msgerror;
        }

    }
}
