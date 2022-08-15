using System;
using Microsoft.AspNetCore.Mvc;
using WsCACC.Dao;
using WsCACC.Model;

namespace WsCACC.Controllers
{
    /// <summary>
    /// Controlador Quem Somos
    /// </summary>    
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DiretoriaController : ControllerBase
    {
        /// <summary>
        /// Retorna os registros da diretoria ativos
        /// </summary>
        /// <returns>
        /// </returns>
        /// <response code="200">Sucess</response>
        [HttpGet("[Action]")]
        public JsonResult getDiretoria()
        {
            Retorno retorno = new Retorno();
            try
            {
                DaoDiretoria daoDiretoria = new DaoDiretoria();
                object diretoria = daoDiretoria.getDiretoria();

                retorno.data = diretoria;
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
        /// Retorna os registros da diretoria ativos e desativados
        /// </summary>
        /// <returns>
        /// </returns>
        /// <response code="200">Sucess</response>
        [HttpGet("[Action]")]
        public JsonResult getFullDiretoria()
        {
            Retorno retorno = new Retorno();
            try
            {
                DaoDiretoria daoDiretoria = new DaoDiretoria();
                object data = daoDiretoria.getFullDiretoria();

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
        /// Ativa ou Desativa o registro
        /// </summary>
        /// <param name="id">id do registro</param>
        /// <returns>
        /// </returns>
        /// <response code="200">Sucess</response>
        [HttpPut("[Action]")]
        public JsonResult alterarStatus(string id)
        {
            Retorno retorno = new Retorno();
            try
            {
                DaoDiretoria daoDiretoria = new DaoDiretoria();
                bool deu_certo = daoDiretoria.alterarStatus(id);

                if (deu_certo)
                {
                    retorno.data = id;
                    retorno.success = true;
                }

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
        /// Cria um registro
        /// </summary>
        /// <param name="model">Modelo de Criação</param>
        /// <returns>
        /// </returns>
        /// <response code="200">Sucess</response>
        [HttpPost("[Action]")]
        public JsonResult createRegistro([FromBody] CreateDiretoria model)
        {
            Retorno retorno = new Retorno();
            try
            {
                DaoDiretoria daoDiretoria = new DaoDiretoria();
                bool deu_certo = daoDiretoria.createRegistro(model);

                if (deu_certo)
                {
                    retorno.data = "OK";
                    retorno.success = true;
                }

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
        /// Deletar o registro
        /// </summary>
        /// <param name="id">id do registro</param>
        /// <returns>
        /// </returns>
        /// <response code="200">Sucess</response>
        [HttpDelete("[Action]")]
        public JsonResult deleteRegistro(string id)
        {
            Retorno retorno = new Retorno();
            try
            {
                DaoDiretoria daoDiretoria = new DaoDiretoria();
                bool deu_certo = daoDiretoria.deleteRegistro(id);

                if (deu_certo)
                {
                    retorno.data = id;
                    retorno.success = true;
                }

                return new JsonResult(retorno);
            }
            catch (Exception ex)
            {
                retorno.addItem(ex.Message);
                retorno.success = false;

                return new JsonResult(retorno);
            }
        }
    }
}