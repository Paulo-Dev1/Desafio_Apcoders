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
    public class InquilinosController : Controller
    {
        private readonly ApContext _context;

        public InquilinosController(ApContext context)
        {
            _context = context;
        }

        // GET: Inquilinos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Inquilinos.ToListAsync());
        }

        // GET: Inquilinos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inquilinos = await _context.Inquilinos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inquilinos == null)
            {
                return NotFound();
            }

            return View(inquilinos);
        }

        // GET: Inquilinos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inquilinos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Idade,Sexo,Telefone,Email")] Inquilinos inquilinos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inquilinos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inquilinos);
        }

        // GET: Inquilinos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inquilinos = await _context.Inquilinos.FindAsync(id);
            if (inquilinos == null)
            {
                return NotFound();
            }
            return View(inquilinos);
        }

        // POST: Inquilinos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Idade,Sexo,Telefone,Email")] Inquilinos inquilinos)
        {
            if (id != inquilinos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inquilinos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InquilinosExists(inquilinos.Id))
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
            return View(inquilinos);
        }

        // GET: Inquilinos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inquilinos = await _context.Inquilinos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inquilinos == null)
            {
                return NotFound();
            }

            return View(inquilinos);
        }

        // POST: Inquilinos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inquilinos = await _context.Inquilinos.FindAsync(id);
            _context.Inquilinos.Remove(inquilinos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InquilinosExists(int id)
        {
            return _context.Inquilinos.Any(e => e.Id == id);
        }
    }
}
