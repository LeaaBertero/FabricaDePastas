using FabricaPastas.BD.Data;
using FabricaPastas.Client.Servicios;
using FabricaPastas.Server.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

#region codigo para ignorar ciclos
//-----------------------------------------------------------------------------
builder.Services.AddControllersWithViews().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
//-----------------------------------------------------------------------------
#endregion

#region Client
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//#region ConnectionString
//builder.Services.AddDbContext<Context>(op => op.UseSqlServer("name=conn"));
//#endregion

builder.Services.AddDbContext<Context>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("conn")));


#region Automapper
builder.Services.AddAutoMapper(typeof(Program));
#endregion


#region Inyección de dependencias de la interfaz IRepositorio
builder.Services.AddScoped<ICategoria_ProductoRepositorio, Categoria_ProductoRepositorio>();
builder.Services.AddScoped<IDetalle_Lista_PrecioRepositorio, Detalle_Lista_PrecioRepositorio>();
builder.Services.AddScoped<IDetalle_PedidoRepositorio, Detalle_PedidoRepositorio>();
builder.Services.AddScoped<IEstado_PedidoRepositorio, Estado_PedidoRepositorio>();
builder.Services.AddScoped<IForma_PagoRepositorio, Forma_PagoRepositorio>();
builder.Services.AddScoped<ILista_PrecioRepositorio, Lista_PrecioRepositorio>();
builder.Services.AddScoped<IMetodo_EntregaRepositorio, Metodo_EntregaRepositorio>();
builder.Services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
builder.Services.AddScoped<IPromocion_ProductoRepositorio, Promocion_ProductoRepositorio>();
builder.Services.AddScoped<IPromocion_UsuarioRepositorio, Promocion_UsuarioRepositorio>();
builder.Services.AddScoped<IPromocionRepositorio, PromocionRepositorio>();
builder.Services.AddScoped<IRolRepositorio, RolRepositorio>();
builder.Services.AddScoped<ITipo_ClienteRepositorio, Tipo_ClienteRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<CarritoServicio>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();


app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
