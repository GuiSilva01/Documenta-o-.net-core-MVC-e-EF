using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestCRUDProducao.Models
{
    public class Produto
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        [DisplayFormat(DataFormatString = "{0:f2}")]

        public double Preco { get; set; }

        public ICollection<Producao> Producaos { get; set; }
    }
}
