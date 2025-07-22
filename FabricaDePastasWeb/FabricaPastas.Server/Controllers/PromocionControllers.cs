using FabricaPastas.BD.Data;
using Microsoft.AspNetCore.Mvc;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Promocion")]

    public class PromocionControllers : ControllerBase
    {
        private readonly Context context;

        public PromocionControllers(Context context)
        {
            this.context = context;
        }
    }
}
