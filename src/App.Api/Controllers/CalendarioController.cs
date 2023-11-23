using App.Application.Interfaces;
using App.ModelDto.Commons;
using App.ModelDto.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CalendarioController : ControllerBase
	{
		private readonly ICalendarioService _calendarioService;
		private readonly ILogger<CalendarioController> _logger;

		public CalendarioController(ICalendarioService calendarioService, ILogger<CalendarioController> logger)
		{
			_calendarioService = calendarioService;
			_logger = logger;
		}

		//[HttpGet("Obtener/{id}")]
		//public async Task<IActionResult> Obtener(int id)
		//{
		//	var response = new Response<CalendarioDTO>();
		//	try
		//	{
		//		var result = await _calendarioService.ObtenerPorClave(id);
		//		if (result == null) return NotFound();

		//		response.Data = result;
		//		response.IsSuccess = true;
		//	}
		//	catch (Exception ex)
		//	{
		//		string msgerror = GetErrorMessage(ex);
		//		_logger.LogError(msgerror);

		//		response.IsSuccess = false;
		//		response.Message = msgerror;
		//	}
		//	return Ok(response);
		//}

		[HttpGet("ObtieneFechaFinal")]
		public async Task<IActionResult> ObtieneFechaFinal(string fechaInicio, int cantDias)
		{
			var response = new Response<List<CalendarioDTO>>();
			try
			{
				var result = await _calendarioService.ObtieneFechaFinal( fechaInicio,  cantDias);
				response.Data = result;
				response.IsSuccess = true;
			}
			catch (Exception ex)
			{
				string msgerror = GetErrorMessage(ex);
				_logger.LogError(msgerror);

				response.IsSuccess = false;
				response.Message = msgerror;
			}
			return Ok(response);
		}

		//[HttpPost("Agregar")]
		//public async Task<IActionResult> Agregar([FromBody] CalendarioDTO param)
		//{
		//	var response = new Response<int>();
		//	try
		//	{
		//		var id = await _calendarioService.Agregar(param);
		//		response.Data = id;
		//		response.IsSuccess = true;
		//	}
		//	catch (Exception ex)
		//	{
		//		string msgerror = GetErrorMessage(ex);
		//		_logger.LogError(msgerror);

		//		response.IsSuccess = false;
		//		response.Message = msgerror;
		//	}

		//	return Ok(response);

		//}

		[HttpPut("ActualizarFeriado")]
		public async Task<IActionResult> ActualizarFeriado( [FromBody] CalendarioActualizaDTO param)
		{
			var response = new Response<int>();
			try
			{
				var item = await _calendarioService.ObtenerPorClave(param.Fecha);
				if (item == null) return NotFound();

				//Map campos que se requiere actualizar
				CalendarioActualizaDTO entidad = new CalendarioActualizaDTO();
				entidad.Fecha = item.Fecha.ToString("yyyyMMdd"); ;
				entidad.EsFeriado = param.EsFeriado;
                await _calendarioService.Actualizar(entidad);

				response.Data =Convert.ToInt32(param.Fecha);
				response.IsSuccess = true;
			}
			catch (Exception ex)
			{
				string msgerror = GetErrorMessage(ex);
				_logger.LogError(msgerror);

				response.IsSuccess = false;
				response.Message = msgerror;
			}

			return Ok(response);

		}

		//[HttpDelete("Eliminar")]
		//public async Task<IActionResult> Eliminar(int id)
		//{
		//	var response = new Response<int>();
		//	try
		//	{
		//		var item = await _calendarioService.ObtenerPorClave(id);
		//		if (item == null) return NotFound();

		//		await _calendarioService.Eliminar(id);

		//		response.Data = 1;
		//		response.IsSuccess = true;
		//	}
		//	catch (Exception ex)
		//	{
		//		string msgerror = GetErrorMessage(ex);
		//		_logger.LogError(msgerror);

		//		response.IsSuccess = false;
		//		response.Message = msgerror;
		//	}

		//	return Ok(response);

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
