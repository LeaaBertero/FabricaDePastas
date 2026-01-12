using System.Linq;
using FabricaPastas.BD.Data.Entity;

namespace FabricaPastas.BD.Data.Seed
{
    public static class DbInitializer
    {
        public static void Seed(Context context)
        {
            // 1️⃣ Crear roles si no existen
            if (!context.Rol.Any())
            {
                context.Rol.AddRange(
                    new Rol { Nombre_rol = "Administrador" },
                    new Rol { Nombre_rol = "Cliente" }
                );

                context.SaveChanges();
            }

            // 2️⃣ Obtener rol Administrador
            var rolAdmin = context.Rol
                .FirstOrDefault(r => r.Nombre_rol == "Administrador");

            if (rolAdmin == null)
                return;

            // 3️⃣ Crear usuario administrador si no existe
            if (!context.Usuario.Any(u => u.Rol_Id == rolAdmin.Rol_Id))
            {
                var admin = new Usuario
                {
                    Nombre = "Administrador",
                    Apellido = "Sistema",
                    NombreUsuario = "admin",
                    Email = "admin@lanonna.com",
                    Contraseña = "Admin123", // ⚠️ luego se mejora
                    Teléfono = "000000000",
                    Dirección = "Sistema",
                    Cuit_Cuil = "00-00000000-0",
                    Rol_Id = rolAdmin.Rol_Id,
                    Tipo_Cliete_Id = 1
                };

                context.Usuario.Add(admin);
                context.SaveChanges();
            }
        }
    }
}
