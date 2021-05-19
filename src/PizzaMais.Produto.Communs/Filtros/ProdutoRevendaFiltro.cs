namespace PizzaMais.Produto.Communs.Filtros
{
    public class ProdutoRevendaFiltro : FiltroBase
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public bool? Ativo { get; set; }
        public string Codigo { get; set; }
        public string FornecedorNome { get; set; }
        public decimal? Preco { get; set; }
    }
}
