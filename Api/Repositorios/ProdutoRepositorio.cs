using Api.Interface;
using Api.Model;
using System;
using System.Collections.Generic;

namespace Api.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private List<Produtos> produtos = new List<Produtos>();
        private int _nextId = 1;
        public ProdutoRepositorio()
        {
            Add(new Produtos { Name = "Guarana", Categoria = "Refrigerante", Preco = 4.59M });
            Add(new Produtos { Name = "Coca Cola", Categoria = "Refrigerante", Preco = 5.59M });
            Add(new Produtos { Name = "Fanta", Categoria = "Refrigerante", Preco = 6.59M });
            Add(new Produtos { Name = "Feijão", Categoria = "Condimentos", Preco = 4.59M });

        }
        public Produtos Add(Produtos item)
        {
            if (item == null)
            {
                throw new ArgumentException("item");
            }
            item.Id = _nextId++;
            produtos.Add(item);
            return item;
        }

        public Produtos Get(int id)
        {
            return produtos.Find(p => p.Id == id);

        }

        public IEnumerable<Produtos> GetAll()
        {
            return produtos;
        }

        public void Remove(int id)
        {
            produtos.RemoveAll(p => p.Id == id);
        }

        public bool Update(Produtos item)
        {
            if (item == null)
            {
                throw new ArgumentException("item");
            }

            int index = produtos.FindIndex(p => p.Id == item.Id);
            if (index==-1)
            {
                return false; 
            }
            produtos.RemoveAt(index);
            produtos.Add(item);
            return true;
        }
    }
}
