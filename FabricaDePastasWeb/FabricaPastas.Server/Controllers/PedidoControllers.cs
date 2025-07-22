using FabricaPastas.BD.Data;
using Microsoft.AspNetCore.Mvc;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Pedido")]

    public class PedidoControllers : ControllerBase
    {
        private readonly Context context;

        public PedidoControllers(Context context)
        {
            this.context = context;
        }
    }
}
