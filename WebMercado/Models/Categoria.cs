using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebMercado.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome", Prompt = "Nome")]
        [Required(ErrorMessage = "Por favor, informe o Nome da Categoria")]
        [StringLength(50, ErrorMessage = "O Nome deve possuir no máximo 50 caracteres")]
        public string Nome { get; set; }
    }

}
