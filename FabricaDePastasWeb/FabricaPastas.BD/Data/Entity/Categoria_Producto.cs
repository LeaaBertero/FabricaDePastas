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
    //[Index(nameof(Categoria_Producto_Id), Name = "Categoria_Producto_Id_UQ", IsUnique = true)]
    [Index(nameof(Nombre_Categoria),
    Name = "Nombre_Categoria", IsUnique = false)]
    #endregion

    public class Categoria_Producto : EntityBase 
    {

        #region Clave Primaria
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Categoria_Producto_Id { get; set; }
        #endregion

        #region Atributos de Validación
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public string? Nombre_Categoria { get; set; }
        
        [Required(ErrorMessage = "La imagen de la categoría es obligatoria")]
        public string? Imagen_Url { get; set; }
        #endregion







    }
}
