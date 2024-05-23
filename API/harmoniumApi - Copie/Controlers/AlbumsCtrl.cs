using harmoniumApi.models;
using harmoniumApi.Context;
using Microsoft.EntityFrameworkCore;

namespace harmoniumApi.Controlers
{
    public static class AlbumsCtrl
    {
        public static void ControleurAlbums(this WebApplication appli)
        {
            var albumitems = appli.MapGroup("/Albumitems");

            albumitems.MapGet("/", GetAllAlbums);
            albumitems.MapGet("/{id}", GetAlbumById);
            albumitems.MapPost("/", CreateAlbum);
            albumitems.MapPut("/{id}", UpdateAlbum);
            albumitems.MapDelete("/{id}", DeleteAlbum);
        }
        //AFFICHAGE DE TOUS LES ALBUMS
        public static async Task<IResult> GetAllAlbums(AlbumDb db)
        {
            return TypedResults.Ok(await db.AlbumSet.ToArrayAsync());
        }

        //RECHERCHER UN ALBUM PAR ID
        public static async Task<IResult> GetAlbumById(int id, AlbumDb db)
        {
            return await db.AlbumSet.FindAsync(id)
                is Album nouvelAlbum
                    ? Results.Ok(nouvelAlbum)
                    : Results.NotFound();
        }

        //AJOUT D'UN NOUVEL ALBUM
        public static async Task<IResult> CreateAlbum(Album nouvelAlbum, AlbumDb database)
        {
            database.AlbumSet.Add(nouvelAlbum);
            await database.SaveChangesAsync();

            //GENERATION D'ID POUR UN NOUVEAU GROUPE
            return Results.Created($"/Albumitems/{nouvelAlbum.id_album}", nouvelAlbum);
        }

        //MODIFICATION D'UN ALBUM
        public static async Task<IResult> UpdateAlbum(int id, Album inputAlbum, AlbumDb db)
        {
            var albumAModifier = await db.AlbumSet.FindAsync(id);

            if (albumAModifier is null) return Results.NotFound();

            albumAModifier.aNom = inputAlbum.aNom;
            albumAModifier.aImg = inputAlbum.aImg;

            await db.SaveChangesAsync();

            return Results.NoContent();
        }

        //SUPPRESSION D'UN ALBUM
        public static async Task<IResult> DeleteAlbum(int id, AlbumDb db)
        {
            if (await db.AlbumSet.FindAsync(id) is Album albumASupprimer)
            {
                db.AlbumSet.Remove(albumASupprimer);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.NotFound();
        }

    }
}
