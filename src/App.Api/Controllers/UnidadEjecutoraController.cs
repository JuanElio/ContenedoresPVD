using App.Application.Interfaces;
using App.ModelDto.Commons;
using App.ModelDto.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UnidadejecutoraController : ControllerBase
	{
		private readonly IUnidadEjecutoraService _unidadejecutoraService;
		private readonly ILogger<UnidadejecutoraController> _logger;

		public UnidadejecutoraController(IUnidadEjecutoraService unidadejecutoraService, ILogger<UnidadejecutoraController> logger)
		{
			_unidadejecutoraService = unidadejecutoraService;
			_logger = logger;
		}

		[HttpGet("Obtener/{id}")]
		public async Task<IActionResult> Obtener(int id)
		{
			var response = new Response<UnidadEjecutoraDTO>();
			try
			{
				var result = await _unidadejecutoraService.ObtenerPorClave(id);
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
		public async Task<IActionResult> Listar(int numeropagina = 1, int cantfilas = 10, string nombre = "", string ubigeoReniec = "", string ubigeoInei = "")
		{
			var response = new ResponsePaginado<List<UnidadEjecutoraDTO>>();
			try
			{
				var result = await _unidadejecutoraService.Listar(numeropagina, cantfilas, nombre.Trim(), ubigeoReniec.Trim(), ubigeoInei.Trim());
                response.Data = result.ListaUnidadEjecutoraDTO;
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
		public async Task<IActionResult> Agregar([FromBody] UnidadEjecutoraDTO param)
		{
			var response = new Response<int>();
			try
			{
				var id = await _unidadejecutoraService.Agregar(param);
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
		public async Task<IActionResult> Actualizar(int id, [FromBody] UnidadEjecutoraDTO param)
		{
			var response = new Response<int>();
			try
			{
				var item = await _unidadejecutoraService.ObtenerPorClave(id);
				if (item == null) return NotFound();

				//Map campos que se requiere actualizar


				await _unidadejecutoraService.Actualizar(item);

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
		//		var item = await _unidadejecutoraService.ObtenerPorClave(id);
		//		if (item == null) return NotFound();

		//		await _unidadejecutoraService.Eliminar(id);

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
