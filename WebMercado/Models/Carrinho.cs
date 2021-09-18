using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMercado.Models
{
    public class Carrinho
    {
        public List<Item> Items { get; set; }
        public int QtdeItens { get; set; }
        public double ValorTotal { get; set; }
        public string ValorTotalTexto { get; set; }

        public Carrinho()
        {
            Items = new List<Item>();
            QtdeItens = 0;
            ValorTotal = 0;
            ValorTotalTexto = "R$ 0,00";
        }
    }

    public class Item
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public string TotalItem { get; set; }
    }

}
