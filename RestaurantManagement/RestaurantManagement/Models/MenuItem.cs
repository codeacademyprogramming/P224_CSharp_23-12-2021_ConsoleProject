using RestaurantManagement.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagement.Models
{
    class MenuItem
    {
        private static int Count = 100;
        public string No { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }

        public MenuItem(string name, double price, Category category)
        {
            Count++;
            Name = name;
            Price = price;
            Category = category;

            switch ((int)category)
            {
                case 0:
                    No += "S" + Count;
                    break;
                case 1:
                    No += "DE" + Count;
                    break;
                case 2:
                    No += "DR" + Count;
                    break;
                case 3:
                    No += "M" + Count;
                    break;
            }
        }

        public override string ToString()
        {
            return $"Nomresi: {No}\nName: {Name}\nPrice: {Price}\nCategory: {Category}";
        }
    }
}
