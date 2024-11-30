using Filmy_EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Filmy_EF.Controllers
{
    public class FilmController : Controller
    {
        private readonly FilmsDbContext _context;
        public FilmController(FilmsDbContext context)
        {
            _context = context;
        }

        // GET: FilmController
        public ActionResult Index()
        {
            var filmyZKategoria = _context.Films.Include(f => f.Kategoria).ToList();
            return View(filmyZKategoria);
        }

        // GET: FilmController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FilmController/Create
        // GET: Film/Create
        public ActionResult Create()
        {
            // Pobierz kategorie z bazy danych
            var kategorie = _context.Kategorie.ToList();
            // Utwórz SelectList i przekaż ją do ViewBag
            ViewBag.KategoriaId = new SelectList(kategorie, "Id", "Name");
            return View();
        }

        // POST: FilmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ID,Tytul,Opis,Ocena,KategoriaId")]Film film)
        {
            try
            {
                _context.Films.Add(film);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var kategorie = _context.Kategorie.ToList();
                ViewBag.KategoriaId = new SelectList(kategorie, "Id",
                "Name");
                return View(film);
            }
        }

        // GET: FilmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FilmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FilmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FilmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
