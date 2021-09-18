using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebMercado.Models
{
    public class LoginViewModel
    {
        [Display(Name = "E-mail de Acesso", Prompt = "E-mail de Acesso")]
        [Required(ErrorMessage = "Por favor, Informe o E-mail de Acesso")]
        [EmailAddress(ErrorMessage = "Por favor, Informe um E-mail Válido!!")]
        public string Email { get; set; }

        [Display(Name = "Senha de Acesso", Prompt = "Senha de Acesso")]
        [Required(ErrorMessage = "Por favor, Informe a Senha de Acesso")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Continuar Conectado?")]
        public bool Manter { get; set; }
    }


    public class RegisterViewModel
    {
        [Display(Name = "Nome Completo", Prompt = "Nome Completo")]
        [Required(ErrorMessage = "Por favor, informe o Nome do Usuário")]
        [StringLength(50, ErrorMessage = "O Nome do Usuário deve possuir no máximo 50 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Apelido", Prompt = "Apelido")]
        [StringLength(20, ErrorMessage = "O Apelido deve possuir no máximo 20 caracteres")]
        public string Apelido { get; set; }

        [Display(Name = "Data de Nascimento", Prompt = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "E-mail de Acesso", Prompt = "E-mail de Acesso")]
        [Required(ErrorMessage = "Por favor, Informe o E-mail de Acesso")]
        [EmailAddress(ErrorMessage = "Por favor, Informe um E-mail Válido!!")]
        public string Email { get; set; }

        [Display(Name = "Senha de Acesso", Prompt = "Senha de Acesso")]
        [Required(ErrorMessage = "Por favor, Informe a Senha de Acesso")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Confirmação de Senha", Prompt = "Confirmação de Senha")]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "Senha e Confirmação de Senha não conferem!")]
        public string ConfirmarSenha { get; set; }

        [Display(Name = "Continuar Conectado?")]
        public bool Manter { get; set; }
    }

    public class ForgotPasswordModel
    {
        [Display(Name = "E-mail de Acesso", Prompt = "E-mail de Acesso")]
        [Required(ErrorMessage = "Por favor, informe o E-mail de Acesso")]
        [EmailAddress(ErrorMessage = "Por favor, informe o E-mail de Acesso")]
        public string Email { get; set; }
    }

    public class ResetPasswordModel
    {
        [Display(Name = "Senha de Acesso", Prompt = "Senha de Acesso")]
        [Required(ErrorMessage = "Por favor, Informe a Senha de Acesso")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Confirmação de Senha", Prompt = "Confirmação de Senha")]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "Senha e Confirmação de Senha não conferem!")]
        public string ConfirmarSenha { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }
    }

    public class UsuarioViewModel
    {
        [HiddenInput]
        public string Id { get; set; }

        [Display(Name = "E-mail de Acesso", Prompt = "E-mail de Acesso")]
        [Required(ErrorMessage = "Por favor, Informe o E-mail de Acesso")]
        [EmailAddress(ErrorMessage = "Por favor, Informe um E-mail Válido!!")]
        public string Email { get; set; }

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

        [Display(Name = "Perfil de Acesso")]
        [Required(ErrorMessage = "Por favor, informe o Perfil de Acesso do Usuário")]
        public string Perfil { get; set; }
    }

}
