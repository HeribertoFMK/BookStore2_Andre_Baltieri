using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore2.ViewModels
{
    public class VincularLivroAutorViewModels
    {
        [Required(ErrorMessage ="*")]
        public int AutorId { get; set; }
        [Required(ErrorMessage = "*")]
        public int LivroId { get; set; }
    }
}