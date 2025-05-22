using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCFilmes2025.Data;
using MVCFilmes2025.Models;

namespace MVCFilmes2025.Controllers
{
    public class FilmesCController : Controller
    {
        private readonly MVCFilmes2025Context _context;

        public FilmesCController(MVCFilmes2025Context context)
        {
            _context = context;
        }

        // GET: FilmesC
        public async Task<IActionResult> Index(string texto, string genero)
        { 
            //query genero
            IQueryable<string> generos = from g in _context.Filme
                                         orderby g.Genero
                                         select g.Genero;
            
            //query para filmes
            var filmes = from f in _context.Filme
                         select f;

            //filtro de filme
            if (!string.IsNullOrWhiteSpace(texto))
            {
                filmes = filmes.Where(s => s.Titulo!.Contains(texto));
            }

            //filtro de genero
            if (!string.IsNullOrWhiteSpace(genero))
            {
                filmes = filmes.Where(s => s.Genero == genero);
            }

            var filmeViewModel = new FilmesViewModel()
            {
                Filmes = await filmes.ToListAsync(),
                Generos = new SelectList(await generos.Distinct().ToListAsync())
            };


            return View(filmeViewModel);
        }

        // GET: FilmesC/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme
                .FirstOrDefaultAsync(m => m.ID == id);
            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        // GET: FilmesC/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FilmesC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Titulo,DataLancamento,Genero,Avaliacao")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filme);
        }

        // GET: FilmesC/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme.FindAsync(id);
            if (filme == null)
            {
                return NotFound();
            }
            return View(filme);
        }

        // POST: FilmesC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Titulo,DataLancamento,Genero,Avaliacao")] Filme filme)
        {
            if (id != filme.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmeExists(filme.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(filme);
        }

        // GET: FilmesC/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme
                .FirstOrDefaultAsync(m => m.ID == id);
            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        // POST: FilmesC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filme = await _context.Filme.FindAsync(id);
            if (filme != null)
            {
                _context.Filme.Remove(filme);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmeExists(int id)
        {
            return _context.Filme.Any(e => e.ID == id);
        }
    }
}
