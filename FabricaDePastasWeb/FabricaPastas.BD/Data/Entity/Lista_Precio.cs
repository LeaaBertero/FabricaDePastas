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
    [Index(nameof(Lista_Precio_Id), Name = "Lista_Precio_Id_UQ", IsUnique = true)]
    [Index(nameof(Fecha_Desde), nameof(Fecha_Hasta),
    Name = "Fecha_Desde_Fecha_Hasta", IsUnique = false)]
    #endregion

    public class Lista_Precio : EntityBase
    {

        #region Clave Primaria
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Lista_Precio_Id { get; set; }
        #endregion

        #region Claves Foráneas
        public int Usuario_Id { get; set; }
        #endregion

        #region atributos de Validación
        [Required(ErrorMessage = "El campo Fecha_Desde es obligatorio")]
        public DateOnly? Fecha_Desde { get; set; }

        [Required(ErrorMessage = "El campo Fecha_Hasta es obligatorio")]
        public DateOnly? Fecha_Hasta { get; set; }
        #endregion


    }
}
