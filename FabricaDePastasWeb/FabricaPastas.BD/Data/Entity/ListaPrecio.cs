using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPastas.BD.Data.Entity
{
    [Index(nameof(Lista_Precio_Id), Name = "Lista_Precio_Id_UQ", IsUnique = true)]
    [Index(nameof(Fecha_Desde), nameof(Fecha_Hasta),Name = "Fecha_Desde_Fecha_Hasta", IsUnique = false)]

    public class ListaPrecio : EntityBase
    {

        public int Lista_Precio_Id { get; set; }

        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El campo E-mail es obligatorio")]
        public DateTime Fecha_Desde { get; set; }

        [Required(ErrorMessage = "El campo E-mail es obligatorio")]
        public DateTime Fecha_Hasta { get; set; }


    }
}
