using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPastas.BD.Data.Entity
{
    [Index(nameof(Detalle_Lista_Id), Name = "Detalle_Lista_Id_UQ", IsUnique = true)]
    [Index(nameof(Precio_Personalizado), Name = "Precio_Personalizado", IsUnique = false)]
    public class DetalleListaPrecio : EntityBase
    {

        public int Detalle_Lista_Id { get; set; }

        public int ListaPrecioId { get; set; }


        public int ProductoId { get; set; }


        public decimal Precio_Personalizado { get; set; }
    }
}
