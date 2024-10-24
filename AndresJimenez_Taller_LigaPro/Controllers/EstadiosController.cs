using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AndresJimenez_Taller_LigaPro.Data;
using AndresJimenez_Taller_LigaPro.Models;

namespace AndresJimenez_Taller_LigaPro.Controllers
{
    public class EstadiosController : Controller
    {
        private readonly AndresJimenez_Taller_LigaProContext _context;

        public EstadiosController(AndresJimenez_Taller_LigaProContext context)
        {
            _context = context;
        }

        // GET: Estadios1
        public async Task<IActionResult> Index()
        {
            var andresJimenez_Taller_LigaProContext = _context.Estadio.Include(e => e.Equipo);
            return View(await andresJimenez_Taller_LigaProContext.ToListAsync());
        }

        // GET: Estadios1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadio = await _context.Estadio
                .Include(e => e.Equipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadio == null)
            {
                return NotFound();
            }

            return View(estadio);
        }

        // GET: Estadios1/Create
        public IActionResult Create()
        {
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "Id", "Name");
            return View();
        }

        // POST: Estadios1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Direccion,Ciudad,Capacidad,IdEquipo")] Estadio estadio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "Id", "Name", estadio.IdEquipo);
            return View(estadio);
        }

        // GET: Estadios1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadio = await _context.Estadio.FindAsync(id);
            if (estadio == null)
            {
                return NotFound();
            }
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "Id", "Name", estadio.IdEquipo);
            return View(estadio);
        }

        // POST: Estadios1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Direccion,Ciudad,Capacidad,IdEquipo")] Estadio estadio)
        {
            if (id != estadio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadioExists(estadio.Id))
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
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "Id", "Name", estadio.IdEquipo);
            return View(estadio);
        }

        // GET: Estadios1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadio = await _context.Estadio
                .Include(e => e.Equipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadio == null)
            {
                return NotFound();
            }

            return View(estadio);
        }

        // POST: Estadios1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadio = await _context.Estadio.FindAsync(id);
            if (estadio != null)
            {
                _context.Estadio.Remove(estadio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadioExists(int id)
        {
            return _context.Estadio.Any(e => e.Id == id);
        }
    }
}
