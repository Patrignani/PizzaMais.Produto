namespace PizzaMais.Produto.Communs.Model
{
    public class ProdutoRevenda : Base
    {
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public int FornecedorId { get; set; }
        public double Quantidade { get; set; }
        public int UnidadeMedidaId { get; set; }
        public double Preco { get; set; }

    }
}
