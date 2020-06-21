using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteSOUE.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O campo CPF deve ser informado!")]
        public string Cpf { get; set; }

        public bool Validate()
        {
            CadastroModel cadastroModel = new CadastroModel();

            cadastroModel = cadastroModel.SearchForCpf(Cpf);

            return false;
        }

    }
}
