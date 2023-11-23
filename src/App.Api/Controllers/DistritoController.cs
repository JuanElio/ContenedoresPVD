using App.Application.Interfaces;
using App.ModelDto.Commons;
using App.ModelDto.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DistritoController : ControllerBase
	{
		private readonly IDistritoService _distritoService;
		private readonly ILogger<DistritoController> _logger;

		public DistritoController(IDistritoService distritoService, ILogger<DistritoController> logger)
		{
			_distritoService = distritoService;
			_logger = logger;
		}

		[HttpGet("Obtener/{id}")]
		public async Task<IActionResult> Obtener(int id)
		{
			var response = new Response<DistritoDTO>();
			try
			{
				var result = await _distritoService.ObtenerPorClave(id);
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
		public async Task<IActionResult> Listar(string codigoProvinciaReniec = "", string codigoProvinciaInei= "")
		{
			var response = new Response<List<DistritoDTO>>();
			try
			{
				var result = await _distritoService.Listar(codigoProvinciaReniec.Trim(), codigoProvinciaInei.Trim());
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

		[HttpPost("Agregar")]
		public async Task<IActionResult> Agregar([FromBody] DistritoDTO param)
		{
			var response = new Response<int>();
			try
			{
				var id = await _distritoService.Agregar(param);
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

		[HttpPut("Actualizar")]
		public async Task<IActionResult> Actualizar(int id, [FromBody] DistritoDTO param)
		{
			var response = new Response<int>();
			try
			{
				var item = await _distritoService.ObtenerPorClave(id);
				if (item == null) return NotFound();

				//Map campos que se requiere actualizar


				await _distritoService.Actualizar(item);

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

		//[HttpDelete("Eliminar")]
		//public async Task<IActionResult> Eliminar(int id)
		//{
		//	var response = new Response<int>();
		//	try
		//	{
		//		var item = await _distritoService.ObtenerPorClave(id);
		//		if (item == null) return NotFound();

		//		await _distritoService.Eliminar(id);

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
