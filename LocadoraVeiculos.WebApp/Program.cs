using LocadoraVeiculos.Dominio.GrupoDeVeiculos;
using LocadoraVeiculos.Infra.ORM.Compartilhado;


namespace LocadoraVeiculos.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<LocadoraDbContext>();

            builder.Services.AddControllersWithViews();


            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute("default", "{controller=Inicio}/{action=Index)/{id:int?}");

            app.Run();
        }
    }
}
