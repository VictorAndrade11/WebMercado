using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMercado.Data;
using WebMercado.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using X.PagedList;


namespace WebMercado.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly WebMercadoContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProdutosController(WebMercadoContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            webHostEnvironment = webHost;
        }

        public async Task<IActionResult> Index(string filtro, string pesquisa, int? pagina)
        {
            if (pesquisa != null)
            {
                pagina = 1;
            }
            else
            {
                pesquisa = filtro;
            }
            ViewData["Filtro"] = pesquisa;

            var produtos = from p in _context.Produtos.Include(p => p.Categoria) select p;

            if (!String.IsNullOrEmpty(pesquisa))
            {
                produtos = produtos.Where(p => p.Nome.Contains(pesquisa)).AsNoTracking();
            }
            int itensPorPagina = 10;
            return View(await produtos.ToPagedListAsync(pagina, itensPorPagina));
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,EstoqueAtual,EstoqueMinimo,ValorCusto,ValorVenda,DataCadastro,CategoriaId,Imagem")] Produto produto, IFormFile Imagem)
        {
            if (ModelState.IsValid)
            {
                if (Imagem != null)
                {
                    string pasta = Path.Combine(webHostEnvironment.WebRootPath, "img\\produtos");
                    var nomeArquivo = Guid.NewGuid().ToString() + "_" + Imagem.FileName;
                    string caminhoArquivo = Path.Combine(pasta, nomeArquivo);
                    using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                    {
                        await Imagem.CopyToAsync(stream);
                    }
                    produto.Imagem = "/img/produtos/" + nomeArquivo;
                }
                produto.DataCadastro = DateTime.Now; // inclui a data de cadastro
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome", produto.CategoriaId);
            return View(produto);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome", produto.CategoriaId);
            ViewData["CaminhoImagem"] = webHostEnvironment.WebRootPath;
            return View(produto);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,EstoqueAtual,EstoqueMinimo,ValorCusto,ValorVenda,DataCadastro,CategoriaId,Imagem")] Produto produto, IFormFile NovaImagem)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (NovaImagem != null)
                    {
                        string pasta = Path.Combine(webHostEnvironment.WebRootPath, "img\\produtos");
                        var nomeArquivo = Guid.NewGuid().ToString() + "_" + NovaImagem.FileName;
                        string caminhoArquivo = Path.Combine(pasta, nomeArquivo);
                        using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                        {
                            await NovaImagem.CopyToAsync(stream);
                        }
                        produto.Imagem = "/img/produtos/" + nomeArquivo;
                    }
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome", produto.CategoriaId);
            ViewData["CaminhoImagem"] = webHostEnvironment.WebRootPath;
            return View(produto);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
