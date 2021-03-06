﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestCRUDProducao.Data;
using TestCRUDProducao.Models;

namespace TestCRUDProducao.Controllers
{
    public class ProducaosController : Controller
    {
        private readonly SchoolContext _context;

        public ProducaosController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Producaos
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["ProdutoSortParm"] = String.IsNullOrEmpty(sortOrder) ? "produto_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            var producaos = from p in _context.Producaos.Include(p => p.Produto)
                            select p;

            switch (sortOrder)
            {
                case "produto_desc":
                    producaos = producaos.OrderByDescending(s => s.Produto.Nome);
                    break;
                case "Date":
                    producaos = producaos.OrderBy(p => p.Data);
                    break;
                case "date_desc":
                    producaos = producaos.OrderByDescending(p => p.Data);
                    break;
                default:
                    producaos = producaos.OrderBy(s => s.Lote);
                    break;
            }
            return View(await producaos.AsNoTracking().ToListAsync());
        }

        // GET: Producaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producao = await _context.Producaos
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (producao == null)
            {
                return NotFound();
            }

            return View(producao);
        }

        // GET: Producaos/Create
        public IActionResult Create()
        {
            ViewData["ProdutoID"] = new SelectList(_context.Produtos, "ID", "Nome");
            return View();
        }

        // POST: Producaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProdutoID,Data,Equipamento,Lote,Observacao")] Producao producao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoID"] = new SelectList(_context.Produtos, "ID", "Nome", producao.ProdutoID);
            return View(producao);
        }

        // GET: Producaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producao = await _context.Producaos.FindAsync(id);
            if (producao == null)
            {
                return NotFound();
            }
            ViewData["ProdutoID"] = new SelectList(_context.Produtos, "ID", "Nome", producao.ProdutoID);
            return View(producao);
        }

        // POST: Producaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProdutoID,Data,Equipamento,Lote,Observacao")] Producao producao)
        {
            if (id != producao.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProducaoExists(producao.ID))
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
            ViewData["ProdutoID"] = new SelectList(_context.Produtos, "ID", "Nome", producao.ProdutoID);
            return View(producao);
        }

        // GET: Producaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producao = await _context.Producaos
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (producao == null)
            {
                return NotFound();
            }

            return View(producao);
        }

        // POST: Producaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producao = await _context.Producaos.FindAsync(id);
            _context.Producaos.Remove(producao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProducaoExists(int id)
        {
            return _context.Producaos.Any(e => e.ID == id);
        }
    }
}
