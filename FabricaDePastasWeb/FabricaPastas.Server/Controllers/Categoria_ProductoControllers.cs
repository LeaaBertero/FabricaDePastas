using FabricaPastas.BD.Data;
using Microsoft.AspNetCore.Mvc;

namespace FabricaPastas.Server.Controllers
{

    [ApiController]
    [Route("api/Categoria_Producto")]

    public class Categoria_ProductoControllers : ControllerBase
    {
        private readonly Context context;

        public Categoria_ProductoControllers(Context context)
        {
            this.context = context;
        }
    }
}
