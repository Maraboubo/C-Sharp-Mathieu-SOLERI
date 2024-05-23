using Microsoft.EntityFrameworkCore;
using harmoniumApi.Context;
using static harmoniumApi.Controlers.UtilisateursCtrl;
using static harmoniumApi.Controlers.GroupesCtrl;
using static harmoniumApi.Controlers.AlbumsCtrl;
using static harmoniumApi.Controlers.MorceauxCtrl;
using static harmoniumApi.Controlers.JamCtrl;
using static harmoniumApi.Controlers.PisteCtrl;
using static harmoniumApi.Controlers.ComposantsCtrl;
using harmoniumApi.Controlers;
using System.Text.Json.Serialization;

namespace harmoniumApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<UtilisateursDb>(opt => opt.UseInMemoryDatabase("Harmonium"));
            builder.Services.AddDbContext<GroupeDb>(opt => opt.UseInMemoryDatabase("Harmonium"));
            builder.Services.AddDbContext<AlbumDb>(opt => opt.UseInMemoryDatabase("Harmonium"));
            builder.Services.AddDbContext<MorceauDb>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddDbContext<JamDb>(opt => opt.UseInMemoryDatabase("Harmonium"));
            builder.Services.AddDbContext<PisteDb>(opt => opt.UseInMemoryDatabase("Harmonium"));
            builder.Services.AddDbContext<ComposantDb>(opt => opt.UseInMemoryDatabase("Harmonium"));
            //builder.Services.AddDbContext<UtilisateurDbContext>(opt => opt.UseInMemoryDatabase("Harmonium"));
            builder.Services.AddDbContext<InstrumentDb>(opt => opt.UseInMemoryDatabase("Harmonium"));
            builder.Services.AddDbContext<InstrumentUtilisateurDb>(opt => opt.UseInMemoryDatabase("Harmonium"));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            var app = builder.Build();

            app.ControleurUtilisateurs();
            app.ControleurGroupes();
            app.ControleurAlbums();
            app.ControleurMorceaux();
            app.ControleurJam();
            app.ControleurPiste();
            app.ControleurComposant();
            app.ControleurInstruments();
            app.ControleurInstrumentUtilisateurs();

            app.Run();
        }
    }
}
