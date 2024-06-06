using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabalhoDAAW.Data;
using TrabalhoDAAW.Models;

namespace TrabalhoDAAW.Controllers
{
    public class CadastroUsuariosController : Controller
    {
        private readonly TrabalhoDAAWContext _context;

        public CadastroUsuariosController(TrabalhoDAAWContext context)
        {
            _context = context;
        }

        // GET: CadastroUsuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastroUsuario.ToListAsync());
        }

        // GET: CadastroUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroUsuario = await _context.CadastroUsuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroUsuario == null)
            {
                return NotFound();
            }

            return View(cadastroUsuario);
        }

        // GET: CadastroUsuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,senha,email")] CadastroUsuario cadastroUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroUsuario);
        }

        // GET: CadastroUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroUsuario = await _context.CadastroUsuario.FindAsync(id);
            if (cadastroUsuario == null)
            {
                return NotFound();
            }
            return View(cadastroUsuario);
        }

        // POST: CadastroUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,senha,email")] CadastroUsuario cadastroUsuario)
        {
            if (id != cadastroUsuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroUsuarioExists(cadastroUsuario.Id))
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
            return View(cadastroUsuario);
        }

        // GET: CadastroUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroUsuario = await _context.CadastroUsuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroUsuario == null)
            {
                return NotFound();
            }

            return View(cadastroUsuario);
        }

        // POST: CadastroUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroUsuario = await _context.CadastroUsuario.FindAsync(id);
            if (cadastroUsuario != null)
            {
                _context.CadastroUsuario.Remove(cadastroUsuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroUsuarioExists(int id)
        {
            return _context.CadastroUsuario.Any(e => e.Id == id);
        }
    }
}
