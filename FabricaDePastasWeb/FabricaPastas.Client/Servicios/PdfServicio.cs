using FabricaPastas.BD.Data.Entity;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;
using System.Reflection.Metadata;

namespace FabricaPastas.Server.Servicios
{
    public class PdfServicio
    {
        public byte[] GenerarRecibo(Pedido pedido)
        {
            using var ms = new MemoryStream();
            using var writer = new PdfWriter(ms);
            using var pdf = new PdfDocument(writer);
            var document = new iText.Layout.Document(pdf);


            document.Add(new Paragraph("🧾 Recibo de Pedido"));
            document.Add(new Paragraph($"Código: {pedido.Codigo_Pedido}"));
            document.Add(new Paragraph($"Fecha pedido: {pedido.Fecha_Pedido:dd/MM/yyyy}"));
            document.Add(new Paragraph($"Fecha entrega: {pedido.Fecha_Entrega:dd/MM/yyyy}"));
            document.Add(new Paragraph($"Cliente ID: {pedido.Usuario_Id}"));
            document.Add(new Paragraph($"Total: ${pedido.Total}"));
            document.Add(new Paragraph("Detalles:"));

            foreach (var detalle in pedido.Detalles)
            {
                document.Add(new Paragraph($"{detalle.Nombre} x {detalle.Cantidad} = ${detalle.Subtotal}"));
            }

            document.Close();
            return ms.ToArray();
        }
    }
}
