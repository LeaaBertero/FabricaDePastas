using AutoMapper;
using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using FabricaPastas.Server.Repositorio;
using FabricaPastas.Server.Servicios;
using FabricaPastas.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly Context _context;
        private readonly IPedidoRepositorio _repositorio;
        private readonly IMapper _mapper;

        #region Constructor
        public PedidoController(Context context, IPedidoRepositorio repositorio, IMapper mapper)
        {
            _context = context;
            _repositorio = repositorio;
            _mapper = mapper;
        }
        #endregion

        #region GET: Todos los pedidos
        [HttpGet]
        public async Task<ActionResult<List<Pedido>>> Get()
        {
            var pedidos = await _context.Pedido
                .Include(p => p.Detalles) // ✅ solo incluimos la lista de detalles
                .ToListAsync();

            return Ok(pedidos);
        }
        #endregion

        #region GET: Pedido por ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pedido>> Get(int id)
        {
            var pedido = await _context.Pedido
                .Include(p => p.Detalles)
                .FirstOrDefaultAsync(p => p.Pedido_Id == id);

            if (pedido == null)
                return NotFound("No se encontró el pedido solicitado.");

            return Ok(pedido);
        }
        #endregion

        #region POST: Crear pedido
        [HttpPost]
        public async Task<ActionResult<int>> CrearPedido([FromBody] CrearPedidoDTO dto)
        {
            if (dto == null || dto.Productos == null || dto.Productos.Count == 0)
                return BadRequest("El pedido debe contener al menos un producto.");

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var totalCalculado = dto.Productos.Sum(p => p.Cantidad * p.Precio_Unitario);

                var pedido = new Pedido
                {
                    Usuario_Id = dto.Usuario_Id,
                    Estado_Pedido_Id = 1, // Pendiente
                    Forma_Pago_Id = dto.Forma_Pago_Id,
                    Metodo_Entrega_Id = dto.Metodo_Entrega_Id,
                    Fecha_Pedido = dto.Fecha_Pedido,
                    Fecha_Entrega = dto.Fecha_Entrega,
                    Total = totalCalculado,
                    Metodo_Pago = dto.MetodoPago ?? "Efectivo",
                    Codigo_Pedido = dto.CodigoPedido,
                    Detalles = dto.Productos.Select(p => new Detalle_Pedido
                    {
                        Producto_Id = p.Producto_Id,
                        Nombre = p.Nombre,
                        Cantidad = p.Cantidad,
                        Precio_Unitario = p.Precio_Unitario,
                        Subtotal = p.Cantidad * p.Precio_Unitario
                    }).ToList()
                };

                _context.Pedido.Add(pedido);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(pedido.Pedido_Id);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return BadRequest($"Error al guardar el pedido: {ex.Message}");
            }
        }
        #endregion

        #region PUT: Actualizar pedido
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Pedido entidad)
        {
            if (id != entidad.Pedido_Id)
                return BadRequest("El ID del pedido no coincide.");

            var pedidoExistente = await _context.Pedido.FindAsync(id);
            if (pedidoExistente == null)
                return NotFound("No se encontró el pedido.");

            pedidoExistente.Fecha_Pedido = entidad.Fecha_Pedido;
            pedidoExistente.Fecha_Entrega = entidad.Fecha_Entrega;
            pedidoExistente.Total = entidad.Total;
            pedidoExistente.Observaciones_Catering = entidad.Observaciones_Catering;
            pedidoExistente.Estado_Pedido_Id = entidad.Estado_Pedido_Id;

            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Error al actualizar el pedido: {e.Message}");
            }
        }
        #endregion

        #region GET: Descargar recibo PDF
        [HttpGet("{id:int}/recibo")]
        public async Task<IActionResult> DescargarRecibo(int id)
        {
            var pedido = await _context.Pedido
                .Include(p => p.Detalles)
                .FirstOrDefaultAsync(p => p.Pedido_Id == id);

            if (pedido == null)
                return NotFound("Pedido no encontrado.");

            var pdfServicio = new PdfServicio(); // Asegurate de tener esta clase implementada
            var pdfBytes = pdfServicio.GenerarRecibo(pedido);

            return File(pdfBytes, "application/pdf", $"Recibo_{pedido.Codigo_Pedido}.pdf");
        }
        #endregion
    }
}
