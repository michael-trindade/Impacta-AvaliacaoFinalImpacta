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
    public class FrequenciasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FrequenciasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Frequencias
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Frequencia.Include(f => f.Funcionario).Include(f => f.Situacao);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Frequencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Frequencia == null)
            {
                return NotFound();
            }

            var frequencia = await _context.Frequencia
                .Include(f => f.Funcionario)
                .Include(f => f.Situacao)
                .FirstOrDefaultAsync(m => m.FrequenciaId == id);
            if (frequencia == null)
            {
                return NotFound();
            }

            return View(frequencia);
        }

        // GET: Frequencias/Create
        public IActionResult Create()
        {
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome");
            ViewData["SituacaoId"] = new SelectList(_context.Set<Situacao>(), "SituacaoId", "Descricao");
            return View();
        }

        // POST: Frequencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FrequenciaId,FuncionarioId,SituacaoId,DataInicio,DataFim")] Frequencia frequencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(frequencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome", frequencia.FuncionarioId);
            ViewData["SituacaoId"] = new SelectList(_context.Set<Situacao>(), "SituacaoId", "Descricao", frequencia.SituacaoId);
            return View(frequencia);
        }

        // GET: Frequencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Frequencia == null)
            {
                return NotFound();
            }

            var frequencia = await _context.Frequencia.FindAsync(id);
            if (frequencia == null)
            {
                return NotFound();
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome", frequencia.FuncionarioId);
            ViewData["SituacaoId"] = new SelectList(_context.Set<Situacao>(), "SituacaoId", "Descricao", frequencia.SituacaoId);
            return View(frequencia);
        }

        // POST: Frequencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FrequenciaId,FuncionarioId,SituacaoId,DataInicio,DataFim")] Frequencia frequencia)
        {
            if (id != frequencia.FrequenciaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(frequencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FrequenciaExists(frequencia.FrequenciaId))
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
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome", frequencia.FuncionarioId);
            ViewData["SituacaoId"] = new SelectList(_context.Set<Situacao>(), "SituacaoId", "Descricao", frequencia.SituacaoId);
            return View(frequencia);
        }

        // GET: Frequencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Frequencia == null)
            {
                return NotFound();
            }

            var frequencia = await _context.Frequencia
                .Include(f => f.Funcionario)
                .Include(f => f.Situacao)
                .FirstOrDefaultAsync(m => m.FrequenciaId == id);
            if (frequencia == null)
            {
                return NotFound();
            }

            return View(frequencia);
        }

        // POST: Frequencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Frequencia == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Frequencia'  is null.");
            }
            var frequencia = await _context.Frequencia.FindAsync(id);
            if (frequencia != null)
            {
                _context.Frequencia.Remove(frequencia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FrequenciaExists(int id)
        {
          return _context.Frequencia.Any(e => e.FrequenciaId == id);
        }
    }
}
