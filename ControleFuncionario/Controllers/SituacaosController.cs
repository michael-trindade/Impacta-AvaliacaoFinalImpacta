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
    public class SituacaosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SituacaosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Situacaos
        [Authorize]
        public async Task<IActionResult> Index()
        {
              return View(await _context.Situacao.ToListAsync());
        }

        // GET: Situacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Situacao == null)
            {
                return NotFound();
            }

            var situacao = await _context.Situacao
                .FirstOrDefaultAsync(m => m.SituacaoId == id);
            if (situacao == null)
            {
                return NotFound();
            }

            return View(situacao);
        }

        // GET: Situacaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Situacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SituacaoId,Descricao")] Situacao situacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(situacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(situacao);
        }

        // GET: Situacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Situacao == null)
            {
                return NotFound();
            }

            var situacao = await _context.Situacao.FindAsync(id);
            if (situacao == null)
            {
                return NotFound();
            }
            return View(situacao);
        }

        // POST: Situacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SituacaoId,Descricao")] Situacao situacao)
        {
            if (id != situacao.SituacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(situacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SituacaoExists(situacao.SituacaoId))
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
            return View(situacao);
        }

        // GET: Situacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Situacao == null)
            {
                return NotFound();
            }

            var situacao = await _context.Situacao
                .FirstOrDefaultAsync(m => m.SituacaoId == id);
            if (situacao == null)
            {
                return NotFound();
            }

            return View(situacao);
        }

        // POST: Situacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Situacao == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Situacao'  is null.");
            }
            var situacao = await _context.Situacao.FindAsync(id);
            if (situacao != null)
            {
                _context.Situacao.Remove(situacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SituacaoExists(int id)
        {
          return _context.Situacao.Any(e => e.SituacaoId == id);
        }
    }
}
