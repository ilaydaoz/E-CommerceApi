using E_CommerceApi.Shared.Entities;

namespace E_CommerceApi.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string Description{ get; set; }
        public string Address{ get; set; }
        //çokoçok ilişki
        public ICollection <Product> Products { get; set; }
        //bire çok ilişki koruldu
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
