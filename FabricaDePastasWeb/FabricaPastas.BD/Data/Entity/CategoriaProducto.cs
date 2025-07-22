using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPastas.BD.Data.Entity
{
    [Index(nameof(Categoria_Producto_Id), Name = "Categoria_Id_UQ", IsUnique = true)]
    [Index(nameof(Nombre_Categoria), Name = "Nombre_Categoria", IsUnique = false)]
    public class CategoriaProducto:EntityBase 
    {


        public int Categoria_Producto_Id { get; set; }

        [Required(ErrorMessage = "El campo E-mail es obligatorio")]
        [MaxLength(150, ErrorMessage = "Máximo número de caracteres {1}")]
        public string Nombre_Categoria { get; set; }


    }
}
