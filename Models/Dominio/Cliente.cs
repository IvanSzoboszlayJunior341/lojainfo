using System;

namespace LojaInfo.Models.Dominio
{
    public class Cliente
    {
        public int Id { get; set;}
        public string Nome { get; set;}
        public string Email { get; set;}
        public DateTime DataCadastro { get; set;}
        public Cliente()
        {

        }
        public Cliente(int id, string nome, string email, DateTime datacadastro)
        {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.DataCadastro = datacadastro;
        }
    }
}