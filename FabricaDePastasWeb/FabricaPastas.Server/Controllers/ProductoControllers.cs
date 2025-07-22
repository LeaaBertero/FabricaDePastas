using FabricaPastas.BD.Data;
using Microsoft.AspNetCore.Mvc;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Producto")]

    public class ProductoControllers : ControllerBase
    {
        private readonly Context context;

        public ProductoControllers(Context context)
        {
            this.context = context;
        }
    }
}
