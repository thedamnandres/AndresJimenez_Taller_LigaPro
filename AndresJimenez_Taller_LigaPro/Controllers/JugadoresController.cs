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
    public class JugadoresController : Controller
    {
        private readonly AndresJimenez_Taller_LigaProContext _context;

        public JugadoresController(AndresJimenez_Taller_LigaProContext context)
        {
            _context = context;
        }

        //// GET: Jugadores
        //public async Task<IActionResult> Index()
        //{
        //    var andresJimenez_Taller_LigaProContext = _context.Jugadores.Include(j => j.Equipo);
        //    return View(await andresJimenez_Taller_LigaProContext.ToListAsync());
        //}

        // GET: Jugadores
        public async Task<IActionResult> Index(int? equipoId)
        {
            // Obtener todos los equipos para mostrarlos en el filtro
            var equipos = await _context.Set<Equipo>().ToListAsync();
            ViewBag.Equipos = new SelectList(equipos, "Id", "Name");

            // Obtener la lista de jugadores, incluyendo la información del equipo
            IQueryable<Jugador> jugadores = _context.Jugadores.Include(j => j.Equipo);

            // Filtrar jugadores si se proporciona un equipoId
            if (equipoId.HasValue)
            {
                jugadores = jugadores.Where(j => j.IdEquipo == equipoId.Value);
            }

            // Devolver la lista filtrada a la vista
            return View(await jugadores.ToListAsync());
        }



        // GET: Jugadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugadores
                .Include(j => j.Equipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // GET: Jugadores/Create
        public IActionResult Create()
        {
            ViewData["IdEquipo"] = new SelectList(_context.Set<Equipo>(), "Id", "Name");
            return View();
        }

        // POST: Jugadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Posicion,Edad,IdEquipo")] Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jugador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEquipo"] = new SelectList(_context.Set<Equipo>(), "Id", "Name", jugador.IdEquipo);
            return View(jugador);
        }

        // GET: Jugadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugadores.FindAsync(id);
            if (jugador == null)
            {
                return NotFound();
            }
            ViewData["IdEquipo"] = new SelectList(_context.Set<Equipo>(), "Id", "Name", jugador.IdEquipo);
            return View(jugador);
        }

        // POST: Jugadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Posicion,Edad,IdEquipo")] Jugador jugador)
        {
            if (id != jugador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jugador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JugadorExists(jugador.Id))
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
            ViewData["IdEquipo"] = new SelectList(_context.Set<Equipo>(), "Id", "Name", jugador.IdEquipo);
            return View(jugador);
        }

        // GET: Jugadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugadores
                .Include(j => j.Equipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // POST: Jugadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jugador = await _context.Jugadores.FindAsync(id);
            if (jugador != null)
            {
                _context.Jugadores.Remove(jugador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JugadorExists(int id)
        {
            return _context.Jugadores.Any(e => e.Id == id);
        }
    }
}
