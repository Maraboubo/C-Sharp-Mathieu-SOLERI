using Harmonium.Repository;
using Harmonium.Services;
using Microsoft.AspNetCore.Connections;

namespace Harmonium
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            
            // Configuration des services pour les couches
            builder.Services.AddSingleton<InterfaceConnexion>(sp =>
                new GenerateurConnexion(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<InterfaceUtilisateurRepository, UtilisateurRepository>();
            builder.Services.AddScoped<InterfaceUtilisateurService, UtilisateurService>();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
