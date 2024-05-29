using HARMONIUM.Repository;
using HARMONIUM.Services;

namespace HARMONIUM
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();

            // Configuration des services pour les couches
            builder.Services.AddSingleton<IDbConnectionFactory>(sp =>
                new SqlConnectionFactory(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();
            builder.Services.AddScoped<IUtilisateurService, UtilisateurService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
