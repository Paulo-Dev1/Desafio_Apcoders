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
    public class DespesasController : Controller
    {
        private readonly ApContext _context;

        public DespesasController(ApContext context)
        {
            _context = context;
        }

        // GET: Despesas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Despesas.ToListAsync());
        }

        // GET: Despesas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesas = await _context.Despesas
                .FirstOrDefaultAsync(m => m.Id_Despesa == id);
            if (despesas == null)
            {
                return NotFound();
            }

            return View(despesas);
        }

        // GET: Despesas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Despesas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Despesa,Descricao,Tipo_Despesa,Valor,Vencimento_Fatura,Status_Pagamento,UnidadeId_unidade")] Despesas despesas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(despesas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(despesas);
        }

        // GET: Despesas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesas = await _context.Despesas.FindAsync(id);
            if (despesas == null)
            {
                return NotFound();
            }
            return View(despesas);
        }

        // POST: Despesas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Despesa,Descricao,Tipo_Despesa,Valor,Vencimento_Fatura,Status_Pagamento,UnidadeId_unidade")] Despesas despesas)
        {
            if (id != despesas.Id_Despesa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(despesas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DespesasExists(despesas.Id_Despesa))
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
            return View(despesas);
        }

        // GET: Despesas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesas = await _context.Despesas
                .FirstOrDefaultAsync(m => m.Id_Despesa == id);
            if (despesas == null)
            {
                return NotFound();
            }

            return View(despesas);
        }

        // POST: Despesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var despesas = await _context.Despesas.FindAsync(id);
            _context.Despesas.Remove(despesas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DespesasExists(int id)
        {
            return _context.Despesas.Any(e => e.Id_Despesa == id);
        }
    }
}
