using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPastas.BD.Data.Entity
{
    public class PromocionUsuario : EntityBase
    {
        public int Promocion_Usuario_ID { get; set; }
        public int Promocion_ID { get; set; }
        public int Usuario_ID { get; set; } 


    }
}
