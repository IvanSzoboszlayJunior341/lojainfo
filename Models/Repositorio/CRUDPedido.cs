using System;
using System.Collections.Generic;
using System.Data;
using LojaInfo.Models.Dominio;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace LojaInfo.Models.Repositorio
{
    public class CRUDPedido:Conexao
    {
        public string Cadastrado(Pedido cliente){
            string msg = "";
            try{
                con = new MySqlConnection();
                con.ConnectionString = local;
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Insert na tabela cliente (idcliente) values (@idc)";
                cmd.Parameters.AddWithValue("@idc",cliente.IdCliente);
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
        public string Atualizar(Pedido cliente){
           string msg = "";
           try{
             con = new MySqlConnection();
             con.ConnectionString = local;
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;cmd.CommandText = "Atualizar na tabela cliente set id=@i, datapedido=@dp, idcliente=@id";
                cmd.Parameters.AddWithValue("@i",cliente.Id);
                cmd.Parameters.AddWithValue("@dp",cliente.DataPedido);
                cmd.Parameters.AddWithValue("@id",cliente.IdCliente);
                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    msg = "Pedido atualizado com Sucesso!";
                else
                    msg = "Não foi possivel atualizar o pedido";
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
        public string Deletar(Pedido cliente){
           string msg = "";
           try{
             con = new MySqlConnection();
             con.ConnectionString = local;
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;cmd.CommandText = "Deletar na tabela cliente set id=@i";
                cmd.Parameters.AddWithValue("@i",cliente.Id);
                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    msg = "Pedido deletado com Sucesso!";
                else
                    msg = "Não foi possivel deletado o pedido";
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
        public List<Pedido> Listar(){
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