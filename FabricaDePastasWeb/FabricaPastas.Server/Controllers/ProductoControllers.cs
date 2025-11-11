using AutoMapper;
using FabricaPastas.BD.Data;
using FabricaPastas.BD.Data.Entity;
using FabricaPastas.Server.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaPastas.Server.Controllers
{
    [ApiController]
    [Route("api/Producto")]
    public class ProductoControllers : ControllerBase
    {
        private readonly IProductoRepositorio repositorio;
        private readonly IMapper mapper;

        #region constructor
        public ProductoControllers(IProductoRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }
        #endregion


        // ✅ NUEVO MÉTODO PARA SUBIR IMAGEN
        [HttpPost("SubirImagen")]
        [RequestSizeLimit(10_000_000)] // opcional: límite de 10 MB
        [Consumes("multipart/form-data")] // 👈 ESTA LÍNEA ES LA CLAVE
        public async Task<ActionResult<string>> SubirImagen(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Archivo no válido");

            // Generar nombre único
            var nombreArchivo = $"{Guid.NewGuid()}_{file.FileName}";
            var carpeta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

            // Crear carpeta si no existe
            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);

            // Guardar archivo
            var rutaArchivo = Path.Combine(carpeta, nombreArchivo);
            using (var stream = new FileStream(rutaArchivo, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Devolver URL accesible desde el cliente
            var url = $"/images/{nombreArchivo}";
            return Ok(url);
        }


        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> Get()
        {
            return await repositorio.Select();
        }
        #endregion

        #region Método Get por {id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Producto>> Get(int id)
        {
            var dammy = await repositorio.SelectById(id);

            if (dammy == null)
            {
                return NotFound();
            }

            return dammy;
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Producto entidad)
        {
            try
            {
                return await repositorio.Insert(entidad);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region Método Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Producto entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var dammy = await repositorio.SelectById(id);

            if (dammy == null)
            {
                return NotFound("No se encontró el producto buscado");
            }

            dammy.Nombre = entidad.Nombre;
            dammy.Descripcion = entidad.Descripcion;
            dammy.PrecioBase = entidad.PrecioBase;
            dammy.Imagen_Url = entidad.Imagen_Url;
            dammy.Stock = entidad.Stock;

            try
            {
                await repositorio.Update(id, dammy);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region Método Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await repositorio.Existe(id);

            if (!existe)
            {
                return NotFound($"El producto {id} no existe.");
            }

            if (await repositorio.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest("No se pudo eliminar el producto");
            }
        }
        #endregion
    }
}
