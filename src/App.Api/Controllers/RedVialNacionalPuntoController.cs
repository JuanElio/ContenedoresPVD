using App.Application.Interfaces;
using App.ModelDto.Commons;
using App.ModelDto.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RedVialNacionalPuntoController : ControllerBase
	{
		private readonly IRedVialNacionalPuntoService _redvialnacionalpuntoService;
		private readonly ILogger<RedVialNacionalPuntoController> _logger;

		public RedVialNacionalPuntoController(IRedVialNacionalPuntoService redvialnacionalpuntoService, ILogger<RedVialNacionalPuntoController> logger)
		{
			_redvialnacionalpuntoService = redvialnacionalpuntoService;
			_logger = logger;
		}

		//[HttpGet("Obtener/{id}")]
		//public async Task<IActionResult> Obtener(int id)
		//{
		//	var response = new Response<RedVialNacionalPuntoDTO>();
		//	try
		//	{
		//		var result = await _redvialnacionalpuntoService.ObtenerPorClave(id);
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
		public async Task<IActionResult> Listar()
		{
			var response = new Response<List<RedVialNacionalPuntoDTO>>();
			try
			{
				var result = await _redvialnacionalpuntoService.Listar();
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

        [HttpGet("Listar/{ruta}")]
        public async Task<IActionResult> Listar(string ruta)
        {
            var response = new Response<List<RedVialNacionalPuntoDTO>>();
            try
            {
                var result = await _redvialnacionalpuntoService.Listar(ruta);
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
		public async Task<IActionResult> Agregar([FromBody] RedVialNacionalPuntoDTO param)
		{
			var response = new Response<int>();
			try
			{
				var id = await _redvialnacionalpuntoService.Agregar(param);
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
		//public async Task<IActionResult> Actualizar(int id, [FromBody] RedVialNacionalPuntoDTO param)
		//{
		//	var response = new Response<int>();
		//	try
		//	{
		//		var item = await _redvialnacionalpuntoService.ObtenerPorClave(id);
		//		if (item == null) return NotFound();

		//		//Map campos que se requiere actualizar


		//		await _redvialnacionalpuntoService.Actualizar(item);

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
		//		var item = await _redvialnacionalpuntoService.ObtenerPorClave(id);
		//		if (item == null) return NotFound();

		//		await _redvialnacionalpuntoService.Eliminar(id);

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
