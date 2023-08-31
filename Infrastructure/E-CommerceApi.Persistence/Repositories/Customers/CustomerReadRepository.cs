using E_CommerceApi.Application.Repositories.Customers;
using E_CommerceApi.Domain.Entities;
using E_CommerceApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApi.Persistence.Repositories.Customers
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(EfContext context) : base(context)
        {
        }
    }
}
