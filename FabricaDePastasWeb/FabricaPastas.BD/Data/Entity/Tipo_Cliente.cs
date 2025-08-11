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

    #region indices
    [Index(nameof(Tipo_Cliente_Id), Name = "Tipo_Cliente_Id_UQ", IsUnique = true)]
    [Index(nameof(Descripcion),
    Name = "Descripcion", IsUnique = false)]
    #endregion
    public class Tipo_Cliente : EntityBase
    {

        #region Clave primaria
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Tipo_Cliente_Id { get; set; }
        #endregion

        #region Atributos de Validación
        [Required(ErrorMessage = "El campo Descripción es obligatorio")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public string Descripcion { get; set; }
        #endregion




    }


}
