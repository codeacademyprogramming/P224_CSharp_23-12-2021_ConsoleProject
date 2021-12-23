using RestaurantManagement.Enums;
using RestaurantManagement.Interfaces;
using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagement.Services
{
    class RestaurantManager : IRestaurantManager
    {
        public MenuItem[] MenuItems => _menuItems;
        //{
        //    get
        //    {
        //        return _menuItems;
        //    }
        //}
        private MenuItem[] _menuItems;
        public Order[] Orders => _orders;
        private Order[] _orders;

        public RestaurantManager()
        {
            _menuItems = new MenuItem[0];
            _orders = new Order[0];
        }

        public void AddMenuItem(string name, double price, Category category)
        {
            MenuItem menuItem = new MenuItem(price: price, category: category, name: name);
            Array.Resize(ref _menuItems, _menuItems.Length + 1);
            _menuItems[_menuItems.Length - 1] = menuItem;
        }

        public void AddOrder(OrderItem[] orderItems, DateTime date)
        {
            Order order = new Order(orderItems, date);
            Array.Resize(ref _orders, _orders.Length + 1);
            _orders[_orders.Length - 1] = order;
        }

        public void EditMenuItem(string menuItemNo, string name, double price, Category category)
        {
            MenuItem menuItem = null;

            foreach (MenuItem item in _menuItems)
            {
                if (item.No == menuItemNo)
                {
                    menuItem = item;
                    break;
                }
            }

            menuItem.Name = name;
            menuItem.Price = price;
            menuItem.Category = category;
        }

        public MenuItem[] GetMenuItemsByCategory(Category category)
        {
            MenuItem[] menuItems = new MenuItem[0];

            foreach (MenuItem item in _menuItems)
            {
                if (item != null && item.Category == category)
                {
                    Array.Resize(ref menuItems, menuItems.Length + 1);
                    menuItems[menuItems.Length - 1] = item;
                }
            }

            return menuItems;
        }

        public MenuItem[] GetMenuItemsByPriceInterval(double startPrice, double endPrice)
        {
            MenuItem[] menuItems = new MenuItem[0];

            foreach (MenuItem item in _menuItems)
            {
                if (item.Price >= startPrice && item.Price <= endPrice)
                {
                    Array.Resize(ref menuItems, menuItems.Length + 1);
                    menuItems[menuItems.Length - 1] = item;
                }
            }

            return menuItems;
        }

        public Order[] GetOrderByDate(DateTime date)
        {
            Order[] orders = new Order[0];

            foreach (Order item in _orders)
            {
                if (item != null &&  item.Date == date)
                {
                    Array.Resize(ref orders, orders.Length + 1);
                    orders[orders.Length - 1] = item;
                }
            }

            return orders;
        }

        public Order GetOrderByNo(int orderNo)
        {
            Order order = null;

            foreach (Order item in _orders)
            {
                if (item != null && item.No == orderNo)
                {
                    order = item;
                }
            }

            return order;
        }

        public Order[] GetOrdersByDatesInterval(DateTime startDate, DateTime endDate)
        {
            Order[] orders = new Order[0];

            foreach (Order item in _orders)
            {
                if (item != null && item.Date >= startDate && item.Date <= endDate )
                {
                    Array.Resize(ref orders, orders.Length + 1);
                    orders[orders.Length - 1] = item;
                }
            }

            return orders;
        }

        public Order[] GetOrdersByPriceInterval(double startTotalAmount, double endTotalAmount)
        {
            Order[] orders = new Order[0];

            foreach (Order item in _orders)
            {
                if (item != null && item.TotalAmount >= startTotalAmount && item.TotalAmount <= endTotalAmount)
                {
                    Array.Resize(ref orders, orders.Length + 1);
                    orders[orders.Length - 1] = item;
                }
            }

            return orders;
        }

        public void RemoveOrder(int orderNo)
        {
            for (int i = 0; i < _orders.Length; i++)
            {
                if (_orders[i] != null && _orders[i].No == orderNo)
                {
                    _orders[i] = null;
                    return;
                }
            }
        }

        public void RemoveMenuItem(string menuItemNo)
        {
            for (int i = 0; i < _menuItems.Length; i++)
            {
                if (_menuItems[i] != null && _menuItems[i].No == menuItemNo)
                {
                    _menuItems[i] = null;
                    return;
                }
            }
        }

        public MenuItem[] SearchMenuItem(string search)
        {
            MenuItem[] menuItems = new MenuItem[0];

            //double searchPrice;

            //double.TryParse(search, out searchPrice);

            foreach (MenuItem item in _menuItems)
            {
                if (item != null && item.No.ToLower().Contains(search.ToLower()) || item.Name.ToLower().Contains(search.ToLower()) || item.Price.ToString().Contains(search)/*(searchPrice > 0 && item.Price == searchPrice)*/ )
                {
                    Array.Resize(ref menuItems, menuItems.Length + 1);
                    menuItems[menuItems.Length - 1] = item;
                }
            }

            return menuItems;
        }
    }
}
