using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPastas.Shared.DTO
{
    public class CrearCategoria_ProductoDTO
    {
        #region Atributos de Validación
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public string? Nombre_Categoria { get; set; }

        [Required(ErrorMessage = "La imagen de la categoría es obligatoria")]
        public string? Imagen_Url { get; set; }
        #endregion
    }
}
