using System;

namespace LojaInfo.Models.Dominio
{
    public class Pedido
    {
        public int Id { get; set;}
        public DateTime DataPedido { get; set;}
        public int IdCliente {get; set;}
        public Pedido()
        {

        }
        public Pedido(int id, DateTime datapedido, int idcliente)
        {
            this.Id = id;
            this.DataPedido = datapedido;
            this.IdCliente = idcliente;
        }
    }
}