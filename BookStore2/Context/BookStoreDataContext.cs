using BookStore.Domain;
using BookStore2.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore2.Content
{
    public class BookStoreDataContext : DbContext


    {
        public BookStoreDataContext():base("BookStoreConnectionString")
        {

        }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Categoria>Categorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AutorMap());
            modelBuilder.Configurations.Add(new LivroMap());
            modelBuilder.Configurations.Add(new CategoriaMap());



        }
    }
    
}