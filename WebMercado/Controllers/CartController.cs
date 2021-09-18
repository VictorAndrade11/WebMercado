using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMercado.Data;
using WebMercado.Helpers;
using WebMercado.Models;

namespace WebMercado.Controllers
{
    public class CartController : Controller
    {
        private readonly WebMercadoContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CartController(WebMercadoContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            webHostEnvironment = webHost;
        }


        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<Carrinho>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart == null ? 0 : cart.Items.Sum(item => item.Produto.ValorVenda * item.Quantidade);
            return View();
        }

        public Carrinho GetCarrinho()
        {
            if (SessionHelper.GetObjectFromJson<Carrinho>(HttpContext.Session, "cart") == null)
                return null;
            else
                return SessionHelper.GetObjectFromJson<Carrinho>(HttpContext.Session, "cart");
        }

        public IActionResult Adicionar(int id)
        {
            Produto produto = _context.Produtos.Find(id);
            Carrinho cart = new Carrinho();
            if (SessionHelper.GetObjectFromJson<Carrinho>(HttpContext.Session, "cart") == null)
            {
                cart.Items.Add(new Item { Produto = produto, Quantidade = 1, TotalItem = string.Format("R$ {0:N2}", produto.ValorVenda) });
            }
            else
            {
                cart = SessionHelper.GetObjectFromJson<Carrinho>(HttpContext.Session, "cart");
                int index = Existe(id, cart);
                if (index != -1)
                {
                    cart.Items[index].Quantidade++;
                    cart.Items[index].TotalItem = string.Format("R$ {0:N2}", cart.Items[index].Produto.ValorVenda * cart.Items[index].Quantidade);
                }
                else
                {
                    cart.Items.Add(new Item { Produto = produto, Quantidade = 1, TotalItem = string.Format("R$ {0:N2}", produto.ValorVenda) });
                }
            }
            cart.QtdeItens = cart.Items.Count();
            cart.ValorTotal = cart.Items.Sum(item => item.Produto.ValorVenda * item.Quantidade);
            cart.ValorTotalTexto = string.Format("R$ {0:N2}", cart.ValorTotal);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return PartialView("_CartPartial");
        }

        public IActionResult Diminuir(int id)
        {
            var cart = SessionHelper.GetObjectFromJson<Carrinho>(HttpContext.Session, "cart");
            int index = Existe(id, cart);
            if (index != -1)
            {
                if (cart.Items[index].Quantidade > 1)
                {
                    cart.Items[index].Quantidade--;
                    cart.Items[index].TotalItem = string.Format("R$ {0:N2}", cart.Items[index].Produto.ValorVenda * cart.Items[index].Quantidade);
                }
            }
            cart.QtdeItens = cart.Items.Count();
            cart.ValorTotal = cart.Items.Sum(item => item.Produto.ValorVenda * item.Quantidade);
            cart.ValorTotalTexto = string.Format("R$ {0:N2}", cart.ValorTotal);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return PartialView("_CartPartial");
        }


        public IActionResult Remover(int id)
        {
            var cart = SessionHelper.GetObjectFromJson<Carrinho>(HttpContext.Session, "cart");
            int index = Existe(id, cart);
            cart.Items.RemoveAt(index);
            cart.QtdeItens = cart.Items.Count();
            cart.ValorTotal = cart.Items.Sum(item => item.Produto.ValorVenda * item.Quantidade);
            cart.ValorTotalTexto = string.Format("R$ {0:N2}", cart.ValorTotal);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return PartialView("_CartPartial");
        }


        public int Existe(int id, Carrinho cart)
        {
            int index = -1;
            int i = 0;
            foreach (var item in cart.Items)
            {
                if (item.Produto.Id == id)
                {
                    index = i;
                    break;
                }
                i += 1;
            }
            return index;
        }

    }
}
