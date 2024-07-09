using ApiCreadocs.Repository;
using ApiCreadocs.Services;
using Microsoft.AspNetCore.Connections;

namespace ApiCreadocs
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

            builder.Services.AddScoped<InterfaceInterlocuteurRepository, InterlocuteurRepository>();
            builder.Services.AddScoped<InterfaceInterlocuteurService, InterlocuteurService>();

            builder.Services.AddScoped<InterfaceAgenceRepository, AgenceRepository>();
            builder.Services.AddScoped<InterfaceAgenceService, AgenceService>();

            builder.Services.AddScoped<InterfaceTitreRepository, TitreRepository>();
            builder.Services.AddScoped<InterfaceTitreService, TitreService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            var app = builder.Build();

            // Utiliser les services CORS
            app.UseCors("AllowAllOrigins");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
