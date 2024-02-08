using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppVendasWeb.Data;
using AppVendasWeb.Models;

namespace AppVendasWeb.Controllers
{
    public class ItensDaVendaController : Controller
    {
        private readonly AppVendasContext _context;

        public ItensDaVendaController(AppVendasContext context)
        {
            _context = context;
        }

        // GET: ItensDaVenda
        public async Task<IActionResult> Index()
        {
            var appVendasContext = _context.ItensDaVenda.Include(i => i.Produto);
            return View(await appVendasContext.ToListAsync());
        }

        // GET: ItensDaVenda/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemDaVenda = await _context.ItensDaVenda
                .Include(i => i.Produto)
                .FirstOrDefaultAsync(m => m.ItemDaVendaID == id);
            if (itemDaVenda == null)
            {
                return NotFound();
            }

            return View(itemDaVenda);
        }

        // GET: ItensDaVenda/Create
        public IActionResult Create()
        {
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Descricao");
            return View();
        }

        // POST: ItensDaVenda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemDaVendaID,ProdutoId,Quantidade,Valor")] ItemDaVenda itemDaVenda)
        {
            if (ModelState.IsValid)
            {
                itemDaVenda.ItemDaVendaID = Guid.NewGuid();
                _context.Add(itemDaVenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Descricao", itemDaVenda.ProdutoId);
            return View(itemDaVenda);
        }

        // GET: ItensDaVenda/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemDaVenda = await _context.ItensDaVenda.FindAsync(id);
            if (itemDaVenda == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Descricao", itemDaVenda.ProdutoId);
            return View(itemDaVenda);
        }

        // POST: ItensDaVenda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ItemDaVendaID,ProdutoId,Quantidade,Valor")] ItemDaVenda itemDaVenda)
        {
            if (id != itemDaVenda.ItemDaVendaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemDaVenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemDaVendaExists(itemDaVenda.ItemDaVendaID))
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
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Descricao", itemDaVenda.ProdutoId);
            return View(itemDaVenda);
        }

        // GET: ItensDaVenda/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemDaVenda = await _context.ItensDaVenda
                .Include(i => i.Produto)
                .FirstOrDefaultAsync(m => m.ItemDaVendaID == id);
            if (itemDaVenda == null)
            {
                return NotFound();
            }

            return View(itemDaVenda);
        }

        // POST: ItensDaVenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var itemDaVenda = await _context.ItensDaVenda.FindAsync(id);
            if (itemDaVenda != null)
            {
                _context.ItensDaVenda.Remove(itemDaVenda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemDaVendaExists(Guid id)
        {
            return _context.ItensDaVenda.Any(e => e.ItemDaVendaID == id);
        }
    }
}
