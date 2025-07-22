using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPastas.BD.Data.Entity
{
    [Index(nameof(Pedido_Id), Name = "Pedido_Id", IsUnique = true)]
    [Index(nameof(Fecha_Pedido), nameof(Total), Name = "Fecha_Pedido_Total", IsUnique = false)]
    public class Pedido : EntityBase
    {

        public int Pedido_Id { get; set; }
   
        public int UsuarioId { get; set; }


        public int EstadoPedidoId { get; set; }


        public int FormaPagoId { get; set; }
  

        public int MetodoEntregaId { get; set; }

        [Required(ErrorMessage = "El campo E-mail es obligatorio")]
        public DateTime Fecha_Pedido { get; set; }

        public decimal Total { get; set; }

    }
}
