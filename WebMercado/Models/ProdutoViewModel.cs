using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMercado.Models
{
    public class ProdutoViewModel
    {
        public List<Categoria> Categorias { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
