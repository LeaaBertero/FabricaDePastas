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
    [Index(nameof(Pedido_Id), Name = "Pedido_Id", IsUnique = true)]
    [Index(nameof(Fecha_Pedido), nameof(Total),
    Name = "Fecha_Pedido_Total", IsUnique = false)]
    #endregion
    public class Pedido : EntityBase
    {

        #region Clave Primaria
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public DateOnly? Fecha_Pedido { get; set; }

        [Required(ErrorMessage = "La fecha de entrega es obligatoria")]
        public DateOnly? Fecha_Entrega { get; set; } //agregado para el método de entrega

        public decimal Total { get; set; }

        //#region Tablas relacionadas (Uno a muchos) - Listas
        //public List<Pedido>? Pedidos { get; set; }
        //public List<Promocion_Usuario>? Promociones_Usuario { get; set; }
        //public List<Promocion_Producto>? Promociones_Producto { get; set; }
        //public List<Promocion>? Promociones { get; set; }
        //#endregion
        #endregion

    }
}
