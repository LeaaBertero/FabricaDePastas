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
    [Index(nameof(Metodo_Entrega_Id), Name = "Metodo_Entrega_Id_UQ", IsUnique = true)]
    [Index(nameof(Descripcion),
    Name = "Descripcion", IsUnique = false)]
    #endregion
    public class Metodo_Entrega : EntityBase
    {

        #region Clave Primaria 
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Metodo_Entrega_Id { get; set; }
        #endregion

        #region Atributos
        [Required(ErrorMessage = "El campo Descripción de la entrega es obligatorio")]
        [MaxLength(30, ErrorMessage = "Máximo número de caracteres {1}")]
        public string? Descripcion { get; set; }
        #endregion


    }
}
