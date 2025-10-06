using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPastas.BD.Data.Entity
{
    public class Promocion_Usuario : EntityBase
    {
        #region Clave primaria

        public int Promocion_Usuario_Id { get; set; }
        #endregion

        #region Claves foráneas
        public int Promocion_Id { get; set; }
        public int Usuario_Id { get; set; }
        #endregion


        //agregados atributos para manejar las fechas de inicio y fin de la promoción por usuario
        #region atributos 
        [Required(ErrorMessage = "La fecha de inicio de promo es obligatoria")]
        public DateOnly Fecha_Inicio_Promo { get; set; }
        [Required(ErrorMessage = "La fecha de fin de promo es obligatoria")]
        public DateOnly Fecha_Fin_Promo { get; set; }
        
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public string? Descripcion { get; set; }
        #endregion


    }
}
