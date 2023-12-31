﻿using Core.Interfaces;
using Core.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Skynet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]

        public async Task<ActionResult<List<Product>>> GetProducts()
        {
           var products= await _repo.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _repo.GetProductByIdAsync(id);
            if (product != null) return product;
            return NotFound("Product not found");
        }
    }
}
