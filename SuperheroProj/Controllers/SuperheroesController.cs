using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperheroProj.Data;
using SuperheroProj.Models;

namespace SuperheroProj.Controllers
{
    public class SuperheroesController : Controller
    {
        ApplicationDbContext _context;


        public SuperheroesController(ApplicationDbContext context)
        {
            _context = context;
            
        }



        // GET: Superheros
        public ActionResult Index()
        {
            var superheroes = _context.Superheroes.ToList();
            return View(superheroes);
        }

        // GET: Superheros/Details/5
        public ActionResult Details(int id)
        {
            var superheroInDB = _context.Superheroes.Where(s => s.Id == id).FirstOrDefault();
            return View(superheroInDB);
        }

        // GET: Superheros/Create
        public ActionResult Create()
        {
            Superhero superhero = new Superhero();
            return View(superhero);
        }

        // POST: Superheros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                // TODO: Add insert logic here

                _context.Superheroes.Add(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));



            }
            catch
            {
                return View(superhero);
            }
        }

        // GET: Superheros/Edit/5
        public ActionResult Edit(int id)
        {
            var superheroInDB = _context.Superheroes.Where(s => s.Id == id).FirstOrDefault();
            return View(superheroInDB);
        }



        // POST: Superheros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Superhero superhero)
        {
            try
            {
                // TODO: Add update logic here
                _context.Superheroes.Update(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(superhero);
            }
        }

        // GET: Superheros/Delete/5
        public ActionResult Delete(int id)
        {
            var superheroInDB = _context.Superheroes.Where(s => s.Id == id).FirstOrDefault();
            return View(superheroInDB);
        }

        // POST: Superheros/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Superhero superhero)
        {
            try
            {
                // TODO: Add delete logic here

                _context.Superheroes.Remove(superhero);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(superhero);
            }
        }
    }
}