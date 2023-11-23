using App.Application.Interfaces;
using App.ModelDto.Commons;
using App.ModelDto.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CentroPobladoController : ControllerBase
	{
		private readonly ICentroPobladoService _centropobladoService;
		private readonly ILogger<CentroPobladoController> _logger;

		public CentroPobladoController(ICentroPobladoService centropobladoService, ILogger<CentroPobladoController> logger)
		{
			_centropobladoService = centropobladoService;
			_logger = logger;
		}

		//[HttpGet("Obtener/{id}")]
		//public async Task<IActionResult> Obtener(int id)
		//{
		//	var response = new Response<CentropobladoDTO>();
		//	try
		//	{
		//		var result = await _centropobladoService.ObtenerPorClave(id);
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

		[HttpGet("Listar")]
        public async Task<IActionResult> Listar(int numeropagina = 1, int cantfilas = 10, string nombre = "", string ubigeoReniec = "", string ubigeoInei = "")
        {
			var response = new ResponsePaginado<List<CentroPobladoDTO>>();
			try
			{
				var result = await _centropobladoService.Listar( numeropagina,  cantfilas, nombre.Trim(), ubigeoReniec.Trim(),  ubigeoInei.Trim());
				response.Data = result.ListaCentroPobladoDTO;
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
		public async Task<IActionResult> Agregar([FromBody] CentroPobladoDTO param)
		{
			var response = new Response<int>();
			try
			{
				var id = await _centropobladoService.Agregar(param);
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
		//public async Task<IActionResult> Actualizar(int id, [FromBody] CentroPobladoDTO param)
		//{
		//	var response = new Response<int>();
		//	try
		//	{
		//		var item = await _centropobladoService.ObtenerPorClave(id);
		//		if (item == null) return NotFound();

		//		//Map campos que se requiere actualizar


		//		await _centropobladoService.Actualizar(item);

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
		//		var item = await _centropobladoService.ObtenerPorClave(id);
		//		if (item == null) return NotFound();

		//		await _centropobladoService.Eliminar(id);

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
