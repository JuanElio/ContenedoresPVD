using App.Application.Interfaces;
using App.Application.Services;
using App.ModelDto.Commons;
using App.ModelDto.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RedVialNacionalController : ControllerBase
	{
		private readonly IRedVialNacionalService _redvialnacionalService;
		private readonly ILogger<RedVialNacionalController> _logger;

		public RedVialNacionalController(IRedVialNacionalService redvialnacionalService, ILogger<RedVialNacionalController> logger)
		{
			_redvialnacionalService = redvialnacionalService;
			_logger = logger;
		}

		//[HttpGet("Obtener/{id}")]
		//public async Task<IActionResult> Obtener(int id)
		//{
		//	var response = new Response<RedvialnacionalDTO>();
		//	try
		//	{
		//		var result = await _redvialnacionalService.ObtenerPorClave(id);
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

		//[HttpGet("Listar/{ruta}")]
		//public async Task<IActionResult> Listar(int numeropagina, int cantfilas, string ruta)
		//{
		//	var response = new Response<RedVialNacionalDTO>();
		//	try
		//	{
		//		var result = await _redvialnacionalService.Listar(  ruta);
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

        [HttpGet("Listar/{ruta}")]
        public async Task<IActionResult> Listar(string ruta)
        {
            var response = new Response<RedVialNacionalListasDTO>();
            try
            {
                var result = await _redvialnacionalService.Listar(ruta);
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
		public async Task<IActionResult> Agregar([FromBody] RedVialNacionalDTO param)
		{
			var response = new Response<int>();
			try
			{
				var id = await _redvialnacionalService.Agregar(param);
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
		//public async Task<IActionResult> Actualizar(int id, [FromBody] RedVialNacionalDTO param)
		//{
		//	var response = new Response<int>();
		//	try
		//	{
		//		var item = await _redvialnacionalService.ObtenerPorClave(id);
		//		if (item == null) return NotFound();

		//		//Map campos que se requiere actualizar


		//		await _redvialnacionalService.Actualizar(item);

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
		//		var item = await _redvialnacionalService.ObtenerPorClave(id);
		//		if (item == null) return NotFound();

		//		await _redvialnacionalService.Eliminar(id);

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
