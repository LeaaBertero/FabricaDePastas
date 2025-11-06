using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FabricaPastas.Shared.DTO
{
    public class CrearPedidoDTO
    {
        [Required(ErrorMessage = "La fecha del pedido es obligatoria")]
        public DateOnly Fecha_Pedido { get; set; }

        [Required(ErrorMessage = "La fecha de entrega es obligatoria")]
        public DateOnly Fecha_Entrega { get; set; }

        public string? Observaciones_Catering { get; set; }

        public decimal Total { get; set; }

        // ✅ Cambiamos el tipo de lista
        public List<CrearDetalle_PedidoDTO> Productos { get; set; } = new();

        public int? Usuario_Id { get; set; }
        public int? Forma_Pago_Id { get; set; }
        public int? Metodo_Entrega_Id { get; set; }
    }

}
