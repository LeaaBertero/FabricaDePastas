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
    //[Index(nameof(Forma_Pago_Id), Name = "Forma_Pago_Id_UQ", IsUnique = true)]
    [Index(nameof(Metodo),
    Name = "Metodo", IsUnique = false)]
    #endregion
    public class Forma_Pago : EntityBase
    {

        #region Clave Primaria
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Forma_Pago_Id { get; set; }
        #endregion

        #region Atributos 
        [Required(ErrorMessage = "El campo Método es obligatorio")]
        [MaxLength(50, ErrorMessage = "Máximo número de caracteres {1}")]
        public string? Metodo { get; set; }
        #endregion


    }
}
