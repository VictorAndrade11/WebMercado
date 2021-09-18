using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebMercado.Models
{
    public class Contato
    {
        [Display(Prompt = "Informe seu Nome")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, ErrorMessage = "O Nome deve possuir no máximo 50 carateres")]
        public string Nome { get; set; }

        [Display(Prompt = "Informe seu E-mail")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido")]
        [StringLength(100, ErrorMessage = "O E-mail deve possuir no máximo 100 carateres")]
        public string Email { get; set; }

        [Display(Prompt = "Informe o Assunto")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, ErrorMessage = "O Assunto deve possuir no máximo 50 carateres")]
        public string Assunto { get; set; }

        [Display(Prompt = "Deixe sua Mensagem Aqui")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(500, ErrorMessage = "A Mensagem deve possuir no máximo 500 carateres")]
        public string Mensagem { get; set; }
    }
}