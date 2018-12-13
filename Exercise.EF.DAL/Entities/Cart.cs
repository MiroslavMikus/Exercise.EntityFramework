using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise.EF.DAL.Entities
{
    public class Cart
    {
        public int CartId { get; private set; }

        public User User { get; private set; }
        public int UserId { get; private set; }

        public ICollection<CartItem> CartItems { get; } = new List<CartItem>();

        public DateTime CreatedAt { get; private set; }

        public void AddItem(CatalogItem catalogItem, int quantity)
        {
            var cartItem = CartItems
                .Where(x => x.CatalogItem == catalogItem)
                .FirstOrDefault();
            if (cartItem == null)
            {
                cartItem = CartItem.Create(catalogItem);
                CartItems.Add(cartItem);
            }

            cartItem.IncreaseQuantity(quantity);
        }

        public static Cart Create(int userId)
        {
            return new Cart
            {
                UserId = userId,
                CreatedAt = DateTime.Now
            };
        }
    }
}
