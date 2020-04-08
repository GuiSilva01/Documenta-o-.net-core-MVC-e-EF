using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TestCRUDProducao.Models
{
    public class Producao
    {
        public int ID { get; set; }

        [Display(Name = "Produto")]

        public int ProdutoID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public string Equipamento { get; set; }
        public string Lote { get; set; }
        public int Quantidade { get; set; }
        public string Observacao { get; set; }

        public Produto Produto { get; set; }
    }
}
