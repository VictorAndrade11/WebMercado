using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using WebMercado.Models;
using WebMercado.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebMercado.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Usuario> userManager;
        private readonly SignInManager<Usuario> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<Usuario> user, SignInManager<Usuario> sign, RoleManager<IdentityRole> role)
        {
            userManager = user;
            signInManager = sign;
            roleManager = role;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();
            foreach (var user in users)
            {
                // Cria uma lista dos perfis (roles) de cada usuário (user)
                var perfis = await userManager.GetRolesAsync(user);
                // Join, para unir todos os items da lista em uma única string
                user.Roles = string.Join(", ", perfis);
            }
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = userManager.Users.Where(u => u.Id == id).SingleOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            // Pesquisar o perfil do usuário
            var perfil = await userManager.GetRolesAsync(user);
            ViewData["Perfis"] = new SelectList(roleManager.Roles, "NormalizedName", "Name");

            // Criarmos um objeto UsuarioViewModel
            UsuarioViewModel model = new UsuarioViewModel()
            {
                Id = user.Id,
                Nome = user.Nome,
                Apelido = user.Apelido,
                DataNascimento = user.DataNascimento,
                Email = user.Email,
                Perfil = perfil[0]
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, UsuarioViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = userManager.Users.Where(u => u.Id == id).SingleOrDefault();
                    user.Nome = model.Nome;
                    user.Apelido = model.Apelido;
                    user.DataNascimento = model.DataNascimento;
                    await userManager.UpdateAsync(user); // Salvar os dados do usuário

                    var perfil = await userManager.GetRolesAsync(user);
                    if (perfil[0] != model.Perfil)
                    {
                        await userManager.RemoveFromRoleAsync(user, perfil[0]);
                        await userManager.AddToRoleAsync(user, model.Perfil);
                    }
                }
                catch
                {
                    throw;
                }
                return RedirectToAction("Index");
            }
            // Cria uma lista de perfis
            ViewData["Perfis"] = new SelectList(roleManager.Roles, "NormalizedName", "Name");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = userManager.Users.Where(u => u.Id == id).SingleOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            // Pesquisar o perfil do usuário
            var perfil = await userManager.GetRolesAsync(user);
            ViewData["Perfis"] = new SelectList(roleManager.Roles, "NormalizedName", "Name");

            // Criarmos um objeto UsuarioViewModel
            UsuarioViewModel model = new UsuarioViewModel()
            {
                Id = user.Id,
                Nome = user.Nome,
                Apelido = user.Apelido,
                DataNascimento = user.DataNascimento,
                Email = user.Email,
                Perfil = perfil[0]
            };

            return View(model);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = userManager.Users.Where(u => u.Id == id).SingleOrDefault();
            try
            {
                await userManager.DeleteAsync(user);
            }
            catch
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel userModel, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            var result = await signInManager.PasswordSignInAsync(userModel.Email, userModel.Senha, userModel.Manter, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                // Retorna o usuário pelo Email
                var user = await userManager.FindByEmailAsync(userModel.Email);
                // Retornar os perfis do usuário
                var roles = await userManager.GetRolesAsync(user);
                if (roles.Contains("Administrador"))
                    return RedirectToAction("Index", "Admin");

                return RedirectToLocal(returnUrl);
            }
            if (result.IsLockedOut)
                ModelState.AddModelError("", "Usuário Bloqueado, aguarde liberação!!");
            else
                ModelState.AddModelError("", "E-mail de Acesso e/ou Senha Inválidos!!!");
            return View(userModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new Usuario()
            {
                UserName = model.Email,
                Nome = model.Nome,
                Apelido = model.Apelido ?? model.Nome.Split(' ', StringSplitOptions.None)[0],
                DataNascimento = model.DataNascimento,
                Email = model.Email,
                EmailConfirmed = false
            };
            // Cria a conta do usuário
            var result = await userManager.CreateAsync(user, model.Senha);
            // Verifica se deu errro
            if (!result.Succeeded)
            {
                foreach (var erro in result.Errors)
                {
                    if (erro.Code == "DuplicateEmail")
                    {
                        ModelState.AddModelError("", "O E-mail informado já encontra-se cadastrado em nosso site");
                    }
                    if (erro.Code == "PasswordTooShort")
                    {
                        ModelState.AddModelError("", "A Senha informada é muito curta. Use no mínimo 5 caracteres");
                    }
                }
                return View(model);
            }
            // Adicionar o perfil de "Cliente" ao usuário
            await userManager.AddToRoleAsync(user, "CLIENTE");

            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            var link = Url.Action("ConfirmEmail", "Account", new { token, email = user.Email }, Request.Scheme);
            var mensagem = string.Format("Clique <a href='{0}'>AQUI</a> para ativar sua conta", link);
            var email = new EmailSender();
            await email.Mail(model.Email, "suporte@webmercado.com", "Ativação da Conta | WebMercado", mensagem);
            // Já faz o login do usuário
            // await signInManager.PasswordSignInAsync(model.Email, model.Senha, model.Manter, lockoutOnFailure: true);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
                return View("Error");
            var result = await userManager.ConfirmEmailAsync(user, token);
            return View(result.Succeeded ? nameof(ConfirmEmail) : "Error");
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult SuccessRegistration()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Localizar
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return RedirectToAction("ForgotPasswordConfirmation");

            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var link = Url.Action("ResetPassword", "Account", new { token, email = user.Email }, Request.Scheme);
            var email = new EmailSender();
            string mensagem = string.Format("Clique <a href='{0}'>AQUI</a> para resetar sua senha", link);
            await email.Mail(model.Email, "suporte@etecshop.com", "Recuperação de Senha", mensagem);

            return RedirectToAction("ForgotPasswordConfirmation");
        }

        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPasswordModel { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Localizar se o email informada é de um usuário
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "E-mail não encontrado! Entre em contato com o suporte");
                return View(model);
            }

            var reset = await userManager.ResetPasswordAsync(user, model.Token, model.Senha);
            if (!reset.Succeeded)
            {
                foreach (var error in reset.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return View(model);
            }

            return RedirectToAction("ResetPasswordConfirmation");
        }

        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [AllowAnonymous]
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
