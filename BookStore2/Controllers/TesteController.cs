using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore2.Controllers
{
    [RoutePrefix("Teste")]
    [Route("{Action = MinhaRota}")]
    public class TesteController : Controller        
    {
        

        public ViewResult MinhaRota4(string info)
        {
            return View(info);
        }
        

        public JsonResult Minharota()
        {
            var autor = new Autor
            {
                Id = 1,
                Nome = "Andre Baltieri"
            };
            return Json(autor, JsonRequestBehavior.AllowGet);
        }
        


        [HttpPost]
        [ActionName("AUTOR")]
        public JsonResult Minharota(Autor autor)
        {
            return Json(autor);
        }

        public string Teste(int id)
            {
                return "index do Id é" + id.ToString();
            }

        public JsonResult Minharota2(int id, string nome)
        {
            var autor = new Autor
            {
                Id = id,
                Nome = nome
            };
            return Json(autor, JsonRequestBehavior.AllowGet);
        }
            
            public JsonResult Minharota3(int? id, string nome)
            {
                var autor = new Autor
                {
                    Id = 0,
                    Nome = nome
                };
                return Json(autor, JsonRequestBehavior.AllowGet);

            }
        public ActionResult Dados(int Id)
        {
            var autor = new Autor
            {
                Id = 1,
                Nome = "Andre Baltieri"
            };

            ViewBag.Categoria = "Produtos de Limpeza";
            ViewData["Categoria"] = "Produtos de Higiene";
            TempData["Categoria"] = "Produto de Escritorio";
            Session["Categoria"] = "MOveis";
            return View(autor);
        }

        [Route("Minharota/{id:int}")]
        public string Meulocal(int id)

        {
            return "Ok!CHeguei na Rota";
        }




    }
    } 
    
    
