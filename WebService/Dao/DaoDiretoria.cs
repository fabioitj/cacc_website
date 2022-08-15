using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WsCACC.Model;

namespace WsCACC.Dao
{
    public class DaoDiretoria
    {
        public bool createRegistro(CreateDiretoria model)
        {
            ConnectionMySql conexao = new ConnectionMySql();
            try
            {
                string sql = $@"    INSERT INTO 
                                        CACC.DIRETORIA
                                        (
                                            NOME,
                                            CARGO,
                                            APRESENTACAO,
                                            IMAGEM,
                                            ATIVO,
                                            ORDEM
                                        )
                                        VALUES
                                        (
                                            '{model.nome}',
                                            '{model.cargo}',
                                            '{model.apresentacao}',
                                            '{model.imagem}',
                                            'S',
                                            2
                                        )";

                conexao.StartTransaction();
                conexao.ExecuteNonQuery(sql);
                conexao.CommitTransaction();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Diretoria> getDiretoria()
        {
            ConnectionMySql conexao = new ConnectionMySql();
            try
            {
                string sql = $@"SELECT
                                    IDDIRETORIA,
                                    NOME,
                                    CARGO,
                                    APRESENTACAO,
                                    IMAGEM,
                                    ATIVO
                                FROM
                                    CACC.DIRETORIA
                                WHERE 
                                    ATIVO = 'S'
                                ORDER BY
                                    ORDEM
                                ASC";

                MySqlDataReader table = conexao.ExecuteQuery(sql);
                List<Diretoria> diretoria = new List<Diretoria>();
                while (table.Read())
                {
                    Diretoria item = new Diretoria();
                    item.iddiretoria = table["IDDIRETORIA"].ToString();
                    item.nome = table["NOME"].ToString();
                    item.cargo = table["CARGO"].ToString();
                    item.apresentacao = table["APRESENTACAO"].ToString();
                    item.imagem = table["IMAGEM"].ToString();
                    item.ativo = table["ATIVO"].ToString();

                    diretoria.Add(item);
                }
                table.Close();

                return diretoria;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.conn.Close();
            }
        }

        public List<Diretoria> getFullDiretoria()
        {
            ConnectionMySql conexao = new ConnectionMySql();
            try
            {
                string sql = $@"SELECT
                                    IDDIRETORIA,
                                    NOME,
                                    CARGO,
                                    APRESENTACAO,
                                    IMAGEM,
                                    ATIVO
                                FROM
                                    CACC.DIRETORIA
                                ORDER BY
                                    ORDEM
                                ASC";

                MySqlDataReader table = conexao.ExecuteQuery(sql);
                List<Diretoria> diretoria = new List<Diretoria>();
                while (table.Read())
                {
                    Diretoria item = new Diretoria();
                    item.iddiretoria = table["IDDIRETORIA"].ToString();
                    item.nome = table["NOME"].ToString();
                    item.cargo = table["CARGO"].ToString();
                    item.apresentacao = table["APRESENTACAO"].ToString();
                    item.imagem = table["IMAGEM"].ToString();
                    item.ativo = table["ATIVO"].ToString();

                    diretoria.Add(item);
                }
                table.Close();

                return diretoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.conn.Close();
            }
        }

        public Diretoria getDiretoriaById(string id)
        {
            ConnectionMySql conexao = new ConnectionMySql();
            try
            {
                string sql = $@"SELECT
                                    IDDIRETORIA,
                                    NOME,
                                    CARGO,
                                    APRESENTACAO,
                                    IMAGEM,
                                    ATIVO
                                FROM
                                    CACC.DIRETORIA
                                WHERE 
                                    IDDIRETORIA = '{id}'";

                MySqlDataReader table = conexao.ExecuteQuery(sql);
                Diretoria diretoria = new Diretoria();
                while (table.Read())
                {
                    diretoria.iddiretoria = table["IDDIRETORIA"].ToString();
                    diretoria.nome = table["NOME"].ToString();
                    diretoria.cargo = table["CARGO"].ToString();
                    diretoria.apresentacao = table["APRESENTACAO"].ToString();
                    diretoria.imagem = table["IMAGEM"].ToString();
                    diretoria.ativo = table["ATIVO"].ToString();
                }
                table.Close();

                return diretoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.conn.Close();
            }
        }

        public Diretoria getDiretoriaById(string id, ConnectionMySql conexao)
        {
            try
            {
                string sql = $@"SELECT
                                    IDDIRETORIA,
                                    NOME,
                                    CARGO,
                                    APRESENTACAO,
                                    IMAGEM,
                                    ATIVO
                                FROM
                                    CACC.DIRETORIA
                                WHERE 
                                    IDDIRETORIA = '{id}'";

                MySqlDataReader table = conexao.ExecuteQuery(sql);
                Diretoria diretoria = new Diretoria();
                while (table.Read())
                {
                    diretoria.iddiretoria = table["IDDIRETORIA"].ToString();
                    diretoria.nome = table["NOME"].ToString();
                    diretoria.cargo = table["CARGO"].ToString();
                    diretoria.apresentacao = table["APRESENTACAO"].ToString();
                    diretoria.imagem = table["IMAGEM"].ToString();
                    diretoria.ativo = table["ATIVO"].ToString();
                }
                table.Close();

                return diretoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool alterarStatus(string id)
        {
            ConnectionMySql conexao = new ConnectionMySql();
            try
            {
                conexao.StartTransaction();

                Diretoria diretoria = getDiretoriaById(id, conexao);

                string sqlUpdate = $@"UPDATE CACC.DIRETORIA SET ATIVO = {(diretoria.ativo == "S" ? "'N'" : "'S'")} WHERE IDDIRETORIA = '{id}'";
                conexao.ExecuteNonQuery(sqlUpdate);

                conexao.CommitTransaction();
                return true;
            }
            catch(Exception ex)
            {
                conexao.RollBackTransaction();
                throw ex;
            }
        }

        public bool deleteRegistro(string id)
        {
            ConnectionMySql conexao = new ConnectionMySql();
            try
            {
                conexao.StartTransaction();

                string sqlDelete = $@"DELETE FROM CACC.DIRETORIA WHERE IDDIRETORIA = '{id}'";
                conexao.ExecuteNonQuery(sqlDelete);
                conexao.CommitTransaction();

                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
