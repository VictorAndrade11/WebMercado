using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMercado.Models
{
    public class Usuario : IdentityUser
    {
        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "Por favor, informe o Nome do Usuário")]
        [StringLength(50, ErrorMessage = "O Nome do Usuário deve possuir no máximo 50 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Apelido")]
        [StringLength(20, ErrorMessage = "O Apelido deve possuir no máximo 20 caracteres")]
        public string Apelido { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [NotMapped]  // Significa que essa propriedade não vai existir no banco
        public string Roles { get; set; }
    }
}
