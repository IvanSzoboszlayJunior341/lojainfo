namespace LojaInfo.Models.Dominio
{
    public class DetalhePedido
    {
        public int Id { get; set;}
        public int IdPedido { get; set;}
        public int IdProduto { get; set;}
        public int Quantidade { get; set;}
        public DetalhePedido()
        {

        }
        public DetalhePedido(int id, int idpedido, int idproduto, int quantidade)
        {
            this.Id = id;
            this.IdPedido = idpedido;
            this.IdProduto = idproduto;
            this.Quantidade = quantidade;
        }
    }
}