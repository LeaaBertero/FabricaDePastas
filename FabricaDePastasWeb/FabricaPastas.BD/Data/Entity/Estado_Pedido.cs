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
    [Index(nameof(Estado_Pedido_Id), Name = "Estado_Pedido_Id_UQ", IsUnique = true)]
    [Index(nameof(Descripcion),
    Name = "Descripcion", IsUnique = false)]
    #endregion

    public class Estado_Pedido : EntityBase
    {

        #region Clave Primaria
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Estado_Pedido_Id { get; set; }
        #endregion

        #region Atributos
        [Required(ErrorMessage = "El campo Descripcion del pedido es obligatorio")]
        [MaxLength(255, ErrorMessage = "Máximo número de caracteres {1}")]
        public string? Descripcion { get; set; }
        #endregion


    }
}
