using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPastas.BD.Data.Entity
{

    #region Indices
    [Index(nameof(Producto_Id), Name = "Producto_Id_UQ", IsUnique = true)]
    [Index(nameof(Nombre), nameof(Descripcion), nameof(PrecioBase), nameof(Imagen_Url), nameof(Stock),
    Name = "Nombre_Descripcion_PrecioBase_Imagen_Url_Stock", IsUnique = false)]
    #endregion
    public class Producto : EntityBase
    {

        #region Clave primaria
        public int Producto_Id { get; set; }
        #endregion

        #region Claves foráneas
        public int Categoria_Id { get; set; }
        #endregion

        #region Atributos de Validación
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Descripción es obligatorio")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El campo PrecioBase es obligatorio")]
        public decimal? PrecioBase { get; set; }

        [Required(ErrorMessage = "La imagen del producto es obligatoria")]
        public string? Imagen_Url { get; set; }

        [Required(ErrorMessage = "El campo Stock es obligatorio")]
        public int? Stock { get; set; }
        #endregion





    }
}
