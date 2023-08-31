using E_CommerceApi.Application.Repositories.Products;
using E_CommerceApi.Domain.Entities;
using E_CommerceApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApi.Persistence.Repositories.Products
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(EfContext context) : base(context)
        {
        }
    }
}
