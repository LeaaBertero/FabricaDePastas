using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPastas.BD.Data.Entity
{
    [Index(nameof(Detalle_Pedido_Id), Name = "Detalle_Pedido_Id_UQ", IsUnique = true)]
    [Index(nameof(Cantidad), nameof(Precio_Unitario), Name = "Cantidad_Precio_Unitario", IsUnique = false)]
    public class DetallePedido : EntityBase
    {


        public int Detalle_Pedido_Id { get; set; }


        public int PedidoId { get; set; }


        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El campo E-mail es obligatorio")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El campo E-mail es obligatorio")]
        public decimal Precio_Unitario { get; set; }
    }
}
