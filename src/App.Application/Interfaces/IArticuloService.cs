using App.ModelDto.DTOs;

namespace App.Application.Interfaces
{
    public interface IArticuloService
    {
        public Task<ArticuloDTO> ObtenerPorClave(int param);
        public Task<ArticuloDTO> ObtenerPorGuid(string guid);
        public Task<List<ArticuloDTO>> Listar();
        public Task<int> Agregar(ArticuloDTO param);
        public Task Actualizar(ArticuloDTO param);
        //public Task Eliminar(id param);
    }
}
