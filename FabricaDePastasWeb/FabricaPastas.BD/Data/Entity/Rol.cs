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
    [Index(nameof(Rol_Id), Name = "Rol_Id_UQ", IsUnique = true)]
    [Index(nameof(Nombre_rol),
    Name = "Nombre_rol", IsUnique = false)]
    #endregion

    public class Rol : EntityBase
    {
        #region Clave primaria
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Rol_Id { get; set; }
        #endregion

        #region Atributos de Validación
        [Required(ErrorMessage = "El campo Nombre_Rol es obligatorio")]
        [MaxLength(255, ErrorMessage = "Máximo número de caracteres {1}")]
        public string Nombre_rol { get; set; }
        #endregion



    }
}
