using RestaurantManagement.Enums;
using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagement.Interfaces
{
    interface IRestaurantManager
    {
        MenuItem[] MenuItems { get; }
        Order[] Orders { get; }

        void AddOrder(OrderItem[] orderItems, DateTime date);
        void RemoveOrder(int orderNo);
        Order[] GetOrdersByDatesInterval(DateTime startDate, DateTime endDate);
        Order[] GetOrderByDate(DateTime date);
        Order[] GetOrdersByPriceInterval(double startTotalAmount, double endTotalAmount);
        Order GetOrderByNo(int orderNo);
        void AddMenuItem(string name, double price, Category category);
        void EditMenuItem(string menuItemNo, string name, double price, Category category);
        MenuItem[] GetMenuItemsByCategory(Category category);
        MenuItem[] GetMenuItemsByPriceInterval(double startPrice, double endPrice);
        MenuItem[] SearchMenuItem(string search);
        void RemoveMenuItem(string menuItemNo);
    }
}
