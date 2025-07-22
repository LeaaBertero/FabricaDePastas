using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPastas.BD.Data.Entity
{

    [Index(nameof(Promocion_Producto_Id), Name = "Promocion_Producto_Id_UQ", IsUnique = true)]
    [Index(nameof(Descuento_Porcentaje), nameof(Precio_Promocional), Name = "Descuento_Porcentaje_Precio_Promocional", IsUnique = false)]

    public class PromocionProducto : EntityBase
    {

        public int Promocion_Producto_Id { get; set; }

        public int Promocion_ID { get; set; }


        public int Producto_ID { get; set; }

        [Required(ErrorMessage = "El campo E-mail es obligatorio")]
        public decimal Descuento_Porcentaje { get; set; }

        [Required(ErrorMessage = "El campo E-mail es obligatorio")]
        public decimal Precio_Promocional { get; set; }


    }
}
