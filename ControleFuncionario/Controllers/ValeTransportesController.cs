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
    public class ValeTransportesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ValeTransportesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ValeTransportes
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ValeTransporte.Include(v => v.Empresa).Include(v => v.Funcionario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ValeTransportes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ValeTransporte == null)
            {
                return NotFound();
            }

            var valeTransporte = await _context.ValeTransporte
                .Include(v => v.Empresa)
                .Include(v => v.Funcionario)
                .FirstOrDefaultAsync(m => m.ValeTransporteId == id);
            if (valeTransporte == null)
            {
                return NotFound();
            }

            return View(valeTransporte);
        }

        // GET: ValeTransportes/Create
        public IActionResult Create()
        {
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "EmpresaId", "NomeEmpresa");
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome");
            return View();
        }

        // POST: ValeTransportes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ValeTransporteId,EmpresaId,FuncionarioId,Qtde,Valor")] ValeTransporte valeTransporte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(valeTransporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "EmpresaId", "NomeEmpresa", valeTransporte.EmpresaId);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome", valeTransporte.FuncionarioId);
            return View(valeTransporte);
        }

        // GET: ValeTransportes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ValeTransporte == null)
            {
                return NotFound();
            }

            var valeTransporte = await _context.ValeTransporte.FindAsync(id);
            if (valeTransporte == null)
            {
                return NotFound();
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "EmpresaId", "NomeEmpresa", valeTransporte.EmpresaId);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome", valeTransporte.FuncionarioId);
            return View(valeTransporte);
        }

        // POST: ValeTransportes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ValeTransporteId,EmpresaId,FuncionarioId,Qtde,Valor")] ValeTransporte valeTransporte)
        {
            if (id != valeTransporte.ValeTransporteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(valeTransporte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ValeTransporteExists(valeTransporte.ValeTransporteId))
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
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "EmpresaId", "NomeEmpresa", valeTransporte.EmpresaId);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Nome", valeTransporte.FuncionarioId);
            return View(valeTransporte);
        }

        // GET: ValeTransportes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ValeTransporte == null)
            {
                return NotFound();
            }

            var valeTransporte = await _context.ValeTransporte
                .Include(v => v.Empresa)
                .Include(v => v.Funcionario)
                .FirstOrDefaultAsync(m => m.ValeTransporteId == id);
            if (valeTransporte == null)
            {
                return NotFound();
            }

            return View(valeTransporte);
        }

        // POST: ValeTransportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ValeTransporte == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ValeTransporte'  is null.");
            }
            var valeTransporte = await _context.ValeTransporte.FindAsync(id);
            if (valeTransporte != null)
            {
                _context.ValeTransporte.Remove(valeTransporte);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ValeTransporteExists(int id)
        {
          return _context.ValeTransporte.Any(e => e.ValeTransporteId == id);
        }
    }
}
