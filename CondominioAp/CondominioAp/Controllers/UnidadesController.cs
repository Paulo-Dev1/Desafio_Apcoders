using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CondominioAp.Data;
using CondominioAp.Models;

namespace CondominioAp.Controllers
{
    public class UnidadesController : Controller
    {
        private readonly ApContext _context;

        public UnidadesController(ApContext context)
        {
            _context = context;
        }

        // GET: Unidades
        public async Task<IActionResult> Index()
        {
            var apContext = _context.Unidades.Include(u => u.Inquilinos);
            return View(await apContext.ToListAsync());
        }

        // GET: Unidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidades = await _context.Unidades
                .Include(u => u.Inquilinos)
                .FirstOrDefaultAsync(m => m.Id_Unidade == id);
            if (unidades == null)
            {
                return NotFound();
            }

            return View(unidades);
        }

        // GET: Unidades/Create
        public IActionResult Create()
        {
            ViewData["InquilinosId_Inquilino"] = new SelectList(_context.Inquilinos, "Id_Inquilino", "Email");
            return View();
        }

        // POST: Unidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Unidade,Identificacao,Propietario,Condominio,Endereco,InquilinosId_Inquilino")] Unidades unidades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InquilinosId_Inquilino"] = new SelectList(_context.Inquilinos, "Id_Inquilino", "Email", unidades.InquilinosId_Inquilino);
            return View(unidades);
        }

        // GET: Unidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidades = await _context.Unidades.FindAsync(id);
            if (unidades == null)
            {
                return NotFound();
            }
            ViewData["InquilinosId_Inquilino"] = new SelectList(_context.Inquilinos, "Id_Inquilino", "Email", unidades.InquilinosId_Inquilino);
            return View(unidades);
        }

        // POST: Unidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Unidade,Identificacao,Propietario,Condominio,Endereco,InquilinosId_Inquilino")] Unidades unidades)
        {
            if (id != unidades.Id_Unidade)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadesExists(unidades.Id_Unidade))
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
            ViewData["InquilinosId_Inquilino"] = new SelectList(_context.Inquilinos, "Id_Inquilino", "Email", unidades.InquilinosId_Inquilino);
            return View(unidades);
        }

        // GET: Unidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidades = await _context.Unidades
                .Include(u => u.Inquilinos)
                .FirstOrDefaultAsync(m => m.Id_Unidade == id);
            if (unidades == null)
            {
                return NotFound();
            }

            return View(unidades);
        }

        // POST: Unidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unidades = await _context.Unidades.FindAsync(id);
            _context.Unidades.Remove(unidades);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadesExists(int id)
        {
            return _context.Unidades.Any(e => e.Id_Unidade == id);
        }
    }
}
