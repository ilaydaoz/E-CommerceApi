﻿using E_CommerceApi.Shared.Entities;

namespace E_CommerceApi.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

        public ICollection<Order> Orders{ get; set; }
}
}
