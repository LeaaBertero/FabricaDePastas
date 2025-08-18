using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPastas.Shared.DTO
{
    public class CrearPromocionDTO
    {
        #region Atributos  
        [Required(ErrorMessage = "El campo Título es obligatorio")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "El campo Descripción es obligatorio")]
        [MaxLength(255, ErrorMessage = "Máximo número de caracteres {1}")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Fecha_Inicio es obligatorio")]
        public DateOnly Fecha_Inicio { get; set; }

        [Required(ErrorMessage = "El campo Fecha_Fin es obligatorio")]
        public DateOnly Fecha_Fin { get; set; }

        [Required(ErrorMessage = "El campo Activo es obligatorio")]
        public bool Activa { get; set; }
        #endregion  
    }
}
