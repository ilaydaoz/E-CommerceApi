using E_CommerceApi.Shared.Entities;

namespace E_CommerceApi.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        //bir müş. birden çok orderı olabilir ama bir orderın bir müşterisi olabilir
        public ICollection<Order> Orders { get; set; }
    }
}
