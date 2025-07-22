using FabricaPastas.BD.Data;
using Microsoft.AspNetCore.Mvc;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Estado_Pedido")]

    public class Estado_PedidoControllers : ControllerBase
    {
        private readonly Context context;

        public Estado_PedidoControllers(Context context)
        {
            this.context = context;
        }
    }
}
