using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagement.Models
{
    class OrderItem
    {
        public MenuItem MenuItem { get; set; }
        public int Count { get; set; }

        public OrderItem(MenuItem menuItem, int count)
        {
            MenuItem = menuItem;
            Count = count;
        }
    }
}
