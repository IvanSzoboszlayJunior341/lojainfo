using System;
using System.Collections.Generic;
using System.Data;
using LojaInfo.Models.Dominio;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace LojaInfo.Models.Repositorio
{
    public class CRUDCliente:Conexao
    {
       public string Cadastro(Cliente cliente){
           string msg = "";
           try{
               /* Vamos instanciar o objeto con */
               con = new MySqlConnection();

               /* Passar o caminho e as credenciais do bando de dados. */
                con.ConnectionString = local;
                con.Open();
                cmd = new MySqlCommand();

                /* Vamos estabelecer a relação entre os comandos de sql (cmd) com o banco de dados (don) */
                cmd.Connection = con;
                /* Vamos definir o tipo de comando que será executado*/
                cmd.CommandType = CommandType.Text;
                /*Escrever o comando de SQL que será executado */
                cmd.CommandText = "insert into cliente(nome, email) values (@n, @e)";
                cmd.Parameters.AddWithValue("@n",cliente.Nome);
                cmd.Parameters.AddWithValue("@e",cliente.Email);
                /* Vamos executar a consulta de inserção */
                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    msg = "Cliente cadastrado com Sucesso!";
                else
                    msg = "Não foi possivel cadastrar o cliente";

                /* Vamos limpar o valor do presente no parametro */
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

       public string Atualizar(Cliente cliente){
           string msg = "";
           try{
               /* Vamos instanciar o objeto con */
               con = new MySqlConnection();

               /* Passar o caminho e as credenciais do bando de dados. */
                con.ConnectionString = local;
                con.Open();
                cmd = new MySqlCommand();

                /* Vamos estabelecer a relação entre os comandos de sql (cmd) com o banco de dados (don) */
                cmd.Connection = con;
                /* Vamos definir o tipo de comando que será executado*/
                cmd.CommandType = CommandType.Text;
                /*Escrever o comando de SQL que será executado */
                cmd.CommandText = "Update na tabela cliente set nome=@n, email@e, where id=#i";
                cmd.Parameters.AddWithValue("@n",cliente.Nome);
                cmd.Parameters.AddWithValue("@e",cliente.Email);
                cmd.Parameters.AddWithValue("@i",cliente.Id);
                /* Vamos executar a consulta de inserção */
                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    msg = "Cliente atualizado com Sucesso!";
                else
                    msg = "Não foi possivel atualizar o cliente";

                /* Vamos limpar o valor do presente no parametro */
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
        public string Deletar(Cliente cliente){
           string msg = "";
           try{
               /* Vamos instanciar o objeto con */
               con = new MySqlConnection();

               /* Passar o caminho e as credenciais do bando de dados. */
                con.ConnectionString = local;
                con.Open();
                cmd = new MySqlCommand();

                /* Vamos estabelecer a relação entre os comandos de sql (cmd) com o banco de dados (don) */
                cmd.Connection = con;
                /* Vamos definir o tipo de comando que será executado*/
                cmd.CommandType = CommandType.Text;
                /*Escrever o comando de SQL que será executado */
                cmd.CommandText = "delete from cliente where id=@i";
                cmd.Parameters.AddWithValue("@i",cliente.Id);
                /* Vamos executar a consulta de inserção */
                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    msg = "Cliente deletar com Sucesso!";
                else
                    msg = "Não foi possivel deletar o cliente";

                /* Vamos limpar o valor do presente no parametro */
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
        public List<Cliente> Listar(){
            List<Cliente> ListarClientes = new List<Cliente>();

            try{
                /* Instância o con */
                con = new MySqlConnection();
                /* Passsar o caminho e as credenciais do banco de dados */
                con.ConnectionString = local;
                /* Abrir o banco */
                con.Open();
                /* Instanciar o objeto cmd */
                cmd = new MySqlCommand();

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "Select * from cliente";

                dr = cmd.ExecuteReader();

                /* Enquanto ouver dados presentes no dr deve ser executado a leitura desses dados */
                while(dr.Read()){
                    /* Capturar os dados de dr e mostrar uma lista de clientes para ser adicionado a lista de clientes */
                    Cliente cli = new Cliente();
                    cli.Id = dr.GetInt32(0);
                    cli.Nome = dr.GetString(1);
                    cli.Email = dr.GetString(2);
                    cli.DataCadastro = dr.GetDateTime(3);
                    ListarClientes.Add(cli); 
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
            return ListarClientes;
        }

        public List<Cliente> Listar(int id){
            List<Cliente> ListarClientes = new List<Cliente>();

            try{
                /* Instância o con */
                con = new MySqlConnection();
                /* Passsar o caminho e as credenciais do banco de dados */
                con.ConnectionString = local;
                /* Abrir o banco */
                con.Open();
                /* Instanciar o objeto cmd */
                cmd = new MySqlCommand();

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "Select * from cliente where id=@i";
                cmd.Parameters.AddWithValue("@i" ,id);

                dr = cmd.ExecuteReader();

                /* Enquanto ouver dados presentes no dr deve ser executado a leitura desses dados */
                while(dr.Read()){
                    /* Capturar os dados de dr e mostrar uma lista de clientes para ser adicionado a lista de clientes */
                    Cliente cli = new Cliente();
                    cli.Id = dr.GetInt32(0);
                    cli.Nome = dr.GetString(1);
                    cli.Email = dr.GetString(2);
                    cli.DataCadastro = dr.GetDateTime(3);
                    ListarClientes.Add(cli); 
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
            return ListarClientes;
        }
    }
}