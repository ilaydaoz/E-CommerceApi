using E_CommerceApi.Application.Repositories.Orders;
using E_CommerceApi.Domain.Entities;
using E_CommerceApi.Shared.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceApi.Controllers
{
    public class ProductsController : BaseController
    {
        readonly private IOrderReadRepository _orderReadRepository;
        readonly private IOrderWriteRepository _orderWriteRepository;

        public ProductsController(IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository)
        {
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            Order order = await _orderReadRepository.GetByIdAsync("");
            order.Address = "istanbul";
            await _orderWriteRepository.SaveAsync();
        }
    }
}
