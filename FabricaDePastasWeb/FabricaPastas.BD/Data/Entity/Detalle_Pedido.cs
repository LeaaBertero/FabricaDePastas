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
    [Index(nameof(Detalle_Pedido_Id), Name = "Detalle_Pedido_Id_UQ", IsUnique = true)]
    [Index(nameof(Cantidad), nameof(Precio_Unitario),
    Name = "Cantidad_Precio_Unitario", IsUnique = false)]
    #endregion
    public class Detalle_Pedido : EntityBase
    {
        #region Clave Primaria
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Detalle_Pedido_Id { get; set; }
        #endregion

        #region Claves Foráneas
        public int Pedido_Id { get; set; }

        public int Producto_Id { get; set; }
        #endregion

        #region Atributos de Validación
        [Required(ErrorMessage = "El campo Cantidad es obligatorio")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El campo Precio_Unitario es obligatorio")]
        public decimal? Precio_Unitario { get; set; }
        #endregion

    }
}
