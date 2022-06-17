﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlDeInventarios.Models;

namespace ControlDeInventarios.Controllers
{
    public class TiendaController : Controller
    {
        private readonly InventoryContext _context;

        public TiendaController(InventoryContext context)
        {
            _context = context;
        }

        // GET: Tienda
        public async Task<IActionResult> Index()
        {
              return _context.Tienda != null ? 
                          View(await _context.Tienda.ToListAsync()) :
                          Problem("Entity set 'InventoryContext.Tienda'  is null.");
        }

        // GET: Tienda/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Tienda == null)
            {
                return NotFound();
            }

            var tiendum = await _context.Tienda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiendum == null)
            {
                return NotFound();
            }

            return View(tiendum);
        }

        // GET: Tienda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tienda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Producto,Entradas,Salidas,Total,PrecioUnitario,Ubicación,GuíaDespacho,Proveedor,Fecha,Observaciones")] Tiendum tiendum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiendum);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Registro agregado con exito";
                return RedirectToAction(nameof(Index));
            }
            return View(tiendum);
        }

        // GET: Tienda/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Tienda == null)
            {
                return NotFound();
            }

            var tiendum = await _context.Tienda.FindAsync(id);
            if (tiendum == null)
            {
                return NotFound();
            }
            return View(tiendum);
        }

        // POST: Tienda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Producto,Entradas,Salidas,Total,PrecioUnitario,Ubicación,GuíaDespacho,Proveedor,Fecha,Observaciones")] Tiendum tiendum)
        {
            if (id != tiendum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiendum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiendumExists(tiendum.Id))
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
            return View(tiendum);
        }

        // GET: Tienda/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Tienda == null)
            {
                return NotFound();
            }

            var tiendum = await _context.Tienda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiendum == null)
            {
                return NotFound();
            }

            return View(tiendum);
        }

        // POST: Tienda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Tienda == null)
            {
                return Problem("Entity set 'InventoryContext.Tienda'  is null.");
            }
            var tiendum = await _context.Tienda.FindAsync(id);
            if (tiendum != null)
            {
                _context.Tienda.Remove(tiendum);
            }
            
            await _context.SaveChangesAsync();
            TempData["Message"] = "Registro eliminado con exito";
            return RedirectToAction(nameof(Index));
        }

        private bool TiendumExists(long id)
        {
          return (_context.Tienda?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
