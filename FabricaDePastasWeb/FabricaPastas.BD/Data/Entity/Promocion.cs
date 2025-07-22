using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPastas.BD.Data.Entity
{

    [Index(nameof(Promocion_Id), Name = "Promocion_Id_UQ", IsUnique = true)]
    [Index(nameof(Titulo), nameof(Descripcion), nameof(Fecha_Inicio), nameof(Fecha_Fin), nameof(Activa), Name = "Titulo_Descripcion_Fecha_Inicio_Fecha_Fin_Activa", IsUnique = false)]
    public class Promocion : EntityBase
    {

        public int Promocion_Id { get; set; }

        [Required(ErrorMessage = "El campo E-mail es obligatorio")]
        [MaxLength(150, ErrorMessage = "Máximo número de caracteres {1}")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El campo E-mail es obligatorio")]
        [MaxLength(150, ErrorMessage = "Máximo número de caracteres {1}")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo E-mail es obligatorio")]
        public DateTime Fecha_Inicio { get; set; }

        [Required(ErrorMessage = "El campo E-mail es obligatorio")]
        public DateTime Fecha_Fin { get; set; }
        
        public bool Activa { get; set; }


    }
}
