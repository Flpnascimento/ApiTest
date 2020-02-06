using Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Interface
{
    public interface IProdutoRepositorio
    {
        IEnumerable<Produtos> GetAll();
        Produtos Get(int id);
        Produtos Add(Produtos item);
        bool Update(Produtos item);
        void Remove(int id);


    }
}
