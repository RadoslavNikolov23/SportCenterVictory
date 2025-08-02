namespace SCV.Data.Models
{
    using Microsoft.EntityFrameworkCore;

    [Comment("Represents an item in an order, linking a product to an order with quantity and price details")]
    public class OrderProduct
    {
        [Comment("Foreign key to the referenced Order. Part of the entity composite PK.")]
        public Guid OrderId { get; set; }

        public Order Order { get; set; } = null!;

        [Comment("Foreign key to the referenced Product. Part of the entity composite PK.")]
        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;

        [Comment("The quantity of the product")]
        public int Quantity { get; set; }

        [Comment("Price per single unit")]
        public decimal Price { get; set; }

        //Add IsDeleted property if you want to support soft deletion
        //The current implementation does not include soft deletion for OrderProduct
        // and in the services layer, is used only hard deletion.


    }
}