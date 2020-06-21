using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TesteSOUE.Models.UseFul;

namespace TesteSOUE.Models
{
    public class CadastroModel
    {
        public int Id { get; set; }
        //
        [Required(ErrorMessage = "O campo nome deve ser informado!")]
        public string Name { get; set; }
        //
        [Required(ErrorMessage = "O campo CPF deve ser informado!")]
        public string Cpf { get; set; }
        //
        [Required(ErrorMessage = "O campo E-MAIL deve ser informado!")]
        public string Email { get; set; }
        //
        [Required(ErrorMessage = "O campo Telefone deve ser informado!")]
        public string PhoneNumber { get; set; }
        //
        [Required(ErrorMessage = "O campo Endereço deve ser informado!")]
        public string Address { get; set; }

        public void Create()
        {
            MySqlCommand Command = new MySqlCommand();
            DalModel objDAL = new DalModel();

                string sql = @"INSERT INTO soue_tb_register_client(name, cpf, email, phoneNumber, address) value (@Name, @Cpf, @Email, @PhoneNumber, @Address)";


                Command.CommandText = sql;
                Command.Parameters.AddWithValue("@Name", Name);
                Command.Parameters.AddWithValue("@Cpf", Cpf);
                Command.Parameters.AddWithValue("@Email", Email);
                Command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                Command.Parameters.AddWithValue("@Address", Address);

                objDAL.ExecuteCommandSQL(Command);
                objDAL.CloseConnection();
        }

        public CadastroModel SearchForCpf(string cpf)
        {
            string sql = @"SELECT * FROM soue_tb_register_client WHERE cpf = @Cpf ORDER BY id ASC LIMIT 1";

            MySqlCommand Command = new MySqlCommand();
            DalModel objDAL = new DalModel();

            Command.CommandText = sql;
            Command.Parameters.AddWithValue("@Cpf", cpf);

            DataTable dt = objDAL.ReturnDataTable(Command);
            objDAL.CloseConnection();

            if (dt.Rows.Count > 0)
            {
                CadastroModel RegisterClient = new CadastroModel() { 
                    Id = Convert.ToInt32(dt.Rows[0]["id"]),
                    Name = dt.Rows[0]["name"].ToString(),
                    Cpf = dt.Rows[0]["cpf"].ToString(),
                    Email = dt.Rows[0]["email"].ToString(),
                    PhoneNumber = dt.Rows[0]["phonenumber"].ToString(),
                    Address = dt.Rows[0]["address"].ToString()
                };

                return RegisterClient;
            }

            return null;
        }
    }
}
