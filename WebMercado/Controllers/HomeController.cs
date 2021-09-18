using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebMercado.Data;
using WebMercado.Services;
using WebMercado.Models;
using X.PagedList;

namespace WebMercado.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebMercadoContext _context;

        public HomeController(ILogger<HomeController> logger, WebMercadoContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ProdutoViewModel pvm = new ProdutoViewModel();
            pvm.Categorias = _context.Categorias.ToList();
            pvm.Produtos = _context.Produtos.Include(c => c.Categoria).ToList();
            return View(pvm);
        }

        public IActionResult Produtos(string Pesquisa)
        {
            ProdutoViewModel pvm = new ProdutoViewModel();
            pvm.Categorias = _context.Categorias.ToList();
            if (string.IsNullOrEmpty(Pesquisa))
            { 
                pvm.Produtos = _context.Produtos.Include(c => c.Categoria).ToList();
            }
            else
            {
                pvm.Produtos = _context.Produtos.Include(c => c.Categoria).Where(p => p.Nome.Contains(Pesquisa)).ToList();
            }
            ViewData["Numero"] = pvm.Produtos.Count();
            return View(pvm);

        }

        public ActionResult ProdutosFiltrados(int id)
        {
            var produtos = _context.Produtos.Include(c => c.Categoria).ToList();
            if (id != 0)
            {
                produtos = _context.Produtos.Include(c => c.Categoria).Where(p => p.CategoriaId == id).ToList();
            }
            ViewData["Numero"] = produtos.Count();
            return PartialView("_ProdutosFiltrados", produtos);
        }

        public IActionResult Contatos()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Contatos(Contato model)
        {
            if (ModelState.IsValid)
            {
                var email = new EmailSender();
                string mensagem = string.Format(
   "Contato feito no WebMercado<br>Nome: {0}<br>Email: {1}<br>Assunto: {2}<br>Mensagem: {3}<br>",
                   model.Nome, model.Email, model.Assunto, model.Mensagem);
                await email.Mail("nadavison@live.com", model.Email, "Contato WebMercado", mensagem);
                return Json(new { success = true, message = "Enviado" });
            }
            return Json(new { success = false, message = "Dados Incompletos" });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
