using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagement.Models
{
    class Order
    {
        private static int Count = 0;
        public int No { get; set; }
        public OrderItem[] OrderItems { get; set; }
        public double TotalAmount { get; set; }
        public DateTime Date { get; set; }

        public Order(OrderItem[] orderItems, DateTime date)
        {
            if (orderItems.Length <= 0)
            {
                Console.WriteLine("Order Items Bos Ola Bilmez");
                return;
            }

            Count++;
            No = Count;
            OrderItems = orderItems;
            foreach (OrderItem orderItem in OrderItems)
            {
                TotalAmount += (orderItem.MenuItem.Price * orderItem.Count);
            }
            Date = date;
        }

        public override string ToString()
        {
            return $"{No} {OrderItems.Length} {TotalAmount} {Date.ToString("dd/MM/yyyy")}";
        }
    }
}
