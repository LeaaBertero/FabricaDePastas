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
    [Index(nameof(Detalle_Lista_Id), Name = "Detalle_Lista_Id_UQ", IsUnique = true)]
    [Index(nameof(Precio_Personalizado),
    Name = "Precio_Personalizado", IsUnique = false)]
    #endregion
    public class Detalle_Lista_Precio : EntityBase
    {

        #region clave primaria
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Detalle_Lista_Id { get; set; }
        #endregion

        #region claves foráneas
        public int Lista_Precio_Id { get; set; }

        public int Producto_Id { get; set; }
        #endregion

        #region atributos de validación
        public decimal? Precio_Personalizado { get; set; }
        #endregion
    }
}
