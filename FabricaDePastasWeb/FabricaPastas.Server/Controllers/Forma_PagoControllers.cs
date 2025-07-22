using FabricaPastas.BD.Data;
using Microsoft.AspNetCore.Mvc;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Forma_Pago")]

    public class Forma_PagoControllers : ControllerBase
    {
        private readonly Context context;

        public Forma_PagoControllers(Context context)
        {
            this.context = context;
        }
    }
}
