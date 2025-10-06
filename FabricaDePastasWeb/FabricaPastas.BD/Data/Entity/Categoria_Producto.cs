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
    [Index(nameof(Tipo_Pasta), nameof(Forma), nameof(Tamanio), nameof(IngredientesBase), nameof(ProcesoElaboracion),
    Name = "Tipo_Pasta_Forma_Tamanio_IngredientesBase_ProcesoElaboracion", IsUnique = false)]
    
    #endregion

    public class Categoria_Producto : EntityBase 
    {

        #region Clave Primaria
        public int Categoria_Producto_Id { get; set; }
        #endregion

        #region Atributos de Validación
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public string? Tipo_Pasta { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public string? Forma { get; set; }
        
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public string? Tamanio { get; set; }

        //[Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public string? IngredientesBase { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}")]
        public string? ProcesoElaboracion { get; set; }
        #endregion







    }
}
