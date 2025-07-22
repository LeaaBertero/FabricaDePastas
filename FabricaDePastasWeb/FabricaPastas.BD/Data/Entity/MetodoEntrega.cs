using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPastas.BD.Data.Entity
{
    [Index(nameof(Metodo_Entrega_Id), Name = "Metodo_Entrega_Id_UQ", IsUnique = true)]
    [Index(nameof(Descripcion),
  Name = "Descripcion", IsUnique = false)]

    public class MetodoEntrega : EntityBase
    {

        public int Metodo_Entrega_Id { get; set; }

        [Required(ErrorMessage = "El campo E-mail es obligatorio")]
        [MaxLength(150, ErrorMessage = "Máximo número de caracteres {1}")]
        public string Descripcion { get; set; }


    }
}
