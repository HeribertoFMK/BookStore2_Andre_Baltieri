using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BookStore2.Mapping
{
    public class CategoriaMap: EntityTypeConfiguration<Categoria>
    {
        public CategoriaMap()
        {
            ToTable("Categoria");
            HasKey(x => x.Id);
            Property(x => x.Nome).HasMaxLength(60).IsRequired();
            HasMany(x => x.Livros).WithRequired(x => x.Categorias);
            
        }
    }
}