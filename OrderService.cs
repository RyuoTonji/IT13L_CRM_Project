using MyKioski.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace MyKioski
{
    public static class OrderService
    {
        private static readonly string filePath = "orders.json";

        public static List<Order> GetAllOrders()
        {
            if (!File.Exists(filePath)) { return new List<Order>(); }
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Order>>(json) ?? new List<Order>();
        }

        public static void SaveOrder(Order newOrder)
        {
            List<Order> allOrders = GetAllOrders();
            allOrders.Add(newOrder);
            SaveChanges(allOrders);
        }

        public static void DeleteOrder(string orderId)
        {
            List<Order> allOrders = GetAllOrders();
            Order orderToRemove = allOrders.FirstOrDefault(o => o.OrderId == orderId);
            if (orderToRemove != null)
            {
                allOrders.Remove(orderToRemove);
                SaveChanges(allOrders);
            }
        }

        private static void SaveChanges(List<Order> orders)
        {
            string json = JsonConvert.SerializeObject(orders, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        // --- Analytics Methods ---
        public static decimal GetTotalSales()
        {
            return GetAllOrders().Sum(order => order.TotalAmount);
        }

        public static decimal GetAverageDailySales()
        {
            List<Order> allOrders = GetAllOrders();
            if (!allOrders.Any()) return 0;
            var salesByDay = allOrders.GroupBy(order => order.OrderDateTime.Date)
                                      .Select(dayGroup => dayGroup.Sum(order => order.TotalAmount));
            return salesByDay.Any() ? salesByDay.Average() : 0;
        }

        public static decimal GetAverageWeeklySales()
        {
            List<Order> allOrders = GetAllOrders();
            if (!allOrders.Any()) return 0;
            var salesByWeek = allOrders.GroupBy(order => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(order.OrderDateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday))
                                      .Select(weekGroup => weekGroup.Sum(order => order.TotalAmount));
            return salesByWeek.Any() ? salesByWeek.Average() : 0;
        }

        public static decimal GetAverageMonthlySales()
        {
            List<Order> allOrders = GetAllOrders();
            if (!allOrders.Any()) return 0;
            var salesByMonth = allOrders.GroupBy(order => new { order.OrderDateTime.Year, order.OrderDateTime.Month })
                                        .Select(monthGroup => monthGroup.Sum(order => order.TotalAmount));
            return salesByMonth.Any() ? salesByMonth.Average() : 0;
        }

        public static Dictionary<DateTime, decimal> GetDailySalesForLastDays(int days)
        {
            List<Order> allOrders = GetAllOrders();
            var dailySales = new Dictionary<DateTime, decimal>();
            for (int i = 0; i < days; i++)
            {
                dailySales[DateTime.Today.AddDays(-i)] = 0;
            }

            var recentOrders = allOrders.Where(o => o.OrderDateTime.Date >= DateTime.Today.AddDays(-days + 1));
            foreach (var group in recentOrders.GroupBy(o => o.OrderDateTime.Date))
            {
                dailySales[group.Key] = group.Sum(o => o.TotalAmount);
            }
            return dailySales.OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        public static Dictionary<string, int> GetSalesByItem()
        {
            return GetAllOrders()
                .SelectMany(order => order.Items)
                .GroupBy(cartItem => cartItem.Item.Name)
                .ToDictionary(group => group.Key, group => group.Sum(cartItem => cartItem.Quantity));
        }
    }
}