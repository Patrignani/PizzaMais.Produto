using PizzaMais.Produto.Communs.Enum;

namespace PizzaMais.Produto.Communs.Filtros
{
    public class FornecedorFiltro : FiltroBase
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public bool? Ativo { get; set; }
        public string Documento { get; set; }
        public TipoDocumento? TipoDocumento { get; set; }
    }
}
