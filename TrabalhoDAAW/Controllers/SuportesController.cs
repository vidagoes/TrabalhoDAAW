using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabalhoDAAW.Data;
using TrabalhoDAAW.Models;

namespace TrabalhoDAAW.Controllers
{
    public class SuportesController : Controller
    {
        private readonly TrabalhoDAAWContext _context;

        public SuportesController(TrabalhoDAAWContext context)
        {
            _context = context;
        }

        // GET: Suportes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Suporte.ToListAsync());
        }

        // GET: Suportes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suporte = await _context.Suporte
                .FirstOrDefaultAsync(m => m.MessageId == id);
            if (suporte == null)
            {
                return NotFound();
            }

            return View(suporte);
        }

        // GET: Suportes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suportes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MessageId,Nome,Email,Descricao,Conteudo,DataEnvio")] Suporte suporte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(suporte);
        }

        // GET: Suportes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suporte = await _context.Suporte.FindAsync(id);
            if (suporte == null)
            {
                return NotFound();
            }
            return View(suporte);
        }

        // POST: Suportes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MessageId,Nome,Email,Descricao,Conteudo,DataEnvio")] Suporte suporte)
        {
            if (id != suporte.MessageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suporte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuporteExists(suporte.MessageId))
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
            return View(suporte);
        }

        // GET: Suportes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suporte = await _context.Suporte
                .FirstOrDefaultAsync(m => m.MessageId == id);
            if (suporte == null)
            {
                return NotFound();
            }

            return View(suporte);
        }

        // POST: Suportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suporte = await _context.Suporte.FindAsync(id);
            if (suporte != null)
            {
                _context.Suporte.Remove(suporte);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuporteExists(int id)
        {
            return _context.Suporte.Any(e => e.MessageId == id);
        }
    }
}
