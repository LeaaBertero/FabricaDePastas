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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Pedido_Id { get; set; }
        #endregion

        #region Claves Foráneas
        public int Usuario_Id { get; set; }
        public int Estado_Pedido_Id { get; set; }
        public int Forma_Pago_Id { get; set; }
        public int Metodo_Entrega_Id { get; set; }
        #endregion

        #region Atributos de Validación
        [Required(ErrorMessage = "El campo Fecha de pedido es obligatorio")]
        public DateOnly? Fecha_Pedido { get; set; }


        public decimal? Total { get; set; }
        #endregion

    }
}
