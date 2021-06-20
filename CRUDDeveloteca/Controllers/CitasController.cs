using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDDeveloteca.Datos;
using CRUDDeveloteca.Models;

namespace CRUDDeveloteca.Controllers
{
    public class CitasController : Controller
    {
        private readonly contextoDB _context;

        public CitasController(contextoDB context)
        {
            _context = context;
        }

        // GET: Citas
        public async Task<IActionResult> Index()
        {
            return View(await _context.citas.ToListAsync());
        }

        // GET: Citas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citaModel = await _context.citas
                .FirstOrDefaultAsync(m => m.id == id);
            if (citaModel == null)
            {
                return NotFound();
            }

            return View(citaModel);
        }

        // GET: Citas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Titulo,Fecha,Hora")] CitaModel citaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(citaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(citaModel);
        }

        // GET: Citas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citaModel = await _context.citas.FindAsync(id);
            if (citaModel == null)
            {
                return NotFound();
            }
            return View(citaModel);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Titulo,Fecha,Hora")] CitaModel citaModel)
        {
            if (id != citaModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(citaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaModelExists(citaModel.id))
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
            return View(citaModel);
        }

        // GET: Citas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citaModel = await _context.citas
                .FirstOrDefaultAsync(m => m.id == id);
            if (citaModel == null)
            {
                return NotFound();
            }

            return View(citaModel);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var citaModel = await _context.citas.FindAsync(id);
            _context.citas.Remove(citaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitaModelExists(int id)
        {
            return _context.citas.Any(e => e.id == id);
        }
    }
}
