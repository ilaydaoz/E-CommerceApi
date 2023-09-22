﻿using E_CommerceApi.Application.Repositories.Products;
using E_CommerceApi.Application.RequestParameters;
using E_CommerceApi.Application.ViewModels.Products;
using E_CommerceApi.Domain.Entities;
using E_CommerceApi.Shared.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace E_CommerceApi.Controllers
{
    public class ProductsController : BaseController 
    { 
      readonly private IProductReadRepository _productReadRepository;
      readonly private IProductWriteRepository _productWriteRepository;

      public ProductsController(IProductReadRepository productReadRepository,
        IProductWriteRepository productWriteRepository)
      {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
      }

      [HttpGet]
      public async Task<IActionResult> Get([FromQuery]Pagination pagination)
      {
            var totalCount = _productReadRepository.GetAll(false).Count();
            var products = _productReadRepository.GetAll(false).Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(p => new
            {
                p.Id,
                p.Name,
                p.Stock,
                p.Price,
                p.CreatedDate,
                p.UpdateDate
            }).ToList();
             return Ok(new
             {
                 totalCount,
                 products
             });
      }

      [HttpGet("{id}")]
      public async Task<IActionResult> Get(string id)
      {
            return Ok(await _productReadRepository.GetByIdAsync(id,false));
      }
      [HttpPost]
      public async Task<IActionResult> Post(VM_Create_Product model)
        {
         
           await _productWriteRepository.AddAsync(new ()
           {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock,
           });
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
      }
        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
          Product product =await _productReadRepository.GetByIdAsync(model.Id);
            product.Stock = model.Stock;
            product.Name = model.Name;
            product.Price = model.Price;
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
    }
}

