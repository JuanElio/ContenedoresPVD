using App.Application.Interfaces;
using App.ModelDto.Commons;
using App.ModelDto.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CentrosaludController : ControllerBase
	{
		private readonly ICentroSaludService _centrosaludService;
		private readonly ILogger<CentrosaludController> _logger;

		public CentrosaludController(ICentroSaludService centrosaludService, ILogger<CentrosaludController> logger)
		{
			_centrosaludService = centrosaludService;
			_logger = logger;
		}

		//[HttpGet("Obtener/{id}")]
		//public async Task<IActionResult> Obtener(int id)
		//{
		//	var response = new Response<CentrosaludDTO>();
		//	try
		//	{
		//		var result = await _centrosaludService.ObtenerPorClave(id);
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

		//[HttpGet("Listar/{numeropagina}/{cantfilas}/{nombre}/{ubigeoReniec}/{ubigeoInei?}")]
        [HttpGet("Listar")]
        public async Task<IActionResult> Listar(int numeropagina=1, int cantfilas=10, string nombre="", string ubigeoReniec = "", string ubigeoInei = "")
		{
			var response = new ResponsePaginado<List<CentroSaludDTO>>();
			try
			{
				var result = await _centrosaludService.Listar(numeropagina, cantfilas, nombre.Trim(), ubigeoReniec.Trim(), ubigeoInei.Trim() );
                response.Data = result.ListaCentroSaludDTO;
                response.TotalPaginas = result.TotalPaginas;
                response.TotalRegistros = result.TotalRegistros;

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

		[HttpPost("Agregar")]
		public async Task<IActionResult> Agregar([FromBody] CentroSaludDTO param)
		{
			var response = new Response<int>();
			try
			{
				var id = await _centrosaludService.Agregar(param);
				response.Data = id;
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

		//[HttpPut("Actualizar")]
		//public async Task<IActionResult> Actualizar(int id, [FromBody] CentroSaludDTO param)
		//{
		//	var response = new Response<int>();
		//	try
		//	{
		//		var item = await _centrosaludService.ObtenerPorClave(id);
		//		if (item == null) return NotFound();

		//		//Map campos que se requiere actualizar


		//		await _centrosaludService.Actualizar(item);

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

		//[HttpDelete("Eliminar")]
		//public async Task<IActionResult> Eliminar(int id)
		//{
		//	var response = new Response<int>();
		//	try
		//	{
		//		var item = await _centrosaludService.ObtenerPorClave(id);
		//		if (item == null) return NotFound();

		//		await _centrosaludService.Eliminar(id);

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
