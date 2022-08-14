using System;
using Microsoft.AspNetCore.Mvc;
using WsCACC.Dao;
using WsCACC.Model;

namespace WsCACC.Controllers
{
    /// <summary>
    /// Controlador Projetos
    /// </summary>    
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Faz o Login
        /// </summary>
        /// <param name="signin">objeto de login</param>
        /// <returns>
        /// </returns>
        /// <response code="200">Sucess</response>
        [HttpPost("[Action]")]
        public JsonResult signin(Signin signin)
        {
            Retorno retorno = new Retorno();
            try
            {
                DaoAuth daoAuth = new DaoAuth();
                object data = daoAuth.signin(signin.email, signin.password);

                retorno.data = data;
                retorno.success = true;

                return new JsonResult(retorno);
            }
            catch (Exception ex)
            {
                retorno.addItem(ex.Message);
                retorno.success = false;

                return new JsonResult(retorno);
            }
        }

        /// <summary>
        /// Valida o Token
        /// </summary>
        /// <param name="token">token</param>
        /// <returns>
        /// </returns>
        /// <response code="200">Sucess</response>
        [HttpPost("[Action]")]
        public JsonResult validateToken(string token)
        {
            try
            {
                User user = new User();
                user.id = "4";
                user.email = "fabioitj2010@hotmail.com";
                user.name = "Fabinho";
                user.senha = "123456";

                object retorno = new
                {
                    user,
                    token
                };

                return new JsonResult(retorno);
            }
            catch (Exception ex)
            {
                return new JsonResult("erro");
            }
        }
    }
}