using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FabricaPastas.BD.Migrations
{
    /// <inheritdoc />
    public partial class ActualizoTipoCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria_Producto",
                columns: table => new
                {
                    Categoria_Producto_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Categoria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria_Producto", x => x.Categoria_Producto_Id);
                });

            migrationBuilder.CreateTable(
                name: "Detalle_Lista_Precio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Detalle_Lista_Id = table.Column<int>(type: "int", nullable: false),
                    Lista_Precio_Id = table.Column<int>(type: "int", nullable: false),
                    Producto_Id = table.Column<int>(type: "int", nullable: false),
                    Precio_Personalizado = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_Lista_Precio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Detalle_Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Detalle_Pedido_Id = table.Column<int>(type: "int", nullable: false),
                    Pedido_Id = table.Column<int>(type: "int", nullable: false),
                    Producto_Id = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio_Unitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_Pedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado_Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado_Pedido_Id = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado_Pedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Forma_Pago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Forma_Pago_Id = table.Column<int>(type: "int", nullable: false),
                    Metodo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forma_Pago", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lista_Precio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lista_Precio_Id = table.Column<int>(type: "int", nullable: false),
                    Usuario_Id = table.Column<int>(type: "int", nullable: false),
                    Fecha_Desde = table.Column<DateOnly>(type: "date", nullable: false),
                    Fecha_Hasta = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lista_Precio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Metodo_entrega",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Metodo_Entrega_Id = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metodo_entrega", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Pedido_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario_Id = table.Column<int>(type: "int", nullable: false),
                    Estado_Pedido_Id = table.Column<int>(type: "int", nullable: false),
                    Forma_Pago_Id = table.Column<int>(type: "int", nullable: false),
                    Metodo_Entrega_Id = table.Column<int>(type: "int", nullable: false),
                    Fecha_Pedido = table.Column<DateOnly>(type: "date", nullable: false),
                    Fecha_Entrega = table.Column<DateOnly>(type: "date", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Pedido_Id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Producto_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria_Producto_Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PrecioBase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Imagen_Url = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Producto_Id);
                });

            migrationBuilder.CreateTable(
                name: "Promocion",
                columns: table => new
                {
                    Promocion_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Fecha_Inicio = table.Column<DateOnly>(type: "date", nullable: false),
                    Fecha_Fin = table.Column<DateOnly>(type: "date", nullable: false),
                    Activa = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocion", x => x.Promocion_Id);
                });

            migrationBuilder.CreateTable(
                name: "Promocion_Producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Promocion_Producto_Id = table.Column<int>(type: "int", nullable: false),
                    Promocion_Id = table.Column<int>(type: "int", nullable: false),
                    Producto_Id = table.Column<int>(type: "int", nullable: false),
                    Nombre_Producto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descuento_Porcentaje = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Precio_Promocional = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocion_Producto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promocion_Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Promocion_Usuario_Id = table.Column<int>(type: "int", nullable: false),
                    Promocion_Id = table.Column<int>(type: "int", nullable: false),
                    Usuario_Id = table.Column<int>(type: "int", nullable: false),
                    Fecha_Inicio_Promo = table.Column<DateOnly>(type: "date", nullable: false),
                    Fecha_Fin_Promo = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocion_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rol_Id = table.Column<int>(type: "int", nullable: false),
                    Nombre_rol = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo_Cliente_Id = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario_Id = table.Column<int>(type: "int", nullable: false),
                    Tipo_Cliete_Id = table.Column<int>(type: "int", nullable: false),
                    Rol_Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Teléfono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Dirección = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cuit_Cuil = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "Categoria_Producto_Id_UQ",
                table: "Categoria_Producto",
                column: "Categoria_Producto_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Nombre_Categoria",
                table: "Categoria_Producto",
                column: "Nombre_Categoria");

            migrationBuilder.CreateIndex(
                name: "Detalle_Lista_Id_UQ",
                table: "Detalle_Lista_Precio",
                column: "Detalle_Lista_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Precio_Personalizado",
                table: "Detalle_Lista_Precio",
                column: "Precio_Personalizado");

            migrationBuilder.CreateIndex(
                name: "Cantidad_Precio_Unitario",
                table: "Detalle_Pedido",
                columns: new[] { "Cantidad", "Precio_Unitario" });

            migrationBuilder.CreateIndex(
                name: "Detalle_Pedido_Id_UQ",
                table: "Detalle_Pedido",
                column: "Detalle_Pedido_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Descripcion",
                table: "Estado_Pedido",
                column: "Descripcion");

            migrationBuilder.CreateIndex(
                name: "Estado_Pedido_Id_UQ",
                table: "Estado_Pedido",
                column: "Estado_Pedido_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Forma_Pago_Id_UQ",
                table: "Forma_Pago",
                column: "Forma_Pago_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Metodo",
                table: "Forma_Pago",
                column: "Metodo");

            migrationBuilder.CreateIndex(
                name: "Fecha_Desde_Fecha_Hasta",
                table: "Lista_Precio",
                columns: new[] { "Fecha_Desde", "Fecha_Hasta" });

            migrationBuilder.CreateIndex(
                name: "Lista_Precio_Id_UQ",
                table: "Lista_Precio",
                column: "Lista_Precio_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Descripcion",
                table: "Metodo_entrega",
                column: "Descripcion");

            migrationBuilder.CreateIndex(
                name: "Metodo_Entrega_Id_UQ",
                table: "Metodo_entrega",
                column: "Metodo_Entrega_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Fecha_Pedido_Total",
                table: "Pedido",
                columns: new[] { "Fecha_Pedido", "Total" });

            migrationBuilder.CreateIndex(
                name: "Pedido_Id",
                table: "Pedido",
                column: "Pedido_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Nombre_Descripcion_PrecioBase_Imagen_Url_Stock",
                table: "Producto",
                columns: new[] { "Nombre", "Descripcion", "PrecioBase", "Imagen_Url", "Stock" });

            migrationBuilder.CreateIndex(
                name: "Producto_Id_UQ",
                table: "Producto",
                column: "Producto_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Promocion_Id_UQ",
                table: "Promocion",
                column: "Promocion_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Titulo_Descripcion_Fecha_Inicio_Fecha_Fin_Activa",
                table: "Promocion",
                columns: new[] { "Titulo", "Descripcion", "Fecha_Inicio", "Fecha_Fin", "Activa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria_Producto");

            migrationBuilder.DropTable(
                name: "Detalle_Lista_Precio");

            migrationBuilder.DropTable(
                name: "Detalle_Pedido");

            migrationBuilder.DropTable(
                name: "Estado_Pedido");

            migrationBuilder.DropTable(
                name: "Forma_Pago");

            migrationBuilder.DropTable(
                name: "Lista_Precio");

            migrationBuilder.DropTable(
                name: "Metodo_entrega");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Promocion");

            migrationBuilder.DropTable(
                name: "Promocion_Producto");

            migrationBuilder.DropTable(
                name: "Promocion_Usuario");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Tipo_Cliente");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
