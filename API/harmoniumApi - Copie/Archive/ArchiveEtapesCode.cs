namespace harmoniumApi.Archive
{
    public class ArchiveEtapesCode
    {
        //TROISIEME VERSION DU CODE (AVANT REORGANISATION DES CLASSES)
        /*
        var builder = WebApplication.CreateBuilder(args);
        //builder.Services.AddDbContext<UtilisateursDb>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddDbContext<UtilisateursDb>(opt => opt.UseInMemoryDatabase("Harmonium"));
        builder.Services.AddDbContext<GroupeDb>(opt => opt.UseInMemoryDatabase("Harmonium"));
        builder.Services.AddDbContext<AlbumDb>(opt => opt.UseInMemoryDatabase("Harmonium"));
        builder.Services.AddDbContext<MorceauDb>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddDbContext<JamDb>(opt => opt.UseInMemoryDatabase("Harmonium"));
        builder.Services.AddDbContext<PisteDb>(opt => opt.UseInMemoryDatabase("Harmonium"));
        builder.Services.AddDbContext<ComposantDb>(opt => opt.UseInMemoryDatabase("Harmonium"));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        var app = builder.Build();

        //AFFECTATION DU CHEMIN "app.MapGroup("/Utilisateursitems")" A LA VARIABLE "utilisateursitems"
        //QUE L'ON VA UTILISER SUR CHAQUE REQUETE.
        var utilisateursitems = app.MapGroup("/Utilisateursitems");
        var groupeitems = app.MapGroup("/Groupeitems");
        var albumitems = app.MapGroup("/Albumitems");
        var morceauitems = app.MapGroup("/Morceauitems");
        var jamitems = app.MapGroup("/Jamitems");
        var pisteitems = app.MapGroup("/Pisteitems");
        var composantitems = app.MapGroup("/Composantitems");

        //ROUTES POUR LES METHODES CONCERNANT LES UTILISATEURS
        utilisateursitems.MapGet("/", GetAllUtilisateurs);
        utilisateursitems.MapGet("/{id}", GetUtilisateursById);
        utilisateursitems.MapPost("/", CreateUtilisateur);
        utilisateursitems.MapPut("/{id}", UpdateUtilisateurs);
        utilisateursitems.MapDelete("/{id}", DeleteUtilisateur);
        //ROUTES POUR LES METHODES CONCERNANT LES GROUPES
        groupeitems.MapGet("/", GetAllGroupes);
        groupeitems.MapGet("/{id}", GetGroupeById);
        groupeitems.MapPost("/", CreateGroupe);
        groupeitems.MapPut("/{id}", UpdateGroupe);
        groupeitems.MapDelete("/{id}", DeleteGroupe);
        //ROUTES POUR LES METHODES CONCERNANT LES ALBUMS
        albumitems.MapGet("/", GetAllAlbums);
        albumitems.MapGet("/{id}", GetAlbumById);
        albumitems.MapPost("/", CreateAlbum);
        albumitems.MapPut("/{id}", UpdateAlbum);
        albumitems.MapDelete("/{id}", DeleteAlbum);
        //ROUTES POUR LES METHODES CONCERNANT LES MORCEAUX
        morceauitems.MapGet("/", GetAllMorceaux);
        morceauitems.MapGet("/{id}", GetMorceauById);
        morceauitems.MapPost("/", CreateMorceau);
        morceauitems.MapPut("/{id}", UpdateMorceau);
        morceauitems.MapDelete("/{id}", DeleteMorceau);
        //ROUTES POUR LES METHODES CONCERNANT LES JAM
        jamitems.MapGet("/", GetAllJam);
        jamitems.MapGet("/{id}", GetJamById);
        jamitems.MapPost("/", CreateJam);
        jamitems.MapPut("/{id}", UpdateJam);
        jamitems.MapDelete("/{id}", DeleteJam);
        //ROUTES POUR LES METHODES CONCERNANT LES PISTES
        pisteitems.MapGet("/", GetAllPistes);
        pisteitems.MapGet("/{id}", GetPisteById);
        pisteitems.MapPost("/", CreatePiste);
        pisteitems.MapPut("/{id}", UpdatePiste);
        pisteitems.MapDelete("/{id}", DeletePiste);
        //ROUTES POUR LES METHODES CONCERNANT LES COMPOSANTS
        composantitems.MapGet("/", GetAllComposants);
        composantitems.MapGet("/{id}", GetComposantById);
        composantitems.MapPost("/", CreateComposant);
        composantitems.MapPut("/{id}", UpdateComposant);
        composantitems.MapDelete("/{id}", DeleteComposant);


        app.Run();

        //AFFICHAGE DE TOUTS LES COMPOSANTS
        static async Task<IResult> GetAllComposants(ComposantDb db)
        {
            return TypedResults.Ok(await db.ComposantSet.ToArrayAsync());
        }

        //RECHERCHER COMPOSANT PAR ID
        static async Task<IResult> GetComposantById(int id, ComposantDb db)
        {
            return await db.ComposantSet.FindAsync(id)
                is Composant nouveauComposant
                    ? Results.Ok(nouveauComposant)
                    : Results.NotFound();
        }

        //AJOUT D'UN NOUVEAU COMOPOSANT
        static async Task<IResult> CreateComposant(Composant nouveauComposant, ComposantDb database)
        {
            database.ComposantSet.Add(nouveauComposant);
            await database.SaveChangesAsync();

            //GENERATION D'ID POUR UN NOUVEAU COMPOSANT
            return Results.Created($"/Composantitems/{nouveauComposant.id_composant}", nouveauComposant);
        };

        //MODIFICATION D'UN COMPOSANT
        static async Task<IResult> UpdateComposant(int id, Composant inputComposant, ComposantDb db)
        {
            var composantAModifier = await db.ComposantSet.FindAsync(id);

            if (composantAModifier is null) return Results.NotFound();

            composantAModifier.cNom = inputComposant.cNom;
            composantAModifier.cDateCrea = inputComposant.cDateCrea;
            composantAModifier.cDateModif = inputComposant.cDateModif;
            composantAModifier.cImg = inputComposant.cImg;
            composantAModifier.cFich = inputComposant.cFich;


            await db.SaveChangesAsync();

            return Results.NoContent();
        };

        //SUPPRESSION D'UN COMPOSANT
        static async Task<IResult> DeleteComposant(int id, ComposantDb db)
        {
            if (await db.ComposantSet.FindAsync(id) is Composant ComposantASupprimer)
            {
                db.ComposantSet.Remove(ComposantASupprimer);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.NotFound();
        };


        //AFFICHAGE DE TOUTES LES PISTES
        static async Task<IResult> GetAllPistes(PisteDb db)
        {
            return TypedResults.Ok(await db.PisteSet.ToArrayAsync());
        }

        //RECHERCHER PISTE PAR ID
        static async Task<IResult> GetPisteById(int id, PisteDb db)
        {
            return await db.PisteSet.FindAsync(id)
                is Piste nouvellePiste
                    ? Results.Ok(nouvellePiste)
                    : Results.NotFound();
        }

        //AJOUT D'UN NOUVELLE PISTE
        static async Task<IResult> CreatePiste(Piste nouvellePiste, PisteDb database)
        {
            database.PisteSet.Add(nouvellePiste);
            await database.SaveChangesAsync();

            //GENERATION D'ID POUR UN NOUVEAU GROUPE
            return Results.Created($"/Pisteitems/{nouvellePiste.id_Piste}", nouvellePiste);
        };

        //MODIFICATION D'UNE PISTE
        static async Task<IResult> UpdatePiste(int id, Piste inputPiste, PisteDb db)
        {
            var pisteAModifier = await db.PisteSet.FindAsync(id);

            if (pisteAModifier is null) return Results.NotFound();

            pisteAModifier.id_morceau = inputPiste.id_morceau;
            pisteAModifier.pNom = inputPiste.pNom;
            pisteAModifier.pImg = inputPiste.pImg;

            await db.SaveChangesAsync();

            return Results.NoContent();
        };

        //SUPPRESSION D'UNE PISTE
        static async Task<IResult> DeletePiste(int id, PisteDb db)
        {
            if (await db.PisteSet.FindAsync(id) is Piste PisteASupprimer)
            {
                db.PisteSet.Remove(PisteASupprimer);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.NotFound();
        };


        //AFFICHAGE DE TOUTES LES JAM
        static async Task<IResult> GetAllJam(JamDb db)
        {
            return TypedResults.Ok(await db.JamSet.ToArrayAsync());
        }

        //RECHERCHER JAM PAR ID
        static async Task<IResult> GetJamById(int id, JamDb db)
        {
            return await db.JamSet.FindAsync(id)
                is Jam nouvelleJam
                    ? Results.Ok(nouvelleJam)
                    : Results.NotFound();
        }

        //AJOUT D'UN NOUVELLE JAM
        static async Task<IResult> CreateJam(Jam nouvelleJam, JamDb database)
        {
            database.JamSet.Add(nouvelleJam);
            await database.SaveChangesAsync();

            //GENERATION D'ID POUR UN NOUVEAU GROUPE
            return Results.Created($"/Morceauitems/{nouvelleJam.id_jam}", nouvelleJam);
        };

        //MODIFICATION D'UNE JAM
        static async Task<IResult> UpdateJam(int id, Jam inputJam, JamDb db)
        {
            var jamAModifier = await db.JamSet.FindAsync(id);

            if (jamAModifier is null) return Results.NotFound();

            jamAModifier.jNom = inputJam.jNom;
            jamAModifier.jDateCrea = inputJam.jDateCrea;
            jamAModifier.jDateDif = inputJam.jDateDif;
            jamAModifier.jDur = inputJam.jDur;
            jamAModifier.jLink = inputJam.jLink;

            await db.SaveChangesAsync();

            return Results.NoContent();
        };

        //SUPPRESSION D'UNE JAM
        static async Task<IResult> DeleteJam(int id, JamDb db)
        {
            if (await db.JamSet.FindAsync(id) is Jam JamASupprimer)
            {
                db.JamSet.Remove(JamASupprimer);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.NotFound();
        };


        //AFFICHAGE DE TOUS LES MORCEAUX
        static async Task<IResult> GetAllMorceaux(MorceauDb db)
        {
            return TypedResults.Ok(await db.Morceauitems.ToArrayAsync());
        }

        //RECHERCHER UN MORCEAU PAR ID
        static async Task<IResult> GetMorceauById(int id, MorceauDb db)
        {
            return await db.Morceauitems.FindAsync(id)
                is Morceau nouveauMorceau
                    ? Results.Ok(nouveauMorceau)
                    : Results.NotFound();
        }

        //AJOUT D'UN NOUVEAU MORCEAU
        static async Task<IResult> CreateMorceau(Morceau nouveauMorceau, MorceauDb database)
        {
            database.Morceauitems.Add(nouveauMorceau);
            await database.SaveChangesAsync();

            //GENERATION D'ID POUR UN NOUVEAU GROUPE
            return Results.Created($"/Morceauitems/{nouveauMorceau.id_morceau}", nouveauMorceau);
        };

        //MODIFICATION D'UN MORCEAU
        static async Task<IResult> UpdateMorceau(int id, Morceau inputMorceau, MorceauDb db)
        {
            var morceauAModifier = await db.Morceauitems.FindAsync(id);

            if (morceauAModifier is null) return Results.NotFound();

            morceauAModifier.id_album = inputMorceau.id_album;
            morceauAModifier.id_utilisateur = inputMorceau.id_utilisateur;
            morceauAModifier.id_groupe = inputMorceau.id_groupe;
            morceauAModifier.mNom = inputMorceau.mNom;
            morceauAModifier.mImg = inputMorceau.mImg;

            await db.SaveChangesAsync();

            return Results.NoContent();
        };

        //SUPPRESSION D'UN MORCEAU
        static async Task<IResult> DeleteMorceau(int id, MorceauDb db)
        {
            if (await db.Morceauitems.FindAsync(id) is Morceau MorceauASupprimer)
            {
                db.Morceauitems.Remove(MorceauASupprimer);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.NotFound();
        };


        //AFFICHAGE DE TOUS LES ALBUMS
        static async Task<IResult> GetAllAlbums(AlbumDb db)
        {
            return TypedResults.Ok(await db.AlbumSet.ToArrayAsync());
        }

        //RECHERCHER UN ALBUM PAR ID
        static async Task<IResult> GetAlbumById(int id, AlbumDb db)
        {
            return await db.AlbumSet.FindAsync(id)
                is Album nouvelAlbum
                    ? Results.Ok(nouvelAlbum)
                    : Results.NotFound();
        }

        //AJOUT D'UN NOUVEL ALBUM
        static async Task<IResult> CreateAlbum(Album nouvelAlbum, AlbumDb database)
        {
            database.AlbumSet.Add(nouvelAlbum);
            await database.SaveChangesAsync();

            //GENERATION D'ID POUR UN NOUVEAU GROUPE
            return Results.Created($"/Albumitems/{nouvelAlbum.id_album}", nouvelAlbum);
        };

        //MODIFICATION D'UN ALBUM
        static async Task<IResult> UpdateAlbum(int id, Album inputAlbum, AlbumDb db)
        {
            var albumAModifier = await db.AlbumSet.FindAsync(id);

            if (albumAModifier is null) return Results.NotFound();

            albumAModifier.aNom = inputAlbum.aNom;
            albumAModifier.aImg = inputAlbum.aImg;

            await db.SaveChangesAsync();

            return Results.NoContent();
        };

        //SUPPRESSION D'UN ALBUM
        static async Task<IResult> DeleteAlbum(int id, AlbumDb db)
        {
            if (await db.AlbumSet.FindAsync(id) is Album albumASupprimer)
            {
                db.AlbumSet.Remove(albumASupprimer);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.NotFound();
        };


        //AFFICHAGE DE TOUS LES GROUPES
        static async Task<IResult> GetAllGroupes(GroupeDb db)
        {
            return TypedResults.Ok(await db.GroupeSet.ToArrayAsync());
        }

        //RECHERCHER UN GROUPE PAR ID
        static async Task<IResult> GetGroupeById(int id, GroupeDb db)
        {
            return await db.GroupeSet.FindAsync(id)
                is Groupe nouveauGroupe
                    ? Results.Ok(nouveauGroupe)
                    : Results.NotFound();
        }

        //AJOUT D'UN NOUVEAU GROUPE
        static async Task<IResult> CreateGroupe(Groupe nouveauGroupe, GroupeDb database)
        {
            database.GroupeSet.Add(nouveauGroupe);
            await database.SaveChangesAsync();

            //GENERATION D'ID POUR UN NOUVEAU GROUPE
            return Results.Created($"/Groupeitems/{nouveauGroupe.Id_Groupe}", nouveauGroupe);
        };

        //MODIFICATION D'UN GROUPE
        static async Task<IResult> UpdateGroupe(int id, Groupe inputGroupe, GroupeDb db)
        {
            var groupeAModifier = await db.GroupeSet.FindAsync(id);

            if (groupeAModifier is null) return Results.NotFound();

            groupeAModifier.gNom = inputGroupe.gNom;
            groupeAModifier.gDate = inputGroupe.gDate;

            await db.SaveChangesAsync();

            return Results.NoContent();
        };

        //SUPPRESSION D'UN GROUPE
        static async Task<IResult> DeleteGroupe(int id, GroupeDb db)
        {
            if (await db.GroupeSet.FindAsync(id) is Groupe groupeASupprimer)
            {
                db.GroupeSet.Remove(groupeASupprimer);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.NotFound();
        };


        //AFFICHAGE DE TOUS LES UTILISATEURS
        static async Task<IResult> GetAllUtilisateurs(UtilisateursDb db)
        {
            return TypedResults.Ok(await db.UtilisateursSet.ToArrayAsync());
        }

        //RECHERCHE D'UTILISATEUR PAR ID
        static async Task<IResult> GetUtilisateursById(int id, UtilisateursDb db)
        {
            return await db.UtilisateursSet.FindAsync(id)
                is Utilisateurs nouvelUtilisateur
                    ? Results.Ok(nouvelUtilisateur)
                    : Results.NotFound();
        }

        //AJOUT D'UN NOUVEL UTILISATEUR
        static async Task<IResult> CreateUtilisateur(Utilisateurs nouvelUtilisateur, UtilisateursDb db)
        {
            db.UtilisateursSet.Add(nouvelUtilisateur);
            await db.SaveChangesAsync();

            //GENERATION D'ID POUR UN NOUVEL UTILISATEUR
            return Results.Created($"/Utilisateursitems/{nouvelUtilisateur.Id}", nouvelUtilisateur);
        };

        //MODIFICATION D'UN UTILISATEUR
        static async Task<IResult> UpdateUtilisateurs(int id, Utilisateurs inputUtilisateur, UtilisateursDb db)
        {
            var utilisateurAModifier = await db.UtilisateursSet.FindAsync(id);

            if (utilisateurAModifier is null) return Results.NotFound();

            utilisateurAModifier.Email = inputUtilisateur.Email;
            utilisateurAModifier.motDePasse = inputUtilisateur.motDePasse;
            utilisateurAModifier.Nom = inputUtilisateur.Nom;
            utilisateurAModifier.Prenom = inputUtilisateur.Prenom;
            utilisateurAModifier.Adresse1 = inputUtilisateur.Adresse1;
            utilisateurAModifier.Adresse2 = inputUtilisateur.Adresse2;
            utilisateurAModifier.CodePostal = inputUtilisateur.CodePostal;
            utilisateurAModifier.Ville = inputUtilisateur.Ville;
            utilisateurAModifier.NomInstrument = inputUtilisateur.NomInstrument;

            await db.SaveChangesAsync();

            return Results.NoContent();
        };

        //SUPPRESSION D'UN UTILISATEUR
        static async Task<IResult> DeleteUtilisateur(int id, UtilisateursDb db)
        {
            if (await db.UtilisateursSet.FindAsync(id) is Utilisateurs utilisateurASupprimer)
            {
                db.UtilisateursSet.Remove(utilisateurASupprimer);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.NotFound();
        };*/



        //SECONDE VERSION DU CODE AVEC L'AFFECTATION DU CHEMIN "app.MapGroup("/Utilisateursitems")" A LA VARIABLE "utilisateursitems"
        /*
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<UtilisateursDb>(opt => opt.UseInMemoryDatabase("Harmonium"));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        var app = builder.Build();

        //AFFECTATION DU CHEMIN "app.MapGroup("/Utilisateursitems")" A LA VARIABLE "utilisateursitems"
        //QUE L'ON VA UTILISER SUR CHAQUE REQUETE.
        var utilisateursitems = app.MapGroup("/Utilisateursitems");

        utilisateursitems.MapGet("/", async (UtilisateursDb db) =>
            await db.UtilisateursSet.ToListAsync());


        //RECHERCHE D'UTILISATEUR PAR ID
        utilisateursitems.MapGet("/{id}", async (int id, UtilisateursDb db) =>
            await db.UtilisateursSet.FindAsync(id)
                is Utilisateurs nouvelUtilisateur
                    ? Results.Ok(nouvelUtilisateur)
                    : Results.NotFound());

        //AJOUT D'UN NOUVEL UTILISATEUR
        utilisateursitems.MapPost("/", async (Utilisateurs nouvelUtilisateur, UtilisateursDb db) =>
        {
            db.UtilisateursSet.Add(nouvelUtilisateur);
            await db.SaveChangesAsync();

            //GENERATION D'ID POUR UN NOUVEL UTILISATEUR
            return Results.Created($"/Utilisateursitems/{nouvelUtilisateur.Id}", nouvelUtilisateur);
        });

        //MODIFICATION D'UN UTILISATEUR
        utilisateursitems.MapPut("/{id}", async (int id, Utilisateurs inputUtilisateur, UtilisateursDb db) =>
        {
            var utilisateurAModifier = await db.UtilisateursSet.FindAsync(id);

            if (utilisateurAModifier is null) return Results.NotFound();

            utilisateurAModifier.Email = inputUtilisateur.Email;
            utilisateurAModifier.motDePasse = inputUtilisateur.motDePasse;
            utilisateurAModifier.Nom = inputUtilisateur.Nom;
            utilisateurAModifier.Prenom = inputUtilisateur.Prenom;
            utilisateurAModifier.Adresse1 = inputUtilisateur.Adresse1;
            utilisateurAModifier.Adresse2 = inputUtilisateur.Adresse2;
            utilisateurAModifier.CodePostal = inputUtilisateur.CodePostal;
            utilisateurAModifier.Ville = inputUtilisateur.Ville;
            utilisateurAModifier.NomInstrument = inputUtilisateur.NomInstrument;

            await db.SaveChangesAsync();

            return Results.NoContent();
        });

        //SUPPRESSION D'UN UTILISATEUR
        utilisateursitems.MapDelete("/{id}", async (int id, UtilisateursDb db) =>
        {
            if (await db.UtilisateursSet.FindAsync(id) is Utilisateurs utilisateurASupprimer)
            {
                db.UtilisateursSet.Remove(utilisateurASupprimer);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.NotFound();
        });

        app.Run();
        */


        //PREMIERE VERSION DU CODE
        /*

        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<UtilisateursDb>(opt => opt.UseInMemoryDatabase("Harmonium"));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        var app = builder.Build();

        app.MapGet("/Utilisateursitems", async (UtilisateursDb db) =>
            await db.UtilisateursSet.ToListAsync());


        //RECHERCHE D'UTILISATEUR PAR ID
        app.MapGet("/Utilisateursitems/{id}", async (int id, UtilisateursDb db) =>
            await db.UtilisateursSet.FindAsync(id)
                is Utilisateurs nouvelUtilisateur
                    ? Results.Ok(nouvelUtilisateur)
                    : Results.NotFound());

        //AJOUT D'UN NOUVEL UTILISATEUR
        app.MapPost("/Utilisateursitems", async (Utilisateurs nouvelUtilisateur, UtilisateursDb db) =>
        {
            db.UtilisateursSet.Add(nouvelUtilisateur);
            await db.SaveChangesAsync();

            //GENERATION D'ID POUR UN NOUVEL UTILISATEUR
            return Results.Created($"/Utilisateursitems/{nouvelUtilisateur.Id}", nouvelUtilisateur);
        });

        //MODIFICATION D'UN UTILISATEUR
        app.MapPut("/Utilisateursitems/{id}", async (int id, Utilisateurs inputUtilisateur, UtilisateursDb db) =>
        {
            var utilisateurAModifier = await db.UtilisateursSet.FindAsync(id);

            if (utilisateurAModifier is null) return Results.NotFound();

            utilisateurAModifier.Email = inputUtilisateur.Email;
            utilisateurAModifier.motDePasse = inputUtilisateur.motDePasse;
            utilisateurAModifier.Nom = inputUtilisateur.Nom;
            utilisateurAModifier.Prenom = inputUtilisateur.Prenom;
            utilisateurAModifier.Adresse1 = inputUtilisateur.Adresse1;
            utilisateurAModifier.Adresse2 = inputUtilisateur.Adresse2;
            utilisateurAModifier.CodePostal = inputUtilisateur.CodePostal;
            utilisateurAModifier.Ville = inputUtilisateur.Ville;
            utilisateurAModifier.NomInstrument = inputUtilisateur.NomInstrument;

            await db.SaveChangesAsync();

            return Results.NoContent();
        });

        //SUPPRESSION D'UN UTILISATEUR
        app.MapDelete("/Utilisateursitems/{id}", async (int id, UtilisateursDb db) =>
        {
            if (await db.UtilisateursSet.FindAsync(id) is Utilisateurs utilisateurASupprimer)
            {
                db.UtilisateursSet.Remove(utilisateurASupprimer);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.NotFound();
        });

        app.Run();
        */
    }
}
