using Microsoft.EntityFrameworkCore;

namespace TodoApi

{
    /// <summary>
    /// TodoDb : DbContext. Ici TodoDb est un "héritage" de DbContext(importé de Microsoft.EntityFrameworkCore)
    /// </summary>
    public class TodoDb : DbContext
    {
        //TodoDb(DbContextOptions<TodoDb> options) est un constructeur de TodoDb en héritage de "base"(ici DbContext) qui prend en parametre "options".
        //Les expressions entre crochets<> sont des émléments de liste.
        public TodoDb(DbContextOptions<TodoDb> options) : base(options) { }

        //sert à récupérer des infos dans la base de données.
        public DbSet<Todo> Todos => Set<Todo>();
    }
}
