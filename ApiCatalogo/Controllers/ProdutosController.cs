using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCatalogo.Context;
using ApiCatalogo.Models;

namespace ApiCatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> getProdutos()
        {
            var produtos = _context.Produtos.ToList();
            if (produtos is null)
            {
                return NotFound("Produtos não encontrados");
            }
            return produtos;
        }

        [HttpGet("{id:int}", Name= "ObterProduto")]
        public ActionResult<Produto> getById(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if(produto == null)
            {
                return NotFound("Este ID de produto não foi encontrado.");
            }
            return produto;
        }

        [HttpPost]
        public ActionResult insertProduto(Produto produto)
        {
            if (produto == null)
                return BadRequest();

            _context.Produtos.Add(produto); //apenas na memória
            _context.SaveChanges(); //salva as alterações no banco

            return new CreatedAtRouteResult("ObterProduto", 
                new {id = produto.ProdutoId}, produto);
        }

        [HttpPut("{id:int}")]
        public ActionResult updateProduto(int id, Produto produto)
        {
            if(id != produto.ProdutoId)
            {
                return BadRequest("Id não encontrado");
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult deleteProduto(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if(produto is null)
            {
                return BadRequest("Produto não encontrado.");
            }
            _context.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }
    }
}
