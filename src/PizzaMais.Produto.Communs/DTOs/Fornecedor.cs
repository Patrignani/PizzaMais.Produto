using PizzaMais.Produto.Communs.Enum;
using PizzaMais.Produto.Communs.Model;
using System;

namespace PizzaMais.Produto.Communs.DTOs
{
    public class FornecedorBasico
    {
        public string Nome { get; set; }
    }

    public class FornecedorSimplificado : FornecedorBasico
    {
        public int Id { get; set; }
        public string Documento { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public string TipoDocumentoNome => TipoDocumento.CPF == TipoDocumento ? "CPF" : "CNPJ";
    }

    public class FornecedorObter : FornecedorSimplificado
    {
        public FornecedorObter()
        {
        }

        public FornecedorObter(Fornecedor fornecedor)
        {
            Nome = fornecedor.Nome;
            Id = fornecedor.Id;
            Documento = fornecedor.Documento;
            TipoDocumento = fornecedor.TipoDocumento;
            Ativo = fornecedor.Ativo;
        }

        public bool Ativo { get; set; }
    }

    public class FornecedorInserir : FornecedorBasico
    {
        public string Documento { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public bool Ativo { get; set; }

        public Fornecedor GerarFornecedor(int usuarioId) => new Fornecedor
        {
            Nome = Nome,
            TipoDocumento = TipoDocumento,
            Documento = Documento,
            Ativo = Ativo,
            DataCriacao = DateTime.UtcNow,
            UsuarioIdCriacao = usuarioId
        };
    }

    public class FornecedorAtualizar : FornecedorBasico
    {
        public int Id { get; set; }
        public string Documento { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public bool Ativo { get; set; }

        public Fornecedor GerarFornecedor(int usuarioId) => new Fornecedor
        {
            Id = Id,
            Ativo = Ativo,
            Documento = Documento,
            Nome = Nome,
            TipoDocumento = TipoDocumento,
            DataAtualizacao = DateTime.UtcNow,
            UsuarioIdAtualizacao = usuarioId
        };
    }

}
