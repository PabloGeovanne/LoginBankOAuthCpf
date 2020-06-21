using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TesteSOUE.Models;
using System.Security.Claims;
using System.Net;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Microsoft.AspNetCore.Http;
using System.Text.Encodings.Web;

namespace TesteSOUE.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ILogger<ClienteController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            var identity = (ClaimsIdentity)User.Identity;
            string id = identity.Claims.FirstOrDefault(c => c.Type == "Id").Value;
            string cpf = identity.Claims.FirstOrDefault(c => c.Type == "Cpf").Value;
            string name = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            string email = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            string mobilephone = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.MobilePhone).Value;
            string streetaddress = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.StreetAddress).Value;

            CadastroModel cadastro = new CadastroModel() 
            { 
                Id = Convert.ToInt32(id),
                Cpf = cpf,
                Name = name,
                Email = email,
                PhoneNumber = mobilephone,
                Address = streetaddress            
            };

            var cookie = Request.Cookies["Cadastro"];
            LoginLogModel LoginLog = new LoginLogModel()
            {
                DataClient = cadastro,
                Token = cookie
            };
            LoginLog.Create();

            string dataArray = JsonConvert.SerializeObject(cadastro, Formatting.None);

            //CREATE DATA COOKIES NOT SECURE
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(1);
            option.Secure = false;
            option.HttpOnly = true;

            Response.Cookies.Append("Cadastro_UnSafe", dataArray, option);

            return View(cadastro);
        }

        [Authorize]
        public IActionResult Sair()
        {
            Response.Cookies.Delete("Cadastro_UnSafe");
            Response.Cookies.Delete("Cadastro");

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
