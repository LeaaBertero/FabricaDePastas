using FabricaPastas.BD.Data;
using Microsoft.AspNetCore.Mvc;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Detalle_Lista_Precio")]

    public class Detalle_Lista_PrecioControllers : ControllerBase
    {
        private readonly Context context;

        public Detalle_Lista_PrecioControllers(Context context)
        {
            this.context = context;
        }
    }
}
