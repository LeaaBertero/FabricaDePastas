using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPastas.Shared.DTO
{
    public class CrearDetalle_PedidoDTO
    {
        #region Atributos 
        [Required(ErrorMessage = "El campo nombre del peddo es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Cantidad es obligatorio")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El campo Precio_Unitario es obligatorio")]
        public decimal? Precio_Unitario { get; set; }
        #endregion
    }
}
