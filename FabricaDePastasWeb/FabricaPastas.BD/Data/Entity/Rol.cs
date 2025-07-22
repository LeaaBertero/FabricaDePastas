using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPastas.BD.Data.Entity
{
    [Index(nameof(Rol_Id), Name = "Rol_Id_UQ", IsUnique = true)]
    [Index(nameof(Nombre_rol), Name = "Nombre_rol", IsUnique = false)]
    public class Rol : EntityBase
    {
      
        public int Rol_Id { get; set; }



        [Required(ErrorMessage = "El campo E-mail es obligatorio")]
        [MaxLength(150, ErrorMessage = "Máximo número de caracteres {1}")]
        public string Nombre_rol { get; set; }


    }
}
