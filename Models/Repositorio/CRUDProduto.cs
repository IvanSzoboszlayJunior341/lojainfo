using System;
using System.Collections.Generic;
using System.Data;
using LojaInfo.Models.Dominio;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace LojaInfo.Models.Repositorio
{
    public class CRUDProduto : Conexao
    {
        public string Cadastro(Produto Produto)
        {

            string msg = "";

            try
            {
                //vamos instanciar o objento con
                con = new MySqlConnection();
                con.ConnectionString = local;
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                //vamso definir o tipo de comando qie sera executado
                cmd.CommandType = CommandType.Text;
                //ESCREVER o comando de    SQL que sera executado
                cmd.CommandText = " insert into produto (Id,nomeproduto,tipo,preco,quantidade)values(@np,@i,@t,@p,@q)";
                cmd.Parameters.AddWithValue("@np", Produto.NomeProduto);
                cmd.Parameters.AddWithValue("@i", Produto.Id);
                cmd.Parameters.AddWithValue("@t", Produto.Tipo);
                cmd.Parameters.AddWithValue("@p", Produto.Preco);
                cmd.Parameters.AddWithValue("@q", Produto.Quantidade);

                cmd.Parameters.Clear(); 
                //vamos executar a consulta de inserçao
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                    msg = "Produto cadastrado com sucesso!";
                else msg = "Não foi possivel cadastras o produto";
                //vamos limpa o valor que presente no parametro
                cmd.Parameters.Clear();
            }//fim do try
            catch (MySqlException mse)
            {
                msg = "erro ao tentar cadastrar." + mse.Message;
            }
            catch (Exception ex)
            {
                msg = "erro inesperado" + ex.Message;
            }
            finally
            {
                con.Close();
            }
            return msg;
        }


        /*public string Atualizar(Produto produto)
        {

            string msg = "";

            try
            {
                //vamos instanciar o objento con
                con = new MySqlConnection();
                con.ConnectionString = local;
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;

                //vamso definir o tipo de comando qie sera executado

                cmd.CommandType = CommandType.Text;

                //ESCREVER o comando de    SQL que sera executado
                cmd.CommandText = "update produto set nomeproduto=@np,tipo=@t,preco=@p,quantidade=@q where id=@i";
                cmd.Parameters.AddWithValue("@np",produto.NomeProduto);
                cmd.Parameters.AddWithValue("@t", produto.Tipo);
                cmd.Parameters.AddWithValue("@p", produto.Preco);
                cmd.Parameters.AddWithValue("@q", produto.Quantidade);
                cmd.Parameters.AddWithValue("@i", produto.Id);

                //vamos executar a consulta de inserçao
                int r = cmd.ExecuteNonQuery();

                if (r > 0)
                    msg = "produto atualizado com sucesso!";

                else msg = "Não foi possivel atualizar o produto";
                //vamos limpa o valor que presente no parametro
                cmd.Parameters.Clear();
            }
            catch (MySqlException mse)
            {
                msg = "erro ao tentar atualizar." + mse.Message;
            }
            catch (Exception ex)
            {
                msg = "erro inesperado" + ex.Message;
            }
            finally
            {
                con.Close();
            }
            return msg;
        }
        public string Deletar(int id)
        {

            string msg = "";

            try
            {
                //vamos instanciar o objento con
                con = new MySqlConnection();
                con.ConnectionString = local;
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;

                //vamso definir o tipo de comando qie sera executado

                cmd.CommandType = CommandType.Text;

                //ESCREVER o comando de    SQL que sera executado
                cmd.CommandText = "delete from produto where id=@i";
                cmd.Parameters.AddWithValue("@i",id);

                //vamos executar a consulta de inserçao
                int r = cmd.ExecuteNonQuery();

                if (r > 0)
                    msg = "Produto deletado com sucesso!";

                else msg = "Nao foi possivel deletar o produto";
                //vamos limpa o valor que presente no parametro
                cmd.Parameters.Clear();




            }//fim do try
            catch (MySqlException mse)
            {
                msg = "erro ao tentar deletar." + mse.Message;
            }
            catch (Exception ex)
            {
                msg = "erro inesperado" + ex.Message;
            }
            finally
            {
                con.Close();
            }
            return msg;
        }
        */
        public List<Produto> Listar()
        {
            List<Produto> Listarproduto = new List<Produto>();

            try
            {
                //instaciar o objeto con
                con = new MySqlConnection();              
                con.ConnectionString = local;           
                con.Open();                
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "select * from produto";

                dr = cmd.ExecuteReader();

                //enquendo houver dados presentes no dr 
                //dever ser executada a leitura destes dados
                while (dr.Read())
                {
                    //capturar os dados de dr e montar uma lista de cliente
                    //cliente para ser adicionado a lista de clientes

                    Produto pro = new Produto();
                    pro.Id = dr.GetInt32(0);
                    pro.NomeProduto = dr.GetString(1);
                    pro.Tipo = dr.GetString(2);
                    pro.Preco = dr.GetDouble(3);
                    pro.Quantidade = dr.GetInt32(4);
                    Listarproduto.Add(pro);
                }

            }// fim try
            catch (MySqlException mse)
            {
                throw new Exception("Erro ao tentar ler os Produto" + mse.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado" + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return Listarproduto;
        }

        public List<Produto> Listar(int id)
        {
            List<Produto> Listarproduto = new List<Produto>();

            try
            {
                //instaciar o objeto con
                con = new MySqlConnection();
                con.ConnectionString = local;
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "select * from produto where id=@i";
                cmd.Parameters.AddWithValue("@i", id);

                dr = cmd.ExecuteReader();

                //enquendo houver dados presentes no dr 
                //dever ser executada a leitura destes dados
                while (dr.Read())
                {
                    //capturar os dados de dr e montar uma lista de cliente
                    //cliente para ser adicionado a lista de clientes

                    Produto pro = new Produto();
                    pro.Id = dr.GetInt32(0);
                    pro.NomeProduto = dr.GetString(1);
                    pro.Tipo = dr.GetString(2);
                    pro.Preco = dr.GetDouble(3);
                    pro.Quantidade = dr.GetInt32(4);
                    Listarproduto.Add(pro);
                }

            }// fim try
            catch (MySqlException mse)
            {
                throw new Exception("Erro ao tentar ler os produto" + mse.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado" + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return Listarproduto;
        }
    }
}