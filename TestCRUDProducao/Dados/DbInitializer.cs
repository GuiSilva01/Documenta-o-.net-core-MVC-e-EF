using TestCRUDProducao.Models;
using System;
using System.Linq;

namespace TestCRUDProducao.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Produto.
            if (context.Produtos.Any())
            {
                return;   // DB has been seeded
            }

            var Produtos = new Produto[]
            {
            new Produto{Nome="Broa de Milho",Preco=35},
            new Produto{Nome="Bolo de Laranja",Preco=37},
            new Produto{Nome="Brioche",Preco=45},
            new Produto{Nome="Bolo de Limao",Preco=35},
            new Produto{Nome="Bolo de Milho Verde",Preco=35},
            new Produto{Nome="Pão de Ló",Preco=37},
            new Produto{Nome="Pão Integral",Preco=40},
            new Produto{Nome="Bolo de Cenoura",Preco=35}
            };
            foreach (Produto s in Produtos)
            {
                context.Produtos.Add(s);
            }
            context.SaveChanges();

            var Producaos = new Producao[]
            {
            new Producao{ProdutoID=1,Data=DateTime.Parse("2020-03-15"),Equipamento="BM 1200",Lote="013",Quantidade=150,Observacao=""},
            new Producao{ProdutoID=2,Data=DateTime.Parse("2020-03-12"),Equipamento="BM 1200",Lote="010",Quantidade=280,Observacao=""},
            new Producao{ProdutoID=1,Data=DateTime.Parse("2020-03-15"),Equipamento="BM 1200",Lote="014",Quantidade=151,Observacao=""},
            new Producao{ProdutoID=4,Data=DateTime.Parse("2020-03-12"),Equipamento="BM 1200",Lote="09",Quantidade=282,Observacao=""},
            new Producao{ProdutoID=5,Data=DateTime.Parse("2020-03-15"),Equipamento="BM 1200",Lote="015",Quantidade=300,Observacao=""},
            new Producao{ProdutoID=6,Data=DateTime.Parse("2020-03-19"),Equipamento="BM 1200",Lote="023",Quantidade=300,Observacao=""},
            new Producao{ProdutoID=2,Data=DateTime.Parse("2020-03-15"),Equipamento="BM 1200",Lote="011",Quantidade=280,Observacao=""},
            new Producao{ProdutoID=8,Data=DateTime.Parse("2020-03-16"),Equipamento="BM 1200",Lote="013",Quantidade=301,Observacao=""}
            };
            foreach (Producao c in Producaos)
            {
                context.Producaos.Add(c);
            }
            context.SaveChanges();

        }
    }
}
