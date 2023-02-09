using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleFuncionario.Data;
using ControleFuncionario.Models;
using Microsoft.AspNetCore.Authorization;

namespace ControleFuncionario.Controllers
{
    public class LotacaosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LotacaosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lotacaos
        [Authorize]
        public async Task<IActionResult> Index()
        {
              return View(await _context.Lotacao.ToListAsync());
        }

        // GET: Lotacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lotacao == null)
            {
                return NotFound();
            }

            var lotacao = await _context.Lotacao
                .FirstOrDefaultAsync(m => m.LotacaoId == id);
            if (lotacao == null)
            {
                return NotFound();
            }

            return View(lotacao);
        }

        // GET: Lotacaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lotacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LotacaoId,LotacaoRegiao")] Lotacao lotacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lotacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lotacao);
        }

        // GET: Lotacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lotacao == null)
            {
                return NotFound();
            }

            var lotacao = await _context.Lotacao.FindAsync(id);
            if (lotacao == null)
            {
                return NotFound();
            }
            return View(lotacao);
        }

        // POST: Lotacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LotacaoId,LotacaoRegiao")] Lotacao lotacao)
        {
            if (id != lotacao.LotacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lotacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LotacaoExists(lotacao.LotacaoId))
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
            return View(lotacao);
        }

        // GET: Lotacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lotacao == null)
            {
                return NotFound();
            }

            var lotacao = await _context.Lotacao
                .FirstOrDefaultAsync(m => m.LotacaoId == id);
            if (lotacao == null)
            {
                return NotFound();
            }

            return View(lotacao);
        }

        // POST: Lotacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lotacao == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Lotacao'  is null.");
            }
            var lotacao = await _context.Lotacao.FindAsync(id);
            if (lotacao != null)
            {
                _context.Lotacao.Remove(lotacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LotacaoExists(int id)
        {
          return _context.Lotacao.Any(e => e.LotacaoId == id);
        }
    }
}
