using FabricaPastas.BD.Data;
using Microsoft.AspNetCore.Mvc;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Promocion_Producto")]

    public class Promocion_ProductoControllers : ControllerBase
    {
        private readonly Context context;

        public Promocion_ProductoControllers(Context context)
        {
            this.context = context;
        }
    }
}
