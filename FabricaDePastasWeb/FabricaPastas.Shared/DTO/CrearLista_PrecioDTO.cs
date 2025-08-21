using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPastas.Shared.DTO
{
    public class CrearLista_PrecioDTO
    {

        #region atributos de Validación
        [Required(ErrorMessage = "El campo Fecha_Desde es obligatorio")]
        public DateOnly? Fecha_Desde { get; set; }

        [Required(ErrorMessage = "El campo Fecha_Hasta es obligatorio")]
        public DateOnly? Fecha_Hasta { get; set; }
        #endregion
    }
}
