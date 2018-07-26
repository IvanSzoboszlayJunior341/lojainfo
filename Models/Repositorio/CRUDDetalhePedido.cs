using System;
using System.Collections.Generic;
using System.Data;
using LojaInfo.Models.Dominio;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace LojaInfo.Models.Repositorio
{
    public class CRUDDetalhePedido:Conexao
    {
        public string Cadastrado(DetalhePedido detalhePedido){
            string msg = "";
            try{
                con = new MySqlConnection();
                con.ConnectionString = local;
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Insert na tabela detalhePedido (idpedido, idproduto, quantidade) values (@ipe, @ipr, @q)";
                cmd.Parameters.AddWithValue("@ipe",detalhePedido.IdPedido);
                cmd.Parameters.AddWithValue("@ipr",detalhePedido.IdProduto);
                cmd.Parameters.AddWithValue("@q",detalhePedido.Quantidade);
                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    msg = "Pedido cadastrado com sucesso!";
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
        public string Atualizar(DetalhePedido detalhePedido){
           string msg = "";
           try{
             con = new MySqlConnection();
             con.ConnectionString = local;
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;cmd.CommandText = "Atualizar na tabela cliente set id=@i, datapedido=@dp, idcliente=@id";
                cmd.Parameters.AddWithValue("@ipe",detalhePedido.IdPedido);
                cmd.Parameters.AddWithValue("@ipr",detalhePedido.IdProduto);
                cmd.Parameters.AddWithValue("@q",detalhePedido.Quantidade);
                cmd.Parameters.AddWithValue("@i",detalhePedido.Id);
                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    msg = "DetalhePedido atualizado com Sucesso!";
                else
                    msg = "Não foi possivel atualizar o detalhePedido";
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
        public string Deletar(DetalhePedido detalhePedido){
           string msg = "";
           try{
             con = new MySqlConnection();
             con.ConnectionString = local;
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;cmd.CommandText = "Deletar na tabela cliente set id=@i";
                cmd.Parameters.AddWithValue("@i",detalhePedido.Id);
                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    msg = "DetalhePedido deletado com Sucesso!";
                else
                    msg = "Não foi possivel deletado o detalhePedido";
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
        public List<DetalhePedido> Listar(){
            List<DetalhePedido> ListardetalhePedido = new List<DetalhePedido>();
        try{
            con = new MySqlConnection();
            con.ConnectionString = local;
            con.Open();
            cmd = new MySqlCommand();

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "Select * from detalhePedido";

                dr = cmd.ExecuteReader();
            while(dr.Read()){
                DetalhePedido dp = new DetalhePedido();
                    dp.Id = dr.GetInt32(0);
                    dp.IdPedido = dr.GetInt32(1);
                    dp.IdProduto = dr.GetInt32(2);
                    ListardetalhePedido.Add(dp);
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
            return ListardetalhePedido;
        }
        public List<Pedido> Listar(int id){
            List<Pedido> ListarPedidos = new List<Pedido>();
        try{
            con = new MySqlConnection();
            con.ConnectionString = local;
            con.Open();
            cmd = new MySqlCommand();

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "Select * from pedido";

                dr = cmd.ExecuteReader();
            while(dr.Read()){
                Pedido pe = new Pedido();
                    pe.Id = dr.GetInt32(0);
                    pe.DataPedido = dr.GetDateTime(1);
                    pe.IdCliente = dr.GetInt32(2);
                    ListarPedidos.Add(pe);
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
            return ListarPedidos;
        }
    }
}