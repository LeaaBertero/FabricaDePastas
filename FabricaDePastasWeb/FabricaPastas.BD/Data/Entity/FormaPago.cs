using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPastas.BD.Data.Entity
{
    [Index(nameof(Forma_Pago_Id), Name = "Forma_Pago_Id_UQ", IsUnique = true)]
    [Index(nameof(Metodo), Name = "Metodo", IsUnique = false)]
    public class FormaPago : EntityBase
    {
   
        public int Forma_Pago_Id { get; set; }

        [Required(ErrorMessage = "El campo E-mail es obligatorio")]
        [MaxLength(150, ErrorMessage = "Máximo número de caracteres {1}")]
        public string Metodo { get; set; }


    }
}
