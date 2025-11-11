using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FabricaPastas.BD.Migrations
{
    /// <inheritdoc />
    public partial class cambios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Metodo_entrega",
                table: "Metodo_entrega");

            migrationBuilder.DropIndex(
                name: "Cantidad_Precio_Unitario",
                table: "Detalle_Pedido");

            migrationBuilder.RenameTable(
                name: "Metodo_entrega",
                newName: "Metodo_Entrega");

            migrationBuilder.AddColumn<string>(
                name: "Codigo_Pedido",
                table: "Pedido",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Metodo_Pago",
                table: "Pedido",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Detalle_Pedido",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Detalle_Pedido",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Subtotal",
                table: "Detalle_Pedido",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Metodo_Entrega",
                table: "Metodo_Entrega",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Pedido_Pedido_Id",
                table: "Detalle_Pedido",
                column: "Pedido_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Pedido_Producto_Id",
                table: "Detalle_Pedido",
                column: "Producto_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Detalle_Pedido_Pedido_Pedido_Id",
                table: "Detalle_Pedido",
                column: "Pedido_Id",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Detalle_Pedido_Producto_Producto_Id",
                table: "Detalle_Pedido",
                column: "Producto_Id",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detalle_Pedido_Pedido_Pedido_Id",
                table: "Detalle_Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Detalle_Pedido_Producto_Producto_Id",
                table: "Detalle_Pedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Metodo_Entrega",
                table: "Metodo_Entrega");

            migrationBuilder.DropIndex(
                name: "IX_Detalle_Pedido_Pedido_Id",
                table: "Detalle_Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Detalle_Pedido_Producto_Id",
                table: "Detalle_Pedido");

            migrationBuilder.DropColumn(
                name: "Codigo_Pedido",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "Metodo_Pago",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Detalle_Pedido");

            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "Detalle_Pedido");

            migrationBuilder.RenameTable(
                name: "Metodo_Entrega",
                newName: "Metodo_entrega");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Detalle_Pedido",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Metodo_entrega",
                table: "Metodo_entrega",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "Cantidad_Precio_Unitario",
                table: "Detalle_Pedido",
                columns: new[] { "Cantidad", "Precio_Unitario" });
        }
    }
}
