using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TesteSOUE.Models.UseFul;


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

    public class LoginLogModel
    {
        public CadastroModel DataClient { get; set; }

        public string Token { get; set; }

        public void Create()
        {
            MySqlCommand Command = new MySqlCommand();
            DalModel objDAL = new DalModel();

            string sql = @"INSERT INTO soue_tb_log_register_token(id_client, token_number, data_access) value (@Id_Client, @Token_Number, @Data_Access)";

            Command.CommandText = sql;
            Command.Parameters.AddWithValue("@Id_Client", DataClient.Id);
            Command.Parameters.AddWithValue("@Token_Number", Token);
            Command.Parameters.AddWithValue("@Data_Access", ConvertAccessUserJSON(DataClient));

            objDAL.ExecuteCommandSQL(Command);
            objDAL.CloseConnection();
        }

        private object ConvertAccessUserJSON(CadastroModel cadastro)
        {
            return JsonConvert.SerializeObject(cadastro);
        }

    }

}
