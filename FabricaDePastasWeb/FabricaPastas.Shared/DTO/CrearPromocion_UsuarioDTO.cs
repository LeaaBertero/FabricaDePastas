using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPastas.Shared.DTO
{
    public class CrearPromocion_UsuarioDTO
    {

        #region atributos 
        [Required(ErrorMessage = "La fecha de inicio de promo es obligatoria")]
        public DateOnly Fecha_Inicio_Promo { get; set; }
        [Required(ErrorMessage = "La fecha de fin de promo es obligatoria")]
        public DateOnly Fecha_Fin_Promo { get; set; }
        #endregion
    }
}
