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
    //#region Indices
    //[Index(nameof(Promocion_Producto_Id), Name = "Promocion_Producto_Id_UQ", IsUnique = true)]
    //[Index(nameof(Nombre_Producto), nameof(Descuento_Porcentaje), nameof(Precio_Promocional),
    //Name = "Nombre_Producto_Descuento_Porcentaje_Precio_Promocional", IsUnique = false)]
    //#endregion

    public class Promocion_Producto : EntityBase
    {

        #region Clave primaria
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Promocion_Producto_Id { get; set; }
        #endregion

        #region Claves foráneas
        public int Promocion_Id { get; set; }
        public int Producto_Id { get; set; }
        #endregion

        #region Atributos 
        [Required(ErrorMessage = "El Nombre del producto es obligatorio")]
        [MaxLength(50, ErrorMessage = "Máximo número de caracteres {1}")]
        public string? Nombre_Producto { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        public DateOnly FechaDesde { get; set; }

        [Required(ErrorMessage = "La fecha de fin es obligatoria")]
        public DateOnly FechaHasta { get; set; }

        [Required(ErrorMessage = "El campo Descuento_Porcentaje es obligatorio")]
        public decimal Descuento_Porcentaje { get; set; }

        [Required(ErrorMessage = "El campo Precio_Promocional es obligatorio")]
        public decimal Precio_Promocional { get; set; }
        #endregion


    }
}
