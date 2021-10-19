using BookStore.Domain;
using System.Web.Mvc;

namespace BookStore2.Controllers
{
    [RoutePrefix("Teste")]
    [Route("{action=Dados}")]
    //[LogActionFilter()]

    public class TesteController : Controller


    {
        public ViewResult Dados(int Id)
        {
            var autor = new Autor
            {
                Id = 1,
                Nome = "Andre Baltieri"

            };
            ViewBag.Categoria = "Produtos de Limpeza";
            ViewData["Categorias"] = "Produtos de Higiene";
            TempData["Categoria"] = "Produtos de Escritorio";
            Session["Categoria"] = "Moveis";
            return View(autor);
        }
        public ActionResult tresaction(string info)
        {
            return View(info);
        }
        public string teste()
        {
            return "index";
        }
        public JsonResult UmaAction(int Id)
        {
            var autor = new Autor
            {
                Id = 1,
                Nome = "Andre Baltieri"

            };
            return Json(autor, JsonRequestBehavior.AllowGet);


        }
        //https://localhost:44309/Teste/duasAction?Id=1&Nome=Andre
        public JsonResult duasAction(int id, string nome)
        {
            var autor = new Autor
            {
                Id = id,
                Nome = nome

            };
            return Json(autor, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        [ActionName("Autor")]
        public JsonResult duasAction(Autor autor)
        {

            return Json(autor);

        }
        [Route("MinhaRota/{id:int}")]
        public string MinhaAction(int id)
        {
            return "Ok!cheguei na Rota!";
        }

        [Route("~/rotaignorada/{id:int}")]
        public string MinhaAction2(int id)
        {
            return "Ok!cheguei na Rota!";
        }
        [Route("Rota/{categoria:minlength(3)}")]
        public string MinhaAction3(string categoria)
        {
            return "Ok!cheguei na Rota!" + categoria;
        }
        [Route("Rota4/estacao(primavera;verao;outono;inverno)")]
        public string MinhaAction4(string estacao)
        {
            return "Ok!cheguei na Rota!" + estacao;
        }

    }
}
    

