using E_CommerceApi.Application.Repositories.Orders;
using E_CommerceApi.Domain.Entities;
using E_CommerceApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApi.Persistence.Repositories.Orders
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(EfContext context) : base(context)
        {
        }
    }
}
