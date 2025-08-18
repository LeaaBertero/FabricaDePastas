using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPastas.Shared.DTO
{
    public class CrearPromocion_ProductoDTO
    {
        #region Atributos de Validación
        [Required(ErrorMessage = "El campo Descuento_Porcentaje es obligatorio")]
        public decimal Descuento_Porcentaje { get; set; }

        [Required(ErrorMessage = "El campo Precio_Promocional es obligatorio")]
        public decimal Precio_Promocional { get; set; }
        #endregion
    }
}
