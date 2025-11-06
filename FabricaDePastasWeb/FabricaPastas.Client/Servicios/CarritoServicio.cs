using FabricaPastas.Shared.DTO;

namespace FabricaPastas.Client.Servicios
{
    public class CarritoServicio
    {
        private List<CarritoDTO> _items = new();

        public IReadOnlyList<CarritoDTO> Items => _items.AsReadOnly();

        public void Agregar(CarritoDTO item)
        {
            var existente = _items.FirstOrDefault(p => p.IdProducto == item.IdProducto);
            if (existente != null)
            {
                existente.Cantidad += item.Cantidad;
            }
            else
            {
                _items.Add(item);
            }
        }

        public void Eliminar(int idProducto)
        {
            var item = _items.FirstOrDefault(p => p.IdProducto == idProducto);
            if (item != null)
                _items.Remove(item);
        }

        public decimal ObtenerTotal() => _items.Sum(p => p.Subtotal);

        public void Vaciar() => _items.Clear();
    }
}
