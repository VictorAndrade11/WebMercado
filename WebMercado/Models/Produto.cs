using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebMercado.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome", Prompt = "Nome")]
        [Required(ErrorMessage = "Por favor, informe o Nome do Produto")]
        [StringLength(70, ErrorMessage = "O Nome deve possuir no máximo 70 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Descrição", Prompt = "Descrição")]
        [StringLength(500, ErrorMessage = "A Descrição deve possuir no máximo 500 caracteres")]
        public string Descricao { get; set; }

        [Display(Name = "Estoque Atual", Prompt = "Estoque Atual")]
        [Required(ErrorMessage = "Por favor, informe o Estoque Atual")]
        public int EstoqueAtual { get; set; }

        [Display(Name = "Estoque Mínimo", Prompt = "Estoque Mínimo")]
        [Required(ErrorMessage = "Por favor, informe o Estoque Mínimo")]
        public int EstoqueMinimo { get; set; }

        [Display(Name = "Valor de Custo", Prompt = "Valor de Custo")]
        [Required(ErrorMessage = "Por favor, informe o Valor de Custo")]
        public double ValorCusto { get; set; }

        [Display(Name = "Valor de Venda", Prompt = "Valor de Venda")]
        [Required(ErrorMessage = "Por favor, informe o Valor de Venda")]
        public double ValorVenda { get; set; }

        [Display(Name = "Data de Cadastro", Prompt = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Categoria", Prompt = "Categoria")]
        [Required(ErrorMessage = "Por favor, informe a Categoria")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        [Display(Name = "Foto", Prompt = "Foto")]
        [StringLength(500, ErrorMessage = "A Foto deve possuir no máximo 500 caracteres")]
        public string Imagem { get; set; }
    }
}
