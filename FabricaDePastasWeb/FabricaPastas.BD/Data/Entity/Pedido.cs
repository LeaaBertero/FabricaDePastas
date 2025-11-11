using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FabricaPastas.BD.Data.Entity
{
    #region Índices
    [Index(nameof(Fecha_Pedido), nameof(Total), Name = "Fecha_Pedido_Total", IsUnique = false)]
    #endregion
    public class Pedido : EntityBase
    {
        #region Clave Primaria
        public int Pedido_Id { get; set; }
        #endregion

        #region Claves Foráneas
        public int Usuario_Id { get; set; }
        public int Estado_Pedido_Id { get; set; }
        public int Forma_Pago_Id { get; set; }
        public int Metodo_Entrega_Id { get; set; }
        #endregion

        #region Atributos

        [Required(ErrorMessage = "La fecha del pedido es obligatoria")]
        public DateTime Fecha_Pedido { get; set; }

        [Required(ErrorMessage = "La fecha de entrega es obligatoria")]
        public DateTime Fecha_Entrega { get; set; }

        public string? Observaciones_Catering { get; set; }

        [Required(ErrorMessage = "El total del pedido es obligatorio")]
        public decimal Total { get; set; }

        // 🔹 Nuevo campo: método de pago elegido
        [Required(ErrorMessage = "El método de pago es obligatorio")]
        [MaxLength(50)]
        public string Metodo_Pago { get; set; } = "Efectivo"; // Por defecto

        // 🔹 Nuevo campo: número o código de pedido (útil para PDF y búsqueda)
        [MaxLength(20)]
        public string Codigo_Pedido { get; set; } = Guid.NewGuid().ToString("N")[..8].ToUpper();

        // 🔹 Relación con los detalles del pedido
        public List<Detalle_Pedido>? Detalles { get; set; }

        #endregion
    }
}
