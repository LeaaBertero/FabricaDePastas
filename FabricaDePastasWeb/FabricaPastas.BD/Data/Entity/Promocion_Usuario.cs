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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Promocion_Usuario_Id { get; set; }
        #endregion

        #region Claves foráneas
        public int Promocion_Id { get; set; }
        public int Usuario_Id { get; set; }
        #endregion


    }
}
