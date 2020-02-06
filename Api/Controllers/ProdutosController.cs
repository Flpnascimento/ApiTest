using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Interface;
using Api.Model;
using Api.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        static readonly IProdutoRepositorio repositorio = new ProdutoRepositorio();

        [HttpGet]
        public IEnumerable<Produtos> GetTodos()
        {
            return repositorio.GetAll();
        }

        [HttpGet("{id}", Name = "GetProduto")]
        public IActionResult GetProdutoPorId(int id)
        {
            Produtos produtos = repositorio.Get(id);
            if (produtos == null)
            {
                return NotFound();
            }
            return new ObjectResult(produtos);
        }
        public IActionResult CriarProduto([FromBody]Produtos item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            item = repositorio.Add(item);

            return CreatedAtRoute("GetProduto", new { id = item.Id }, item);
        }

        [HttpPut]
        public IActionResult AtualizaProduto(int id [FromBody] Produtos item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            item.Id = id;
            if (!repositorio.Update(item))
            {
                return NotFound();
            }

            return new NoContentResult();
        }

        [HttpDelete]
        public IActionResult RemoverProduto(int id)
        {
            Produtos produtos = repositorio.Get(id);

            if (produtos== null)
            {
                return BadRequest();
            }

            repositorio.Remove(id);
            return new NoContentResult();
        }

    }
}