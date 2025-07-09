namespace SCV.Data.Models
{
    using SCV.GlCommon.Enums;
    using Microsoft.EntityFrameworkCore;

    public class Order
    {
        [Comment("Unique identifier for the order")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Comment("The day in which the order was made")]
        public DateTime OrderDate { get; set; }

        [Comment("The total price of the order")]
        public decimal TotalPrice { get; set; }

        [Comment("Shows what is the status of the order - ")]
        public OrderStatus OrderStatus { get; set; }

        [Comment("Shows the method of payment")]
        public PaymentMethod PaymentMethod { get; set; }

        [Comment("Flag which is used for soft deletion")]
        public bool IsDeleted { get; set; } = false;

        [Comment("Identifier of the customer who made the order")]
        public Guid CustomerId { get; set; }

        public virtual ApplicationUser Customer { get; set; } = null!;

        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();
    }
}