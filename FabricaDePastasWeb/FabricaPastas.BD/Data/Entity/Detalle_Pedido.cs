using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FabricaPastas.BD.Data.Entity
{
    public class Detalle_Pedido : EntityBase
    {
        #region Clave Primaria
        public int Detalle_Pedido_Id { get; set; }
        #endregion

        #region Claves Foráneas
        [ForeignKey("Pedido")]
        public int Pedido_Id { get; set; }

        [ForeignKey("Producto")]
        public int Producto_Id { get; set; }

        // 🔹 Relaciones de navegación
        public Pedido? Pedido { get; set; }
        public Producto? Producto { get; set; }
        #endregion

        #region Atributos

        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El precio unitario es obligatorio")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Precio_Unitario { get; set; }

        // 🔹 Subtotal ahora se mapea y tiene setter — se guardará en la BD
        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }

        // 🔹 Descripción opcional (para PDF o promociones)
        [MaxLength(200)]
        public string? Descripcion { get; set; }

        #endregion
    }
}

