using Microsoft.EntityFrameworkCore;

namespace TodoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            var app = builder.Build();

            var todoItems = app.MapGroup("/todoitems");

            todoItems.MapGet("/", GetAllTodos);
            todoItems.MapGet("/complete", GetCompleteTodos);
            todoItems.MapGet("/{id}", GetTodo);
            todoItems.MapPost("/", CreateTodo);
            todoItems.MapPut("/{id}", UpdateTodo);
            todoItems.MapDelete("/{id}", DeleteTodo);

            app.Run();

            static async Task<IResult> GetAllTodos(TodoDb db)
            {
                return TypedResults.Ok(await db.Todos.ToArrayAsync());
            }

            static async Task<IResult> GetCompleteTodos(TodoDb db)
            {
                return TypedResults.Ok(await db.Todos.Where(t => t.IsComplete).ToListAsync());
            }

            static async Task<IResult> GetTodo(int id, TodoDb db)
            {
                return await db.Todos.FindAsync(id)
                    is Todo todo
                        ? TypedResults.Ok(todo)
                        : TypedResults.NotFound();
            }

            static async Task<IResult> CreateTodo(Todo todo, TodoDb db)
            {
                db.Todos.Add(todo);
                await db.SaveChangesAsync();

                return TypedResults.Created($"/todoitems/{todo.Id}", todo);
            }

            static async Task<IResult> UpdateTodo(int id, Todo inputTodo, TodoDb db)
            {
                var todo = await db.Todos.FindAsync(id);

                if (todo is null) return TypedResults.NotFound();

                todo.Name = inputTodo.Name;
                todo.IsComplete = inputTodo.IsComplete;

                await db.SaveChangesAsync();

                return TypedResults.NoContent();
            }

            static async Task<IResult> DeleteTodo(int id, TodoDb db)
            {
                if (await db.Todos.FindAsync(id) is Todo todo)
                {
                    db.Todos.Remove(todo);
                    await db.SaveChangesAsync();
                    return TypedResults.NoContent();
                }

                return TypedResults.NotFound();
            }
            //SECONDE VERSION DU CODE AVEC LA MISE EN VARIABLE DU CHEMIN
            //var builder = WebApplication.CreateBuilder(args);
            //builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
            //builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            //var app = builder.Build();

            ////ici on met "app.MapGroup("/todoitems")" dans une variable pour éviter de le répéter
            //var todoItems = app.MapGroup("/todoitems");

            //todoItems.MapGet("/", async (TodoDb db) =>
            //    await db.Todos.ToListAsync());

            //todoItems.MapGet("/complete", async (TodoDb db) =>
            //    await db.Todos.Where(t => t.IsComplete).ToListAsync());

            //todoItems.MapGet("/{id}", async (int id, TodoDb db) =>
            //    await db.Todos.FindAsync(id)
            //        is Todo todo
            //            ? Results.Ok(todo)
            //            : Results.NotFound());

            //todoItems.MapPost("/", async (Todo todo, TodoDb db) =>
            //{
            //    db.Todos.Add(todo);
            //    await db.SaveChangesAsync();

            //    return Results.Created($"/todoitems/{todo.Id}", todo);
            //});

            //todoItems.MapPut("/{id}", async (int id, Todo inputTodo, TodoDb db) =>
            //{
            //    var todo = await db.Todos.FindAsync(id);

            //    if (todo is null) return Results.NotFound();

            //    todo.Name = inputTodo.Name;
            //    todo.IsComplete = inputTodo.IsComplete;

            //    await db.SaveChangesAsync();

            //    return Results.NoContent();
            //});

            //todoItems.MapDelete("/{id}", async (int id, TodoDb db) =>
            //{
            //    if (await db.Todos.FindAsync(id) is Todo todo)
            //    {
            //        db.Todos.Remove(todo);
            //        await db.SaveChangesAsync();
            //        return Results.NoContent();
            //    }

            //    return Results.NotFound();
            //});

            //app.Run();

            ///PREMIERE VERSION DU CODE COMMENTEE
            //var builder = WebApplication.CreateBuilder(args);
            ////permet de récupérer les infos de la base de données
            //builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
            //builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            //var app = builder.Build();

            //// Ici on va créer les points de terminaisons de l'api

            ////quand je vais sur ce chemin "/todoitems" je vais faire une liste des items
            //app.MapGet("/todoitems", async (TodoDb db) =>
            //    await db.Todos.ToListAsync());

            //app.MapGet("/todoitems/complete", async (TodoDb db) =>
            //    await db.Todos.Where(t => t.IsComplete).ToListAsync());

            ////quand je vais sur ce chemin "/todoitems/{id}" je vais récupérer les infos la ou l'id est présent
            //app.MapGet("/todoitems/{id}", async (int id, TodoDb db) =>
            //    await db.Todos.FindAsync(id)
            //        is Todo todo
            //            ? Results.Ok(todo)
            //            : Results.NotFound());

            //app.MapPost("/todoitems", async (Todo todo, TodoDb db) =>
            //{
            //    db.Todos.Add(todo);
            //    await db.SaveChangesAsync();

            //    return Results.Created($"/todoitems/{todo.Id}", todo);
            //});

            //app.MapPut("/todoitems/{id}", async (int id, Todo inputTodo, TodoDb db) =>
            //{
            //    var todo = await db.Todos.FindAsync(id);

            //    if (todo is null) return Results.NotFound();

            //    todo.Name = inputTodo.Name;
            //    todo.IsComplete = inputTodo.IsComplete;

            //    await db.SaveChangesAsync();

            //    return Results.NoContent();
            //});

            //app.MapDelete("/todoitems/{id}", async (int id, TodoDb db) =>
            //{
            //    if (await db.Todos.FindAsync(id) is Todo todo)
            //    {
            //        db.Todos.Remove(todo);
            //        await db.SaveChangesAsync();
            //        return Results.NoContent();
            //    }

            //    return Results.NotFound();
            //});
            ////on peut tester les points de terminaison affichage/autres fenetres/explorateur de points de terminaison^puis clic droit sur le point et générer la requete

            //app.Run();
        }
    }
}
