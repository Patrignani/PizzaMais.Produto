using PizzaMais.Produto.Communs.Filtros;
using PizzaMais.Produto.Core.Utils;
using SqlKata;
using System;
using System.Linq;

namespace PizzaMais.Produto.Core.SqlCommands
{
    public static class ProdutoRevendaScript
    {
        private static Query consultas() => new Query("ProdutoRevenda").Select("ProdutoRevenda.Id", "ProdutoRevenda.Codigo", "ProdutoRevenda.FornecedorId",
            "ProdutoRevenda.Nome", "ProdutoRevenda.Quantidade", "ProdutoRevenda.UnidadeMedidaId", "ProdutoRevenda.Preco", "ProdutoRevenda.Ativo");

        public static string Consulta(ProdutoRevendaFiltro filtro)
        {
            var query = consultas()
               .Select("Fornecedor.Nome AS FornecedorNome")
               .Join("Fornecedor", j => j.On("Fornecedor.Id", "ProdutoRevenda.FornecedorId"));

            if (filtro.Id.HasValue)
                query.WhereRaw("CAST(\"ProdutoRevenda\".\"Id\" AS VARCHAR(8)) LIKE CONCAT(CAST(@Id AS VARCHAR(8)),'%') ");

            if (!String.IsNullOrEmpty(filtro.Nome))
                query.WhereLike("ProdutoRevenda.Nome", "LOWER(CONCAT(@Nome,'%'))");

            if (!String.IsNullOrEmpty(filtro.Codigo))
                query.WhereLike("ProdutoRevenda.Codigo", "LOWER(CONCAT(@Codigo,'%'))");

            if (filtro.Preco.HasValue)
                query.WhereRaw("\"ProdutoRevenda\".\"Preco\" >= @Preco");

            if (filtro.Ativo.HasValue)
                query.Where("ProdutoRevenda.Ativo", "@Ativo");

            if (!String.IsNullOrEmpty(filtro.FornecedorNome))
                query.WhereLike("Fornecedor.Nome", "LOWER(CONCAT(@Fornecedor,'%'))");

            query.MontarProdutoRevendaOrderBy(filtro)
                .Offset(filtro.Offset)
                .Limit(filtro.Limit);

            return query.ObterString();
        }

        public static string ObterPorId()
        {
            var query = consultas()
                .Select("Fornecedor.Nome AS FornecedorNome")
                .Join("Fornecedor", j => j.On("Fornecedor.Id", "ProdutoRevenda.FornecedorId"))
                .Where("ProdutoRevenda.Id", "@Id");

            return query.ObterString();
        }

        public static string Inserir() => SqlHelper.Inserir("ProdutoRevenda", new string[] {
            "DataCriacao", "UsuarioIdCriacao","Ativo", "Nome", "Codigo", "FornecedorId", "Quantidade", "UnidadeMedidaId", "Preco"
        });

        public static string Update() =>
            SqlHelper.Update("ProdutoRevenda", new string[] {
            "DataAtualizacao", "UsuarioIdAtualizacao", "Ativo", "Nome","Codigo", "FornecedorId", "Quantidade", "UnidadeMedidaId", "Preco"
      });

        public static string Delete() => SqlHelper.Delete("ProdutoRevenda");

        public static Query MontarProdutoRevendaOrderBy(this Query query, ProdutoRevendaFiltro filtro)
        {
            if (filtro.OrderbyAsc.Any())
            {
                if (filtro.OrderbyAsc.Any(x => x.ToLower().Trim() == "nome"))
                    query.OrderBy("ProdutoRevenda.Nome");

                if (filtro.OrderbyAsc.Any(x => x.ToLower().Trim() == "id"))
                    query.OrderBy("ProdutoRevenda.Id");

                if (filtro.OrderbyAsc.Any(x => x.ToLower().Trim() == "ativo"))
                    query.OrderBy("ProdutoRevenda.Ativo");

                if (filtro.OrderbyAsc.Any(x => x.ToLower().Trim() == "codigo"))
                    query.OrderBy("ProdutoRevenda.Codigo");

                if (filtro.OrderbyAsc.Any(x => x.ToLower().Trim() == "preco"))
                    query.OrderBy("ProdutoRevenda.Preco");

                if (filtro.OrderbyAsc.Any(x => x.ToLower().Trim() == "fornecedornome"))
                    query.OrderBy("Fornecedor.Nome");
            }

            if (filtro.OrderbyDesc.Any())
            {
                if (filtro.OrderbyDesc.Any(x => x.ToLower().Trim() == "nome"))
                    query.OrderByDesc("ProdutoRevenda.Nome");

                if (filtro.OrderbyDesc.Any(x => x.ToLower().Trim() == "id"))
                    query.OrderByDesc("ProdutoRevenda.Id");

                if (filtro.OrderbyDesc.Any(x => x.ToLower().Trim() == "ativo"))
                    query.OrderByDesc("ProdutoRevenda.Ativo");

                if (filtro.OrderbyDesc.Any(x => x.ToLower().Trim() == "codigo"))
                    query.OrderByDesc("ProdutoRevenda.Codigo");

                if (filtro.OrderbyDesc.Any(x => x.ToLower().Trim() == "preco"))
                    query.OrderByDesc("ProdutoRevenda.Preco");

                if (filtro.OrderbyDesc.Any(x => x.ToLower().Trim() == "fornecedornome"))
                    query.OrderByDesc("Fornecedor.Nome");

            }

            return query;
        }
    }
}
