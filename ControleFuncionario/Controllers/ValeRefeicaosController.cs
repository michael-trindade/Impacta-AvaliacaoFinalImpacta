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
    public class ValeRefeicaosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ValeRefeicaosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ValeRefeicaos
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ValeRefeicao.Include(v => v.Empresa).Include(v => v.Funcionario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ValeRefeicaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ValeRefeicao == null)
            {
                return NotFound();
            }

            var valeRefeicao = await _context.ValeRefeicao
                .Include(v => v.Empresa)
                .Include(v => v.Funcionario)
                .FirstOrDefaultAsync(m => m.ValeRefeicaoId == id);
            if (valeRefeicao == null)
            {
                return NotFound();
            }

            return View(valeRefeicao);
        }

        // GET: ValeRefeicaos/Create
        public IActionResult Create()
        {
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "EmpresaId", "NomeEmpresa");
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome");
            return View();
        }

        // POST: ValeRefeicaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ValeRefeicaoId,EmpresaId,FuncionarioId,Qtde,Valor")] ValeRefeicao valeRefeicao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(valeRefeicao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "EmpresaId", "NomeEmpresa", valeRefeicao.EmpresaId);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome", valeRefeicao.FuncionarioId);
            return View(valeRefeicao);
        }

        // GET: ValeRefeicaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ValeRefeicao == null)
            {
                return NotFound();
            }

            var valeRefeicao = await _context.ValeRefeicao.FindAsync(id);
            if (valeRefeicao == null)
            {
                return NotFound();
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "EmpresaId", "NomeEmpresa", valeRefeicao.EmpresaId);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome", valeRefeicao.FuncionarioId);
            return View(valeRefeicao);
        }

        // POST: ValeRefeicaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ValeRefeicaoId,EmpresaId,FuncionarioId,Qtde,Valor")] ValeRefeicao valeRefeicao)
        {
            if (id != valeRefeicao.ValeRefeicaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(valeRefeicao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ValeRefeicaoExists(valeRefeicao.ValeRefeicaoId))
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
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "EmpresaId", "NomeEmpresa", valeRefeicao.EmpresaId);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome", valeRefeicao.FuncionarioId);
            return View(valeRefeicao);
        }

        // GET: ValeRefeicaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ValeRefeicao == null)
            {
                return NotFound();
            }

            var valeRefeicao = await _context.ValeRefeicao
                .Include(v => v.Empresa)
                .Include(v => v.Funcionario)
                .FirstOrDefaultAsync(m => m.ValeRefeicaoId == id);
            if (valeRefeicao == null)
            {
                return NotFound();
            }

            return View(valeRefeicao);
        }

        // POST: ValeRefeicaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ValeRefeicao == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ValeRefeicao'  is null.");
            }
            var valeRefeicao = await _context.ValeRefeicao.FindAsync(id);
            if (valeRefeicao != null)
            {
                _context.ValeRefeicao.Remove(valeRefeicao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ValeRefeicaoExists(int id)
        {
          return _context.ValeRefeicao.Any(e => e.ValeRefeicaoId == id);
        }
    }
}
