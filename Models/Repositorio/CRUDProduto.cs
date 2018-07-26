using System;
using System.Collections.Generic;
using System.Data;
using LojaInfo.Models.Dominio;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace LojaInfo.Models.Repositorio
{
    public class CRUDProduto:Conexao
    {
        public string Cadastrado(Produto produto){
            string msg = "";
            try{
                con = new MySqlConnection();
                con.ConnectionString = local;
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Insert na tabela detalhePedido (nomeproduto, tipo, preco, quantidade) values (@np, @t, @p, @q)";
                cmd.Parameters.AddWithValue("@ipe",produto.NomeProduto);
                cmd.Parameters.AddWithValue("@ipr",produto.Tipo);
                cmd.Parameters.AddWithValue("@q",produto.Quantidade);
                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    msg = "produto cadastrado com sucesso!";
                else
                    msg = "Não foi posivel cadastrar o produto";

                cmd.Parameters.Clear();
                
            }
            catch(MySqlException mse){
                msg = "Erro ao tentar cadastrar. "+mse.Message;
            }
            catch(Exception ex){
                msg = "Erro inesperado. "+ex.Message;
            }
            finally{
                con.Close();
            }
            return msg;
        }
        public string Atualizar(Produto produto){
           string msg = "";
           try{
             con = new MySqlConnection();
             con.ConnectionString = local;
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;cmd.CommandText = "Atualizar na tabela cliente set id=@i, datapedido=@dp, idcliente=@id";
                cmd.Parameters.AddWithValue("@ipe",produto.NomeProduto);
                cmd.Parameters.AddWithValue("@ipr",produto.Tipo);
                cmd.Parameters.AddWithValue("@q",produto.Quantidade);
                cmd.Parameters.AddWithValue("@i",produto.Id);
                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    msg = "produto atualizado com Sucesso!";
                else
                    msg = "Não foi possivel atualizar o produto";
                cmd.Parameters.Clear();
                }
           catch(MySqlException mse){
               msg = "Erro ao tentar atualizar. "+mse.Message;
           }
           catch(Exception ex){
               msg = "Erro inesperado. "+ex.Message;
           }
           finally{
               con.Close();
           }
           return msg;
        }
        public string Deletar(Produto produto){
           string msg = "";
           try{
             con = new MySqlConnection();
             con.ConnectionString = local;
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;cmd.CommandText = "Deletar na tabela cliente set id=@i";
                cmd.Parameters.AddWithValue("@i",produto.Id);
                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    msg = "Produto deletado com Sucesso!";
                else
                    msg = "Não foi possivel deletar o produto";
                cmd.Parameters.Clear();
                }
           catch(MySqlException mse){
               msg = "Erro ao tentar deletar. "+mse.Message;
           }
           catch(Exception ex){
               msg = "Erro inesperado. "+ex.Message;
           }
           finally{
               con.Close();
           }
           return msg;
        }
        public List<Produto> Listar(){
            List<Produto> ListarProduto = new List<Produto>();
        try{
            con = new MySqlConnection();
            con.ConnectionString = local;
            con.Open();
            cmd = new MySqlCommand();

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "Select * from Produto";

                dr = cmd.ExecuteReader();
            while(dr.Read()){
                Produto pr = new Produto();
                    pr.Id = dr.GetInt32(0);
                    pr.NomeProduto = dr.GetString(1);
                    pr.Tipo = dr.GetString(2);
                    pr.Preco = dr.GetDouble(3);
                    pr.Quantidade = dr.GetInt32(4);
                    ListarProduto.Add(pr);
                }
            }
            catch(MySqlException mse){
                throw new Exception("Erro ao tentar ler os cientes. "+mse.Message);
            }
            catch(Exception ex){
                throw new Exception("Erro inesperado. "+ex.Message);
            }
            finally{
                con.Close();
            }
            return ListarProduto;
        }
        public List<Produto> Listar(int id){
            List<Produto> Listarproduto = new List<Produto>();
        try{
            con = new MySqlConnection();
            con.ConnectionString = local;
            con.Open();
            cmd = new MySqlCommand();

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "Select * from produto";

                dr = cmd.ExecuteReader();
            while(dr.Read()){
                Produto pr = new Produto();
                    pr.Id = dr.GetInt32(0);
                    pr.NomeProduto = dr.GetString(1);
                    pr.Tipo = dr.GetString(2);
                    pr.Preco = dr.GetDouble(3);
                    pr.Quantidade = dr.GetInt32(4);
                    Listarproduto.Add(pr);
                }
            }
            catch(MySqlException mse){
                throw new Exception("Erro ao tentar ler os cientes. "+mse.Message);
            }
            catch(Exception ex){
                throw new Exception("Erro inesperado. "+ex.Message);
            }
            finally{
                con.Close();
            }
            return Listarproduto;
        }
    }
}