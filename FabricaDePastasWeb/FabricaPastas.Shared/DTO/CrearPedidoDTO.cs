using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPastas.Shared.DTO
{
    public class CrearPedidoDTO
    {

        #region Atributos 
        [Required(ErrorMessage = "La fecha del pedido es obligatoria")]
        public DateOnly Fecha_Pedido { get; set; }
        
        [Required(ErrorMessage = "La fecha de entrega es obligatoria")]
        public DateOnly Fecha_Entrega { get; set; } //agregado para el método de entrega

        public string? Observaciones_Catering { get; set; } //Descripción del catering (opcional)

        public decimal Total { get; set; }
        #endregion
    }
}
