using App.Application.Interfaces;
using App.ModelDto.Commons;
using App.ModelDto.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TipoPersonaController : ControllerBase
	{
		private readonly ITipoPersonaService _tipopersonaService;
		private readonly ILogger<TipoPersonaController> _logger;

		public TipoPersonaController(ITipoPersonaService tipopersonaService, ILogger<TipoPersonaController> logger)
		{
			_tipopersonaService = tipopersonaService;
			_logger = logger;
		}

		[HttpGet("Obtener/{id}")]
		public async Task<IActionResult> Obtener(string id)
		{
			var response = new Response<TipoPersonaDTO>();
			try
			{
				var result = await _tipopersonaService.ObtenerPorClave(id);
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
			var response = new Response<List<TipoPersonaDTO>>();
			try
			{
				var result = await _tipopersonaService.Listar();
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
		public async Task<IActionResult> Agregar([FromBody] TipoPersonaDTO param)
		{
			var response = new Response<string>();
			try
			{
				var id = await _tipopersonaService.Agregar(param);
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
		public async Task<IActionResult> Actualizar(string id, [FromBody] TipoPersonaDTO param)
		{
			var response = new Response<string>();
			try
			{
				var item = await _tipopersonaService.ObtenerPorClave(id);
				if (item == null) return NotFound();

				//Map campos que se requiere actualizar


				await _tipopersonaService.Actualizar(item);

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
		//		var item = await _tipopersonaService.ObtenerPorClave(id);
		//		if (item == null) return NotFound();

		//		await _tipopersonaService.Eliminar(id);

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
