namespace LojaInfo.Models.Dominio
{
    public class Produto
    {
        public int Id { get; set;}
        public string NomeProduto { get; set;}
        public string Tipo { get; set;}
        public double Preco { get; set;}
        public int Quantidade { get; set;}
        public Produto()
        {

        }
        public Produto(int id, string nomeproduto, string tipo, double preco, int quantidade)
        {
            this.Id = id;
            this.NomeProduto = nomeproduto;
            this.Tipo = tipo ;
            this.Preco = preco ;
            this.Quantidade = quantidade;
        }
    }
}