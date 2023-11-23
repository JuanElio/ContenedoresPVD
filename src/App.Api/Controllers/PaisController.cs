using App.Application.Interfaces;
using App.ModelDto.Commons;
using App.ModelDto.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaisController : ControllerBase
	{
		private readonly IPaisService _paisService;
		private readonly ILogger<PaisController> _logger;

		public PaisController(IPaisService paisService, ILogger<PaisController> logger)
		{
			_paisService = paisService;
			_logger = logger;
		}

		[HttpGet("ObtenerPorCodigoPais")]
		public async Task<IActionResult> ObtenerPorCodigoPais(string codigoPais)
		{
			var response = new Response<PaisDTO>();
			try
			{
				var result = await _paisService.ObtenerPorCodigo(codigoPais);
				if (result == null) return NotFound();

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

		[HttpGet("Listar")]
		public async Task<IActionResult> Listar()
		{
			var response = new Response<List<PaisDTO>>();
			try
			{
				var result = await _paisService.Listar();
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
		//public async Task<IActionResult> Agregar([FromBody] PaisDTO param)
		//{
		//	var response = new Response<int>();
		//	try
		//	{
		//		var id = await _paisService.Agregar(param);
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

		//[HttpPut("Actualizar")]
		//public async Task<IActionResult> Actualizar(int id, [FromBody] PaisDTO param)
		//{
		//	var response = new Response<int>();
		//	try
		//	{
		//		var item = await _paisService.ObtenerPorClave(id);
		//		if (item == null) return NotFound();

		//		//Map campos que se requiere actualizar


		//		await _paisService.Actualizar(item);

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
		//		var item = await _paisService.ObtenerPorClave(id);
		//		if (item == null) return NotFound();

		//		await _paisService.Eliminar(id);

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
