using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPastas.BD.Data.Entity
{

    [Index(nameof(Producto_Id), Name = "Producto_Id_UQ", IsUnique = true)]
    [Index(nameof(Nombre), nameof(Descripcion), nameof(PrecioBase), nameof(Imagen_Url), nameof(Stock),
        Name = "Nombre_Descripcion_PrecioBase_Imagen_Url_Stock", IsUnique = false)]
    public class Producto : EntityBase
    {

        public int Producto_Id { get; set; }

        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "El campo E-mail es obligatorio")]
        [MaxLength(150, ErrorMessage = "Máximo número de caracteres {1}")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo E-mail es obligatorio")]
        [MaxLength(150, ErrorMessage = "Máximo número de caracteres {1}")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo E-mail es obligatorio")]
        public decimal PrecioBase { get; set; }

        [Required(ErrorMessage = "El campo E-mail es obligatorio")]
        public string Imagen_Url { get; set; }

        [Required(ErrorMessage = "El campo E-mail es obligatorio")]
        public int Stock { get; set; }





    }
}
