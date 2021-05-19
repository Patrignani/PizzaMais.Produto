using PizzaMais.Produto.Communs.Filtros;
using PizzaMais.Produto.Core.Utils;
using SqlKata;
using System;
using System.Linq;

namespace PizzaMais.Produto.Core.SqlCommands
{
    public static class FornecedorSql
    {
        private static Query consultas() => new Query("Fornecedor").Select("Id", "Documento", "TipoDocumento", "Nome", "Ativo");

        public static string ObterPorId()
        {
            var query = consultas()
                   .Where("Id", "@Id");

            return query.ObterString();
        }

        public static string ConsultaSimplificada(FornecedorFiltro filtro)
        {
            var query = new Query("Fornecedor").Select("Id", "Documento", "TipoDocumento", "Nome");

            if (!String.IsNullOrEmpty(filtro.Nome))
                query.WhereLike("Nome", "CONCAT(@Nome,'%')");

            if (filtro.Ativo.HasValue)
                query.Where("Ativo", "@Ativo");

            query
                .Limit(8)
                .OrderBy("Nome");

            return query.ObterString();
        }


        public static string Consulta(FornecedorFiltro filtro)
        {
            var query = consultas();

            if (filtro.Id.HasValue)
                query.WhereRaw("CAST(\"Id\" AS VARCHAR(8)) LIKE CONCAT(CAST(@Id AS VARCHAR(8)),'%') ");

            if (!String.IsNullOrEmpty(filtro.Nome))
                query.WhereLike("Nome", "CONCAT(@Nome,'%')");

            if (!String.IsNullOrEmpty(filtro.Documento))
                query.WhereLike("Documento", "CONCAT(@Documento,'%')");

            if (filtro.TipoDocumento.HasValue)
                query.Where("TipoDocumento", "@TipoDocumento");

            if (filtro.Ativo.HasValue)
                query.Where("Ativo", "@Ativo");

            query.MontarFornecedorOrderBy(filtro)
                .Offset(filtro.Offset)
                .Limit(filtro.Limit);

            return query.ObterString();
        }

        public static string Inserir() => SqlHelper.Inserir("Fornecedor", new string[] {
            "DataCriacao", "UsuarioIdCriacao","Ativo", "Nome", "Documento", "TipoDocumento"
        });

        public static string Update() =>
            SqlHelper.Update("Fornecedor", new string[] {
            "DataAtualizacao", "UsuarioIdAtualizacao", "Ativo", "Nome", "Documento", "TipoDocumento"
        });


        public static string Delete() => SqlHelper.Delete("Fornecedor");

        public static Query MontarFornecedorOrderBy(this Query query, FornecedorFiltro filtro)
        {
            if (filtro.OrderbyAsc.Any())
            {
                if (filtro.OrderbyAsc.Any(x => x.ToLower().Trim() == "nome"))
                    query.OrderBy("Nome");

                if (filtro.OrderbyAsc.Any(x => x.ToLower().Trim() == "id"))
                    query.OrderBy("Id");

                if (filtro.OrderbyAsc.Any(x => x.ToLower().Trim() == "ativo"))
                    query.OrderBy("Ativo");

                if (filtro.OrderbyAsc.Any(x => x.ToLower().Trim() == "documento"))
                    query.OrderBy("Documento");

                if (filtro.OrderbyAsc.Any(x => x.ToLower().Trim() == "tipodocumento"))
                    query.OrderBy("TipoDocumento");
            }

            if (filtro.OrderbyDesc.Any())
            {
                if (filtro.OrderbyDesc.Any(x => x.ToLower().Trim() == "nome"))
                    query.OrderByDesc("Nome");

                if (filtro.OrderbyDesc.Any(x => x.ToLower().Trim() == "id"))
                    query.OrderByDesc("Id");

                if (filtro.OrderbyDesc.Any(x => x.ToLower().Trim() == "ativo"))
                    query.OrderByDesc("Ativo");

                if (filtro.OrderbyDesc.Any(x => x.ToLower().Trim() == "documento"))
                    query.OrderByDesc("Documento");

                if (filtro.OrderbyDesc.Any(x => x.ToLower().Trim() == "tipodocumento"))
                    query.OrderByDesc("TipoDocumento");

            }

            return query;
        }
    }
}
