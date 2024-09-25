using DAL.Enums;
using DAL.Models.Users;

namespace DAL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public User User { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int DeliveryAddressId { get; set; }
        public Address DeliveryAddress { get; set; }
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public decimal DeliveryFee { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
