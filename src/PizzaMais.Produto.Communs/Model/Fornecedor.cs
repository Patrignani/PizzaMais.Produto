using PizzaMais.Produto.Communs.Enum;

namespace PizzaMais.Produto.Communs.Model
{
    public class Fornecedor : Base
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
    }
}
