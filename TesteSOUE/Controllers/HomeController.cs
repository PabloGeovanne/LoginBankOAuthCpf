using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using TesteSOUE.Models;

namespace TesteSOUE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult AbriConta(CadastroModel cadastro) 
        {
            if (ModelState.IsValid)
            {
                if (cadastro.SearchForCpf(cadastro.Cpf) == null)
                {
                    cadastro.Create();

                    return RedirectToAction("Authenticate", "Home", new RouteValueDictionary(cadastro));
                }
            }

            return RedirectToAction("Index", "Auth");
        } 

        public IActionResult Investimento()
        {
            return View();
        }

        public IActionResult Planos() 
        {
            return View();
        }

        public IActionResult QuemSomos() 
        {
            return View();
        }

        public IActionResult NossosServicos()
        {
            return View();
        }

        public IActionResult Carreiras()
        {
            return View();
        }

        public IActionResult Desenvolvedores()
        {
            return View();
        }

        public IActionResult CartoesCreditos ()
        {
            return View();
        }

        public IActionResult CreditosFinanciamento()
        {
            return View();
        }

        public IActionResult InvestimentosPessoaFisica()
        {
            return View();
        }

        public IActionResult ComercialBanking()
        {
            return View();
        }

        public IActionResult Seguros()
        {
            return View();
        }

        public IActionResult TesouroDireto()
        {
            return View();
        }

        public IActionResult Authenticate(CadastroModel cadastro)
        {
            cadastro = cadastro.SearchForCpf(cadastro.Cpf);

            if (cadastro != null)
            {
                var grandmaClaims = new List<Claim>() { 
            
                    new Claim(ClaimTypes.Name, cadastro.Name),
                    new Claim(ClaimTypes.Email, cadastro.Email),
                    new Claim("Cpf", cadastro.Cpf),
                    new Claim(ClaimTypes.MobilePhone, cadastro.PhoneNumber),
                    new Claim(ClaimTypes.StreetAddress, cadastro.Address)
                };

                var grandmaIdentity = new ClaimsIdentity(grandmaClaims, "Grandma Identity");
                var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });

                HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("RedirectToAccount", "Auth");
            }

            return RedirectToAction("index", "Auth");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
