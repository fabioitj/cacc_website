using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WsCACC.Model;

namespace WsCACC.Dao
{
    public class DaoAuth
    {
        public object signin(string email, string senha)
        {
            try
            {
                if (email == "testebanido@gmail.com")
                    throw new Exception("Este usuário foi banido!");

                if (email == "fabioitj2010@hotmail.com" && senha == "123456")
                {
                    User user = new User();
                    user.id = "4";
                    user.email = email;
                    user.name = "Fabio";
                    user.senha = senha;

                    string token = "123456789";

                    object data = new
                    {
                        user,
                        token
                    };

                    return data;
                }
                else
                    throw new Exception("Você inseriu as credenciais incorretamente!");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
