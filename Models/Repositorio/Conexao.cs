using System.Data;
using MySql.Data.MySqlClient;

namespace LojaInfo.Models.Repositorio
{
    /* A classe Conexão será nossa classe Pai. Portanto ela foi setada como abstract, ou seja, não
        poderá ser instanciada */
    public abstract class Conexao
    {
        protected MySqlConnection con;
        /* MySqlConnection permite estabelecer a conecão com o servidor
        de bando de dados e passar o nome do banco, nome de usuário, senha e porta
        de comunicação. */    
        protected MySqlCommand cmd;
        /* MySqlCommand permite executar os comandos de SQL( Select, Insert, Update, Delete, etc ) na conexão acima. */
        protected MySqlDataReader dr;
        /* MySqlDataReader é um leitor de danos q retornam de um select. */
        protected MySqlDataAdapter adt;
        /* MySqlDataAdapter é uma forma mais simples de se fazer select. */
        protected DataTable dt;
        /* MySqlDataTable nos ajuda a organizar os dados em forma tabular. */
        protected const string local = "Persist Security Info=False; database=dblojainfo; server=localhost; port=3306; sslmode=none; user=root; password=senac@tat";
        
    }
}