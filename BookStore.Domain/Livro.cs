using System;
using System.Collections.Generic;

namespace BookStore.Domain
{
    public class Livro
    {
       
        public int Id { get; set; }
        
        public string Nome { get; set; }
        public string ISBN { get; set; }
        public DateTime DatadeLancamento { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categorias { get; set; }
        public ICollection<Autor> Autores { get; set; }

        public Livro()
        {
            this.Autores = new List<Autor>();
        }


    }
}