using FabricaPastas.BD.Data;
using Microsoft.AspNetCore.Mvc;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Detalle_Pedido")]

    public class Detalle_PedidoControllers : ControllerBase
    {
        private readonly Context context;

        public Detalle_PedidoControllers(Context context)
        {
            this.context = context;
        }
    }
}
