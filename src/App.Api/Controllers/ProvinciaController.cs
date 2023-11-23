using App.Application.Interfaces;
using App.ModelDto.Commons;
using App.ModelDto.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProvinciaController : ControllerBase
	{
		private readonly IProvinciaService _provinciaService;
		private readonly ILogger<ProvinciaController> _logger;

		public ProvinciaController(IProvinciaService provinciaService, ILogger<ProvinciaController> logger)
		{
			_provinciaService = provinciaService;
			_logger = logger;
		}

		[HttpGet("Obtener/{id}")]
		public async Task<IActionResult> Obtener(int id)
		{
			var response = new Response<ProvinciaDTO>();
			try
			{
				var result = await _provinciaService.ObtenerPorClave(id);
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

		[HttpGet("Listar/{codigoDepartamento}")]
		public async Task<IActionResult> Listar(string codigoDepartamento)
		{
			var response = new Response<List<ProvinciaDTO>>();
			try
			{
				var result = await _provinciaService.Listar(codigoDepartamento);
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
		public async Task<IActionResult> Agregar([FromBody] ProvinciaDTO param)
		{
			var response = new Response<int>();
			try
			{
				var id = await _provinciaService.Agregar(param);
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
		public async Task<IActionResult> Actualizar(int id, [FromBody] ProvinciaDTO param)
		{
			var response = new Response<int>();
			try
			{
				var item = await _provinciaService.ObtenerPorClave(id);
				if (item == null) return NotFound();

				//Map campos que se requiere actualizar


				await _provinciaService.Actualizar(item);

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
		//		var item = await _provinciaService.ObtenerPorClave(id);
		//		if (item == null) return NotFound();

		//		await _provinciaService.Eliminar(id);

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
