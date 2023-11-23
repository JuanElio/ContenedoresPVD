using App.Domain.Entities;

namespace App.Infrastructure.Interfaces
{
    public interface IArticuloRepository
    {
        public Task<Articulo> ObtenerPorClave(int param);
        public Task<Articulo> ObtenerPorGuid(string guid);
        public Task<List<Articulo>> Listar();
        public Task<int> Agregar(Articulo param);
        public Task Actualizar(Articulo param);
    }
}
