using BookStore.Domain;
using BookStore2.Repository.Contracts;
using System.Web.Mvc;

namespace BookStore2.Controllers
{

    [RoutePrefix("autores")]
    //[LogActionFilter()]
    public class AuthorController : Controller
    {
        private IAuthorsRepository _repository;
        public AuthorController(IAuthorsRepository repository)
        {
            _repository = repository;
        }
        // GET: Author
        [Route("listar")]
        public ActionResult Index()
        {
            var autores = _repository.Get();
            return View(autores);
        }
        [Route("criar")]
        public ActionResult Create()
        {
            return View();
        }
        [Route("criar")]
        [HttpPost]
        public ActionResult Create(Autor author)
        {
            if (_repository.Create(author))
                RedirectToAction("Index");
                       
            return View(author);
        }
        [Route("editar/{id:int}")]
        public ActionResult Edit(int id)
        {
            var author = _repository.Get(id);
            return View(author);
        }
        [Route("editar/{id:int}")]
        [HttpPost]
        public ActionResult Edit(Autor author)
        {
            if (_repository.Update(author))
                RedirectToAction("Index");
            return View(author);
        }

        [Route("excluir/{id:int}")]
        public ActionResult Delete(int id)
        {
            var author = _repository.Get(id);
            return View(author);
        }
        [Route("excluir/{id:int}")]
        [HttpPost]
        [ActionName("Deletar")]
        public ActionResult DeleteConfirm(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}