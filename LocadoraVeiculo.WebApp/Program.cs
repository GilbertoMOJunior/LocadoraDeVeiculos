using System.Reflection;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloPlanos;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraVeiculos.Dominio.GrupoDeVeiculos;
using LocadoraVeiculos.Dominio.ModuloPlanos;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using LocadoraVeiculos.Infra.ORM.ModuloGrupoDeVeiculos;
using LocadoraVeiculos.Infra.ORM.ModuloPlanos;
using LocadoraVeiculos.Infra.ORM.ModuloTaxa;
using LocadoraVeiculos.Infra.ORM.ModuloVeiculo;

namespace LocadoraVeiculo.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<LocadoraDbContext>();

            builder.Services.AddScoped<IRepositorioGrupoDeVeiculos, RepositorioGrupoDeVeiculosOrm>();
            builder.Services.AddScoped<IRepositorioVeiculo, RepositorioVeiculoEmOrm>();
            builder.Services.AddScoped<IRepositorioPlanos, RepositorioPlanosEmOrm>();
            builder.Services.AddScoped<IRepositorioTaxa, RepositorioTaxaEmOrm>();
            
            builder.Services.AddScoped<ServicoGrupoVeiculos>();
            builder.Services.AddScoped<ServicoVeiculo>();
            builder.Services.AddScoped<ServicoPlanos>();
            builder.Services.AddScoped<ServicoTaxa>();

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(Assembly.GetEntryAssembly());
            });

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
