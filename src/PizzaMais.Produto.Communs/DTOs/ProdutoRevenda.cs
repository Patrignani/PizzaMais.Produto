using PizzaMais.Produto.Communs.Model;
using System;

namespace PizzaMais.Produto.Communs.DTOs
{

    public class ProdutoRevendaBasico
    {
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public int FornecedorId { get; set; }
        public double Quantidade { get; set; }
        public int UnidadeMedidaId { get; set; }
        public double Preco { get; set; }
        public bool Ativo { get; set; }
        public string FornecedorNome { get; set; }
    }

    public class ProdutoRevendaObter : ProdutoRevendaBasico
    {
        public int Id { get; set; }

        public ProdutoRevendaObter()
        { 
        
        }

        public ProdutoRevendaObter(ProdutoRevenda produto, string fornecedorNome)
        {
            Nome = produto.Nome;
            Id = produto.Id;
            Codigo = produto.Codigo;
            FornecedorId = produto.FornecedorId;
            Quantidade = produto.Quantidade;
            UnidadeMedidaId = produto.UnidadeMedidaId;
            Preco = produto.Preco;
            Ativo = produto.Ativo;
            FornecedorNome = fornecedorNome;
        }
    }


    public class ProdutoRevendaInserir : ProdutoRevendaBasico
    {
  
        public ProdutoRevenda GerarProdutoRevenda(int usuarioId) => new ProdutoRevenda
        {
            Nome = Nome,
            Codigo = Codigo,
            FornecedorId = FornecedorId,
            Ativo = Ativo,
            Quantidade = Quantidade,
            UnidadeMedidaId= UnidadeMedidaId,
            Preco= Preco,
            DataCriacao = DateTime.UtcNow,
            UsuarioIdCriacao = usuarioId
        };
    }

    public class ProdutoRevendaAtualizar : ProdutoRevendaBasico
    {
        public int Id { get; set; }

        public ProdutoRevenda GerarProdutoRevenda(int usuarioId) => new ProdutoRevenda
        {
            Id = Id,
            Nome = Nome,
            Codigo = Codigo,
            FornecedorId = FornecedorId,
            Ativo = Ativo,
            Quantidade = Quantidade,
            UnidadeMedidaId = UnidadeMedidaId,
            Preco = Preco,
            DataCriacao = DateTime.UtcNow,
            UsuarioIdCriacao = usuarioId
        };
    }
}
