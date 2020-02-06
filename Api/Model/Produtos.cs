using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
    }
}
