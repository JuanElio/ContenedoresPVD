using App.Application.Interfaces;
using App.ModelDto.Commons;
using App.ModelDto.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TipoDocumentalController : ControllerBase
	{
		private readonly ITipoDocumentalService _tipodocumentalService;
		private readonly ILogger<TipoDocumentalController> _logger;

		public TipoDocumentalController(ITipoDocumentalService tipodocumentalService, ILogger<TipoDocumentalController> logger)
		{
			_tipodocumentalService = tipodocumentalService;
			_logger = logger;
		}

        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            var response = new Response<List<TipoDocumentalDTO>>();
            try
            {
                var result = await _tipodocumentalService.Listar();
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

  //      [HttpGet("Obtener/{id}")]
		//public async Task<IActionResult> Obtener(int id)
		//{
		//	var response = new Response<TipodocumentalDTO>();
		//	try
		//	{
		//		var result = await _tipodocumentalService.ObtenerPorClave(id);
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

		

		//[HttpPost("Agregar")]
		//public async Task<IActionResult> Agregar([FromBody] TipodocumentalDTO param)
		//{
		//	var response = new Response<int>();
		//	try
		//	{
		//		var id = await _tipodocumentalService.Agregar(param);
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
		//public async Task<IActionResult> Actualizar(int id, [FromBody] TipodocumentalDTO param)
		//{
		//	var response = new Response<int>();
		//	try
		//	{
		//		var item = await _tipodocumentalService.ObtenerPorClave(id);
		//		if (item == null) return NotFound();

		//		//Map campos que se requiere actualizar


		//		await _tipodocumentalService.Actualizar(item);

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
		//		var item = await _tipodocumentalService.ObtenerPorClave(id);
		//		if (item == null) return NotFound();

		//		await _tipodocumentalService.Eliminar(id);

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
