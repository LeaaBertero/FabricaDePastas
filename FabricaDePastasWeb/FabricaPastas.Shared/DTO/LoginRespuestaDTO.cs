using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPastas.Shared.DTO
{
    public class LoginRespuestaDTO
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public string? Token { get; set; } // Opcional, si usas JWT
    }
}
