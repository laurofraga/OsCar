﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OsCar.Data;
using OsCar.Models;

namespace OsCar.Controllers
{
    public class NotasController : Controller
    {
        private readonly OsCarContext _context;

        public NotasController(OsCarContext context)
        {
            _context = context;
        }

        // GET: Notas
        public async Task<IActionResult> Index()
        {
            var osCarContext = _context.Nota.Include(n => n.Carro).Include(n => n.Cliente).Include(n => n.Vendedor);
            return View(await osCarContext.ToListAsync());
        }

        // GET: Notas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nota == null)
            {
                return NotFound();
            }

            var nota = await _context.Nota
                .Include(n => n.Carro)
                .Include(n => n.Cliente)
                .Include(n => n.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nota == null)
            {
                return NotFound();
            }

            return View(nota);
        }

        // GET: Notas/Create
        public IActionResult Create()
        {
            ViewData["CarroId"] = new SelectList(_context.Carro, "Id", "Modelo");
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Name");
            ViewData["VendedorId"] = new SelectList(_context.Vendedor, "Id", "Name");
            return View();
        }

        // POST: Notas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,DataEmissao,Garantia,ValorVenda,CarroId,ClienteId,VendedorId")] Nota nota)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(nota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //    }
            //    ViewData["CarroId"] = new SelectList(_context.Carro, "Id", "Modelo", nota.CarroId);
            //    ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Name", nota.ClienteId);
            //    ViewData["VendedorId"] = new SelectList(_context.Vendedor, "Id", "Name", nota.VendedorId);
            //    return View(nota);
            }

            // GET: Notas/Edit/5
            public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nota == null)
            {
                return NotFound();
            }

            var nota = await _context.Nota.FindAsync(id);
            if (nota == null)
            {
                return NotFound();
            }
            ViewData["CarroId"] = new SelectList(_context.Carro, "Id", "Id", nota.CarroId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Name", nota.ClienteId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedor, "Id", "Name", nota.VendedorId);
            return View(nota);
        }

        // POST: Notas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,DataEmissao,Garantia,ValorVenda,CarroId,ClienteId,VendedorId")] Nota nota)
        {
            if (id != nota.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(nota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotaExists(nota.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            //}
            //ViewData["CarroId"] = new SelectList(_context.Carro, "Id", "Id", nota.CarroId);
            //ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Name", nota.ClienteId);
            //ViewData["VendedorId"] = new SelectList(_context.Vendedor, "Id", "Name", nota.VendedorId);
            //return View(nota);
        }

        // GET: Notas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nota == null)
            {
                return NotFound();
            }

            var nota = await _context.Nota
                .Include(n => n.Carro)
                .Include(n => n.Cliente)
                .Include(n => n.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nota == null)
            {
                return NotFound();
            }

            return View(nota);
        }

        // POST: Notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nota == null)
            {
                return Problem("Entity set 'OsCarContext.Nota'  is null.");
            }
            var nota = await _context.Nota.FindAsync(id);
            if (nota != null)
            {
                _context.Nota.Remove(nota);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotaExists(int id)
        {
          return (_context.Nota?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
