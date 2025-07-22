using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPastas.BD.Data.Entity
{

    #region Indices
    [Index(nameof(Promocion_Id), Name = "Promocion_Id_UQ", IsUnique = true)]
    [Index(nameof(Titulo), nameof(Descripcion), nameof(Fecha_Inicio), nameof(Fecha_Fin), nameof(Activa),
    Name = "Titulo_Descripcion_Fecha_Inicio_Fecha_Fin_Activa", IsUnique = false)]
    #endregion
    public class Promocion : EntityBase
    {

        #region Clave primaria
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Promocion_Id { get; set; }
        #endregion

        #region Atributos de Validación
        [Required(ErrorMessage = "El campo Título es obligatorio")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El campo Descripción es obligatorio")]
        [MaxLength(255, ErrorMessage = "Máximo número de caracteres {1}")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Fecha_Inicio es obligatorio")]
        public DateOnly Fecha_Inicio { get; set; }

        [Required(ErrorMessage = "El campo Fecha_Fin es obligatorio")]
        public DateOnly Fecha_Fin { get; set; }

        [Required(ErrorMessage = "El campo Activo es obligatorio")]
        public bool Activa { get; set; }
        #endregion


    }
}
